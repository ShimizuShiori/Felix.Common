using Felix.Tools.ToolFactories;

namespace Felix.Tools
{
	static class AppContext
	{
		public static string SelectedText { get; set; } = string.Empty;
		public static string SelectedCategory { get; set; } = string.Empty;
		public static IToolFactory ToolFactory { get; } = new ToolFactory();
	}
}
