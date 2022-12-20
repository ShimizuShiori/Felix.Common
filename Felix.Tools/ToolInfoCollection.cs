using Felix.Tools.Tools;
using System.Reflection;

namespace Felix.Tools
{
	static class ToolInfoCollection
	{
		public static IEnumerable<ToolInfo> ToolInfos { get; }

		static ToolInfoCollection()
		{
			ToolInfos = typeof(StartForm).Assembly.GetTypes()
				.Where(t => typeof(Form).IsAssignableFrom(t) || typeof(ITool).IsAssignableFrom(t))
				.Where(t => !t.IsAbstract)
				.Select(t => new ToolInfo(t.GetCustomAttribute<ToolAttribute>() ?? ToolAttribute.Empty, t))
				.Where(x => !ToolAttribute.IsEmpty(x.Attribute));
		}

		public static ICollection<string> GetCategories()
		{
			return ToolInfos
				.Select(x => x.Attribute.Category)
				.Distinct()
				.OrderBy(x => x)
				.ToList();
		}

		public static ICollection<ToolInfo> GetByCategory(string category)
		{
			return ToolInfos
				.Where(x => x.Attribute.Category == category)
				.OrderBy(x => x.Attribute.Name)
				.ToList();
		}
	}
}
