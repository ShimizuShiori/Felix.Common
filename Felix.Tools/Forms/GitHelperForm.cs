using Felix.Tools.Forms;
using System.Diagnostics;

namespace Felix.Tools
{
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
			this.statusStrip1.Items[0].Text = this.gitRepoPath;
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
			else if (message is GitErrorStartMessage)
			{
				this.textBox1.AppendText("======= ERROR ======= ");
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
					p.StartInfo.RedirectStandardError = true;

					p.Start();
					while (true)
					{
						string? str = p.StandardOutput.ReadLine();
						if (str == null)
						{
							int i = 0;
							while (true)
							{
								string? err = p.StandardError.ReadLine();
								if (err == null)
									break;
								if (i++ == 0)
									AppContext.PublishUiMessage(new GitErrorStartMessage());
								AppContext.PublishUiMessage(new GitInputMessage(err));
							}
							break;
						}
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
			if (string.IsNullOrEmpty(newBranchName))
				return;
			string fromBranchName = InputBox.Show("From Branch Name", "master");
			if (string.IsNullOrEmpty(fromBranchName))
				return;
			RunCommand($"checkout -b {newBranchName} {fromBranchName}");
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

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string branchName = InputBox.Show("Branch Name");
			if (string.IsNullOrEmpty(branchName))
				return;

			RunCommand($"branch -D {branchName}");
		}

		private void statusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("status");
		}

		private void logsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("log");
		}

		private void addAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("add .");
		}

		private void commitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string comment = InputBox.Show("message");
			if (string.IsNullOrEmpty(comment))
				return;
			RunCommand(@$"commit -m ""{comment}""");
		}

		#region Inner Classes

		record GitOutputMessage(string Message);

		record GitInputMessage(string Command);

		record GitErrorStartMessage();

		#endregion
	}
}
