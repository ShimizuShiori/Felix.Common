namespace Felix.Tools.Jobs
{
	static class JobStarter
	{
		public static void Start(CancellationToken cancellationToken)
		{
			var jobs = typeof(JobStarter)
				.Assembly
				.GetTypes()
				.Where(x => typeof(IJob).IsAssignableFrom(x))
				.Where(x => x.IsClass && !x.IsAbstract)
				.Select(x => Activator.CreateInstance(x))
				.Where(x => x != null)
				.Cast<IJob>();

			foreach (var job in jobs)
			{
				job.OnStart(cancellationToken)
					.ContinueWith(x =>
					{
						AppContext.JobCounter.Decrement();
					});
				AppContext.JobCounter.Increment();
			}
		}
	}
}
