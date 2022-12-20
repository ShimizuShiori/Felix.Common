using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[Tool("Open", "Local CW1")]
	class OpenCW1 : ITool
	{
		public Task StartAsync()
		{
			using (var p = new Process())
			{
				p.StartInfo.FileName = @"C:\BinRepo\CargoWise\Dev\CargoWiseOneAnyCpu.exe";
				p.Start();
			}
			return Task.CompletedTask;
		}
	}
}
