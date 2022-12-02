using Felix.Common;

namespace Felix.Tools.Tools
{
	[Tool("NewWorktree", "Repo")]
	class CreateWorktree : ITool
	{
		public void Start()
		{
			string folderName = Path.GetDirectoryName(AppContext.SelectedText) ?? string.Empty;
			if (string.IsNullOrEmpty(folderName))
				return;

			string branchName = InputBox.Show("BranchName");
			if (string.IsNullOrEmpty(branchName))
				return;

			branchName = branchName
				.Replace("/", "_");

			var runner = new GitRunner(AppContext.SelectedText);
			MessageBox.Show(runner.Run($"worktree add {folderName}_{branchName} {branchName}"));
		}
	}
}
