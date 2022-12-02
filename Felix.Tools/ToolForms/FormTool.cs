using Felix.Tools.Tools;

namespace Felix.Tools.ToolForms
{
	class FormTool : SyncTool
	{
		readonly Form form;

		public FormTool(Form form)
		{
			this.form = form;
		}

		protected override void Start()
		{
			form.ShowDialog();
		}
	}
}
