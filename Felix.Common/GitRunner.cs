using System.Diagnostics;

namespace Felix.Common
{
	public class GitRunner
	{
		readonly string workingDirectory;
		public GitRunner(string workingDirectory)
		{
			this.workingDirectory = workingDirectory;
		}

		public string Run(string command)
		{
			using (var p = new Process())
			{
				p.StartInfo.FileName = "git.exe";
				p.StartInfo.Arguments = command;
				p.StartInfo.CreateNoWindow = true;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.WorkingDirectory = workingDirectory;
				p.Start();
				p.WaitForExit();
				return p.StandardOutput.ReadToEnd();
			}
		}
	}

	public static class GitRunnerExt
	{
		public static string GetCurrentBranch(this GitRunner runner)
		{
			return runner.Run("status")
				.Pickup(@"On branch (?<branch>.*)", "branch");
		}

		public static void SwitchBranch(this GitRunner runner, string branch)
		{
			runner.Run($"checkout {branch}");
		}

		public static void CreateWorktreeForCurrentBranch(this GitRunner runner, Func<string, string> path)
		{
			var branch = runner.GetCurrentBranch();
			runner.SwitchBranch("master");
			runner.Run($"worktree add {path(branch)} {branch}");
		}

		public static void RemoveWorktree(this GitRunner runner, string path)
		{
			runner.Run($"worktree remove {path}");
		}
	}
}
