using Felix.Tools.Attributes;
using Felix.Tools.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Felix.Tools.Tools.DbTools
{
	[TextTool("TableInfo", "DB", @"^\S*$")]
	class ShowTableInfo : DbTool
	{
		protected override Task DoSomethingForDb(IDbConnection dbConnection)
		{
			string tableName = AppContext.SelectedText;


			using (var cmd = dbConnection.CreateCommand())
			{
				cmd.CommandText = $"sp_help {tableName}";
				SqlDataAdapter adapter = new SqlDataAdapter();
				adapter.SelectCommand = (SqlCommand)cmd;
				using (var set = new DataSet())
				{
					adapter.Fill(set);
					TableInfoForm.Show(set);
				}
			}

			return Task.CompletedTask;
		}
	}
}
