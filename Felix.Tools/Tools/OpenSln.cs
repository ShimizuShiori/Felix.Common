using Felix.Common;
using Felix.Tools.Attributes;
using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[FileTool("Sln", "Open")]
	class OpenSln : ITool
	{
		public void Start()
		{
			foreach (var path in AppContext.SelectedFilePathList)
				OpenSlnByPath(path);
		}

		void OpenSlnByPath(string path)
		{
			var file = new FileInfo(path);
			var dir = file.Directory;
			if (dir == null)
				return;

			FileInfo[] slns;
			while ((slns = dir.GetFiles("*.sln")).Length == 0)
			{
				dir = dir.Parent;
				if (dir == null)
					break;
			}

			if (slns.Length == 1)
			{
				OpenDevenv(slns[0].FullName, path);
			}
			else
			{
				var selectedSln = ChooesForm<FileInfo>.Show("",
					slns.ToMap(f => (f.Name, f)),
					new FileInfo("c:\\NOT EXIST.txt"));
				if (selectedSln.Name == "NOT EXIST.txt")
					return;

				OpenDevenv(selectedSln.FullName, path);
			}
			return;
		}

		void OpenDevenv(string path, string filePath)
		{
			Process p = new Process();
			p.StartInfo.FileName = @"C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\devenv.exe";
			p.StartInfo.Arguments = $"{path} {filePath}";
			p.StartInfo.UseShellExecute = true;
			p.Start();
		}
	}
}
