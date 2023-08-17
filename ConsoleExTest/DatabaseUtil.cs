using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoWise.Glow.Index.Service.Utils
{
	public static class DatabaseUtil
	{
		public static bool TryGetGlobalAppLock(IDbConnection connection, string resource)
		{
			var result = GetAppLock(connection, resource, "Exclusive", "Session");
			var success = result == 0 || result == 1;

			return success;
		}

		public static int GetAppLock(IDbConnection connection, string resource, string lockMode, string lockOwner)
		{
			using (var cmd = CreateCommand(connection, ScriptToGetLock, new Dictionary<string, object>()
				{
					{ "Resource", resource },
					{ "LockMode", lockMode },
					{ "LockOwner", lockOwner },
				}))
			{
				var result = (int)cmd.ExecuteScalar();
				return result;
			}
		}
		public static int GetAppLock2(IDbConnection connection, string resource, string lockMode, string lockOwner)
		{
			return RunProc(connection, "sp_getapplock", new Dictionary<string, object>()
				{
					{ "Resource", resource },
					{ "LockMode", lockMode },
					{ "LockOwner", lockOwner },
					{ "LockTimeout", 0 },
				});
		}

		static void ReleaseAppLock(IDbConnection connection, string resource, string lockOwner)
		{
			using (var cmd = CreateCommand(connection, ScriptToReleaseLock, new Dictionary<string, object>()
				{
					{ "Resource", resource },
					{ "LockOwner", lockOwner },
				}))
			{
				cmd.ExecuteNonQuery();
			}
		}

		static void FillCommand(IDbCommand command, Dictionary<string, object> parameters)
		{
			foreach (var item in parameters)
			{
				var parameter = command.CreateParameter();
				parameter.ParameterName = item.Key;
				parameter.Value = item.Value;
				command.Parameters.Add(parameter);
			}
		}


		static IDbCommand CreateCommand(IDbConnection connection, string command, Dictionary<string, object> parameters)
		{
			var cmd = connection.CreateCommand();
			cmd.CommandText = command;
			FillCommand(cmd, parameters);
			return cmd;
		}

		static int RunProc(IDbConnection connection, string procName, Dictionary<string, object> parameters)
		{
			using (var cmd = connection.CreateCommand())
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = procName;
				FillCommand(cmd, parameters);

				var p = cmd.CreateParameter();
				p.Direction = ParameterDirection.ReturnValue;
				cmd.Parameters.Add(p);

				cmd.ExecuteNonQuery();

				return 1;
			}
		}

		const string ScriptToGetLock = "Declare @i int\nEXEC @i = sp_getapplock @Resource = @Resource, @LockMode = @LockMode, @LockOwner=@LockOwner, @LockTimeout=0\nSelect @i";
		const string ScriptToReleaseLock = "Declare @i int\nEXEC @i = sp_releaseapplock @Resource = @Resource, @LockOwner=@LockOwner\nSelect @i";
	}
}
