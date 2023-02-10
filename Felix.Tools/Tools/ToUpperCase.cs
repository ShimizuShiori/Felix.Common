using Felix.Tools.Attributes;

namespace Felix.Tools.Tools
{
	[TextTool("Upper", "To")]
	class ToUpperCase : ITool
	{
		public void Start()
		{
			OutputBox.Show(AppContext.SelectedText.ToUpper());
			return;
		}
	}
}
