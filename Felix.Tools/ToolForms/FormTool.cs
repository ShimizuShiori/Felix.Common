using Felix.Tools.Tools;

namespace Felix.Tools.ToolForms
{
	class FormTool : ITool
	{
		readonly Form form;

		public FormTool(Form form)
		{
			this.form = form;
		}

		public void Start()
		{
			form.ShowDialog();
		}
	}
}
