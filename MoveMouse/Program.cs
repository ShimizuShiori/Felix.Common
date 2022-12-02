using Felix.Common;

namespace MoveMouse
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int x = 100, y = 100;
			while (true)
			{
				for (int i = 0; i < 500; i++)
				{
					User32.SetCursorPos(x + i, y + i);
					Thread.Sleep(1);
				}
				for (int i = 500; i >=0; i--)
				{
					User32.SetCursorPos(x + i, y + i);
					Thread.Sleep(1);
				}
			}
		}
	}
}