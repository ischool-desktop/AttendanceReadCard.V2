using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;
using System.Text;

namespace AttendanceReadCard
{
    public partial class ReadCardInformation : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();

        public ReadCardInformation()
        {
            InitializeComponent();
        }

        private void ExportCardDatabtn_Click(object sender, EventArgs e)
        {
            #region 讀卡
            string cardInformation = "";
            try
            {
                // 設定讀卡機讀取範圍
                OMRCardReader.Open(35, 100);

                DataTable dt = new DataTable();

                byte[] data;
                Exception error;

                

                while (true)
                {
                    if (OMRCardReader.FeedSheet(out data, out error))
                    {
                        int index = 0;
                        // 讀取卡片資訊 
                        foreach (var d in data)
                        {
                            if (d >= 5)
                            {
                                cardInformation += 1;
                            }
                            else
                            {
                                cardInformation += 0;
                            }

                            // 35換行
                            if (index == 35)
                            {
                                cardInformation += System.Environment.NewLine;
                                // 歸零
                                index = 0;
                            }
                            index++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch
            {

            }
            #endregion

            #region 存檔
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "文字文件 (*.txt)|*.txt";
            saveDialog.FileName = "卡紙解析資訊";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = saveDialog.FileName;

                    FileStream fs = new FileStream(path, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);

                    sw.Write(cardInformation);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
                catch
                {
                    FISCA.Presentation.Controls.MsgBox.Show("指定路徑無法存取。", "建立檔案失敗", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
