//using Felix.Tools.Tools;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Felix.Tools.Jobs
//{
//    class CallIdleWhenMouseStopped : IJob
//    {
//        public Task OnStart(CancellationToken cancellationToken)
//        {
//            return Task.Factory.StartNew(async () =>
//            {
//                var logger = AppContext.CreateLogger(typeof(CallIdleWhenMouseStopped));
//                Point? p = null;
//                while (true)
//                {
//                    try
//                    {
//                        if (p == null)
//                        {
//                            p = System.Windows.Forms.Control.MousePosition;
//                        }
//                        else
//                        {
//                            var p2 = System.Windows.Forms.Control.MousePosition;
//                            if (p2.X == p.Value.X && p2.Y == p.Value.Y)
//                            {
//                                logger.Append("Mouse didn't move");
//                                bool isRunning = false;
//                                lock (AppContext.Items)
//                                {
//                                    if (AppContext.Items.TryGetValue("IDLERUNNING", out var v))
//                                    {
//                                        logger.Append($"IDLERUNNING = {v}");
//                                        isRunning = (bool)v;
//                                    }
//                                }
//                                logger.Append($"check isRunning, it is {isRunning}");
//                                if (!isRunning)
//                                {
//                                    IDLEKeyboardTool t = new IDLEKeyboardTool();
//                                    t.Start();
//                                    logger.Append("IDLEKeyboardTool Started");
//                                }
//                            }
//                            else
//                            {
//                                p = p2;
//                            }
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        logger.Append($"Exception: {ex}");
//                    }
//                    finally
//                    {
//                        logger.Append($"Mouse @ ({p.Value.X}, {p.Value.Y})");
//                        await Task.Delay(TimeSpan.FromMinutes(2));
//                    }
//                }
//            }, TaskCreationOptions.LongRunning);
//        }
//    }
//}
