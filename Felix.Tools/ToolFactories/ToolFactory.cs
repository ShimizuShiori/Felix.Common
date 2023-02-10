using Felix.Tools.Tools;

namespace Felix.Tools.ToolFactories
{
	class ToolFactory : IToolFactory
	{
		static readonly IToolFactory[] subFactories = new IToolFactory[]
		{
			new SimpleToolFactory(),
			new FormToolFactory(),
			new ExternalToolFactory()
		};

		public ITool CreateTool(string toolName)
		{
			foreach (var factory in subFactories)
			{
				var tool = factory.CreateTool(toolName);
				if (tool.IsNull())
					continue;

				return tool;
			}
			return NullTool.Default;
		}

		public IEnumerable<string> GetCategories()
		{
			HashSet<string> categories = new HashSet<string>();
			foreach (var factory in subFactories)
			{
				foreach (var category in factory.GetCategories())
				{
					categories.Add(category);
				}
			}
			return categories.OrderBy(category => category);
		}

		public IEnumerable<ToolInfo> GetToolInfosByCategory(string categoryName)
		{
			List<ToolInfo> toolInfos = new List<ToolInfo>();
			foreach (var factory in subFactories)
				toolInfos.AddRange(factory.GetToolInfosByCategory(categoryName));
			return toolInfos.OrderBy(x => x.Attribute.Name);
		}
	}
}
