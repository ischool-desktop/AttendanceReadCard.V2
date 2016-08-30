using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Linq;
using FISCA;
using FISCA.Presentation.Controls;
using System.Collections.Generic;

namespace AttendanceReadCard
{
	public enum CardType { 點名卡 = 56, 請假卡 = 12 };
    public partial class CardReadingForm : BaseForm
	{
		private delegate XElement ParserDelegate(byte[] source, int level, int source_length);
		private delegate XElement TransformDelegate(XElement content);
		private ParserDelegate Parser;
		private TransformDelegate Transformer;
        private int _intValue;
        public CardReadingForm(CardSetup setup, CardType type,int value)
        {
            InitializeComponent();
            CardSetup = setup;
			Type = type;
            _intValue = value;

			if (this.Type == CardType.請假卡)
			{
				Parser = new ParserDelegate(WVSOMRParser.Instance.LeaveParser);
				Transformer = new TransformDelegate(CardSetup.TransformLeaveCardData);
			}
			if (this.Type == CardType.點名卡)
			{ 
				Parser = new ParserDelegate(WVSOMRParser.Instance.Parser);
				Transformer = new TransformDelegate(CardSetup.TransformAbsenceCardData);
			}
        }

        private void CardReadingForm_Load(object sender, EventArgs e)
        {
            try
            {
                XmlResult = new XElement("OMRReadResult");
                ReadingTask = new BackgroundWorker();
                ReadingTask.WorkerSupportsCancellation = true;
				ReadingTask.DoWork += new DoWorkEventHandler(ReadingTask_DoWork);
                ReadingTask.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ReadingTask_RunWorkerCompleted);
                ReadingTask.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                Close();
            }
        }

        private void ReadingTask_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
				OMRCardReader.Open(35, (int)this.Type); //點名卡規格。56x35

                byte[] data; //儲存讀進來的 Binary 資料。
                Exception error; //讀卡錯誤資訊。

                while (true)
                {
                    if (ReadingTask.CancellationPending)
                        break;

                    if (OMRCardReader.FeedSheet(out data, out error))
                    {
						//XElement phrase1 = WVSOMRParser.Instance.Parser(data, 35*(int)this.Type);
						XElement phrase1 = this.Parser.Invoke(data, _intValue, 35 * (int)this.Type);

                        XElement errors;
						if (!WVSOMRParser.Instance.IsValidated(phrase1, out errors))
                        {
                            e.Result = errors;
                            break;
                        }

                        XElement phrase2 = this.Transformer.Invoke(phrase1);

                        XmlResult.Add(phrase2);
                    }
                    else
                    {
                        e.Result = error;
                        break;
                    }
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
        }
		
        private void ReadingTask_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null) //如果沒有任何 Result 代表沒有發生任何類型的錯誤。
                Close();
            else //有錯!!
            {
                DialogResult dr = System.Windows.Forms.DialogResult.None;
                if (e.Result is XElement)
                {
                    string msg = "驗證讀卡資料發生錯誤：\n\n";
					foreach (XElement each in (e.Result as XElement).Elements("Message"))
                        msg += each.Value + "\n";
                    msg += "\n繼續讀卡？";

                    dr = MessageBox.Show(msg, "ischool", MessageBoxButtons.YesNo);
                }
                else if (e.Result is Exception)
                {
                    string msg = string.Empty;

                    if (e.Result is OMRCardReaderException)
                    {
                        OMRCardReaderException omrerror = e.Result as OMRCardReaderException;
                        msg = GetOMRErrorMessage(omrerror);
                    }

                    if (string.IsNullOrWhiteSpace(msg)) //沒有訊息時才顯示一般性訊息。
                        msg = "讀卡錯誤：\n\n" + (e.Result as Exception).Message + "\n\n 繼續讀卡？";

                    dr = MessageBox.Show(msg, "ischool", MessageBoxButtons.YesNo);
                }

                if (dr == System.Windows.Forms.DialogResult.Yes)
                    ReadingTask.RunWorkerAsync(); //繼續讀卡。
                else //不讀了。
                    Close();
            }
        }

        private static string GetOMRErrorMessage(OMRCardReaderException omrerror)
        {
            string msg = string.Empty;

            if (omrerror.Status == OMRStatus.SR_ERROR_STATUS_Q1_SheetEmpty)
                msg = "已經沒有卡了！\n\n繼續讀卡？";
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReadingTask.CancelAsync();
        }

        private BackgroundWorker ReadingTask { get; set; }

        /// <summary>
        /// 讀卡設定。
        /// </summary>
		private CardSetup CardSetup { get; set; }

		/// <summary>
		/// 讀卡種類。
		/// </summary>
		private CardType Type { get; set; }

        /// <summary>
        /// 讀卡後的結果。
        /// </summary>
        public XElement XmlResult { get; private set; }
    }
}
