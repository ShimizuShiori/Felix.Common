using Felix.Common;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

namespace ConsoleExTest
{
	internal class Program
	{
		static GitRunner runner = new GitRunner(@"C:\git\wtg\CargoWise\Dev");

		static void Main(string[] args)
		{
			var builder = new SqlConnectionStringBuilder();
			builder.DataSource = ".";
			builder.InitialCatalog = "Odyssey";
			if (builder.InitialCatalog == "")
				return;
			builder.IntegratedSecurity = true;
			using (var conn = new SqlConnection(builder.ToString()))
			{
				conn.Open();
				var sqlTransaction = conn.BeginTransaction();
				using (var cmd = conn.CreateCommand())
				{
					cmd.Transaction = sqlTransaction;
					cmd.CommandText = $"DECLARE @R INT\nEXEC @R = sp_getapplock @Resource = @Resource, @LockMode = @LockMode\nSELECT @R";

					var p1 = cmd.CreateParameter();
					p1.ParameterName = "Resource";
					p1.Value = "Form1";
					cmd.Parameters.Add(p1);

					var p2 = cmd.CreateParameter();
					p2.ParameterName = "LockMode";
					p2.Value = "Shared";
					cmd.Parameters.Add(p2);

					var r = cmd.ExecuteScalar();

					Console.WriteLine(r);
				}
			}
		}

		/// <summary>d
		/// 32位MD5加密
		/// </summary>
		/// <param name="password"></param>
		/// <returns></returns>
		public static string MD5Encrypt32(string password)
		{
			string cl = password;
			string pwd = "";
			MD5 md5 = MD5.Create(); //实例化一个md5对像
									// 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
			byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
			// 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
			for (int i = 0; i < s.Length; i++)
			{
				// 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
				pwd = pwd + s[i].ToString("X");
			}
			return pwd;
		}

		static void CreateBranch()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			runner.CreateWorktreeForCurrentBranch(b => @$"C:\git\wtg\CargoWise\Dev_{b.Replace("/", "_")}");
			//RemoveBranch();
			sw.Stop();
			Console.WriteLine("Over, {0}ms", sw.ElapsedMilliseconds);
		}

		static void RemoveBranch()
		{
			runner.RemoveWorktree(@"C:\git\wtg\CargoWise\Shared_FLF_WI00532049_EORIPrefix");
		}
	}
}