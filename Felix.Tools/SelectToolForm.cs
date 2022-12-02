using Felix.Common;
using Felix.Tools.Tools;

namespace Felix.Tools
{
	public partial class SelectToolForm : Form
	{
		public SelectToolForm()
		{
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Shown += SelectToolForm_Shown;
		}

		private async void SelectToolForm_Shown(object? sender, EventArgs e)
		{
			this.Hide();
			var infos = AppContext.ToolFactory.GetToolInfosByCategory(AppContext.SelectedCategory);
			var selectedName = ChooesForm<string>.Show("Select Tool",
				  infos.ToMap(x => (x.Attribute.Name, x.Attribute.Name)), string.Empty);

			if (selectedName == string.Empty)
				return;

			var ins = AppContext.ToolFactory.CreateTool(selectedName);
			if (ins == null)
				return;
			if (ins is ITool ts)
			{
				ts.Start();
			}
			else return;
			this.Close();
		}
	}
}
