using Felix.Tools.Attributes;

namespace Felix.Tools.Tools.CSharps
{
	[TextTool("Del-", "C#")]
	class RemoveMinusFromGuid : ITool
	{
		public void Start()
		{
			OutputBox.Show(AppContext.SelectedText.Replace("-", ""));
		}
	}
}
