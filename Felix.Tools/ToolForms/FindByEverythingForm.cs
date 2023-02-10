using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Felix.Tools.ToolForms
{
	public partial class FindByEverythingForm : Form
	{
		public FindByEverythingForm()
		{
			InitializeComponent();
			this.Shown += FindByEverythingForm_Shown;
		}

		private async void FindByEverythingForm_Shown(object? sender, EventArgs e)
		{
			this.Hide();
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = @"C:\Program Files\Everything\Everything.exe";
			psi.Arguments = $"-s {AppContext.SelectedText}";
			using (var p = new Process())
			{
				p.StartInfo = psi;
				p.Start();
				await Task.Delay(TimeSpan.FromSeconds(10));
				using (var p2 = new Process())
				{
					p2.StartInfo.FileName = @"C:\Program Files\Everything\Everything.exe";
					p2.StartInfo.Arguments = "-close";
					p2.Start();
				}
			}
			this.Close();
		}
	}
}
