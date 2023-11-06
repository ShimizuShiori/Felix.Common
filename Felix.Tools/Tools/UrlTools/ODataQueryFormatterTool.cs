using Felix.Tools.Attributes;
using System.Text.RegularExpressions;

namespace Felix.Tools.Tools.UrlTools
{
	[TextTool("ODataFilterFormatter", "URL", textMatcherType: typeof(ODataQueryMatcher))]
	class ODataQueryFormatterTool : ITool
	{
		public const string KEY = "$filter=";
		public void Start()
		{
			var url = AppContext.SelectedText;
			var i = url.IndexOf(KEY) + KEY.Length;
			var j = url.IndexOf("&", i);
			var express = j == -1 ? url.Substring(i) : url.Substring(i, j - i);
			var ts = new Regex(@"\b").Split(express);
			
		}
	}

	class ODataQueryMatcher : ITextMatcher
	{
		public bool IsMatch(string text)
		{
			return text.Contains(ODataQueryFormatterTool.KEY);
		}
	}
}
