using Felix.Tools.Attributes;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Felix.Tools.Tools.Glow
{
    [TextTool("FlattenGlowLog", "Glow")]
    class FlattenGlowLog : ITool
    {
        public void Start()
        {
            try
            {
                var logs = JsonSerializer.Deserialize<GlowLog[]>(AppContext.SelectedText);
                StringBuilder sb = new StringBuilder();
                foreach (var log in logs)
                {
                    sb.Append($"{log.timestamp}\t{log.message}");
                    sb.AppendLine();
                }
                OutputBox.Show(sb.ToString());
            }
            catch (Exception)
            {

            }
        }
    }

    public class GlowLog
    {
        public string timestamp { get; set; }
        public string message { get; set; }
    }
}
