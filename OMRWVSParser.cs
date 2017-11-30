using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using Campus.Configuration;

namespace AttendanceReadCard
{
    /// <summary>
    /// 點名卡資料解析。
    /// </summary>
    public class WVSOMRParser
    {
        // 2017/11/30 羿均 。 讀卡解析設定xml儲存在list table，以config方式讀取設定。
        // 修改Validate() 卡片判讀方式。將請假卡解析程式碼刪除

        //	解析「年級」之畫記
        private sealed class GradeYearParser : Decorator
		{
            // 透過config讀取設定
            static K12.Data.Configuration.ConfigData _CardSettingData = K12.Data.School.Configuration["CardSettingData"];
            static XDocument cardSettingData = XDocument.Parse(_CardSettingData.PreviousData.OuterXml);

            static XElement gradeYear = cardSettingData.Element("CardPositionSetting").Element("MappingClass").Element("GradeYear");

            List<XElement> positionList = gradeYear.Descendants("Position").ToList();
            
            public override bool Validate()
			{
                // 年級只畫一次
				int mark_count = 0;
                // 年級
				int mark_no = 1;

                foreach (XElement position in positionList)
                {
                    if (this.Source.ElementAt(int.Parse(position.Attribute("Col").Value)) >= this.Level)
                    {
                        mark_count += 1;
                        // 設定畫卡的值
                        mark_no = int.Parse(position.Attribute("Value").Value);
                    }
                }

				if (mark_count != 1)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「年級」畫記錯誤。"));
					return false & base.Validate();
				}
				else
				{
					this.Message.Element("Success").Add(new XElement("GradeYear", mark_no));
					return base.Validate();
				}
			}
		}
		//	解析「班級」之畫記
		private sealed class ClassParser : Decorator
		{
            // 透過config讀取設定
            static K12.Data.Configuration.ConfigData _CardSettingData = K12.Data.School.Configuration["CardSettingData"];
            static XDocument cardSettingData = XDocument.Parse(_CardSettingData.PreviousData.OuterXml);

            List<XElement> Code = cardSettingData.Element("CardPositionSetting").Element("MappingClass").Element("Class").Elements("Code").ToList();

			public override bool Validate()
			{
                string mark_no = ""; // 值
                int mark_count = 0; // 畫卡次數
                int i = 1;
                foreach (XElement c in Code)
                {
                    int index; // 第幾個點
                    if (int.Parse(c.Attribute("Position").Value) == i)
                    {
                        foreach (XElement position in c.Elements("Position").ToList())
                        {
                            index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);
                            if (this.Source.ElementAt(index) >= this.Level)
                            {
                                mark_no += position.Attribute("Value").Value;
                                mark_count++;
                            }
                        }
                    }
                    i++;
                }
                if (mark_count == 4)
                {
                    this.Message.Element("Success").Add(new XElement("Class", string.Join("", mark_no)));
                    return base.Validate();
                }
                else
                {
                    this.Message.Element("Failure").Add(new XElement("Message", "「班級」畫記錯誤。"));

                    return false & base.Validate();
                }
			}
		}
		
		//	解析「點名日期--年」之畫記
		private sealed class YearParser : Decorator
		{
            // 透過config讀取設定
            static K12.Data.Configuration.ConfigData _CardSettingData = K12.Data.School.Configuration["CardSettingData"];
            static XDocument cardSettingData = XDocument.Parse(_CardSettingData.PreviousData.OuterXml);

            List<XElement> yearPositionList = cardSettingData.Element("CardPositionSetting").Element("MappingDate").Element("Year").Elements("Position").ToList();

			public override bool Validate()
			{
				int mark_count = 0; // 畫卡幾次 
                string mark_no = ""; // 值

                foreach (XElement position in yearPositionList)
                {
                    // 位置
                    int index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        mark_count++;
                        mark_no = position.Attribute("Value").Value;
                    }
                }

				if (mark_count != 1)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「點名日期--年」畫記錯誤。"));

					return false & base.Validate();
				}
				else
				{
					this.Message.Element("Success").Add(new XElement("Year", mark_no));

					return base.Validate();
				}
			}
		}

		//	解析「點名日期--月」之畫記
		private sealed class MonthParser : Decorator
		{
            // 透過config讀取設定
            static K12.Data.Configuration.ConfigData _CardSettingData = K12.Data.School.Configuration["CardSettingData"];
            static XDocument cardSettingData = XDocument.Parse(_CardSettingData.PreviousData.OuterXml);

            static XElement month = cardSettingData.Element("CardPositionSetting").Element("MappingDate").Element("Month");
            List<XElement> monthPositionList = month.Elements("Position").ToList();

			public override bool Validate()
			{
				int mark_count = 0;
				int mark_no = 1;

                foreach (XElement mp in monthPositionList)
                {
                    int i = int.Parse(mp.Attribute("Row").Value) * 35 + int.Parse(mp.Attribute("Col").Value);
                    if (this.Source.ElementAt(i) >= this.Level)
                    {
                        mark_count += 1;
                        mark_no = int.Parse(mp.Attribute("Value").Value);
                    }
                }
				if (mark_count != 1)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「點名日期--月」畫記錯誤。"));
					return false & base.Validate();
				}
				else
				{
					this.Message.Element("Success").Add(new XElement("Month", mark_no));
					return base.Validate();
				}
			}
		}

		//	解析「點名日期--日」之畫記
		private sealed class DayParser : Decorator
		{
            // 透過config讀取設定
            static K12.Data.Configuration.ConfigData _CardSettingData = K12.Data.School.Configuration["CardSettingData"];
            static XDocument cardSettingData = XDocument.Parse(_CardSettingData.PreviousData.OuterXml);

            static XElement day = cardSettingData.Element("CardPositionSetting").Element("MappingDate").Element("Day");
            List<XElement> dayPositionList = day.Elements("Position").ToList();

			public override bool Validate()
			{
				int mark_count = 0; // 畫卡次數
				string mark_no = ""; // 值
                foreach (XElement dp in dayPositionList)
                {
                    int index = int.Parse(dp.Attribute("Row").Value) * 35 + int.Parse(dp.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        mark_no = dp.Attribute("Value").Value;
                        mark_count++;
                    }
                }

				if (mark_count == 1)
				{
					this.Message.Element("Success").Add(new XElement("Day", string.Join("", mark_no)));
					return base.Validate();
				}
				else
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「點名日期--日」畫記錯誤。"));
					return false & base.Validate();
				}
			}
		}

		//	解析「遲到早退/曠課」之畫記		
		//<Discipline SeatNo="1">
		//	<Period Name="第一節">
		//		<Reason>遲</Reason>
		//		<Reason>缺</Reason>
		//	</Period>
		//</Discipline>
		private sealed class AttendanceParser : Decorator
		{
            // 透過config讀取設定
            static K12.Data.Configuration.ConfigData _CardSettingData = K12.Data.School.Configuration["CardSettingData"];
            static XDocument cardSettingData = XDocument.Parse(_CardSettingData.PreviousData.OuterXml);

            static XElement MappingAttendance = cardSettingData.Element("CardPositionSetting").Element("MappingAttendance");
            static int starRow = int.Parse(MappingAttendance.Element("StartRow").Value);
            static List<XElement> periods = MappingAttendance.Descendants("Period").ToList();
            static XElement paper = cardSettingData.Element("CardPositionSetting").Element("Paper");
            static int colCount = int.Parse(paper.Element("PerRowCount").Value);
            static int totalRow = int.Parse(paper.Element("PerColumnCount").Value);
            
            public override bool Validate()
			{
                int position = 0;
                int seatNumber = 1;
                int c = 0; // 從1號開始，第0列
                // 缺曠畫卡範圍
                for (int i = starRow; i < totalRow; i++)
                {
                    XElement Discipline = new XElement("Discipline", new XAttribute("SeatNo", seatNumber++));
                    this.Message.Element("Success").Add(Discipline);
                    
                    foreach (XElement period in periods)
                    {
                        // mark 標記 畫卡方式:{ 1_0 , 0_1 , 1_1}
                        string mark = "";
                        position = int.Parse(period.Attribute("StartCol").Value) + (starRow + c) * colCount;
                        for (int n = 0; n < 2; n++)
                        {
                            if (this.Source.ElementAt(position + n) >= this.Level)
                            {
                                mark += 1;
                            }
                            else
                                mark += 0;
                        }

                        XElement Period = new XElement("Period", new XAttribute("Name", period.Attribute("Value").Value));
                        Discipline.Add(Period);

                        List<XElement> absence = period.Elements("Absence").ToList();
                        foreach (XElement ab in absence)
                        {
                            if (mark == ab.Attribute("Mark").Value)
                            {
                                Period.Add(new XElement("Reason", ab.Attribute("Value").Value));
                            }
                        }
                    }
                    // 換下一個座號
                    c++;
                }
                return true & base.Validate();
            }
		}
		
		private static readonly WVSOMRParser instance = new WVSOMRParser();
		
		public static WVSOMRParser Instance { get { return instance; } }

		/// <summary>
		/// 解析請假卡片資料。
		/// </summary>
		/// <param name="source">資料來源</param>
		/// <param name="level">畫卡濃度,預設為3。</param>
		/// <returns></returns>
		public XElement LeaveParser(byte[] source, int level, int source_length)
		{
			if (source.Length != source_length)
				throw new ArgumentException("卡片格式不正確，請確認卡片為「請假卡」。");

			iParser Parser = new ConcreteParser();	
			
			////	學號
			//Decorator Decorator = new LeaveStudentNumberParser();
			//Decorator.SetParser(Parser);
			//Decorator.SetParams(source, level);
			//Parser = Decorator;
			////	假別
			//Decorator = new LeaveAttendanceTypeParser();
			//Decorator.SetParser(Parser);
			//Decorator.SetParams(source, level);
			//Parser = Decorator;
			////	請假日期
			//Decorator = new LeaveRangeParser();
			//Decorator.SetParser(Parser);
			//Decorator.SetParams(source, level);
			//Parser = Decorator;

			bool result1 = Parser.Validate();
			XElement Element = Parser.GetMessage();

			return Element;
		}
        
        /// <summary>
        /// 解析出勤卡片資料。
        /// </summary>
        /// <param name="source">資料來源</param>
        /// <param name="level">畫卡濃度,預設為3。</param>
        /// <returns></returns>
		public XElement Parser(byte[] source, int level, int source_length)
        {
			if (source.Length != source_length)
				throw new ArgumentException("卡片格式不正確，請確認卡片為「出勤點名卡」。");

			iParser Parser = new ConcreteParser();
			//	年級
			Decorator Decorator = new GradeYearParser();
			Decorator.SetParser(Parser);
			Decorator.SetParams(source, level);
			Parser = Decorator;
			//	班級
			Decorator = new ClassParser();
			Decorator.SetParser(Parser);
			Decorator.SetParams(source, level);
			Parser = Decorator;
			//	點名日期--年
			Decorator = new YearParser();
			Decorator.SetParser(Parser);
			Decorator.SetParams(source, level);
			Parser = Decorator;
			//	點名日期--月
			Decorator = new MonthParser();
			Decorator.SetParser(Parser);
			Decorator.SetParams(source, level);
			Parser = Decorator;
			//	點名日期--日
			Decorator = new DayParser();
			Decorator.SetParser(Parser);
			Decorator.SetParams(source, level);
			Parser = Decorator;
			//	遲到早退/曠課
			Decorator = new AttendanceParser();
			Decorator.SetParser(Parser);
			Decorator.SetParams(source, level);
			Parser = Decorator;

			bool result1 = Parser.Validate();
			XElement Element = Parser.GetMessage();

			return Element;
        }

		//<Failure>
		//	<Message>「點名日期--日」畫記錯誤。</Message>
		//	<Message>「點名日期--月」畫記錯誤。</Message>
		//	<Message>「點名日期--年」畫記錯誤。</Message>
		//	<Message>「班級」畫記錯誤。</Message>
		//	<Message>「年級」畫記錯誤。</Message>
		//</Failure>
		public bool IsValidated(XElement disciplineContent, out XElement errorMessages)
		{
			errorMessages = new XElement("Messages");
			XElement em = errorMessages;

			em.Add(disciplineContent.Element("Failure").Nodes());

			return em.Elements("Message").Count() <= 0;
		}
    }
}
