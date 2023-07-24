using Microsoft.VisualBasic;
using System.Net.Sockets;
using System.Text;

namespace Client
{
	internal class Program
	{
		async static Task Main(string[] args)
		{
			TcpClient tc = new TcpClient();
			await tc.ConnectAsync("127.0.0.1", 8888);

			byte[] buffer = Encoding.Default.GetBytes("PING");

			_ = Task.Factory.StartNew(async () =>
			{
				NetworkStream networkStream = tc.GetStream();
				while (true)
				{
					byte[] readBuffer = new byte[1024];
					var len = await networkStream.ReadAsync(readBuffer);
					Console.WriteLine(Encoding.Default.GetString(readBuffer, 0, len));
				}
			}, TaskCreationOptions.LongRunning);
			while (true)
			{
				NetworkStream networkStream = tc.GetStream();

				await networkStream.WriteAsync(buffer, 0, buffer.Length);

				await Task.Delay(1000).ConfigureAwait(false);
			}

		}

		static int TranCount;
		private static int RowCount;

		static int AcquireOrUpdateSqlMutex(
			string category,
			string lockInfo,
			int timeoutInSeconds,
			out DateTime currentTimeUtc,
			out DateTime mutexExpiresAtTimeUtc,
			out string returnMessage,
			Guid? parentId = null,
			string? parentTableCode = null,
			string? workStationName = null,
			int? processId = null,
			string? userCode = null)
		{
			returnMessage = null;

			if (TranCount != 0)
			{
				throw new ApplicationException("AcquireOrUpdateSqlMutex must NOT be run in transaction");
			}

			if (workStationName == null)
				workStationName = HOST_NAME();
			if (processId == null)
				processId = HOST_ID();

			DateTime
				lastEditTimeUtc,
				expiresAtTimeUtc;
			int
				result = -1,
				success = 0,
				rowsAffected;

			returnMessage = DateTime.UtcNow + ": started";
			mutexExpiresAtTimeUtc = DateTime.MinValue;
			currentTimeUtc = DateTime.MinValue;

			currentTimeUtc = DateTime.UtcNow;

			try
			{
				if (timeoutInSeconds < 0)
				{
					lastEditTimeUtc = DateTime.UtcNow;
					expiresAtTimeUtc = lastEditTimeUtc.AddSeconds(timeoutInSeconds);

					Update("StmServiceMutex")
						.Set("SMX_ExpiresAtUtc", expiresAtTimeUtc)
						.Set("SMX_TimeoutInSeconds", timeoutInSeconds)
						.Set("SMX_SystemLastEditTimeUtc", lastEditTimeUtc)
						.Set("SMX_SystemLastEditUser", userCode)
					.Where("SMX_ServiceClass", "=", category)
						.And("SMX_LockInfo", "=", lockInfo)
						.And("SMX_WorkstationName", "=", workStationName)
						.And("SMX_ProcessId", "=", processId);

					rowsAffected = RowCount;
					mutexExpiresAtTimeUtc = expiresAtTimeUtc;
					currentTimeUtc = lastEditTimeUtc;
					result = success;
					returnMessage += "\r\n" + DateTime.UtcNow.ToString() + ": release(" + rowsAffected.ToString() + ")";
				}
				else
				{
					int existingLockRecordsCount;

					existingLockRecordsCount = SelectCount(@"StmServiceMutex", @"SMX_ServiceClass = @category AND  
    SMX_LockInfo = @lockInfo AND  
    SMX_WorkstationName = @workStationName AND  
    SMX_ProcessId = @processId AND  
    SMX_ExpiresAtUtc >= @currentTimeUtc ");

					lastEditTimeUtc = DateTime.UtcNow;
					expiresAtTimeUtc = lastEditTimeUtc.AddSeconds(timeoutInSeconds);

					if (existingLockRecordsCount > 0)
					{
						Update("StmServiceMutex")
							.Set("SMX_ExpiresAtUtc", expiresAtTimeUtc)
							.Set("SMX_TimeoutInSeconds", timeoutInSeconds)
							.Set("SMX_SystemLastEditTimeUtc", lastEditTimeUtc)
							.Set("SMX_SystemLastEditUser", userCode)
						.Where("SMX_ServiceClass", "=", category)
							.And("SMX_LockInfo", "=", lockInfo)
							.And("SMX_WorkstationName", "=", workStationName)
							.And("SMX_ProcessId", "=", processId)
							.And("SMX_ExpiresAtUtc", ">=", currentTimeUtc);

						rowsAffected = RowCount;

						if (rowsAffected > 0)
						{
							mutexExpiresAtTimeUtc = expiresAtTimeUtc;
							currentTimeUtc = lastEditTimeUtc;
							result = success;
						}
					}
					else
					{
						Exec(@"UPDATE [StmServiceMutex]  
     SET  
      SMX_ExpiresAtUtc = @expiresAtTimeUtc,  
      SMX_TimeoutInSeconds = @timeoutInSeconds,  
      SMX_WorkstationName = @workStationName,  
      SMX_ProcessId = @processId,  
      SMX_ParentId = @parentId,  
      SMX_ParentTableCode = @parentTableCode,  
      SMX_SystemLastEditTimeUtc = @lastEditTimeUtc,  
      SMX_SystemLastEditUser = @userCode  
     WHERE  
      SMX_ServiceClass = @category  
      AND SMX_LockInfo = @lockInfo  
      AND SMX_ExpiresAtUtc <= @lastEditTimeUtc;  ");

						rowsAffected = RowCount;
						if (rowsAffected > 0)
						{
							mutexExpiresAtTimeUtc = expiresAtTimeUtc;
							currentTimeUtc = lastEditTimeUtc;
							result = success;
						}
						else
						{
							Exec(@"INSERT [StmServiceMutex] (  
      SMX_ServiceClass,  
      SMX_LockInfo,  
      SMX_ExpiresAtUtc,  
      SMX_TimeoutInSeconds,  
      SMX_WorkstationName,  
      SMX_ProcessId,  
      SMX_ParentId,  
      SMX_ParentTableCode,  
      SMX_SystemCreateTimeUtc,  
      SMX_SystemCreateUser,  
      SMX_SystemLastEditTimeUtc,  
      SMX_SystemLastEditUser  
      ) VALUES (  
       @category,  
       @lockInfo,  
       @expiresAtTimeUtc,  
       @timeoutInSeconds,  
       @workStationName,  
       @processId,  
       @parentId,  
       @parentTableCode,  
       @lastEditTimeUtc,  
       @userCode,  
       @lastEditTimeUtc,  
       @userCode  
      );  ");
							rowsAffected = RowCount;
							if(rowsAffected>0)
							{
								mutexExpiresAtTimeUtc = expiresAtTimeUtc;
								currentTimeUtc = lastEditTimeUtc;
								result = success;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				result = ERROR_NUMBER();
				returnMessage += $"\r\n{DateTime.UtcNow}: error: {ex}";
			}
			return result;
		}

		private static void Exec(string v)
		{
			throw new NotImplementedException();
		}

		private static int SelectCount(string v, string v1)
		{
			throw new NotImplementedException();
		}

		private static int ERROR_NUMBER()
		{
			throw new NotImplementedException();
		}

		private static int? HOST_ID()
		{
			throw new NotImplementedException();
		}

		private static string? HOST_NAME()
		{
			throw new NotImplementedException();
		}

		static UpdateExp Update(string tableName)
		{ throw new NotImplementedException(); }

		class UpdateExp
		{
			public UpdateExp Set(string field, object value)
			{
				throw new NotImplementedException();
			}

			public WhereExp Where(string field, string op, object value) { throw new NotImplementedException(); }
		}
	}
}