﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.Configuration;
using FISCA;
using System.Xml;
using System.Xml.Linq;
using InternalLib;
using System.Xml.XPath;

namespace AttendanceReadCard
{
    /// <summary>
    /// 學生出缺席讀卡設定。
    /// </summary>
    public class CardSetup
	{
        public CardSetup()
        {
            try
            {
                Campus.Configuration.Config.App.Sync("學生出缺席讀卡設定");
                ConfigData cd = Campus.Configuration.Config.App["學生出缺席讀卡設定"];

                if (cd["OverrideOption"] == "覆蓋現有資料")
                    OverrideData = true;
                else
                    OverrideData = false; //預設是這個選項。

                // 2017/11/13 羿均
                //節次對照表。
                PeriodMapping = new Dictionary<string, string>();
                PeriodIndex = new Dictionary<string, int>();

                // 2017/11/30 透過config讀取設定
                K12.Data.Configuration.ConfigData _CardSettingData = K12.Data.School.Configuration["CardSettingData"];
                XDocument cardSettingData = XDocument.Parse(_CardSettingData.PreviousData.OuterXml);

                List<XElement> period = cardSettingData.Element("CardPositionSetting").Element("MappingAttendance").Elements("Period").ToList();
                int index = -1; 
                // 因為讀卡設定功能，已將大部分設定隱藏，所以這邊節次mapping的資料都是直接讀取config 節次設定
                foreach (XElement p in period)
                {
                    index++;
                    if (PeriodMapping.ContainsKey(p.Attribute("Value").Value))
                        throw new Exception("節次對照設定有重覆！");
                    if (string.IsNullOrWhiteSpace(p.Attribute("Value").Value))
                        continue;
                    PeriodMapping.Add(p.Attribute("Value").Value, p.Attribute("Value").Value);
                    PeriodIndex.Add(p.Attribute("Value").Value, index);
                }
                //foreach (string period in Program.PeriodNameList)
                //{
                //    index++;

                //    if (PeriodMapping.ContainsKey(period))
                //        throw new Exception("節次對照設定有重覆！");

                //    if (string.IsNullOrWhiteSpace(cd[period]))
                //        continue;

                //    PeriodMapping.Add(period, cd[period]);
                //    PeriodIndex.Add(cd[period], index);
                //}

                //	假別對照表
    //            AbsenceTypeMapping = new Dictionary<string, string>();
				//index = -1;
				//foreach (string type in Program.LeaveNameList)
				//{
				//	index++;

				//	if (AbsenceTypeMapping.ContainsKey(type))
				//		throw new Exception("節次對照設定有重覆！");

				//	if (string.IsNullOrWhiteSpace(cd[type]))
				//		continue;

				//	AbsenceTypeMapping.Add(type, cd[type]);
				//}

                //讀取班級對照表。
                XmlElement xmlclassmap = cd.GetXml("ClassNameMap", null);

                XElement xclassmap;
                if (xmlclassmap != null)
                    xclassmap = XElement.Parse(xmlclassmap.OuterXml);
                else
                    xclassmap = new XElement("Map");

                ClassMapping = new Dictionary<string, string>();
                foreach (XElement cls in xclassmap.Elements("Class"))
                {
                    string classname = cls.Attribute("ClassName").Value;
                    string cardname = cls.Attribute("CardName").Value;

                    if (string.IsNullOrWhiteSpace(cardname))
                        continue;

                    if (ClassMapping.ContainsKey(cardname))
                        throw new Exception("班級對照表有重覆的代碼設定！");

                    ClassMapping.Add(cardname, classname);
                }
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                throw new Exception("讀取讀卡設定錯誤:" + ex.Message, ex);
            }
        }

        /// <summary>
        /// 讀卡的班級名稱對照表。
        /// </summary>
        public Dictionary<string, string> ClassMapping { get; private set; }

        /// <summary>
        /// 讀卡節次對照表,卡片上的節次對照系統中的節次。
        /// </summary>
		public Dictionary<string, string> PeriodMapping { get; private set; }

		/// <summary>
		/// 讀卡假別對照表,卡片上的假別對照系統中的假別。
		/// </summary>
		public Dictionary<string, string> AbsenceTypeMapping { get; private set; }

        /// <summary>
        /// 節次的索引位置，用於決定要顯示在那個欄位上。
        /// </summary>
        public Dictionary<string, int> PeriodIndex { get; private set; }

        /// <summary>
        /// 是否覆蓋現有資料。
        /// </summary>
        public bool OverrideData { get; private set; }

        /// <summary>
        /// 依據設定轉換點名卡上的資料。
        /// </summary>
        /// <param name="xCardData"></param>
        /// <returns></returns>
        public XElement TransformAbsenceCardData(XElement xCardData)
        {
            XElement source = xCardData;
            XElement result = new XElement("AttendanceData");

            //班級代碼。
			string cn = source.Descendants("Class").First().Value;
            if (!ClassMapping.ContainsKey(cn))
                throw new Exception(string.Format("未定義的班級讀卡代碼：{0}", cn));

            result.Add(new XElement("ClassName", ClassMapping[cn]));

            //日期
			int year = int.Parse(source.Descendants("Year").First().Value);
			string month = source.Descendants("Month").First().Value;
			string day = source.Descendants("Day").First().Value;
			//string dt = string.Format("{0}/{1}/{2}", year, month, day);
			DateTime dd = DateTime.Now;
			if (!DateTime.TryParse(string.Format("{0}/{1}/{2}", year + 1911, month, day), out dd))
				throw new Exception(string.Format("點名日期畫記錯誤：{0}", string.Format("{0}/{1}/{2}", year, month, day)));

			result.Add(new XElement("DateTime", dd.ToString("yyyy/MM/dd")));

			foreach (XElement attendance in source.Descendants("Discipline"))
            {
                XElement newattendance = new XElement("Attendance");
                newattendance.SetAttributeValue("SeatNo", attendance.AttributeText("SeatNo"));
				newattendance.SetAttributeValue("DateTime", dd.ToString("yyyy/MM/dd"));
                foreach (XElement period in attendance.Elements("Period"))
                {
					if (period.Descendants("Reason").Count() == 0)
						continue;

                    XElement newperiod = new XElement("Period");

					string cardPeriod = period.AttributeText("Name");

					if (!PeriodMapping.ContainsKey(cardPeriod)) //沒設定就讀不到。
						continue;

					string periodTitle = PeriodMapping[cardPeriod];

					if (string.IsNullOrWhiteSpace(periodTitle)) //沒設定就讀不到。
						continue;

					newperiod.SetAttributeValue("Name", periodTitle);	//


                    //XElement reason = period.XPathSelectElement("Reason[.='缺']");

                    //if (reason != null) //不是「缺」
                    //    newperiod.SetAttributeValue("Reason", AbsenceString);
                    //else //就是「遲」
                    //    newperiod.SetAttributeValue("Reason", LateString);


                    //2016/9/2 穎驊更新，雖然這邊是寫["假別對照表"] ，但個人人覺得就功能而言比較像是缺曠項目對照表
                    ConfigData absence = Campus.Configuration.Config.App["假別對照表"];
                    XElement xmlabs = XElement.Parse(absence.PreviousData.OuterXml);
                    foreach (XElement abs in xmlabs.Elements("Absence"))
                    {
                        //搜尋的目標會像"Reason[.='曠課']" 之類的
                        XElement reason = period.XPathSelectElement("Reason[.='" + abs.Attribute("Name").Value + "']");

                        if (reason != null)
                        {
                            newperiod.SetAttributeValue("Reason", reason.Value);                                                      
                        }
                    }                                                                                                  

                    newattendance.Add(newperiod);
                }
                result.Add(newattendance);
            }

            return result;
        }
		
		public XElement TransformLeaveCardData(XElement xCardData)
		{
			XElement source = xCardData;
			XElement result = new XElement("AttendanceData");


			result.Add(new XElement("StudentNumber", xCardData.Descendants("StudentNumber").First().Value));
			result.Add(new XElement("AttendanceType", xCardData.Descendants("AttendanceType").First().Value));

			foreach (XElement attendance in source.Descendants("Discipline"))
			{
				XElement newattendance = new XElement("Attendance");
				newattendance.SetAttributeValue("DateTime", attendance.AttributeText("DateTime"));

				foreach (XElement period in attendance.Elements("Period"))
				{
					XElement newperiod = new XElement("Period");

					string cardPeriod = period.AttributeText("Name");

					if (!PeriodMapping.ContainsKey(cardPeriod)) //沒設定就讀不到。
						continue;

					string periodTitle = PeriodMapping[cardPeriod];

					if (string.IsNullOrWhiteSpace(periodTitle)) //沒設定就讀不到。
						continue;

					newperiod.SetAttributeValue("Name", periodTitle);
					newperiod.SetAttributeValue("Reason", xCardData.Descendants("AttendanceType").First().Value);	

					newattendance.Add(newperiod);
				}
				result.Add(newattendance);
			}

			return result;
		}
	}
}
