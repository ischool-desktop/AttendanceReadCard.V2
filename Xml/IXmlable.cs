/*
 * Create Date：2010/10/22
 * Author Name：YaoMing Huang
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace InternalLib
{
    /// <summary>
    /// 代表物件狀態可以轉換成 Xml 資料。
    /// </summary>
    public interface IXmlable
    {
        /// <summary>
        /// 取得代表物件內容的 Xml 字串。
        /// </summary>
        /// <returns>完整 Xml 字串。</returns>
        string XmlString { get; }

        /// <summary>
        /// 將 Xml 資料以 UTF-8 編碼後寫入到指定的檔案。
        /// </summary>
        /// <param name="fileName">檔案名稱。</param>
        void WriteTo(string fileName);
    }
}
