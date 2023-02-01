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
				try
				{
					while (CanRun(p))
					{
						for (int i = 0; i < wordCount; i++)
						{
							if (!SendKey(p, "{BACKSPACE}"))
								return Task.CompletedTask;
						}
						for (int i = 0; wordCount > 0 && i < 60; i++)
						{
							if (!CanRun(p))
								break;

							Thread.Sleep(TimeSpan.FromSeconds(1));
						}
						wordCount = AppContext.Random.Next(10, 20);
						for (int i = 0; i < wordCount; i++)
						{
							if (!SendKey(p, words[AppContext.Random.Next(words.Length)].ToString()))
								return Task.CompletedTask;
						}
					}
					return Task.CompletedTask;
				}
				finally
				{
					p.Kill();
					p.Dispose();
				}
			}
		}

		bool SendKey(Process p, string key)
		{
			if (!CanRun(p))
				return false;

			SendKeys.Send(key);
			return true;
		}

		bool CanRun(Process p)
		{
			return p.MainWindowHandle == User32.GetForegroundWindow() && !p.HasExited;
		}
	}
}
