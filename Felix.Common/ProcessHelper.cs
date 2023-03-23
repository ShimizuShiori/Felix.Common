using System.Diagnostics;

namespace Felix.Common
{
	public static class ProcessHelper
	{
		static Process StartCore(string execFilePath, string arguments = "")
		{
			var p = new Process();
			p.StartInfo.FileName = execFilePath;
			p.StartInfo.Arguments = arguments;
			p.Start();
			return p;
		}
		public static void Start(string execFilePath, string arguments = "")
		{
			using (var p = StartCore(execFilePath, arguments)) { }
		}

		public static void StartAndWaitForInputIdle(string execFilePath, string arguments = "")
		{
			using (var p = StartCore(execFilePath, arguments))
			{
				p.WaitForInputIdle();
			}
		}
	}
}
