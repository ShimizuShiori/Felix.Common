using Felix.Tools.Attributes;
using System.Data;
using System.Text;

namespace Felix.Tools.Tools.DbTools.BOTools
{
	[TextTool("FullName", "BO", @"^[A-Z]+$")]
	class ShortNameToFullName : DbTool
	{
		protected override bool NeedToSelectADb => false;

		protected override Task DoSomethingForDb(IDbConnection dbConnection)
		{
			var shortName = AppContext.SelectedText;
			var sqlCommand = @"select o.name from syscolumns c
inner join sysobjects o on o.id = c.id
where c.name = @name and o.type = 'u'";
			var sb = new StringBuilder();
			using (var cmd = dbConnection.CreateCommand())
			{
				cmd.CommandText = sqlCommand;
				var p = cmd.CreateParameter();
				p.ParameterName = "name";
				p.Value = $"{shortName}_PK";
				cmd.Parameters.Add(p);
				var tableName = "";
				try
				{
					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							tableName = reader.GetString(0);
							if (tableName.Contains("_"))
								continue;
							sb.AppendLine(tableName);
						}
					}
				}
				catch (Exception)
				{
					return Task.CompletedTask;
				}
			}
			OutputBox.Show(sb.ToString());
			return Task.CompletedTask;
		}
	}
}
