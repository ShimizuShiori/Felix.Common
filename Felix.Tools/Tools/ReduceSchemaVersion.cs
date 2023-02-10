using Felix.Tools.Attributes;
using System.Data;

namespace Felix.Tools.Tools
{
	[Tool("ReduceSchemaVersion", "DB")]
	class ReduceSchemaVersion : DbTool
	{
		protected override void DoSomethingForDb(IDbConnection dbConnection)
		{
			using (var cmd = dbConnection.CreateCommand())
			{
				cmd.CommandText = @"UPDATE StmData
SET SD_BinaryValue = convert(image, convert(varbinary(8000), N'6500'))
WHERE SD_Name = 'DATABASE_SCHEMA_VERSION'";
				cmd.ExecuteNonQuery();
			}
		}
	}
}
