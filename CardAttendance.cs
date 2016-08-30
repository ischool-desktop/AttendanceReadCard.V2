using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;
using System.Xml.Linq;

namespace AttendanceReadCard
{
    /// <summary>
    /// 代表一筆缺曠資料。
    /// </summary>
    internal class CardAttendance
    {
		private CardType Type;
        public CardAttendance(CardType type)
        {
            Periods = new List<string>();
            Periods.AddRange(new string[] { "", "", "", "", "", "", "", "", "", "","" });
			this.Type = type;
        }

        public void FillStudentInfo(StudentRecordFinder finder)
        {
			StudentRecord sr = null;
			
			if (this.Type == CardType.點名卡)
				sr = finder.Find(ClassName, SeatNo);
			if (this.Type == CardType.請假卡)
				sr = finder.Find(StudentNumber);

            SRecord = sr;

            if (sr != null)
            {
                Name = sr.Name;
                StudentNumber = sr.StudentNumber;

				if (this.Type == CardType.請假卡)
				{
					ClassRecord clazz = finder.FindClass(StudentNumber);
					if (clazz != null)
						this.ClassName = clazz.Name;
					this.SeatNo = sr.SeatNo.HasValue ? sr.SeatNo.Value.ToString() : string.Empty;
				}
            }
        }

        public StudentRecord SRecord { get; private set; }

        /// <summary>
        /// 儲存整個 Attendance 的資料。  
        /// </summary>
        public XElement XmlData { get; set; }

        public string DateTime { get; set; }

        public string ClassName { get; set; }

        public string SeatNo { get; set; }

        public string Name { get; private set; }

        public string StudentNumber { get; set; }

        public List<string> Periods { get; private set; }

        public string Period0 { get { return Periods[0]; } }

        public string Period1 { get { return Periods[1]; } }

        public string Period2 { get { return Periods[2]; } }

        public string Period3 { get { return Periods[3]; } }

        public string Period4 { get { return Periods[4]; } }

        public string Period5 { get { return Periods[5]; } }

        public string Period6 { get { return Periods[6]; } }

        public string Period7 { get { return Periods[7]; } }

        public string Period8 { get { return Periods[8]; } }

        public string Period9 { get { return Periods[9]; } }

        public string Period10 { get { return Periods[10]; } }
    }
}
