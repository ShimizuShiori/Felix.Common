namespace Felix.Common
{
    public class BackgroundTaskRunnerBuilder
    {
        readonly List<IBackgroundTask> tasks = new List<IBackgroundTask>();
        public BackgroundTaskRunnerBuilder AddTask(IBackgroundTask task)
        {
            tasks.Add(task);
            return this;
        }

        public IBackgroundTaskRunner Build()
        {
            return new BackgroundTaskRunner(tasks);
        }
    }
}
