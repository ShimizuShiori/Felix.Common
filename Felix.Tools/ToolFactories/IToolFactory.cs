using Felix.Tools.Tools;

namespace Felix.Tools.ToolFactories
{
	interface IToolFactory
	{
		void OnRunning();
		ITool CreateTool(string toolName);

		IEnumerable<string> GetCategories();
		IEnumerable<ToolInfo> GetToolInfosByCategory(string categoryName);
	}
}
