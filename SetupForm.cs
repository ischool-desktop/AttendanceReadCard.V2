using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Campus.Configuration;
using FISCA;
using FISCA.Presentation.Controls;
using K12.Data;
using System.Linq;

namespace AttendanceReadCard
{
    //2016/9/2 穎驊筆記，本次最大的更動就是將原本設定遲、曠的cbox :cboLateMap、cboEmptyMap拿掉，
    //改為使用者可以針對各個節次定義兩洞一組的1_0、1_1、0_1 所對應的缺曠類別，
    //如果以後還要用cboLateMap、cboEmptyMap 再去UI 家回來就可以囉~

    public partial class SetupForm : BaseForm
    {
        private ConfigData Config { get; set; }

        public SetupForm()
        {
            InitializeComponent();
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            try
            {
                Config = Campus.Configuration.Config.App["學生出缺席讀卡設定"];

                //顯示「節次對照表」於 DataGridView。
                ConfigData pmap = Campus.Configuration.Config.App["節次對照表"];
                XElement xmlperiod = XElement.Parse(pmap.PreviousData.OuterXml);
                foreach (XElement period in xmlperiod.Elements("Period"))
                    chPeriod.Items.Add(period.Attribute("Name").Value);

                //列出卡片上所有可設定節次。
                string[] periods = Program.PeriodNameList;
                foreach (string period in periods)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    // 2016/9/1 穎驊新增，使介面載入上次設定的個別節次假別對照
                    row.CreateCells(dgvPeriodMap, period, Config[period], Config[period + "leave_1_0"], Config[period + "leave_1_1"], Config[period + "leave_0_1"]);

                    dgvPeriodMap.Rows.Add(row);
				}

                //顯示「假別對照表」於 ComboBox。
                ConfigData absence = Campus.Configuration.Config.App["假別對照表"];
                XElement xmlabs = XElement.Parse(absence.PreviousData.OuterXml);
                foreach (XElement abs in xmlabs.Elements("Absence"))
                {
                    //cboLateMap.Items.Add(abs.Attribute("Name").Value);
                    //cboEmptyMap.Items.Add(abs.Attribute("Name").Value);

					chLeave.Items.Add(abs.Attribute("Name").Value);

                    // 2016/9/1 穎驊新增，讓使用者可以針對各個節數定義畫卡 1_0、1_1、0_1 在系統中的假別是甚麼，
                    //(每節次的讀卡是兩洞一組，1_0 的意思是第一洞塗滿、第二洞沒塗)
                    ch_1_0.Items.Add(abs.Attribute("Name").Value);
                    ch_1_1.Items.Add(abs.Attribute("Name").Value);
                    ch_0_1.Items.Add(abs.Attribute("Name").Value);

				}

                //給使用者留空白選項
                chPeriod.Items.Add("");                
                ch_1_0.Items.Add("");
                ch_1_1.Items.Add("");
                ch_0_1.Items.Add("");


				//顯示「假別對照表」於 DataGridView。
				string[] leaves = Program.LeaveNameList;
				foreach (string leave in leaves)
				{
					DataGridViewRow row = new DataGridViewRow();
					row.CreateCells(dgvLeaveMap, leave, Config[leave]);
					dgvLeaveMap.Rows.Add(row);
				}

                //cboLateMap.Text = Config["遲"];
                //cboEmptyMap.Text = Config["缺"];

                cboOverride.Text = Config["OverrideOption"];

                if (string.IsNullOrWhiteSpace(cboOverride.Text))
                    cboOverride.Text = "略過讀卡資料";

                //顯示班級對照。
                XmlElement oldclassMap = Config.GetXml("ClassNameMap", null);

                XElement classmap;
                if (oldclassMap != null)
                    classmap = XElement.Parse(oldclassMap.OuterXml);
                else
                    classmap = new XElement("Map");

                Dictionary<string, string> classdic = new Dictionary<string, string>();
                foreach (XElement cls in classmap.Elements("Class"))
                {
                    if (!classdic.ContainsKey(cls.Attribute("ClassName").Value))
                        classdic.Add(cls.Attribute("ClassName").Value, cls.Attribute("CardName").Value);
                }

                Class.RemoveAll();
                List<ClassRecord> classes = Class.SelectAll();
                classes.Sort((x, y) =>
                {
                    string X = (x.GradeYear + "").PadLeft(10, '0') + (x.DisplayOrder.PadLeft(10, '0')) + x.Name;
                    string Y = (y.GradeYear + "").PadLeft(10, '0') + (y.DisplayOrder.PadLeft(10, '0')) + y.Name;
                    return X.CompareTo(Y);
                });

				IEnumerable<int> numbers = Enumerable.Range(0, 9999);				
                foreach(int i in numbers)
                {
					chCardName.Items.Add(i.ToString().PadLeft(4, '0'));
                }

                foreach (ClassRecord cr in classes)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvClassMap, cr.Name, classdic.ContainsKey(cr.Name) ? classdic[cr.Name] : "");
                    dgvClassMap.Rows.Add(row);
                }

                //2016/8/31 穎驊新增，由於卡片有差異，目前有分別由104年開始、以及105年開始的卡片，固要新增選項讓使用者看狀況選
                for (int i = 0; i < 7; i++)
                {
                    cboReadingCardStartYear.Items.Add(104+i);
                }
                                
                cboReadingCardStartYear.Text = Config["讀卡起始年"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                FISCA.RTOut.WriteError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Config["遲"] = cboLateMap.Text;
                //Config["缺"] = cboEmptyMap.Text;

                Config["OverrideOption"] = cboOverride.Text;

                //2016/8/31 穎驊新增 讀卡起始年
                Config["讀卡起始年"] = cboReadingCardStartYear.Text;


                HashSet<string> duplicate = new HashSet<string>();
                foreach (DataGridViewRow row in dgvPeriodMap.Rows)
                {
                    string cardPeriod = row.Cells[chCardPeriod.Index].Value + "";
                    string period = row.Cells[chPeriod.Index].Value + "";


                    string leave_1_0 = row.Cells[ch_1_0.Index].Value + "";

                    string leave_1_1 = row.Cells[ch_1_1.Index].Value + "";

                    string leave_0_1 = row.Cells[ch_0_1.Index].Value + "";

                    if (duplicate.Contains(period))
                    {
                        row.ErrorText = "節次重覆！";
                        return;
                    }
                    else
                        row.ErrorText = string.Empty;

                    Config[cardPeriod] = period;

                    Config[cardPeriod + "leave_1_0"] = leave_1_0;

                    Config[cardPeriod + "leave_1_1"] = leave_1_1;

                    Config[cardPeriod + "leave_0_1"] = leave_0_1;


                    if (!string.IsNullOrWhiteSpace(period))
                        duplicate.Add(period);
				}

				duplicate = new HashSet<string>();
				foreach (DataGridViewRow row in dgvLeaveMap.Rows)
				{
					string cardLeave = row.Cells[chCardLeave.Index].Value + "";
					string leave = row.Cells[chLeave.Index].Value + "";

					if (duplicate.Contains(leave))
					{
						row.ErrorText = "資料重覆！";
						return;
					}
					else
						row.ErrorText = string.Empty;

					Config[cardLeave] = leave;

					if (!string.IsNullOrWhiteSpace(leave))
						duplicate.Add(leave);
				}

                duplicate = new HashSet<string>();
                XElement classmap = new XElement("Map");
                foreach (DataGridViewRow row in dgvClassMap.Rows)
                {
                    string classname = row.Cells[chClassName.Index].Value + "";
                    string cardname = row.Cells[chCardName.Index].Value + "";

                    if (string.IsNullOrWhiteSpace(cardname))
                        continue;

                    if (duplicate.Contains(cardname))
                    {
                        row.ErrorText = "資料重覆！";
                        return;
                    }
                    else
                        row.ErrorText = string.Empty;

                    classmap.Add(new XElement("Class",
                        new XAttribute("ClassName", classname),
                        new XAttribute("CardName", cardname)));

                    duplicate.Add(cardname);
                }

                Config["ClassNameMap"] = classmap.ToString();

                Config.Save();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                RTOut.WriteError(ex);
            }
        }
        private void dgvPeriodMap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPeriodMap.BeginEdit(false);

        }

        private void dgvClassMap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvClassMap.BeginEdit(false);
        }

        private void dgvPeriodMap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData.HasFlag(Keys.Delete))
            {
                foreach (DataGridViewCell cell in dgvPeriodMap.SelectedCells)
                {
                    if (cell.OwningColumn == chPeriod)
                        cell.Value = string.Empty;
                }
            }
        }

        private void dgvClassMap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData.HasFlag(Keys.Delete))
            {
                foreach (DataGridViewCell cell in dgvClassMap.SelectedCells)
                {
                    if (cell.OwningColumn == chCardName)
                        cell.Value = string.Empty;
                }
            }
        }

	
    }
}
