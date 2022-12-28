using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.Tools
{
	[TextTool("Being", "Search")]
	class SearchInBeing : ITool
	{
		public Task StartAsync()
		{
			var lang = new (string, string)[]
			{
				("Ch","0"),
				("En","1")
			};
			var selectedLang = ChooesForm<(string, string)>.Show("", lang.ToMap(x => (x.Item1, x)), ("", ""));
			if (selectedLang.Item1 == "")
				return Task.CompletedTask;

			UrlHelper.Open($"https://cn.bing.com/search?q={UrlHelper.Encode(AppContext.SelectedText)}&ensearch={selectedLang.Item2}");
			return Task.CompletedTask;
		}
	}
}
