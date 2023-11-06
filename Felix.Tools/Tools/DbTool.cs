using Felix.Common;
using System.Data;
using System.Data.SqlClient;

namespace Felix.Tools.Tools
{
	abstract class DbTool : ITool
	{
		protected const string DbNameOdyssey = "Odyssey";
		protected const string DbNameOdysseyHYETIP = "OdysseyHYETIP";
		protected virtual bool NeedToSelectADb { get; } = true;

		protected string[] DbNameList = new string[]
		{
			DbNameOdyssey,
			DbNameOdysseyHYETIP
		};

		public void Start()
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
				DoSomethingForDb(conn);
			}
		}

		protected abstract void DoSomethingForDb(IDbConnection dbConnection);
	}
}
