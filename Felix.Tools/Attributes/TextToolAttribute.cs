using Felix.Tools.TextMatchers;
using System.Text.RegularExpressions;

namespace Felix.Tools.Attributes
{
	class TextToolAttribute : ToolAttribute
	{
		readonly string regex;
		readonly ITextMatcher textMatcher;

		public TextToolAttribute(string name, string category, Type? textMatcherType = null, string regex = "") : base(name, category)
		{
			this.regex = regex;
			textMatcher = CreateTextMatcher(textMatcherType, regex);
		}

		static ITextMatcher CreateTextMatcher(Type? textMatcherType = null, string regex = "")
		{
			if (textMatcherType != null)
			{
				var obj = Activator.CreateInstance(textMatcherType);
				if (obj is ITextMatcher m)
					return m;
				return new NullTextMatcher();
			}
			if (textMatcherType == null && string.IsNullOrEmpty(regex))
				return new NullTextMatcher();

			return new RegexTextMatcher(regex);

		}

		public override bool Show()
		{
			return base.Show()
				&& AppContext.CopiedInfo is TextCopiedInfo t
				&& !string.IsNullOrEmpty(t.Text)
				&& textMatcher.IsMatch(t.Text);
			;
		}
	}
}
