using Felix.Tools.Attributes;
using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[TextTool("Everything", "Search")]
	class SearchInEverything : ITool
	{
		public async Task StartAsync()
		{
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = @"C:\Program Files\Everything\Everything.exe";
			psi.Arguments = $"-s {AppContext.SelectedText}";
			using (var p = new Process())
			{
				p.StartInfo = psi;
				p.Start();
				await Task.Delay(TimeSpan.FromMinutes(1));
				using (var p2 = new Process())
				{
					p2.StartInfo.FileName = @"C:\Program Files\Everything\Everything.exe";
					p2.StartInfo.Arguments = "-close";
					p2.Start();
				}
			}
		}
	}
}
