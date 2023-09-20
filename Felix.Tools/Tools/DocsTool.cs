using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.Helpers;
using static Felix.Tools.Helpers.DocHelper;

namespace Felix.Tools.Tools
{
	[Tool("Manager", "Docs")]
	class DocToolBase : ITool
	{
		public void Start()
		{
			var action = ChooesForm<string>.Show("Open", "New", "Fin");
			switch (action)
			{
				case "Open":
					{
						var wi = ChooseWorkItem();
						if (wi == null)
							return;
						OpenWorkitem(wi);
					}
					break;
				case "New":
					{
						var wiName = InputBox.Show("WorkItem", "");
						if (string.IsNullOrEmpty(wiName))
							return;

						var docInfo = DocHelper.Create(wiName);
						OpenWorkitem(docInfo);
					}
					break;
				case "Fin":
					{
						var wi = ChooseWorkItem();
						if (wi == null) return;

						DocHelper.Finish(wi);
					}
					break;
				default:
					break;
			}
		}

		protected DocInfo? ChooseWorkItem()
		{
			var map = GetAllWorkItems(WorkItemStates.WRK).ToMap(x => (x.Name, x));

			if (map == null)
				return null;

			if (map.Count == 1)
				return map.Values.First();

			var workItem = ChooesForm<DocInfo>.Show("", map, new DocInfo("", "", WorkItemStates.FIN));
			if (workItem == null || workItem.Name == "") return null;

			return workItem;
		}

		protected void OpenWorkitem(DocInfo workItem)
		{
			VSCodeRunner.OpenFile(workItem.FullPath);
		}
	}
}
