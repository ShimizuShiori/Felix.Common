using Felix.Tools.Attributes;
using Felix.Tools.SharedInfos;
using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[Tool("GitBash", "Repo")]
	class GitBashRepo : ITool
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
				p.StartInfo.FileName = @"C:\Program Files\Git\git-bash.exe"; 
				p.StartInfo.Arguments = @$"--cd=C:\git\wtg\{selected}\{selected2}";
				p.StartInfo.UseShellExecute = false;
				p.Start();
			}
		}
	}
}
