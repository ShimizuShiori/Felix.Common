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
                var existingProcesses = GetNotepadProcesses();
                logger.Append($"Existing notepad processes: {existingProcesses.Count()}");
                using (var p = new Process())
                {
                    var listener = AppContext.RegisterUiMessageListener(this);
                    p.StartInfo.FileName = "notepad";
                    logger.Append($@"Start {p.StartInfo.FileName}");
                    p.Start();

                    lock (AppContext.Items)
                    {
                        AppContext.Items["IDLERUNNING"] = true;
                    }
                    //p.WaitForInputIdle();
                    //logger.Append($"WaitForInputIdle() End");

                    Process np = null;
                    {
                        int times = 10;
                        while (times >= 0)
                        {
                            logger.Append($"Trying to find the opened notepad.exe, {times}");
                            Thread.Sleep(1000);
                            times--;

                            // get latest notepad process
                            var newProcesses = GetNotepadProcesses().Except(existingProcesses).Where(x => x.MainWindowHandle != IntPtr.Zero);
                            logger.Append($"New notepad processes: {newProcesses.Count()}");
                            foreach (var x in newProcesses)
                            {
                                logger.Append($"+ MainWindowHandle = {(int)x.MainWindowHandle}; Name = {x.ProcessName}");
                            }

                            if (newProcesses.Count() == 0)
                            {
                                logger.Append("No new notepad process found");
                                return;
                            }
                            np = newProcesses.First();
                            break;
                        }
                    }
                    if (np == null)
                    {
                        logger.Append("IDLE Keyboard Tool Exit: Can not find the notepad process");
                        return;
                    }

                    User32.SetForegroundWindow(np.MainWindowHandle);
                    int wordCount = 5;
                    try
                    {
                        while (CanRun(np))
                        {
                            for (int i = 0; i < wordCount; i++)
                            {
                                if (!SendKey(np, words[AppContext.Random.Next(words.Length)].ToString()))
                                    return;
                            }
                            for (int i = 0; i < wordCount; i++)
                            {
                                if (!SendKey(np, "{BACKSPACE}"))
                                    return;
                            }
                            for (int i = 0; wordCount > 0 && i < 10; i++)
                            {
                                if (!CanRun(np))
                                    break;

                                Thread.Sleep(TimeSpan.FromSeconds(1));
                            }
                        }
                        logger.Append("Can Not Run, Reason:");
                        logger.Append($"    MainWindowHandle = {(int)np.MainWindowHandle}");
                        logger.Append($"    GetForegroundWindow = {User32.GetForegroundWindow()}");
                        logger.Append($"    HasExited = {np.HasExited}");
                    }
                    finally
                    {
                        np.Kill();
                        lock (AppContext.Items)
                        {
                            AppContext.Items["IDLERUNNING"] = false;
                        }
                        np.Dispose();
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
            //logger.Append($"ForegroundWindow.Title = {s}");
            //return s.Contains("notepad", StringComparison.OrdinalIgnoreCase);
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

        static IEnumerable<Process> GetNotepadProcesses()
        {
            return Process.GetProcessesByName("notepad");
        }
    }
}
