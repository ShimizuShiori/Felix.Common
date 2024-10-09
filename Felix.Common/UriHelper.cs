using System.Diagnostics;

namespace Felix.Common
{
    public class UriHelper
    {
        public static void Open(string url)
        {
            if (url.StartsWith("http"))
            {
                using (var p = new Process())
                {
                    p.StartInfo.FileName = @"C:\Users\Felix.Fei\AppData\Local\Google\Chrome\Application\chrome.exe";
                    p.StartInfo.Arguments = @$"--profile-directory=""Default"" {url}";
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = false;
                    p.Start();
                }
            }
            else
            {
                using (var p = new Process())
                {
                    p.StartInfo.FileName = url;
                    p.StartInfo.UseShellExecute = true;
                    p.Start();
                }
            }
        }

        public static string Encode(string str)
        {
            return System.Web.HttpUtility.UrlEncode(str);
        }
    }
}
