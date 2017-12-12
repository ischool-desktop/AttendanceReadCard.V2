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
using Campus.Configuration;

namespace AttendanceReadCard
{
    public partial class ReadCardInformation : BaseForm
    {
        string cardInformation = "";

        BackgroundWorker BGW = new BackgroundWorker();

        public ReadCardInformation()
        {
            InitializeComponent();
        }

        private void ExportCardDatabtn_Click(object sender, EventArgs e)
        {
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);
            BGW.RunWorkerAsync();
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            #region 讀卡
            cardInformation = "";
            
            // 濃淡辨識度
            int level = 5;

            try
            {
                // 設定讀卡機讀取範圍Open(column,row)
                OMRCardReader.Open(35, 100);

                byte[] data;
                Exception error;

                if (OMRCardReader.FeedSheet(out data, out error))
                {
                    int index = 0;
                    // 讀取卡片資訊 
                    foreach (var d in data)
                    {
                        if (d >= level)
                        {
                            cardInformation += 1;
                        }
                        else
                        {
                            cardInformation += 0;
                        }

                        index++;

                        // 35換行
                        if (index == 35)
                        {
                            cardInformation += System.Environment.NewLine;
                            // 歸零
                            index = 0;
                        }
                            
                    }
                }
                else
                {
                    e.Result = error;
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
            finally
            {
                try { OMRCardReader.Close(); }
                catch { }
            }

            #endregion
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            #region 錯誤訊息
            if (e.Result != null)
            {
                DialogResult dr = System.Windows.Forms.DialogResult.None;

                if (e.Result is Exception)
                {
                    string msg = string.Empty;

                    if (e.Result is OMRCardReaderException)
                    {
                        OMRCardReaderException omrerror = e.Result as OMRCardReaderException;
                        msg = GetOMRErrorMessage(omrerror);
                    }

                    if (string.IsNullOrWhiteSpace(msg))
                        msg = "讀卡錯誤：\n\n" + (e.Result as Exception).Message;

                    dr = MessageBox.Show(msg, "ischool");
                }
                Close();
            }
            #endregion

            #region 存檔
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "文字文件 (*.txt)|*.txt";
            saveDialog.FileName = "點名讀卡解析";
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
            Close();
            #endregion
        }

        private static string GetOMRErrorMessage(OMRCardReaderException omrerror)
        {
            string msg = string.Empty;

            if (omrerror.Status == OMRStatus.SR_ERROR_STATUS_Q1_SheetEmpty)
                msg = "已經沒有卡了!";
            else if (omrerror.Status == OMRStatus.SR_ERROR_STATUS_Q2_DoubleFeedError)
                msg = "進了多張卡，需要手動處理！\n\n繼續讀卡？";
            else if (omrerror.Status == OMRStatus.SR_ERROR_STATUS_R4M_TimingMarkError)
                msg = "偵測讀卡標記錯誤！\n\n繼續讀卡？";
            else if (omrerror.Status == OMRStatus.SR_ERROR_STATUS_H1_NoPaper)
                msg = "無法進卡！\n\n繼續讀卡？";
            else if (omrerror.Status == OMRStatus.SR_ERROR_STATUS_R4F_FrontTimingMarkError)
                msg = "正面卡片方向錯誤！\n\n繼續讀卡？";
            else if (omrerror.Status == OMRStatus.SR_ERROR_STATUS_CoverOpen)
                msg = "讀卡機蓋子沒蓋好！\n\n繼續讀卡？";
            return msg;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
