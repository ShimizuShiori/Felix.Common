using Felix.Tools.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Felix.Tools
{
	public partial class TestForm : Form
	{
		public TestForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var builder = new SqlConnectionStringBuilder();
			builder.DataSource = ".";
			builder.InitialCatalog = "Odyssey";
			builder.IntegratedSecurity = true;
			using (var conn = new SqlConnection(builder.ConnectionString))
			{
				conn.Open();
				var cmd = conn.CreateCommand();
				cmd.CommandText = "sp_help GlbCompany";
				SqlDataAdapter adapter = new SqlDataAdapter();
				adapter.SelectCommand = cmd;
				using (var set = new DataSet())
				{
					adapter.Fill(set);
					TableInfoForm.Show(set);
				}
			}
		}
	}
}
