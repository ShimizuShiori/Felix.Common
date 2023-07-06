using Felix.Tools.Attributes;
using System.Diagnostics;

namespace Felix.Tools.Tools.FsTools
{
	[FileTool("Unlock", "FS")]
	class Unlocker : ITool
	{
		public void Start()
		{
			foreach (var file in AppContext.SelectedFilePathList)
			{
				var psi = new ProcessStartInfo(@"C:\Program Files (x86)\IObit\IObit Unlocker\IObitUnlocker.exe");
				psi.Arguments = $"/None {file}";
				psi.UseShellExecute = true;
				using (var p = Process.Start(psi))
				{
					
				}
			}
		}
	}
}
