using Felix.Tools.Attributes;
using Felix.Tools.SharedInfos;
using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[Tool("Local", "Repo")]
	class OpenLocalRepo : ITool
	{
		public Task StartAsync()
		{
			var selected = ChooesForm<(string, string[])>.Show(
				TFSInfos.GetProjects());

			if (selected == "")
				return Task.CompletedTask;

			var selected2 = ChooesForm<string>.Show(TFSInfos.GetRepos(selected));
			if (selected2 == "")
				return Task.CompletedTask;

			using (var p = new Process())
			{
				p.StartInfo.FileName = @$"C:\git\wtg\{selected}\{selected2}";
				p.StartInfo.UseShellExecute = true;
				p.Start();
			}
			return Task.CompletedTask;
		}
	}
}
