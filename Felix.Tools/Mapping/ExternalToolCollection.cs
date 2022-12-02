using System.Xml.Serialization;

namespace Felix.Tools.Mapping
{
	[XmlType("Tools")]
	public class ExternalToolCollection : List<ExternalTool>
	{
	}
}
