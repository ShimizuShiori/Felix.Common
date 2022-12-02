using Felix.Common;
using System.ComponentModel;

namespace Felix.Tools
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			bool r = User32.RegisterHotKey(Handle, 1, KeyModifiers.Ctrl, Common.Keys.F1);
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
							if (Clipboard.ContainsText())
							{
								StartWorkWithSelectedText(Clipboard.GetText());
							}
							else if (Clipboard.GetFileDropList().Count > 0)
							{
								StartWorkWithSelectedText(Clipboard.GetFileDropList()[0]);
							}
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

		private void StartWorkWithSelectedText(string selectedText)
		{
			AppContext.SelectedText = selectedText.Trim();
			using (var form = new CategoryForm())
			{
				form.ShowDialog();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}