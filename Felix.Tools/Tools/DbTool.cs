using Felix.Common;
using System.Data;
using System.Data.SqlClient;

namespace Felix.Tools.Tools
{
	abstract class DbTool : ITool
	{
		protected string[] DbNameList = new string[]
		{
			"Odyssey"
		};

		public async Task StartAsync()
		{
			var builder = new SqlConnectionStringBuilder();
			builder.DataSource = ".";
			builder.InitialCatalog = ChooesForm<string>.Show("",
				DbNameList.ToMap(x => (x, x)),
				"");
			if (builder.InitialCatalog == "")
				return;
			builder.IntegratedSecurity = true;
			using (var conn = new SqlConnection(builder.ConnectionString))
			{
				conn.Open();
				await DoSomethingForDb(conn);
			}
		}

		protected abstract Task DoSomethingForDb(IDbConnection dbConnection);
	}
}
