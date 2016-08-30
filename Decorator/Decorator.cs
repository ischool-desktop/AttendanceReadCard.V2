using System.Xml.Linq;
using System.Xml.XPath;

namespace AttendanceReadCard
{
	public abstract class Decorator : iParser
	{
		protected iParser Component;
		protected byte[] Source;
		protected int Level;

		public Decorator()
		{
			this.Message = new XElement("Messages", new XElement("Success"), new XElement("Failure"));
		}

		public void SetParser(iParser Component)
		{
			this.Component = Component;
		}

		public void SetParams(byte[] source, int level)
		{
			this.Source = source;
			this.Level = level;
		}

		public override bool Validate()
		{
			if (this.Component != null)
				return this.Component.Validate();
			else
				return true;
		}

		public override XElement GetMessage(XElement Element=null)
		{
			if (Element == null)
				Element = new XElement("Messages", new XElement("Success"), new XElement("Failure"));

			Element.XPathSelectElement("./Success").Add(this.Message.XPathSelectElements("./Success").Nodes());
			Element.XPathSelectElement("./Failure").Add(this.Message.XPathSelectElements("./Failure").Nodes());
			if (this.Component != null)
				return this.Component.GetMessage(Element);
			else
				return Element;
		}
	}
}
