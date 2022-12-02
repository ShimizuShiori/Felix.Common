namespace Felix.Tools.Jobs
{
	interface IJob
	{
		Task OnStart(CancellationToken cancellationToken);
	}
}
