using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.Tools;
using System.Text;

namespace Felix.Tools
{
	[TextTool("Table", "To")]
	class ToTable : ITool
	{
		public Task StartAsync()
		{
			string[] lines = AppContext.SelectedText.Split(Environment.NewLine);
			if (lines.Length == 0)
				return Task.CompletedTask;

			var spliter = FindSpliter(lines);
			if (spliter == '0')
				return Task.CompletedTask;
			IEnumerable<string[]> splittedLines = lines.Select(x => x.Split(spliter));
			int columnSize = splittedLines.First().Length;
			int[] maxWidthForEachColumn = GetMaxWidthForEachColumn(splittedLines, columnSize);

			var tableText = BuildTableText(splittedLines, columnSize, maxWidthForEachColumn);

			OutputBox.Show(tableText);
			return Task.CompletedTask;
		}

		private string BuildTableText(IEnumerable<string[]> splittedLines, int columnSize, int[] maxWidthForEachColumn)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var line in splittedLines)
			{
				sb.Append("+");
				sb.Append(maxWidthForEachColumn
					.Select(width => "-".Repeat(width + 2))
					.JoinAsString("+"));
				sb.AppendLine("+");

				sb.Append("|");
				sb.Append(line.Select((word, index) =>
				{
					return word.AdjustToLeft(maxWidthForEachColumn[index]);
				}).Select(x => $" {x} ")
				.JoinAsString("|"));
				sb.AppendLine("|");
			}

			sb.Append("+");
			sb.Append(maxWidthForEachColumn
				.Select(width => "-".Repeat(width + 2))
				.JoinAsString("+"));
			sb.AppendLine("+");

			return sb.ToString();
		}

		char FindSpliter(string[] lines)
		{
			foreach (var spliter in new char[] { ',', '\t', ' ', '|' })
			{
				if (IsSpliterForLines(lines, spliter))
					return spliter;
			}
			return '0';
		}

		private bool IsSpliterForLines(string[] lines, char spliter)
		{
			int columns = lines[0].Split(spliter).Length;
			for (int i = 1; i < lines.Length; i++)
			{
				if (columns != lines[i].Split(spliter).Length)
					return false;
			}
			return true;
		}

		private int[] GetMaxWidthForEachColumn(IEnumerable<string[]> lines, int columnSize)
		{
			int[] result = new int[columnSize];
			foreach (var line in lines)
			{
				for (int i = 0; i < line.Length; i++)
				{
					var cell = line[i];
					if (result[i] < cell.Length)
						result[i] = cell.Length;
				}
			}
			return result;
		}
	}
}
