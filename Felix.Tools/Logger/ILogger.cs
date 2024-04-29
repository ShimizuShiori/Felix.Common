using System.Text;

namespace Felix.Tools.Logger
{
    public interface ILogger
    {
        void Append(string message);
    }

    public class DefaultLogger : ILogger
    {
        readonly string filePath;

        public DefaultLogger(string filePath)
        {
            this.filePath = filePath;
        }

        public void Append(string message)
        {
            while (true)
            {
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Append))
                    {
                        var msg = $"[{DateTime.Now.ToShortTimeString()}] - {message}{Environment.NewLine}";
                        byte[] buffer = Encoding.UTF8.GetBytes(msg);
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    break;
                }
                catch (Exception)
                {

                    continue;
                }
            }
        }
    }
}
