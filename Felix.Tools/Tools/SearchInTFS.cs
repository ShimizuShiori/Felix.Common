using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.SharedInfos;

namespace Felix.Tools.Tools
{
	[TextTool("TFS", "Search")]
	class SearchInTFS : SyncTool
	{
		protected override void Start()
		{
			var mode = new (string, string)[]
			{
				("All", "\"{0}\""),
				("BaseType", "basetype: {0}"),
				("Caller", "caller: {0}"),
				("Def", "def: {0}")
			};

			var selectedFormat = ChooesForm<string>.Show(
				"select mode",
				mode.ToMap(x => (x.Item1, x.Item2)),
				"");
			if (selectedFormat == string.Empty)
				return;

			var selectedRepo = ChooesForm<string>.Show(
				TFSInfos.GetProjects().Concat(new string[]
				{
					"All"
				}));
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
