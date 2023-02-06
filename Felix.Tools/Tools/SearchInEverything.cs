using Felix.Tools.Attributes;
using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[TextTool("Everything", "Search")]
	class SearchInEverything : ITool
	{
		public void Start()
		{
			// todo: use thread
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = @"C:\Program Files\Everything\Everything.exe";
			psi.Arguments = $"-s {AppContext.SelectedText}";
			using (var p = new Process())
			{
				p.StartInfo = psi;
				p.Start();
				Thread.Sleep(TimeSpan.FromMinutes(1));
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
