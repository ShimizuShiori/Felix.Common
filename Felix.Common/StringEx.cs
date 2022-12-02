using System.Text;
using System.Text.RegularExpressions;

namespace Felix.Common
{
	public static class StringEx
	{
		public static string Repeat(this string value, int times)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < times; i++)
				sb.Append(value);
			return sb.ToString();
		}

		public static string Pickup(this string value, string regex, string groupName)
		{
			return new Regex(regex)
				.Match(value)
				.Groups[groupName]
				.Value;
		}
	}
}
