using Felix.Common;
using Felix.Tools.Attributes;
using System.Text;

namespace Felix.Tools.Tools
{
	[TextTool("Box", "To")]
	class TextToBoxTool : ITool
	{
		public Task StartAsync()
		{
			string text = AppContext.SelectedText.Replace("\t", "    ");
			string[] lines = text.Split(Environment.NewLine);
			int maxWidth = GetMaxWidth(lines);

			var sb = new StringBuilder((maxWidth + 4) * (lines.Length + 4));

			// First Line
			sb.Append("+-");
			sb.Append("-".Repeat(maxWidth));
			sb.AppendLine("-+");

			if (lines.Length > 1)
			{
				// Space line
				sb.Append("| ");
				sb.Append(" ".Repeat(maxWidth));
				sb.AppendLine(" |");
			}

			// Content
			foreach (var line in lines)
			{
				sb.Append("| ");
				sb.Append(line);
				sb.Append(" ".Repeat(maxWidth - line.Length));
				sb.AppendLine(" |");
			}

			if (lines.Length > 1)
			{
				// Space line
				sb.Append("| ");
				sb.Append(" ".Repeat(maxWidth));
				sb.AppendLine(" |");
			}

			// Last Line
			sb.Append("+-");
			sb.Append("-".Repeat(maxWidth));
			sb.AppendLine("-+");

			OutputBox.Show(sb.ToString());
			return Task.CompletedTask;
		}

		private int GetMaxWidth(string[] lines)
		{
			int maxWidth = 0;
			foreach (var line in lines)
			{
				int width = GetWidth(line);
				if (width > maxWidth)
					maxWidth = width;
			}
			return maxWidth;
		}

		private int GetWidth(string line)
		{
			int i = 0;
			foreach (var c in line)
			{
				i += c == '\t' ? 4 : 1;
			}
			return i;
		}
	}
}
