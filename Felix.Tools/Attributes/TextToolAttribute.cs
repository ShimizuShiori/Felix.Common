using System.Text.RegularExpressions;

namespace Felix.Tools.Attributes
{
	class TextToolAttribute : ToolAttribute
	{
		readonly string regex;
		public TextToolAttribute(string name, string category, string regex = "") : base(name, category)
		{
			this.regex = regex;
		}

		public override bool Show()
		{
			return base.Show()
				&& AppContext.CopiedInfo is TextCopiedInfo t
				&& !string.IsNullOrEmpty(t.Text)
				&&
					(string.IsNullOrEmpty(regex) || Regex.IsMatch(t.Text, regex))
				;
		}
	}
}
