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
                    row.CreateCells(dgvPeriodMap, period, Config[period]);
                    dgvPeriodMap.Rows.Add(row);
				}

                //顯示「假別對照表」於 ComboBox。
                ConfigData absence = Campus.Configuration.Config.App["假別對照表"];
                XElement xmlabs = XElement.Parse(absence.PreviousData.OuterXml);
                foreach (XElement abs in xmlabs.Elements("Absence"))
                {
                    cboLateMap.Items.Add(abs.Attribute("Name").Value);
                    cboEmptyMap.Items.Add(abs.Attribute("Name").Value);
					chLeave.Items.Add(abs.Attribute("Name").Value);
				}

				//顯示「假別對照表」於 DataGridView。
				string[] leaves = Program.LeaveNameList;
				foreach (string leave in leaves)
				{
					DataGridViewRow row = new DataGridViewRow();
					row.CreateCells(dgvLeaveMap, leave, Config[leave]);
					dgvLeaveMap.Rows.Add(row);
				}

                cboLateMap.Text = Config["遲"];
                cboEmptyMap.Text = Config["缺"];
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
                Config["遲"] = cboLateMap.Text;
                Config["缺"] = cboEmptyMap.Text;
                Config["OverrideOption"] = cboOverride.Text;

                HashSet<string> duplicate = new HashSet<string>();
                foreach (DataGridViewRow row in dgvPeriodMap.Rows)
                {
                    string cardPeriod = row.Cells[chCardPeriod.Index].Value + "";
                    string period = row.Cells[chPeriod.Index].Value + "";

                    if (duplicate.Contains(period))
                    {
                        row.ErrorText = "節次重覆！";
                        return;
                    }
                    else
                        row.ErrorText = string.Empty;

                    Config[cardPeriod] = period;

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

		private void btnAutoPeriod_Click(object sender, EventArgs e)
		{

		}
    }
}
