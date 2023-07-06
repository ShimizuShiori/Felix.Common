using Felix.Tools.Attributes;
using System.Diagnostics;

namespace Felix.Tools.Tools.FsTools
{
	[FileTool("Delete", "FS")]
	class Deleter : ITool
	{
		public void Start()
		{
			foreach (var file in AppContext.SelectedFilePathList)
			{
				var psi = new ProcessStartInfo(@"C:\Program Files (x86)\IObit\IObit Unlocker\IObitUnlocker.exe");
				psi.Arguments = $"/Delete {file}";
				psi.UseShellExecute = true;
				using (var p = Process.Start(psi))
				{

				}
			}
		}
	}
}
