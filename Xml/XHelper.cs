/*
 * Create Date：2010/11/2
 * Author Name：YaoMing Huang
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace InternalLib
{
    /// <summary>
    /// 協助建立 Xml 文件的輔助類別。
    /// </summary>
    public class XHelper : IXmlable
    {
        #region Static Methods
        /// <summary>
        /// 格式化 Xml 內容。
        /// </summary>
        /// <returns></returns>
        public static string Format(string xmlContent)
        {
            StringBuilder output = new StringBuilder();

            XmlWriterSettings setting = new XmlWriterSettings();
            setting.OmitXmlDeclaration = true;  //True 是不寫入？註解很怪...
            setting.Encoding = Encoding.UTF8;
            setting.Indent = true;
            setting.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create(output, setting))
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlContent)))
                {
                    writer.WriteNode(reader, true);
                }
            }
            return output.ToString();
        }

        /// <summary>
        /// 讀取到指定路徑上，用「~」分隔。例：Envelope~Header、Header、Header~Body，
        /// 第一個的意思是先讀到 Envelope 再到 Header，第二個是直接到 Header，
        /// 第三個是先到 Header 再到 Body。「~」的意思是接下來到哪裡。
        /// </summary>
        /// <param name="reader">XmlReader。</param>
        /// <param name="path">路徑，不支援 XPath。</param>
        /// <returns></returns>
        internal static bool ReadToFollowing(XmlReader reader, string path)
        {
            foreach (string name in path.Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!reader.ReadToFollowing(name))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 讀取到是 Element 為止。
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        internal static bool ReadToElement(XmlReader reader)
        {
            //往下讀取到 NodeType 是 Element 為止。
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element) continue;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outerxml"></param>
        /// <returns></returns>
        public static XmlElement ParseAsDOM(string outerxml)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(outerxml);
            return doc.DocumentElement;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outerxml"></param>
        /// <returns></returns>
        public static XHelper ParseAsHelper(string outerxml)
        {
            return new XHelper(ParseAsDOM(outerxml));
        }

        internal static void WriteTo(IXmlable obj, string fileName)
        {
            System.IO.File.WriteAllText(fileName, Format(obj.XmlString), Encoding.UTF8);
        }
        #endregion

        /// <summary>
        /// Helper 基礎物件。
        /// </summary>
        public XmlElement Data { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public XHelper()
        {
            Data = ParseAsDOM("<Content/>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outerXml"></param>
        public XHelper(string outerXml)
            : this(ParseAsDOM(outerXml))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public XHelper(XmlElement element)
        {
            if (element == null)
                throw new ArgumentNullException("參數不可為 Null。", "element");

            if (element.NodeType != XmlNodeType.Element)
                throw new ArgumentException("NodeType 僅支援 Element。", "element");

            Data = element;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public XHelper(XElement element)
        {
            if (element == null)
                throw new ArgumentNullException("參數不可為 Null。", "element");

            Data = element.ToXmlElement();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        public XHelper(IXmlable xml)
        {
            if (xml == null)
                Data = ParseAsDOM("<Content/>");
            else
                Data = ParseAsDOM(xml.XmlString);
        }

        #region AddElement
        /// <summary>
        /// 新增空白元素(Empyt Element)到文件中
        /// </summary>
        /// <param name="newName">新元素名稱。</param>
        /// <returns>代表在<see cref="XHelper"/>物件中新元素的實體。</returns>
        public XmlElement AddElement(string newName)
        {
            return AddElement(".", newName, null);
        }

        /// <summary>
        /// 在指定的元素下，新增空白子元素。
        /// </summary>
        /// <param name="xpath">要新增「空白子元素」的「父元素」路徑</param>
        /// <param name="newElement">要新增的元素物件</param>
        /// <returns>代表在<see cref="XHelper"/>物件中新元素的實體。</returns>
        public XmlElement AddElement(string xpath, XmlElement newElement)
        {
            if (XmlDocument.ReferenceEquals(Data.OwnerDocument, newElement.OwnerDocument))
                return (XmlElement)GetLastNode(xpath).AppendChild(newElement);
            else
            {
                XmlNode newNode = Data.OwnerDocument.ImportNode(newElement, true);
                return (XmlElement)GetLastNode(xpath).AppendChild(newNode);
            }
        }

        /// <summary>
        /// 在指定的元素下，新增子元素。
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public XmlElement AddElement(string xpath, IXmlable child)
        {
            return AddElement(xpath, XHelper.ParseAsDOM(child.XmlString));
        }

        /// <summary>
        /// 在指定的元素下，新增空白子元素。
        /// </summary>
        /// <param name="xpath">要新增「空白子元素」的「父元素」路徑。</param>
        /// <param name="newName">空白子元素名稱。</param>
        /// <returns>代表在<see cref="XHelper"/>物件中新元素的實體。</returns>
        public XmlElement AddElement(string xpath, string newName)
        {
            return AddElement(xpath, newName, "");
        }

        /// <summary>
        /// 在指定的元素下，新增子元素，並指定文字資料。
        /// </summary>
        /// <param name="xpath">要新增「子元素」的「父元素」路徑。</param>
        /// <param name="newName">子元素名稱。</param>
        /// <param name="text">子元素文字資料。</param>
        /// <returns>代表在<see cref="XHelper"/>物件中新元素的實體。</returns>
        public XmlElement AddElement(string xpath, string newName, string text)
        {
            return AddElement(xpath, newName, text, false);
        }

        /// <summary>
        /// 在指定的元素下，新增子元素，並指定文字資料。
        /// </summary>
        /// <param name="xpath">要新增「子元素」的「父元素」路徑。</param>
        /// <param name="newName">子元素名稱。</param>
        /// <param name="text">子元素文字資料。</param>
        /// <param name="isXmlContent">文字資料是否為 Xml 字串，可以是單一 Node 或 NodeList。</param>
        /// <returns>代表在<see cref="XHelper"/>物件中新元素的實體。</returns>
        /// <remarks>其他AddElement範例可參考<see cref="XHelper.AddElement(string,string)">
        /// DSXmlHelper.AddElement</see>方法說明。</remarks>
        public XmlElement AddElement(string xpath, string newName, string text, bool isXmlContent)
        {
            XmlElement target = GetLastNode(xpath);

            //Node to be added
            XmlElement elm = CreateElement(newName);
            if (isXmlContent)
                elm.InnerXml = text;
            else
                elm.InnerText = text;

            return target.AppendChild(elm) as XmlElement;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="content"></param>
        public void SetInnerXml(string xpath, string content)
        {
            XmlElement elm = GetElement(xpath);
            if (elm != null)
                elm.InnerXml = content;
            else
                throw new ArgumentException(string.Format("XPath 路徑不存在({0})。", xpath));
        }
        #endregion

        #region SetAttribute
        /// <summary>
        /// 在指定的元素下，新增屬性，並指定值。
        /// </summary>
        /// <param name="xpath">要新增屬性的元素路徑。</param>
        /// <param name="name">屬性名稱。</param>
        /// <param name="value">屬性值。</param>
        /// <returns>XmlAttribute的新實體。</returns>
        public void SetAttribute(string xpath, string name, string value)
        {
            GetLastNode(xpath).SetAttribute(name, value);
        }
        #endregion

        #region GetElement
        /// <summary>
        /// 取得元素物件，但僅取得符合「元素路徑」的第一個元素。
        /// </summary>
        /// <param name="xpath">元素路徑。</param>
        /// <returns>回傳的XmlElement實體。</returns>
        /// <exception cref="Exception">發生再xpath取出的物件不是元素(Element)時。</exception>
        public XmlElement GetElement(string xpath)
        {
            XmlNode nd = Data.SelectSingleNode(xpath);

            if (nd != null && !(nd is XmlElement))
                throw new Exception("取得的資料不是一個元素(Element)。");

            //如果nd是Null，則會回傳Null(表示as運算失敗)
            return (nd as XmlElement);
        }

        /// <summary>
        /// 取得元素物件陣列，將會取得所有符合「元素路徑」的所有元素。
        /// </summary>
        /// <param name="xpath">元素路徑。</param>
        /// <returns>XmlElement的陣列。</returns>
        public XmlElement[] GetElements(string xpath)
        {
            XmlNodeList ndl = Data.SelectNodes(xpath);

            XmlElement[] result = new XmlElement[ndl.Count];
            for (int i = 0; i < ndl.Count; i++)
                result[i] = (XmlElement)ndl[i];
            return result;
        }
        #endregion

        /// <summary>
        /// 移除元素。
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public XmlElement RemoveElement(string xpath)
        {
            XmlElement elm = GetElement(xpath);
            if (elm != null)
                elm = elm.ParentNode.RemoveChild(elm) as XmlElement;

            return elm;
        }

        #region Try Get
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public int TryGetInteger(string xpath, int defaultValue)
        {
            XmlNode n = Data.SelectSingleNode(xpath);

            if (n == null) return defaultValue;

            string strValue;
            if (n is XmlAttribute)
                strValue = n.Value;
            else
                strValue = n.InnerText;

            int intValue;
            if (int.TryParse(strValue, out intValue))
                return intValue;
            else
                return defaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public float TryGetFloat(string xpath, float defaultValue)
        {
            XmlNode n = Data.SelectSingleNode(xpath);

            if (n == null) return defaultValue;

            string strValue;
            if (n is XmlAttribute)
                strValue = n.Value;
            else
                strValue = n.InnerText;

            float intValue;
            if (float.TryParse(strValue, out intValue))
                return intValue;
            else
                return defaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public decimal TryGetDecimal(string xpath, decimal defaultValue)
        {
            XmlNode n = Data.SelectSingleNode(xpath);

            if (n == null) return defaultValue;

            string strValue;
            if (n is XmlAttribute)
                strValue = n.Value;
            else
                strValue = n.InnerText;

            decimal intValue;
            if (decimal.TryParse(strValue, out intValue))
                return intValue;
            else
                return defaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool TryGetBoolean(string xpath, bool defaultValue)
        {
            XmlNode n = Data.SelectSingleNode(xpath);

            if (n == null) return defaultValue;

            string strValue;
            if (n is XmlAttribute)
                strValue = n.Value;
            else
                strValue = n.InnerText;

            bool intValue;
            if (bool.TryParse(strValue, out intValue))
                return intValue;
            else
                return defaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string TryGetString(string xpath, string defaultValue)
        {
            string strValue = GetText(xpath);

            if (string.IsNullOrEmpty(strValue))
                return defaultValue;
            else
                return strValue;
        }
        #endregion

        /// <summary>
        /// 取得指定元素下的文字資料。
        /// </summary>
        /// <param name="xpath">元素路徑。</param>
        /// <returns>元素下的文字資料，如果指定的元素不存在則回傳String.Emtpy(空字串)。</returns>
        public string GetText(string xpath)
        {
            XmlNode n = Data.SelectSingleNode(xpath);

            if (n == null) return string.Empty;

            if (n is XmlAttribute)
                return n.Value;
            else
                return n.InnerText;
        }

        #region Private Method
        private XmlElement GetLastNode(string xpath)
        {
            XmlNodeList nlList = Data.SelectNodes(xpath);
            XmlNode ndTarget = null;

            if (nlList.Count > 0)
                ndTarget = nlList[nlList.Count - 1];
            else
                throw new ArgumentException(string.Format("沒有找到任何資料：「{0}」。", xpath), "xpath");

            return ndTarget as XmlElement;
        }
        private XmlElement CreateElement(string name)
        {
            XmlElement xmlent = Data.OwnerDocument.CreateElement(name);
            return xmlent;
        }
        private XmlAttribute CreateAttribute(string name)
        {
            XmlAttribute xmlbute = Data.OwnerDocument.CreateAttribute(name);
            return xmlbute;
        }
        #endregion

        #region IXmlable 成員

        /// <summary>
        /// 
        /// </summary>
        public string XmlString { get { return Data.OuterXml; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public void WriteTo(string fileName)
        {
            WriteTo(this, fileName);
        }

        #endregion
    }
}
