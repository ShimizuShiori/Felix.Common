using Felix.Tools.Tools;
using System.Diagnostics;

namespace Felix.Tools.Startups
{
    class DevopsAHK : IStartup
    {
        Process p;
        public void Dispose()
        {
            p.Kill();
            p.Dispose();
        }

        public void Start()
        {
            var tool = new Mapping.ExternalTool()
            {
                Category = "AKH",
                Exec = "C:\\AHKs\\Devops.ahk",
                Name = "Devops"
            };
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
            p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
    }
}
