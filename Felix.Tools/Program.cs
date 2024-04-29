using Felix.Tools.Jobs;
using System.Diagnostics;

namespace Felix.Tools
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IsRunning())
            {
                MessageBox.Show("Felix.Tools.exe is running");
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            CancellationTokenSource cts = new CancellationTokenSource();
            JobStarter.Start(cts.Token);
            try
            {
                Application.Run(new StartForm());
            }
            catch (Exception ex)
            {
                OutputBox.Show(ex.ToString());
            }
            finally
            {
                cts.Cancel();
                while (true)
                {
                    if (AppContext.JobCounter.IsEmpty())
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        static bool IsRunning()
        {
            var ps = Process.GetProcessesByName("Felix.Tools.exe");
            return ps.Length > 0;
        }
    }
}