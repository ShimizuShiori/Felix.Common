using Felix.Common.Collections;
using Felix.Tools.Messages;
using System.Text;

namespace Felix.Tools.Forms
{
	public partial class LoggerForm : Form, IUiMessageListener
	{
		IDisposable listener;
		readonly StringBuilder sb = new StringBuilder();
		bool stopped = false;

		public LoggerForm()
		{
			this.DoubleBuffered = true;
			InitializeComponent();
			this.listener = AppContext.RegisterUiMessageListener(this);
			this.Disposed += LoggerForm_Disposed;
		}

		private void LoggerForm_Disposed(object? sender, EventArgs e)
		{
			listener.Dispose();
		}

		#region Data Driver

		#endregion

		#region Data Operator

		void ClearMenuItem_Click(object sender, EventArgs e)
		{
			this.sb.Clear();
		}

		public void OnMessage(object message)
		{
			if (message is LogMessage lm)
			{
				sb.AppendLine($"{DateTime.Now:HH:mm:ss} - [{lm.Sender.GetType()}] - {lm.Message}");
			}
		}

		#endregion

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (this.stopped)
				return;
			int selectionStart = this.textBox1.SelectionStart;
			int selectionLength = this.textBox1.SelectionLength;
			this.textBox1.Text = sb.ToString();
			this.textBox1.SelectionStart = selectionStart;
			this.textBox1.SelectionLength = selectionLength;
			this.textBox1.ScrollToCaret();
		}

		private void StopMenuItem_Click(object sender, EventArgs e)
		{
			stopped = true;
		}

		private void StartMenuItem_Click(object sender, EventArgs e)
		{
			stopped = false;
		}
	}
}
