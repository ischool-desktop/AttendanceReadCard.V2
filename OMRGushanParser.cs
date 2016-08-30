using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AttendanceReadCard
{
    /// <summary>
    /// 鼓山高中缺席記錄卡資料解析。
    /// </summary>
    public static class OMRGushanParser
    {
        public const int GradeYearStart = 6 - 1;
        public const int GradeYearEnd = 11 - 1;

        public const int ClassStart1 = 35 + 6 - 1;
        public const int ClassEnd1 = 35 + 18 - 1;

        public const int ClassStart2 = (35 * 2) + 6 - 1;
        public const int ClassEnd2 = (35 * 2) + 18 - 1;

        public const int YearStart = 24 - 1;
        public const int YearEnd = 35 - 1;

        public const int MonthStart = 35 + 24 - 1;
        public const int MonthEnd = 35 + 35 - 1;

        public const int DayStart1 = (35 * 2) + 24 - 1;
        public const int DayEnd1 = (35 * 2) + 33 - 1;

        public const int DayStart2 = (35 * 3) + 24 - 1;
        public const int DayEnd2 = (35 * 3) + 33 - 1;

        public const int DayStart3 = (35 * 4) + 24 - 1;
        public const int DayEnd3 = (35 * 4) + 34 - 1;

        public const int AttendanceStartRow = 6; //absolute position 9
        public const int AttendanceEndRow = 51;//absolute position 54

        public const int AttendanceStartColumn = 7;
        public const int AttendanceEndColumn = 35;

        /*
        <AbsenceCard>
	        <GradeYear>1</GradeYear>
	        <ClassName>01</ClassName>
		    <Year>2012</Year>
		    <Month>8</Month>
		    <Day>15</Day>
	        <Discipline SeatNo="1">
		        <Period Number="0">
			        <Reason>遲</Reason>
			        <Reason>缺</Reason>
		        </Period>
	        </Discipline>
        </AbsenceCard>
         */
        /// <summary>
        /// 解析卡片資料。
        /// </summary>
        /// <param name="source">資料來源</param>
        /// <param name="level">畫卡濃度,預設為3。</param>
        /// <returns></returns>
        public static XElement Parser(byte[] source, int level)
        {
            if (source.Length < 1750)
                throw new ArgumentException("資料內容長度不正確，應該具有 1750 個資料內容(byte)。");

            XElement result = new XElement("AttendanceCard");

            if (GradeYearEnd - GradeYearStart > 6) //驗證設定
                throw new ArgumentException("年級解析設定錯誤。");

            //年級資訊。
            for (int i = GradeYearStart, gy = 1; i <= GradeYearEnd; i++, gy++)
            {
                if (source[i] >= level) //GradeYearStart - 1 就是年級。
                    result.Add(new XElement("GradeYear", gy));
            }

            if (ClassEnd1 - ClassStart1 > 13) //驗證設定,一排只有13個班級。
                throw new ArgumentException("班級1解析設定錯誤。");

            //第一排班級資訊。
            for (int i = ClassStart1, cn = 1; i <= ClassEnd1; i++, cn++)
            {
                if (source[i] >= level)
                    result.Add(new XElement("ClassName", cn.ToString().PadLeft(2, '0')));
            }

            if (ClassEnd2 - ClassStart2 > 13) //驗證設定,一排只有13個班級。
                throw new ArgumentException("班級1解析設定錯誤。");

            //第二排班級資訊。
            for (int i = ClassStart2, cn = 14; i <= ClassEnd2; i++, cn++)
            {
                if (source[i] >= level)
                    result.Add(new XElement("ClassName", cn.ToString().PadLeft(2, '0')));
            }

            if (YearEnd - YearStart > 12) //驗證設定,12 個年度。
                throw new ArgumentException("年度解析設定錯誤。");

            //年度資訊
            for (int i = YearStart, year = 2012; i <= YearEnd; i++, year++)
            {
                if (source[i] >= level)
                    result.Add(new XElement("Year", year));
            }

            if (MonthEnd - MonthStart > 12) //驗證設定,12 個月份。
                throw new ArgumentException("年度解析設定錯誤。");

            //月份資訊
            for (int i = MonthStart, month = 1; i <= MonthEnd; i++, month++)
            {
                if (source[i] >= level)
                    result.Add(new XElement("Month", month));
            }

            if (DayEnd1 - DayStart1 > 10) //驗證設定,10 個日。
                throw new ArgumentException("年度解析設定錯誤。");

            //日資訊1
            for (int i = DayStart1, day = 1; i <= DayEnd1; i++, day++)
            {
                if (source[i] >= level)
                    result.Add(new XElement("Day", day));
            }

            if (DayEnd2 - DayStart2 > 10) //驗證設定,10 個日。
                throw new ArgumentException("年度解析設定錯誤。");

            //日資訊2
            for (int i = DayStart2, day = 11; i <= DayEnd2; i++, day++)
            {
                if (source[i] >= level)
                    result.Add(new XElement("Day", day));
            }

            if (DayEnd3 - DayStart3 > 10) //驗證設定,11 個日。
                throw new ArgumentException("年度解析設定錯誤。");

            //日資訊3
            for (int i = DayStart3, day = 21; i <= DayEnd3; i++, day++)
            {
                if (source[i] >= level)
                    result.Add(new XElement("Day", day));
            }

            //缺曠資訊
            for (int i = AttendanceStartRow, sn = 1; i < AttendanceEndRow; i++, sn++)
            {
                XElement discipline = null;

                for (int t = AttendanceStartColumn, pn = 0;
                    t <= AttendanceEndColumn;
                    t += 3, pn++) //每節暫3個位置。
                {
                    int index = ((35 * (i - 1)) + (t)) - 1;

                    XElement period = new XElement("Period");
                    period.SetAttributeValue("Name", Program.PeriodNameList[pn]);

                    if (source[index] >= level || source[index + 1] >= level)
                    {
                        if (discipline == null)
                            discipline = NewDiscipline(result, sn);

                        discipline.Add(period);
                    }

                    if (source[index] >= level)
                        period.Add(new XElement("Reason", "遲"));

                    if (source[index + 1] >= level)
                        period.Add(new XElement("Reason", "缺"));

                }
            }

            return result;
        }

        private static XElement NewDiscipline(XElement result, int sn)
        {
            XElement discipline = new XElement("Attendance");
            discipline.SetAttributeValue("SeatNo", sn);
            result.Add(discipline);
            return discipline;
        }

        /// <summary>
        /// 解析卡片資料。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static XElement Parser(byte[] source)
        {
            return Parser(source, 3);
        }

        public static bool IsValidated(XElement disciplineContent, out XElement errorMessages)
        {
            errorMessages = new XElement("Messages");
            XElement em = errorMessages;

            if (disciplineContent == null)
                throw new ArgumentException("資料不可為空白。");

            if (disciplineContent.Elements("GradeYear").Count() <= 0)
                em.Add(new XElement("Msg", "年級資訊錯誤：未偵測到年級資訊畫記。"));

            if (disciplineContent.Elements("GradeYear").Count() > 1)
                em.Add(new XElement("Msg", "年級資訊錯誤：偵測到年級資訊畫記超過一個。"));

            if (disciplineContent.Elements("ClassName").Count() <= 0)
                em.Add(new XElement("Msg", "班級資訊錯誤：未偵測到班級資訊畫記。"));

            if (disciplineContent.Elements("ClassName").Count() > 1)
                em.Add(new XElement("Msg", "班級資訊錯誤：偵測到班級資訊畫記超過一個。"));

            if (disciplineContent.Elements("Year").Count() <= 0)
                em.Add(new XElement("Msg", "日期資訊錯誤：未偵測到「年份」資訊畫記。"));

            if (disciplineContent.Elements("Year").Count() > 1)
                em.Add(new XElement("Msg", "日期資訊錯誤：偵測到「年份」資訊畫記超過一個。"));

            if (disciplineContent.Elements("Month").Count() <= 0)
                em.Add(new XElement("Msg", "日期資訊錯誤：未偵測到「月份」資訊畫記。"));

            if (disciplineContent.Elements("Month").Count() > 1)
                em.Add(new XElement("Msg", "日期資訊錯誤：偵測到「月份」資訊畫記超過一個。"));

            if (disciplineContent.Elements("Day").Count() <= 0)
                em.Add(new XElement("Msg", "日期資訊錯誤：未偵測到「日期」資訊畫記。"));

            if (disciplineContent.Elements("Day").Count() > 1)
                em.Add(new XElement("Msg", "日期資訊錯誤：偵測到「日期」資訊畫記超過一個。"));

            return em.Elements("Msg").Count() <= 0;
        }
    }
}
