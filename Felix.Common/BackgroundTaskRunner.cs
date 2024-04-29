namespace Felix.Common
{
    public class BackgroundTaskRunner : IBackgroundTaskRunner
    {
        readonly Queue<IBackgroundTask> tasks;
        readonly int taskCount;

        public BackgroundTaskRunner(IEnumerable<IBackgroundTask> tasks)
        {
            this.tasks = new Queue<IBackgroundTask>(tasks);
            taskCount = this.tasks.Count;
        }

        public void Run()
        {
            new Thread(Start)
            {
                IsBackground = true,
                Name = "BackgroundTaskThread"
            }.Start();
        }

        void Start(object? obj)
        {
            while (true)
            {
                RunTasks();
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        void RunTasks()
        {
            for (int i = 0; i < taskCount; i++)
            {
                RunTask();
            }
        }

        void RunTask()
        {
            var t = tasks.Dequeue();
            try
            {
                t.Run();
            }
            catch (Exception)
            {

            }
            finally
            {
                tasks.Enqueue(t);
            }
        }
    }
}
