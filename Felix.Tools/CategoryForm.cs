using Felix.Common;
using Felix.Tools.ToolFactories;

namespace Felix.Tools
{
	public partial class CategoryForm : Form
	{
		readonly IToolFactory factory = new ToolFactory();
		public CategoryForm()
		{
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Shown += CategoryForm_Shown;
		}

		private void CategoryForm_Shown(object? sender, EventArgs e)
		{
			this.Hide();
			string selectedCategory = ChooesForm<string>.Show("Select a category",
				AppContext.ToolFactory.GetCategories().ToMap(x => (x, x)), string.Empty);
			if (selectedCategory == string.Empty)
				return;
			AppContext.SelectedCategory = selectedCategory;
			using (var f = new SelectToolForm())
			{
				f.ShowDialog();
			}
			this.Close();
		}

		private void DrawButton(int rowIndex, int colIndex, IEnumerable<string> categories, int v)
		{
			var btn = new Button();
			btn.Width = 300;
			btn.Height = 300;
			btn.Left = colIndex * 300;
			btn.Top = rowIndex * 300;
			btn.Text = categories.ElementAt(v);
			this.Controls.Add(btn);

			btn.Click += (sender, e) =>
			{
				if (sender == null)
					return;
				var btn = (Button)sender;
				AppContext.SelectedCategory = btn.Text;
				using (var f = new SelectToolForm())
				{
					this.Hide();
					f.ShowDialog();
					this.Close();
				}
			};
		}
	}
}
