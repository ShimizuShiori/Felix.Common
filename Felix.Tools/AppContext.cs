using Felix.Tools.ToolFactories;

namespace Felix.Tools
{
	static class AppContext
	{
		public static ICopiedInfo CopiedInfo { get; set; } = NullCopiedInfo.Instance;
		public static string SelectedCategory { get; set; } = string.Empty;
		public static IToolFactory ToolFactory { get; } = new ToolFactory();
		public static JobCounter JobCounter { get; } = new JobCounter();
		public static string SelectedText
		{
			get
			{
				if (CopiedInfo is TextCopiedInfo t)
				{
					return t.Text;
				}
				else if (CopiedInfo is FilePathListCopiedInfo f)
				{
					return f.FilePathList[0];
				}
				return string.Empty;
			}
		}

		public static string[] SelectedFilePathList
		{
			get
			{
				if (CopiedInfo is FilePathListCopiedInfo f)
				{
					return f.FilePathList;
				}
				return Array.Empty<string>();
			}
		}
	}
}
