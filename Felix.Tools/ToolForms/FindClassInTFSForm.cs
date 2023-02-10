using Felix.Common;
using System.Diagnostics;

namespace Felix.Tools.ToolForms
{
	//[Tool("Find In TFS", "Search")]
	public partial class FindClassInTFSForm : Form
	{
		public FindClassInTFSForm()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			var repos = new string[] { "CargoWise" };
			var btn1 = new Button();
			btn1.Text = "All";
			btn1.Width = 300;
			btn1.Height = 300;
			this.flowLayoutPanel1.Controls.Add(btn1);
			btn1.Click += Btn_Click;

			foreach (var repo in repos)
			{
				var btn2 = new Button();
				btn2.Text = repo;
				btn2.Width = 300;
				btn2.Height = 300;
				this.flowLayoutPanel1.Controls.Add(btn2);
				btn2.Click += Btn_Click;
			}
			this.AutoSize = true;
		}

		private void Btn_Click(object? sender, EventArgs e)
		{
			if (sender == null)
				return;

			var btn = (Button)sender;
			var text = btn.Text;

			var sText = $"\"{AppContext.SelectedText}\""
				.Replace("\"", "%22")
				.Replace(" ", "%20");

			if (text == "All")
			{
				UrlHelper.Open($"https://devops.wisetechglobal.com/wtg/_search?text={sText}&type=code");
			}
			else
			{
				UrlHelper.Open($"https://devops.wisetechglobal.com/wtg/{btn.Text}/_search?text={sText}&type=code");
			}
			this.Close();
		}
	}
}
