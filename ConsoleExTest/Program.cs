using Felix.Common;
using System.Diagnostics;

namespace ConsoleExTest
{
	internal class Program
	{
		static GitRunner runner = new GitRunner(@"C:\git\wtg\CargoWise\Dev");

		static void Main(string[] args)
		{
			var p = User32.FindWindow(null, "CargoWise One - ediProd - Branch: China - Company: WiseTech Global (Australia) Pty Ltd - Department: Development (Felix.Fei@wtg.zone@AU2CO-SRDH-002.wtg.zone)");
			//p = User32.FindWindowEx(p, IntPtr.Zero, "Edit", null);
			//Console.WriteLine(p);
			Console.WriteLine(p);
			User32.SetForegroundWindow(p);
			//User32.PostMessage((int)p, User32.WM_CHAR, 'a', 0);
			//User32.PostMessage((int)p, User32.WM_CHAR, 'b', 0);

			//User32.PostMessage((int)p, 0x0112, 0xF100, 0x0046);
			User32.PostMessage((int)p, User32.WM_CHAR, 0x70, 0);

			//User32.PostMessage((int)p, User32.WM_SYSKEYDOWN, 0x11, 1);
			//Thread.Sleep(50);
			//User32.PostMessage((int)p, User32.WM_KEYDOWN, 's', 0);
			//Thread.Sleep(1000);
			//User32.PostMessage((int)p, User32.WM_KEYUP, 's', 0);

			//User32.PostMessage((int)p, User32.WM_SYSKEYDOWN, 0x11, 1);
			//User32.PostMessage((int)p, User32.WM_KEYDOWN, 0x53, 1);
			//User32.PostMessage((int)p, User32.WM_KEYUP, 0x53, 1);
			//User32.PostMessage((int)p, User32.WM_SYSKEYUP, 0x11, 1);

			// CargoWise One - ediProd - Branch: China - Company: WiseTech Global (Australia) Pty Ltd - Department: Development (Felix.Fei@wtg.zone@AU2CO-SRDH-002.wtg.zone)
			//User32.SendMessageA(p, User32.WM_KEYDOWN, 0x5A, 1);

			//var p = User32.FindWindow(null, "CargoWise One - ediProd - Branch: China - Company: WiseTech Global (Australia) Pty Ltd - Department: Development (Felix.Fei@wtg.zone@AU2CO-SRDH-002.wtg.zone");
			//Console.WriteLine(p);

			//User32.SetForegroundWindow(p);
			//Console.ReadLine();
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