using Felix.Common;

namespace Felix.Tools.Tools
{
	[Tool("SO", "Search")]
	class SearchOnSO : SyncTool
	{
		const string urlFormat = @"https://stackoverflow.com/c/wisetechglobal/search?q={0}&searchOn=1";
		protected override void Start()
		{
			var content = AppContext.SelectedText
				.Replace(" ", "+");
			var url = string.Format(urlFormat, content);
			UrlHelper.Open(url);
		}
	}
}
