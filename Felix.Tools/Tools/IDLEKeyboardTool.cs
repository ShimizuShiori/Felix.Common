using Felix.Common;
using Felix.Tools.Attributes;
using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[Tool("Keyboard", "IDLE")]
	class IDLEKeyboardTool : ITool
	{
		const string words = "QWERTYUIOPLKJHGFDSAZXCVBNM";
		public Task StartAsync()
		{
			using (var p = new Process())
			{
				p.StartInfo.FileName = "notepad";
				p.Start();
				p.WaitForInputIdle();
				User32.SetForegroundWindow(p.MainWindowHandle);
				int wordCount = 0;
				while (!p.HasExited)
				{
					for (int i = 0; i < wordCount; i++)
					{
						SendKey(p, "{BACKSPACE}");
					}
					for (int i = 0; wordCount > 0 && i < 60; i++)
					{
						if (p.HasExited)
							break;

						Thread.Sleep(TimeSpan.FromSeconds(1));
					}
					wordCount = AppContext.Random.Next(100);
					for (int i = 0; i < wordCount && !p.HasExited; i++)
					{
						SendKey(p, words[AppContext.Random.Next(words.Length)].ToString());
						Thread.Sleep(0);
					}
				}
			}
			return Task.CompletedTask;
		}

		void SendKey(Process p, string key)
		{
			if (p.HasExited)
				return;

			SendKeys.Send(key);
		}
	}
}
