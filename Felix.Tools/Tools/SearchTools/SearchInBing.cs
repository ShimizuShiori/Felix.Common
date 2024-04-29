using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.Tools.SearchTools
{
	[TextTool("Being", "Search")]
	class SearchInBing : SearchTool
	{
		protected override void StartSearch(string keyword)
		{
			var lang = new (string, string)[]
			{
				("Ch","0"),
				("En","1")
			};
			var selectedLang = ChooesForm<(string, string)>.Show("", lang.ToMap(x => (x.Item1, x)), ("", ""));
			if (selectedLang.Item1 == "")
				return;

			UriHelper.Open($"https://cn.bing.com/search?q={UriHelper.Encode($"{keyword}")}&ensearch={selectedLang.Item2}");
		}
	}
}
