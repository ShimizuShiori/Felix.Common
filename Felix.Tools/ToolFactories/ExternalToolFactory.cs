using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.Mapping;
using Felix.Tools.Tools;

namespace Felix.Tools.ToolFactories
{
	class ExternalToolFactory : IToolFactory
	{
		static ExternalToolCollection externalTools = new ExternalToolCollection();
		static DateTime lastWriteTime = DateTime.MinValue;

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

		public void OnRunning()
		{
			string path = Resources.GetResourcePath(Resources.ExternalXml);
			var info = new FileInfo(path);
			if (!info.Exists)
			{
				using (var stream = FSHelper.CreateFile(path))
					if (stream != null)
						XmlHelper.ToStream(new ExternalToolCollection(), stream);
			}

			if (lastWriteTime < info.LastWriteTime)
			{
				externalTools = XmlHelper.ToObject(path, new ExternalToolCollection());
				lastWriteTime = info.LastWriteTime;
			}
		}
	}
}
