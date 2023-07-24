using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.Tools.SearchTools
{
	[TextTool("Being", "Search")]
	class SearchInBeing : SearchTool
	{
		protected override void StartSearch(string keyword, string otherWord)
		{
			var lang = new (string, string)[]
			{
				("Ch","0"),
				("En","1")
			};
			var selectedLang = ChooesForm<(string, string)>.Show("", lang.ToMap(x => (x.Item1, x)), ("", ""));
			if (selectedLang.Item1 == "")
				return;

			UriHelper.Open($"https://cn.bing.com/search?q={UriHelper.Encode($"{keyword} {otherWord}")}&ensearch={selectedLang.Item2}");
		}
	}
}
