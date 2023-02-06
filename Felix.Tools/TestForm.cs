using Felix.Tools.Forms;
using Felix.Tools.Messages;

namespace Felix.Tools
{
	public partial class TestForm : Form, IUiMessageListener
	{
		IDisposable listener;

		public TestForm()
		{
			InitializeComponent();
			listener = AppContext.RegisterUiMessageListener(this);
			this.Disposed += TestForm_Disposed;
			ThreadPool.QueueUserWorkItem(state =>
			{
				int i = 0;
				while (true)
				{
					Thread.Sleep(1000);
					AppContext.PublishUiMessage(new LogMessage(this, i++.ToString()));
				}
			});
		}

		private void TestForm_Disposed(object? sender, EventArgs e)
		{
			listener.Dispose();
		}

		public void OnMessage(object message)
		{
			label1.Text += "\n" + message.ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var testForm = new LoggerForm();
			testForm.Show();
		}
	}
}
