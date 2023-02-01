using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.SharedInfos;

namespace Felix.Tools.Tools
{
	[Tool("PR", "Repo")]
	class OpenPR : SyncTool
	{
		const string urlFormat = @"https://devops.wisetechglobal.com/wtg/{0}/_git/{1}/pullrequests";
		protected override void Start()
		{
			var selected = ChooesForm<(string, string[])>.Show(
				TFSInfos.GetProjects());

			if (selected == "")
				return;

			var selected2 = ChooesForm<string>.Show(TFSInfos.GetRepos(selected));
			if (selected2 == "")
				return;

			UrlHelper.Open(string.Format(urlFormat, selected, selected2));
		}
	}
}
