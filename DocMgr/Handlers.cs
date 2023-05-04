using Felix.Common;
using System.Diagnostics;

namespace DocMgr
{
	static class Handlers
	{
		const string DocRootPath = @"C:\Users\Felix.Fei\Documents\Docs\Glow";

		public static void List()
		{
			foreach (var dir in Directory.EnumerateDirectories(DocRootPath))
			{
				Console.WriteLine(Path.GetFileName(dir));
			}
		}

		public static void Open(string name)
		{
			var path = Path.Combine(DocRootPath, name);
			if (!Directory.Exists(path))
				return;

			using (var p = new Process())
			{
				p.StartInfo.FileName = @"C:\Users\Felix.Fei\AppData\Local\Programs\Microsoft VS Code\Code.exe";
				p.StartInfo.ArgumentList.Add(path);
				p.StartInfo.Verb = "runasuser";
				p.Start();
			}
			//ProcessHelper.Start(@"C: \Users\Felix.Fei\AppData\Local\Programs\Microsoft VS Code\Code.exe", $"\"{path}\"");
		}
	}
}
