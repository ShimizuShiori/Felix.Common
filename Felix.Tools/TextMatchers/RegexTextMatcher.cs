using System.Text.RegularExpressions;

namespace Felix.Tools.TextMatchers
{
	class RegexTextMatcher : ITextMatcher
	{
		readonly string regex;

		public RegexTextMatcher(string regex)
		{
			this.regex = regex;
		}

		public bool IsMatch(string text)
		{
			return Regex.IsMatch(text, regex);
		}
	}
}
