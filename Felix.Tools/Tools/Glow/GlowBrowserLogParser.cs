using Felix.Tools.Attributes;
using System.Text;
using System.Text.Json;

namespace Felix.Tools.Tools.Glow
{
    [TextTool("BrowserLogParser", "Glow")]
    class GlowBrowserLogParser : ITool
    {
        public void Start()
        {
            var logs = JsonSerializer.Deserialize<GlowBrowserLog[]>(AppContext.SelectedText);
            var sb = new StringBuilder();
            foreach (var log in logs)
            {
                sb.AppendLine($"{log.timestamp}\t{log.message}");
            }
            OutputBox.Show(sb.ToString());
        }
    }

    public class GlowBrowserLog
    {
        public string timestamp { get; set; }
        public string message { get; set; }
    }
}
