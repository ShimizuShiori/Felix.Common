using System.Diagnostics;

namespace Felix.Tools.Tools
{
	class ExternalTool : SyncTool
	{
		readonly string exec;
		readonly string arg;

		public ExternalTool(string exec, string arg)
		{
			this.exec = exec;
			this.arg = arg;
		}

		protected override void Start()
		{
			string realExec = exec;
			string realArg = arg;
			foreach (var property in typeof(AppContext).GetProperties())
			{
				object value = property.GetValue(null);

				if (value == null) continue;
				var str = value.ToString();

				realExec = realExec.Replace($"{{{property.Name}}}", str);
				realArg = realArg.Replace($"{{{property.Name}}}", str);
			}
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.UseShellExecute = true;
			psi.FileName = realExec;
			psi.Arguments = realArg;
			using (var p = new Process())
			{
				p.StartInfo = psi;
				p.Start();
			}
		}
	}
}
