using Felix.Common;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleExTest
{
	internal class Program
	{
		static GitRunner runner = new GitRunner(@"C:\git\wtg\CargoWise\Dev");

		static void Main(string[] args)
		{
			FieldInfo f;

			using (var client = new HttpClient())
			{
				client.MaxResponseContentBufferSize = 1;
				var res = client.GetStreamAsync("http://www.baidu.com")
					.GetAwaiter()
					.GetResult();

				f = res.GetType().GetField("_contentBytesRemaining", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			}

			Stopwatch stopwatch = Stopwatch.StartNew();
			using (var client = new HttpClient())
			{
				client.MaxResponseContentBufferSize = 1;
				var res = client.GetStreamAsync("https://aod.cos.tx.xmcdn.com/group80/M00/66/8C/wKgPEV7MksGBEkH8AJtZ211J2mk729-aacv2-48K.m4a")
					.GetAwaiter()
					.GetResult();
				stopwatch.Stop();
				Console.WriteLine(stopwatch.ElapsedMilliseconds);

				Console.WriteLine(f.GetValue(res));
			}

			stopwatch = Stopwatch.StartNew();
			using (var client = new HttpClient())
			{
				//client.MaxResponseContentBufferSize = 1;
				var res = client.GetAsync("https://aod.cos.tx.xmcdn.com/group80/M00/66/8C/wKgPEV7MksGBEkH8AJtZ211J2mk729-aacv2-48K.m4a")
					.GetAwaiter()
					.GetResult();
				stopwatch.Stop();
				Console.WriteLine(stopwatch.ElapsedMilliseconds);
				Console.WriteLine(res.Content.Headers.ContentLength);
			}
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