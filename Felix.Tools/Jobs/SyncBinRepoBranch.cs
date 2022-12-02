using Felix.Common;

namespace Felix.Tools.Jobs
{
	class SyncBinRepoBranch : IJob
	{
		const string WatchedRepo = @"C:\git\wtg\CargoWise\Dev";
		const string BinRepo = @"C:\BinRepo";
		public async Task OnStart(CancellationToken cancellationToken)
		{
			var runnerForWatched = new GitRunner(WatchedRepo);
			var runnerForBinRepo = new GitRunner(BinRepo);
			while (true)
			{
				await Task.Delay(TimeSpan.FromSeconds(5));
				if (cancellationToken.IsCancellationRequested)
					break;

				var watchedBranch = runnerForWatched.GetCurrentBranch();
				var binRepoBranch = runnerForBinRepo.GetCurrentBranch();
				if (watchedBranch == binRepoBranch)
					continue;

				runnerForBinRepo.CreateBranch(watchedBranch);
				runnerForBinRepo.SwitchBranch(watchedBranch);
			}
		}
	}
}
