using Felix.Common;
using System.Diagnostics;

namespace ConsoleExTest
{
	internal class Program
	{
		static GitRunner runner = new GitRunner(@"C:\git\wtg\CargoWise\Dev");

		static void Main(string[] args)
		{
			var p = User32.FindWindow(null, "*Untitled - Notepad");
			// CargoWise One - ediProd - Branch: China - Company: WiseTech Global (Australia) Pty Ltd - Department: Development (Felix.Fei@wtg.zone@AU2CO-SRDH-002.wtg.zone)
			Console.WriteLine(p);

			User32.SetForegroundWindow(p);
			User32.SendMessage(p, User32.WM_KEYDOWN, 0x400000F, 0x002907C2);
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