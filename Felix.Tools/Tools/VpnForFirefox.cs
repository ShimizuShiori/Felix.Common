using Felix.Tools.Attributes;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Felix.Tools.Tools
{
	[Tool("Firefox", "VPN")]
	class VpnForFirefox : ITool
	{
		const string path = @"C:\Users\Felix.Fei\AppData\Roaming\Mozilla\Firefox\Profiles\v75srzxh.default-release\prefs.js";
		const string regexText = @"user_pref\(""network\.proxy\.type"", \d\);";
		public void Start()
		{
			var action = ChooesForm<string>.Show("Enable", "Disable");
			if (string.IsNullOrEmpty(action))
				return;

			var content = File.ReadAllText(path);
			content = Regex.Replace(content, regexText, $@"user_pref(""network.proxy.type"", {(action == "Enable" ? 1 : 0)});");
			File.WriteAllText(path, content);


			var ps = Process.GetProcessesByName("firefox");
			try
			{
				foreach (var p in ps)
					if (p != null)
					{
						p.CloseMainWindow();
						p.WaitForExit();
					}
			}
			finally
			{
				foreach (var p in ps)
					if (p != null)
						p.Dispose();
			}

			using (var pf = new Process())
			{
				pf.StartInfo.FileName = @"C:\Program Files\Mozilla Firefox\firefox.exe";
				pf.Start();
			}
		}
	}
}
