using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.Helpers;
using static Felix.Tools.Helpers.DocHelper;

namespace Felix.Tools.Tools
{
	abstract class DocToolBase : ITool
	{
		public abstract void Start();

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


	[Tool("Open", "Docs")]
	class OpenDocTool : DocToolBase
	{
		public override void Start()
		{
			var wi = ChooseWorkItem();
			if (wi == null)
				return;
			OpenWorkitem(wi);
		}
	}

	[Tool("New", "Docs")]
	class NewDocTool : DocToolBase
	{
		public override void Start()
		{
			var wiName = InputBox.Show("WorkItem", "");
			if (string.IsNullOrEmpty(wiName))
				return;

			var docInfo = DocHelper.Create(wiName);
			OpenWorkitem(docInfo);
		}
	}

	[Tool("Fin", "Docs")]
	class FinDocTool : DocToolBase
	{
		public override void Start()
		{
			var wi = ChooseWorkItem();
			if (wi == null) return;

			DocHelper.Finish(wi);
		}
	}
}
