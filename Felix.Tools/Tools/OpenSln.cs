using Felix.Common;
using Felix.Tools.Attributes;
using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[FileTool("Sln", "Open")]
	class OpenSln : ITool
	{
		public async Task StartAsync()
		{
			foreach (var path in AppContext.SelectedFilePathList)
				await OpenSlnByPath(path);
		}

		private Task OpenSlnByPath(string path)
		{
			var file = new FileInfo(path);
			var dir = file.Directory;
			if (dir == null)
				return Task.CompletedTask;

			FileInfo[] slns;
			while ((slns = dir.GetFiles("*.sln")).Length == 0)
			{
				dir = dir.Parent;
				if (dir == null)
					break;
			}

			if (slns.Length == 1)
			{
				OpenDevenv(slns[0].FullName);
			}
			else
			{
				var selectedSln = ChooesForm<FileInfo>.Show("",
					slns.ToMap(f => (f.Name, f)),
					new FileInfo("c:\\NOT EXIST.txt"));
				if (selectedSln.Name == "NOT EXIST.txt")
					return Task.CompletedTask;

				OpenDevenv(selectedSln.FullName);
			}
			return Task.CompletedTask;
		}

		void OpenDevenv(string path)
		{
			Process p = new Process();
			p.StartInfo.FileName = @"C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\devenv.exe";
			p.StartInfo.Arguments = path;
			p.StartInfo.UseShellExecute = true;
			p.Start();
		}
	}
}
