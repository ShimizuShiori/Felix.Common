﻿using CargoWise.Glow.Index.Service.Utils;
using Client;
using ConsoleExTest;
using Felix.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

[assembly: UseConst(typeof(WhereExp))]
[assembly: UseConst2()]

namespace ConsoleExTest
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public class UseConstAttribute : Attribute
	{
		public Type Type { get; private set; }

		public UseConstAttribute(Type type)
		{
			Type = type;
		}
	}

	[AttributeUsage(AttributeTargets.Assembly)]
	public class UseConst2Attribute : Attribute
	{
	}

	internal class Program
	{
		static GitRunner runner = new GitRunner(@"C:\git\wtg\CargoWise\Dev");
		static Queue<string> cmds = new Queue<string>();
		public static void MonitorCpuUsage(string processName, int interval)
		{
			var counterName = "% Processor Time";
			var categoryName = "Process";
			var instanceName = Process.GetProcessesByName(processName)[0].ProcessName;
			var counterForCpu = new PerformanceCounter(categoryName, counterName, instanceName, true);
			var counterForRAM = new PerformanceCounter("Process", "Working Set - Private", instanceName, true);
			float maxCpu = 0;
			float maxRAM = 0;
			while (true)
			{
				Queue<string> local = new Queue<string>();
				lock (cmds)
				{
					while (cmds.Count > 0)
						local.Enqueue(cmds.Dequeue());
				}
				while (local.Count > 0)
				{
					var cmd = local.Dequeue();
					if (cmd == "reset")
					{
						maxCpu = 0;
						maxRAM = 0;
					}
				}
				var cpuUsage = counterForCpu.NextValue();
				var ram = counterForRAM.NextValue();
				bool updated = false;
				if (cpuUsage > maxCpu)
				{
					maxCpu = cpuUsage;
					updated = true;
				}
				if (ram > maxRAM)
				{
					maxRAM = ram;
					updated = true;
				}
				if (updated)
				{
					Console.Clear();
					Console.WriteLine($"Max CPU Usage of {processName}: {maxCpu / 16}%");
					{
						var showValue = new Tuple<float, string>(maxRAM / 1024 / 1024, "M");
						if (showValue.Item1 > 1024)
						{
							showValue = new Tuple<float, string>(showValue.Item1 / 1024, "G");
						}

						Console.WriteLine($"Max RAM of {processName}: {showValue.Item1} {showValue.Item2}");
					}
				}
				Thread.Sleep(interval);
			}
		}

		static bool isRunning = false;
		static int c = 0;

		static bool TryGetIndex([NotNullWhen(true)] out int index)
		{
			(var result, index) = c == 0 ? (true, 10000) : (false, -1);
			return result;
		}
		static Action<Func<bool>, Action> GenerateDoubleCheckedRunner()
		{
			object syncObject = new object();
			return new Action<Func<bool>, Action>((predicate, action) =>
			{
				if (predicate())
				{
					lock (syncObject)
					{
						if (predicate())
						{
							action();
						}
					}
				}
			});
		}

		public static void Main(string[] args)
		{
			//var builder = new SqlConnectionStringBuilder();
			//builder.DataSource = ".";
			//builder.InitialCatalog = "Odyssey";
			//builder.IntegratedSecurity = true;
			//using (var conn = new SqlConnection(builder.ConnectionString))
			//{
			//	conn.Open();
			//	Console.WriteLine(DatabaseUtil.GetAppLock2(conn, "TEST", "Exclusive", "Session"));
			//}
			Console.WriteLine(true.ToString());
			Console.WriteLine(false.ToString());
			Console.ReadLine();
		}

		/// <summary>
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




public interface IPrimaryKeyStore
{
	void DeleteTemporaryFiles(Func<string, bool> isPrimaryKeyFile);
	IFileAccessor GetFileAccessor(string fileName);
}

public interface IFileAccessor : IDisposable
{
	void Delete();
	byte[] Read();
	void Write(byte[] buffer);
}