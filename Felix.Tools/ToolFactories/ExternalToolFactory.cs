using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.Mapping;
using Felix.Tools.Tools;

namespace Felix.Tools.ToolFactories
{
	class ExternalToolFactory : IToolFactory
	{
		readonly static ExternalToolCollection externalTools;
		static ExternalToolFactory()
		{
			externalTools = XmlHelper.ToObject("./External.xml", new ExternalToolCollection());
		}


		public ITool CreateTool(string toolName)
		{
			var info = externalTools
				.Where(x => x.Name == toolName)
				.FirstOrDefault();

			if (info == null)
				return NullTool.Default;

			return new Tools.ExternalTool(info);
		}

		public IEnumerable<string> GetCategories()
		{
			return externalTools.Select(x => x.Category);
		}

		public IEnumerable<ToolInfo> GetToolInfosByCategory(string categoryName)
		{
			return externalTools
				.Where(x => x.Category == categoryName)
				.Select(x => new ToolInfo(new ToolAttribute(x.Name, x.Category), typeof(Tools.ExternalTool)));
		}
	}
}
