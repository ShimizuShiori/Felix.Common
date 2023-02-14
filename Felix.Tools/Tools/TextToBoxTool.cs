using Felix.Common;
using Felix.Tools.Attributes;
using System.Text;

namespace Felix.Tools.Tools
{
	[TextTool("Box", "To")]
	class TextToBoxTool : ITool
	{
		public void Start()
		{
			int boxWidth = InputBox.Show<int>("Width", "200", s => int.Parse(s));

			string text = AppContext.SelectedText.Replace("\t", "    ");
			string[] lines = text.Split(Environment.NewLine);
			var boxSize = GetMaxWidth(boxWidth, lines);

			var sb = new StringBuilder((boxSize.Width + 4) * (boxSize.Height + 4));

			// First Line
			sb.Append("+-");
			sb.Append("-".Repeat(boxSize.Width));
			sb.AppendLine("-+");

			if (lines.Length > 1)
			{
				// Space line
				sb.Append("| ");
				sb.Append(" ".Repeat(boxSize.Width));
				sb.AppendLine(" |");
			}

			// Content
			foreach (var line in lines)
			{
				var ps = line.Length / boxSize.Width + 1;
				var changedLine = line.AdjustToEnd(ps * boxSize.Width);
				for (int p = 0; p < line.Length / boxSize.Width + 1; p++)
				{
					sb.Append("| ");
					sb.Append(changedLine.Substring(p * boxSize.Width, boxSize.Width));
					sb.AppendLine(" |");
				}
			}

			if (lines.Length > 1)
			{
				// Space line
				sb.Append("| ");
				sb.Append(" ".Repeat(boxSize.Width));
				sb.AppendLine(" |");
			}

			// Last Line
			sb.Append("+-");
			sb.Append("-".Repeat(boxSize.Width));
			sb.AppendLine("-+");

			OutputBox.Show(sb.ToString());
			return;
		}

		BoxSize GetMaxWidth(int boxWidth, string[] lines)
		{
			int maxWidth = 0;
			int height = 0;
			foreach (var line in lines)
			{
				int width = GetWidth(line);
				if (width > boxWidth)
					width = boxWidth;
				if (width > maxWidth)
					maxWidth = width;

				height += (width / boxWidth) + 1;
			}
			return new BoxSize(maxWidth, height);
		}

		int GetWidth(string line)
		{
			int i = 0;
			foreach (var c in line)
			{
				i += c == '\t' ? 4 : 1;
			}
			return i;
		}

		record BoxSize(int Width, int Height);
	}
}
