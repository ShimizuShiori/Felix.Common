using Felix.Common;
using System.Data;
using System.Data.SqlClient;

namespace Felix.Tools.Tools
{
	abstract class DbTool : ITool
	{
		protected const string DbNameOdyssey = "Odyssey";
		protected virtual bool NeedToSelectADb { get; } = true;

		protected string[] DbNameList = new string[]
		{
			DbNameOdyssey
		};

		public async Task StartAsync()
		{
			var builder = new SqlConnectionStringBuilder();
			builder.DataSource = ".";
			builder.InitialCatalog = DbNameList.Length > 1 && NeedToSelectADb
				? ChooesForm<string>.Show(
					"",
					DbNameList.ToMap(x => (x, x)),
					"")
				: DbNameOdyssey;
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
