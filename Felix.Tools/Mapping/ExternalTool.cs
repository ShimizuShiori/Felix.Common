using System.Xml.Serialization;

namespace Felix.Tools.Mapping
{
	[XmlType("Tool")]
	public class ExternalTool
	{
		[XmlAttribute]
		public string Category { get; set; }
		[XmlAttribute]
		public string Name { get; set; }

		[XmlElement("Exec")]
		public string Exec { get; set; } = string.Empty;

		[XmlElement("Arg")]
		public string Arg { get; set; } = string.Empty;

		[XmlElement("WorkingDirectory")]
		public string WorkingDirectory { get; set; } = string.Empty;
	}
}
