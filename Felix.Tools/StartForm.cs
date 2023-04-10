using Felix.Common;
using Felix.Tools.Forms;
using Felix.Tools.Messages;
using System.ComponentModel;

namespace Felix.Tools
{
	public partial class StartForm : Form, IUiMessageListener
	{
		readonly IDisposable listener;

		public StartForm()
		{
			InitializeComponent();

			bool r = User32.RegisterHotKey(Handle, 1, KeyModifiers.Ctrl, Common.Keys.F1);
			listener = AppContext.RegisterUiMessageListener(this);
			this.Disposed += StartForm_Disposed;
		}

		void StartForm_Disposed(object? sender, EventArgs e)
		{
			listener.Dispose();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			User32.UnregisterHotKey(Handle, 1001);
			base.OnClosing(e);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case 0x0312:
					switch (m.WParam.ToInt32())
					{
						case 1:
							SendKeys.SendWait("^c");
							AppContext.CopiedInfo = CopiedInfoFactory.Create();
							StartWorkWithSelectedCopiedInfo();
							break;
						default:
							break;
					}
					break;
				default:
					break;
			}
			base.WndProc(ref m);
		}

		private void StartWorkWithSelectedCopiedInfo()
		{
			using (var form = new CategoryForm())
			{
				form.ShowDialog();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public void OnMessage(object message)
		{
			if (message is ShowOutputMessage som)
			{
				OutputBox.Show(som.Message, modal: false);
			}
		}
	}
}