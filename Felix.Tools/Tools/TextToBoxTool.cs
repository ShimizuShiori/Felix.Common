using Felix.Tools.Attributes;
using System.Text;

namespace Felix.Tools.Tools
{
	[TextTool("Box", "To")]
	class TextToBoxTool : ITool
	{
		public Task StartAsync()
		{
			int length = AppContext.SelectedText.Length;
			var sb = new StringBuilder((length + 4) * 3);
			sb.Append("+");
			for (int i = 0; i < length + 2; i++)
				sb.Append("-");
			sb.AppendLine("+");

			sb.Append("| ");
			sb.Append(AppContext.SelectedText);
			sb.AppendLine(" |");

			sb.Append("+");
			for (int i = 0; i < length + 2; i++)
				sb.Append("-");
			sb.AppendLine("+");

			OutputBox.Show(sb.ToString());
			return Task.CompletedTask;
		}
	}
}
