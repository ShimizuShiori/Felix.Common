using Felix.Tools.Forms;

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
				while (true)
				{
					Thread.Sleep(1000);
					AppContext.PublishUiMessage("abc");
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
			TestForm testForm = new TestForm();
			testForm.Show();
		}
	}
}
