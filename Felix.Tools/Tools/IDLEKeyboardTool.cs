using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.Forms;
using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[Tool("Keyboard", "IDLE")]
	class IDLEKeyboardTool : ITool, IUiMessageListener
	{
		const string words = "QWERTYUIOPLKJHGFDSAZXCVBNM";

		public IDLEKeyboardTool()
		{
		}

		public void Start()
		{
			ThreadPool.QueueUserWorkItem(state =>
			{
				using (var p = new Process())
				{
					var listener = AppContext.RegisterUiMessageListener(this);
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
									return;
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
									return;
							}
						}
					}
					finally
					{
						p.Kill();
						p.Dispose(); 
						listener.Dispose();
					}
				}
			});
		}

		bool SendKey(Process p, string key)
		{
			if (!CanRun(p))
				return false;

			//SendKeys.Send(key);
			AppContext.PublishUiMessage(new SendKeyMessage(p, key));
			return true;
		}

		bool CanRun(Process p)
		{
			return p.MainWindowHandle == User32.GetForegroundWindow() && !p.HasExited;
		}

		public void OnMessage(object message)
		{
			if (!(message is SendKeyMessage skm))
				return;

			if (!CanRun(skm.Process))
				return;

			SendKeys.Send(skm.Key);
		}

		record SendKeyMessage(Process Process, string Key);
	}
}
