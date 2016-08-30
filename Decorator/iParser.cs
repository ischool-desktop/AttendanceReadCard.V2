using System.Xml.Linq;

namespace AttendanceReadCard
{
	public abstract class iParser
	{
		protected XElement Message;
		public abstract bool Validate();
		public abstract XElement GetMessage(XElement Element=null);
	}
}
