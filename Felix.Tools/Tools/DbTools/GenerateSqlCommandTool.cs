using Felix.Common;
using Felix.Tools.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix.Tools.Tools.DbTools
{
	[TextTool("ShowSql", "DB")]
	class GenerateSqlCommandTool : DbTool
	{
		protected override void DoSomethingForDb(IDbConnection dbConnection)
		{
			var tableName = AppContext.SelectedText;
			var pk = InputBox.Show("PK");
			var keyField = GetKeyFieldName(dbConnection, tableName);
			var selectCommand = $"select * from {tableName} where {keyField} = '{pk}'";
			var fields = new List<string>();
			Dictionary<string, object> values = new Dictionary<string, object>();
			using (var cmd = dbConnection.CreateCommand())
			{
				cmd.CommandText = selectCommand;
				using (var reader = cmd.ExecuteReader())
				{
					using (var table = reader.GetSchemaTable())
					{
						if (table == null)
							return;
						reader.Read();
						foreach (DataRow row in table.Rows)
						{
							var columnName = (string)row["ColumnName"] ?? "";
							fields.Add(columnName);
							values[columnName] = row[columnName];
						}
					}
				}
			}
			var insertSql = $"INSERT INTO [{tableName}]({fields.Select(x => $"[{x}]").JoinAsString(",")})VALUES({fields.Select(x => x == "null" ? x : $"\"{x}\"").JoinAsString(",")})";
			OutputBox.Show(insertSql);
		}

		string GetKeyFieldName(IDbConnection dbConnection, string tableName)
		{
			using (var cmd = dbConnection.CreateCommand())
			{
				cmd.CommandText = $"select top 0 * from {tableName}";
				using (var reader = cmd.ExecuteReader())
				{
					using (var table = reader.GetSchemaTable())
					{
						if (table != null)
							foreach (DataRow row in table.Rows)
							{
								var columnName = (row["ColumnName"]?.ToString()) ?? "";
								if (columnName.EndsWith("_PK"))
								{
									return columnName;
								}
							}
					}
				}
				return "";
			}
		}
	}
}
