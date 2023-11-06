namespace Felix.Tools.TextMatchers
{
	class NullTextMatcher : ITextMatcher
	{
		public bool IsMatch(string text)
		{
			return true;
		}
	}
}
