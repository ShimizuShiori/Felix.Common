using System.Diagnostics;

namespace Felix.Common
{
	public static class VSCodeRunner
	{
		public static void OpenFile(string path)
		{
			var psi = new ProcessStartInfo("code");
			psi.Arguments = $"\"{path.Replace("\\", "\\\\")}\"";
			psi.UseShellExecute = true;
			using (var p = Process.Start(psi)) { }
		}
	}
}
