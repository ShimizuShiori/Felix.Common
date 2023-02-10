using System.Diagnostics;

namespace Felix.Common
{
	public class UrlHelper
	{
		public static void Open(string url)
		{
			using (var p = new Process())
			{
				p.StartInfo.FileName = url;
				p.StartInfo.UseShellExecute = true;
				p.Start();
			}
		}

		public static string Encode(string str)
		{
			return System.Web.HttpUtility.UrlEncode(str);
		}
	}
}
