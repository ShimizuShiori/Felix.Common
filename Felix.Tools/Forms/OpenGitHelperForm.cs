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
			if (AppContext.SelectedFilePathList.Length > 0)
			{
				foreach (var path in AppContext.SelectedFilePathList)
				{
					GitHelperForm f = new GitHelperForm(path);
					f.Show();
				}
			}
			else if (Directory.Exists(AppContext.SelectedText))
			{
				GitHelperForm f = new GitHelperForm(AppContext.SelectedText);
				f.Show();
			}
			else
			{

				var selected = ChooesForm<(string, string[])>.Show(
					TFSInfos.GetProjects());

				if (selected == "")
					return;

				var selected2 = ChooesForm<string>.Show(TFSInfos.GetRepos(selected));
				if (selected2 == "")
					return;

				GitHelperForm f = new GitHelperForm($@"C:\git\wtg\{selected}\{selected2}");
				f.Show();
			}
		}
	}
}
