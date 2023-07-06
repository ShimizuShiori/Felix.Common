using Felix.Tools.Attributes;
using Felix.Tools.Tools;
using System.Reflection;

namespace Felix.Tools.ToolFactories
{
	class SimpleToolFactory : IToolFactory
	{
		static readonly ICollection<ToolInfo> tools;
		static SimpleToolFactory()
		{
			tools = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(x => typeof(ITool).IsAssignableFrom(x))
				.Where(x => x.IsClass && !x.IsAbstract)
				.Select(x => new ToolInfo(
					x.GetCustomAttribute<ToolAttribute>() ?? ToolAttribute.Empty,
					x
				))
				.Where(x => !ToolAttribute.IsEmpty(x.Attribute))
				.ToList();
		}

		public ITool CreateTool(string toolName)
		{
			var info = tools.FirstOrDefault(x => x.Attribute.Name == toolName);

			if (info == null)
				return NullTool.Default;

			var instance = Activator.CreateInstance(info.Type);
			if (instance == null)
				return NullTool.Default;

			return (ITool)instance;
		}

		public IEnumerable<string> GetCategories()
		{
			return tools
				.Where(x => x.Attribute.Show())
				.Select(x => x.Attribute.Category);
		}

		public IEnumerable<ToolInfo> GetToolInfosByCategory(string categoryName)
		{
			return tools
				.Where(x => x.Attribute.Show() && x.Attribute.Category == categoryName);
		}

		public void OnRunning()
		{
		}
	}
}
