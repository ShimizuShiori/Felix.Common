using Felix.Tools.Attributes;
using Felix.Tools.SharedInfos;
using Felix.Tools.Tools;

namespace Felix.Tools
{
	[Tool("GitHelper", "Repo")]
	public class OpenGitHelperForm : ITool
	{
		public void Start()
		{
			GitHelperForm f;
			if (AppContext.SelectedFilePathList.Length > 0)
			{
				bool shown = false;
				foreach (var path in AppContext.SelectedFilePathList)
				{
					if (!Directory.Exists(Path.Combine(path, ".git")))
						continue;
					f = new GitHelperForm(path);
					f.Show();
					shown = true;
				}
				if (shown)
					return;
			}

			if (Directory.Exists(Path.Combine(AppContext.SelectedText, ".git")))
			{
				f = new GitHelperForm(AppContext.SelectedText);
				f.Show();
				return;
			}

			var selected = ChooesForm<(string, string[])>.Show(
				TFSInfos.GetProjects());

			if (selected == "")
				return;

			var selected2 = ChooesForm<string>.Show(TFSInfos.GetRepos(selected));
			if (selected2 == "")
				return;

			f = new GitHelperForm($@"C:\git\wtg\{selected}\{selected2}");
			f.Show();

		}
	}
}
