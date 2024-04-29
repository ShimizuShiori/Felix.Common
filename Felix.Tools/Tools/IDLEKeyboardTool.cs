using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.Forms;
using Felix.Tools.Jobs;
using Felix.Tools.Logger;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Felix.Tools.Tools
{
    [Tool("Keyboard", "IDLE")]
    class IDLEKeyboardTool : ITool, IUiMessageListener
    {
        const string words = "QWERTYUIOPLKJHGFDSAZXCVBNM";
        static readonly ILogger logger = AppContext.CreateLogger(typeof(IDLEKeyboardTool));
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
                    logger.Append($"Start notepad");
                    p.Start();

                    lock (AppContext.Items)
                    {
                        AppContext.Items["IDLERUNNING"] = true;
                    }
                    p.WaitForInputIdle();
                    logger.Append($"WaitForInputIdle() End");
                    Thread.Sleep(1000);
                    User32.SetForegroundWindow(p.MainWindowHandle);
                    int wordCount = 5;
                    try
                    {
                        while (CanRun(p))
                        {
                            for (int i = 0; i < wordCount; i++)
                            {
                                if (!SendKey(p, words[AppContext.Random.Next(words.Length)].ToString()))
                                    return;
                            }
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
                        }
                        logger.Append("Can Not Run, Reason:");
                        logger.Append($"    MainWindowHandle = {(int)p.MainWindowHandle}");
                        logger.Append($"    GetForegroundWindow = {User32.GetForegroundWindow()}");
                        logger.Append($"    HasExited = {p.HasExited}");
                    }
                    finally
                    {
                        p.Kill();
                        lock (AppContext.Items)
                        {
                            AppContext.Items["IDLERUNNING"] = false;
                        }
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
            var sb = new StringBuilder();
            User32.GetWindowText((int)User32.GetForegroundWindow(), sb, 100);
            var s = sb.ToString();
            logger.Append($"ForegroundWindow.Title = {s}");
            return s.Contains("notepad", StringComparison.OrdinalIgnoreCase);
            //return p.MainWindowHandle == User32.GetForegroundWindow() && !p.HasExited;
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
