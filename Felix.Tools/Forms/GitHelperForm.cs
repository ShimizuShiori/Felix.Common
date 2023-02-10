using Felix.Tools.Forms;
using System.Diagnostics;

namespace Felix.Tools
{
	public partial class GitHelperForm : Form, IUiMessageListener
	{
		readonly IDisposable listener;
		readonly string gitRepoPath;
		readonly Guid id = Guid.NewGuid();

		public GitHelperForm(string gitRootPath = "")
		{
			this.gitRepoPath = gitRootPath;
			InitializeComponent();
			listener = AppContext.RegisterUiMessageListener(this);
			this.Disposed += TestForm_Disposed;
			this.statusStrip1.Items[0].Text = this.gitRepoPath;
			this.Text += $" @ {gitRepoPath}";
			this.textBox1.Select(3, 0);
		}

		void TestForm_Disposed(object? sender, EventArgs e)
		{
			listener.Dispose();
		}

		public void OnMessage(object message)
		{
			if (message is GitOutputMessage gom && gom.FormId == id)
			{
				this.textBox1.AppendText(gom.Message);
				this.textBox1.AppendText(Environment.NewLine);
			}
			else if (message is GitInputMessage gim && gim.FormId == id)
			{
				this.textBox1.AppendText("git ");
				this.textBox1.AppendText(gim.Command);
				this.textBox1.AppendText(Environment.NewLine);
			}
			else if (message is GitErrorStartMessage gsm && gsm.FormId == id)
			{
				this.textBox1.AppendText("======= ERROR ======= ");
				this.textBox1.AppendText(Environment.NewLine);
			}
			else if (message is GitCommandEndMessage gcem && gcem.formId == id)
			{
				this.textBox1.AppendText(Environment.NewLine);
				this.textBox1.AppendText(">> ");
			}
		}

		private void TestForm_Load(object sender, EventArgs e)
		{

		}

		void RunCommand(string command)
		{
			ThreadPool.QueueUserWorkItem(state =>
			{
				AppContext.PublishUiMessage(new GitInputMessage(id, command));
				using (var p = new Process())
				{
					p.StartInfo.FileName = "git.exe";
					p.StartInfo.Arguments = command;
					p.StartInfo.WorkingDirectory = gitRepoPath;
					p.StartInfo.UseShellExecute = false;
					p.StartInfo.RedirectStandardInput = true;
					p.StartInfo.RedirectStandardOutput = true;
					p.StartInfo.RedirectStandardError = true;
					p.StartInfo.CreateNoWindow = true;

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
									AppContext.PublishUiMessage(new GitErrorStartMessage(id));
								AppContext.PublishUiMessage(new GitInputMessage(id, err));
							}
							break;
						}
						AppContext.PublishUiMessage(new GitOutputMessage(id, str));
					}
					AppContext.PublishUiMessage(new GitCommandEndMessage(id));
				}
			});
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
			string branchName = InputBox.Show("Branch Name");
			if (string.IsNullOrEmpty(branchName))
				return;
			RunCommand($"push -u origin {branchName}:{branchName}");
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

		private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fromBranch = InputBox.Show("From Branch Name");
			if (string.IsNullOrEmpty(fromBranch))
				return;
			string opt = ChooesForm<string>.Show("", "--no-ff", "--squash");
			if (string.IsNullOrEmpty(opt))
				return;

			RunCommand($"merge {opt} {fromBranch}");
		}

		private void raseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fromBranch = InputBox.Show("From Branch Name");
			if (string.IsNullOrEmpty(fromBranch))
				return;
			RunCommand($"rebase {fromBranch}");
		}

		private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("clean -xfd");
		}

		private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("git restore --staged .");
		}

		private void revertToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("checkout .");
		}

		private void localToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("branch");
		}

		private void remoteToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			RunCommand("branch -r");
		}

		private void fetchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunCommand("fetch");
		}

		#region Inner Classes

		record GitOutputMessage(Guid FormId, string Message);

		record GitInputMessage(Guid FormId, string Command);

		record GitErrorStartMessage(Guid FormId);

		record GitCommandEndMessage(Guid formId);

		#endregion
	}
}
