using System.Diagnostics;

namespace Felix.Tools.ToolForms
{
	[Tool("Unlocker", "FS")]
	public class UnLockerForm : Form
	{
		public UnLockerForm()
		{
			this.Shown += UnLockerForm_Shown;
		}

		private void UnLockerForm_Shown(object? sender, EventArgs e)
		{
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = @"C:\Program Files (x86)\IObit\IObit Unlocker\IObitUnlocker.exe";
			psi.Arguments = $"/None {AppContext.SelectedText}";
			psi.Verb = "runas";
			using (var p = new Process())
			{
				p.StartInfo = psi;
				p.Start();
			}
			this.Close();
		}
	}
}
