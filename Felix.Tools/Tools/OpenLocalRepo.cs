using Felix.Tools.Attributes;
using Felix.Tools.SharedInfos;
using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[Tool("Local", "Repo")]
	class OpenLocalRepo : ITool
	{
		public void Start()
		{
			var selected = ChooesForm<(string, string[])>.Show(
				TFSInfos.GetProjects());

			if (selected == "")
				return;

			var selected2 = ChooesForm<string>.Show(TFSInfos.GetRepos(selected));
			if (selected2 == "")
				return;

			using (var p = new Process())
			{
				p.StartInfo.FileName = @$"C:\git\wtg\{selected}\{selected2}";
				p.StartInfo.UseShellExecute = true;
				p.Start();
			}
		}
	}
}
