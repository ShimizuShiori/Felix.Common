//using System.Diagnostics;

//namespace Felix.Tools.Jobs
//{
//    class ProcessKiller : IJob
//    {
//        static readonly string[] list = new string[]
//        {
//            "CrikeyMonitor",
//        };
//        public Task OnStart(CancellationToken cancellationToken)
//        {
//            var logger = AppContext.CreateLogger(typeof(ProcessKiller));
//            return Task.Factory.StartNew(async () =>
//            {
//                while (!cancellationToken.IsCancellationRequested)
//                {
//                    foreach (var process in Process.GetProcesses())
//                    {
//                        if (list.Contains(process.ProcessName))
//                        {
//                            logger.Append($"{process.ProcessName} will be killed");
//                            process.Kill();
//                            logger.Append($"{process.ProcessName} has been killed");
//                        }
//                    }
//                    await Task.Delay(TimeSpan.FromMinutes(1));
//                }
//            }, TaskCreationOptions.LongRunning);
//        }
//    }
//}
