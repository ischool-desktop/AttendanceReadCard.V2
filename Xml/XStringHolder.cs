/*
 * Create Date：2010/11/3
 * Author Name：YaoMing Huang
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace InternalLib
{
    /// <summary>
    /// 負責持有 Xml 的資料，此類別不會對 Xml 進行任何解析動作
    /// </summary>
    public class XStringHolder : IXmlable
    {
        /// <summary>
        /// 
        /// </summary>
        public XStringHolder()
        {
            XmlString = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outerXml"></param>
        public XStringHolder(string outerXml)
            : this()
        {
            XmlString = outerXml;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public XStringHolder(XmlElement element)
            : this()
        {
            XmlString = element.OuterXml;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public XStringHolder(XElement element)
            : this()
        {
            XmlString = element.ToString();
        }

        #region IXmlable 成員

        /// <summary>
        /// 取得或設定 Xml 資料。
        /// </summary>
        public string XmlString { get; set; }

        /// <summary>
        /// 將 Xml 資料寫入到指定的檔案。
        /// </summary>
        /// <param name="fileName"></param>
        public void WriteTo(string fileName)
        {
            XHelper.WriteTo(this, fileName);
        }

        #endregion
    }
}
