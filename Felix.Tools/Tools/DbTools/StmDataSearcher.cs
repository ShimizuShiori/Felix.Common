using Felix.Tools.Attributes;
using System.Data;

namespace Felix.Tools.Tools.DbTools
{
	[TextTool("StmData", "DB")]
	class StmDataSearcher : DbTool
	{
		protected override bool NeedToSelectADb => true;

		protected override void DoSomethingForDb(IDbConnection dbConnection)
		{
			using (var cmd = dbConnection.CreateCommand())
			{
				cmd.CommandText = $@"select convert(nvarchar(4000), SD_BinaryValue)
from StmData
where SD_Name = '{AppContext.SelectedText}'";
				object? r = cmd.ExecuteScalar();
				if (r == null)
					return;

				var xml = r as string;
				if (xml == null)
					return;
				OutputBox.Show(xml);
			}
		}
	}
}
