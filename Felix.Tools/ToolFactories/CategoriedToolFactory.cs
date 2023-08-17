using Felix.Tools.Attributes;
using Felix.Tools.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Felix.Tools.ToolFactories
{
	class CategoriedToolFactory : IToolFactory
	{
		static readonly IDictionary<string, List<object>> categoiedToolObject = new Dictionary<string, List<object>>();
		static CategoriedToolFactory()
		{
			var objs = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(x => x.IsClass && !x.IsAbstract)
				.Select(x => (x, x.GetCustomAttribute<ToolCategoryAttribute>()))
				.Where(x => x.Item2 != null)
				.Select(x => (Activator.CreateInstance(x.x), x.Item2?.Category));
			foreach (var x in objs)
			{
				if (x.Item1 == null || x.Category == null)
					continue;
				List<object>? list = null;
				if (!categoiedToolObject.TryGetValue(x.Category, out list))
				{
					list = new List<object>();
					categoiedToolObject[x.Category] = list;
				}
				list.Add(x.Item1);
			}
		}
		public ITool CreateTool(string toolName)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<string> GetCategories()
		{
			return categoiedToolObject.Keys;
		}

		public IEnumerable<ToolInfo> GetToolInfosByCategory(string categoryName)
		{
			throw new NotImplementedException();
		}

		public void OnRunning()
		{
		}
	}
}
