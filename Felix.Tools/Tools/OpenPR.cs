using Felix.Common;

namespace Felix.Tools.Tools
{
	[Tool("PR", "Repo")]
	class OpenPR : ITool
	{
		const string urlFormat = @"https://devops.wisetechglobal.com/wtg/{0}/_git/{1}/pullrequests";

		static readonly (string, string[])[] repos = new (string, string[])[]
		{
			("CargoWise", new string[] { "Dev", "Shared" })
		};
		public void Start()
		{
			var selected = ChooesForm<(string, string[])>.Show(
				"Select Repo"
				, repos.ToMap(x => (x.Item1, x))
				, ("", Array.Empty<string>()));
			if (selected.Item2.Length == 0)
				return;
			var selected2 = ChooesForm<string>.Show(
				"Select Repo",
				selected.Item2.ToMap(x => (x, x)),
				""
			);
			if (selected2 == "")
				return;

			UrlHelper.Open(string.Format(urlFormat, selected.Item1, selected2));
		}
	}
}
