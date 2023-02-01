namespace Felix.Tools.Tools
{
	abstract class SyncTool : ITool
	{
		public Task StartAsync()
		{
			Start();
			return Task.CompletedTask;
		}

		protected abstract void Start();
	}
}
