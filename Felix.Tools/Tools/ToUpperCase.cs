using Felix.Tools.Attributes;

namespace Felix.Tools.Tools
{
	[TextTool("Upper", "To")]
	class ToUpperCase : ITool
	{
		public Task StartAsync()
		{
			OutputBox.Show(AppContext.SelectedText.ToUpper());
			return Task.CompletedTask;
		}
	}
}
