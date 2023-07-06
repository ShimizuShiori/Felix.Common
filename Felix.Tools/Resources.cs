namespace Felix.Tools
{
	static class Resources
	{
		public const string ExternalXml = "External.xml";

		static readonly string ROOT_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FelixTool");

		public static string GetResourcePath(string name)
		{
			return Path.Combine(ROOT_PATH, name);
		}
	}
}
