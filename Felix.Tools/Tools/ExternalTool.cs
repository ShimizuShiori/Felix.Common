using System.Diagnostics;

namespace Felix.Tools.Tools
{
	class ExternalTool : ITool
	{
		readonly Felix.Tools.Mapping.ExternalTool tool;

		public ExternalTool(Felix.Tools.Mapping.ExternalTool tool)
		{
			this.tool = tool;
		}

		public void Start()
		{
			string realExec = tool.Exec;
			string realArg = tool.Arg;
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
			if (!string.IsNullOrEmpty(tool.WorkingDirectory))
				psi.WorkingDirectory = tool.WorkingDirectory;
			using (var p = new Process())
			{
				p.StartInfo = psi;
				p.Start();
			}
		}
	}
}
