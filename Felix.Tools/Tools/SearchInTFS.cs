using Felix.Common;

namespace Felix.Tools.Tools
{
	[Tool("On TFS", "Search")]
	class SearchInTFS : SyncTool
	{
		protected override void Start()
		{
			var repos = new string[]
			{
				"All",
				"CargoWise"
			};
			var mode = new (string, string)[]
			{
				("Normal", "{0}"),
				("BaseType", "basetype: {0}")
			};

			var selectedFormat = ChooesForm<string>.Show(
				"select mode",
				mode.ToMap(x => (x.Item1, x.Item2)),
				"");
			if (selectedFormat == string.Empty)
				return;

			var selectedRepo = ChooesForm<string>.Show(
				"Select Repo",
				repos.ToMap(x => (x, x)),
				string.Empty);
			if (selectedRepo == string.Empty)
				return;

			var sText = UrlHelper.Encode(String.Format(selectedFormat, AppContext.SelectedText));
			if (selectedRepo == "All")
			{
				UrlHelper.Open($"https://devops.wisetechglobal.com/wtg/_search?text={sText}&type=code");
			}
			else
			{
				UrlHelper.Open($"https://devops.wisetechglobal.com/wtg/{selectedRepo}/_search?text={sText}&type=code");
			}
		}
	}
}
