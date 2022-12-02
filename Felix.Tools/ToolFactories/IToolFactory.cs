using Felix.Tools.Tools;

namespace Felix.Tools.ToolFactories
{
	interface IToolFactory
	{
		ITool CreateTool(string toolName);

		IEnumerable<string> GetCategories();
		IEnumerable<ToolInfo> GetToolInfosByCategory(string categoryName);
	}
}
