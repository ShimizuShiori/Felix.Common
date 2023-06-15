using Felix.Tools.Attributes;
using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[FileTool("VSCode", "Open")]
	internal class OpenInVsCodeTool : ITool
	{
		Queue<string> solvingDirs = new Queue<string>();
		HashSet<string> dirsToOpen = new HashSet<string>();
		HashSet<string> handledPath = new HashSet<string>();

		IEnumerable<Func<DirectoryInfo, bool>> checkers = new Func<DirectoryInfo, bool>[]
			{
				HasCSProj,
				HasSln,
				HasPackageJson
			};

		public void Start()
		{
			foreach (var path in AppContext.SelectedFilePathList)
			{
				solvingDirs.Enqueue(path);
			}
			SolvePaths();
			OpenByVSC();
		}

		private void OpenByVSC()
		{
			foreach (var path in dirsToOpen)
			{
				using (var p = new Process())
				{
					p.StartInfo.FileName = @"C:\Users\Felix.Fei\AppData\Local\Programs\Microsoft VS Code\Code.exe";
					p.StartInfo.Arguments = path;
					p.Start();
				}
			}
		}

		private void SolvePaths()
		{
			while (solvingDirs.Count > 0)
				SolvePath(solvingDirs.Dequeue());
		}

		private void SolvePath(string path)
		{
			var dir = new DirectoryInfo(path);

			var parent = (dir.Parent != null && handledPath.Add(dir.Parent.FullName)) ?
				dir.Parent.FullName :
				"";

			if (!dir.Exists)
			{
				if (parent != "")
					solvingDirs.Enqueue(parent);
				return;
			}

			if (!ShouldOpen(dir))
			{
				if (parent != "")
					solvingDirs.Enqueue(parent);
				return;
			}

			dirsToOpen.Add(dir.FullName);
		}

		private bool ShouldOpen(DirectoryInfo dir)
		{
			foreach (var checker in checkers)
				if (checker(dir))
					return true;
			return false;
		}

		static bool HasCSProj(DirectoryInfo info) => HasExtension(info, "csproj");
		static bool HasSln(DirectoryInfo info) => HasExtension(info, "sln");
		static bool HasPackageJson(DirectoryInfo info) => HasFile(info, "package.json");

		static bool HasExtension(DirectoryInfo info, string extension) => info.GetFiles("*." + extension).Any();

		static bool HasFile(DirectoryInfo info, string fileName)
			=> File.Exists(Path.Combine(info.FullName, fileName));
	}
}
