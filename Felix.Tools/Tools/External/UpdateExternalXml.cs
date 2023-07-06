using Felix.Tools.Attributes;
using System.Diagnostics;

namespace Felix.Tools.Tools.External
{
	[Tool("Edit", "External")]
	class UpdateExternalXml : ITool
	{
		public void Start()
		{
			string path = Resources.GetResourcePath(Resources.ExternalXml);
			var psi = new ProcessStartInfo("code");
			psi.UseShellExecute = true;
			psi.Arguments = path;
			using (var p = Process.Start(psi)) { }
		}
	}
}
