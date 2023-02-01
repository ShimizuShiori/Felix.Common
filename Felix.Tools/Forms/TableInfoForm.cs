using System.Data;

namespace Felix.Tools.Forms
{
	public partial class TableInfoForm : Form
	{
		readonly DataSet? set;
		static readonly string[] Tabs = new string[]
		{
			"Table",
			"Field",
			"Identity",
			"RowGuidColumn",
			"FileGroup",
			"Index",
			"Constraint",
			"Foreign Key"
		};
		public TableInfoForm() : this(null)
		{
		}
		public TableInfoForm(DataSet? set)
		{
			this.set = set;
			InitializeComponent();
			tabControl1.TabPages.Clear();
			if (set == null)
				return;

			for (int i = 0; i < Tabs.Length && i < set.Tables.Count; i++)
			{
				var tabName = Tabs[i];
				var page = new TabPage(tabName);
				var dataGridView = new DataGridView();
				dataGridView.Dock = DockStyle.Fill;
				dataGridView.DataSource = set.Tables[i];
				dataGridView.AllowUserToAddRows = false;
				dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				dataGridView.ReadOnly = true;

				tabControl1.TabPages.Add(page);
				page.Controls.Add(dataGridView);
			}
		}



		public static void Show(DataSet set)
		{
			TableInfoForm tableInfoForm = new TableInfoForm(set);
			tableInfoForm.ShowDialog();
		}
	}
}
