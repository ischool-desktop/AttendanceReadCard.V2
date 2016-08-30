using System.Xml.Linq;

namespace AttendanceReadCard
{
	public class ConcreteParser : iParser
	{
		public ConcreteParser()
		{
			this.Message = new XElement("Messages", new XElement("Success"), new XElement("Failure"));
		}

		public override bool Validate()
		{
			return true;
		}

		public override XElement GetMessage(XElement Element)
		{
			if (Element == null)
				Element = new XElement("Messages", new XElement("Success"), new XElement("Failure"));

			return Element;
		}
	}
}
