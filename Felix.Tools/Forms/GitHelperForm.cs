using Felix.Tools.Attributes;
using Felix.Tools.Forms;
using Felix.Tools.Tools;
using System.Diagnostics;

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
		}
	}

	public partial class GitHelperForm : Form, IUiMessageListener
	{
		readonly IDisposable listener;
		readonly string gitRepoPath;

		public GitHelperForm(string gitRootPath = "")
		{
			this.gitRepoPath = gitRootPath;
			InitializeComponent();
			listener = AppContext.RegisterUiMessageListener(this);
			this.Disposed += TestForm_Disposed;
		}

		void TestForm_Disposed(object? sender, EventArgs e)
		{
			listener.Dispose();
		}

		public void OnMessage(object message)
		{
			if (message is GitOutputMessage gom)
			{
				this.textBox1.AppendText(gom.Message);
				this.textBox1.AppendText(Environment.NewLine);
			}
			else if (message is GitInputMessage gim)
			{
				this.textBox1.AppendText(">> git ");
				this.textBox1.AppendText(gim.Command);
				this.textBox1.AppendText(Environment.NewLine);
			}
		}

		private void TestForm_Load(object sender, EventArgs e)
		{

		}

		void RunCommand(string command)
		{
			ThreadPool.QueueUserWorkItem(state =>
			{
				AppContext.PublishUiMessage(new GitInputMessage(command));
				using (var p = new Process())
				{
					p.StartInfo.FileName = "git.exe";
					p.StartInfo.Arguments = command;
					p.StartInfo.WorkingDirectory = gitRepoPath;
					p.StartInfo.UseShellExecute = false;
					p.StartInfo.RedirectStandardInput = true;
					p.StartInfo.RedirectStandardOutput = true;

					p.Start();
					while (true)
					{
						string? str = p.StandardOutput.ReadLine();
						if (str == null)
							break;
						AppContext.PublishUiMessage(new GitOutputMessage(str));
					}
				}
			});
		}

		private void BranchListMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("branch");
		}

		private void BranchToMenuItem_Click(object sender, EventArgs e)
		{
			string branchName = InputBox.Show("Branch Name");
			if (string.IsNullOrEmpty(branchName))
				return;

			RunCommand($"checkout {branchName}");
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string newBranchName = InputBox.Show("New Branch Name");
			string fromBranchName = InputBox.Show("From Branch Name", "master");
			RunCommand($"checkout -b {newBranchName} {fromBranchName}");
		}

		private void statuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("status");
		}

		private void clearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.textBox1.Clear();
		}

		private void pushToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("push");
		}

		private void pullToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("pull");
		}

		#region Inner Classes

		record GitOutputMessage(string Message);

		record GitInputMessage(string Command);

		#endregion
	}
}
