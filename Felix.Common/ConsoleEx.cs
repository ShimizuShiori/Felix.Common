namespace Felix.Common
{
	public static class ConsoleEx
	{
		public static int Select(string[] items)
		{
			int currentPosition = 0;
			ConsolePosition[]? positions = null;

			void Draw()
			{
				bool firstTime = false;
				if (positions == null)
				{
					positions = new ConsolePosition[items.Length];
					firstTime = true;
				}
				for (int i = 0; i < positions.Length; i++)
				{
					string content = i == currentPosition ? $"[ {items[i]} ]" : $"  {items[i]}  ";
					if (firstTime)
						positions[i] = WriteLine(content);
					else
						positions[i] = WriteLine(content, positions[i]);
				}
				Console.WriteLine("Using up and down select one...");
			}

			Draw();

			ConsoleKeyInfo keyInfo;
			while ((keyInfo = Console.ReadKey()).Key != ConsoleKey.Enter)
			{
				if (keyInfo.Key == ConsoleKey.UpArrow)
					currentPosition = currentPosition == 0 ? 0 : currentPosition - 1;
				else if (keyInfo.Key == ConsoleKey.DownArrow)
					currentPosition = currentPosition == items.Length - 1 ? currentPosition : currentPosition + 1;
				Draw();
			}

			return currentPosition;
		}

		static ConsolePosition WriteLine(string content, ConsolePosition position)
		{
			Console.CursorTop = position.Top;
			Console.CursorLeft = 0;
			Console.Write(content);
			if (Console.CursorLeft >= position.Left)
			{
				return new ConsolePosition(position.Top, Console.CursorLeft);
			}
			int currentLeft = Console.CursorLeft;
			Console.Write(" ".Repeat(position.Left - currentLeft));
			return new ConsolePosition(position.Top, currentLeft);
		}

		static ConsolePosition WriteLine(string content)
		{
			Console.Write(content);
			ConsolePosition position = new ConsolePosition(Console.CursorTop, Console.CursorLeft);
			Console.WriteLine();
			return position;
		}
	}
}
