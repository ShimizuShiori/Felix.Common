using Felix.Common;
using Felix.Tools.Attributes;
using System.Text.RegularExpressions;

namespace Felix.Tools.Tools.Open
{
	[TextTool("WI", "Open", regex: Reg)]
	class OpenWi : ITool
	{
		public const string Reg = @"(WI|CS)\d{8}";
		public void Start()
		{
			var match = Regex.Match(AppContext.SelectedText, Reg);
			var id = match.Groups[0];
			var type = match.Groups[1];
			string uri = $"edient:Command=ShortCode&Id={id}&Type={type}";
			UriHelper.Open(uri);
		}
	}
}
