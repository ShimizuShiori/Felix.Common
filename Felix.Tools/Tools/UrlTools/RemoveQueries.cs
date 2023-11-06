using Felix.Tools.Attributes;

namespace Felix.Tools.Tools.UrlTools
{
	[TextTool("RemoveQueryString", "URL")]
	class RemoveQueries : ITool
	{
		public void Start()
		{
			int i = AppContext.SelectedText.IndexOf("?");
			if (i == -1)
			{
				OutputBox.Show(AppContext.SelectedText);
				return;
			}
			OutputBox.Show(AppContext.SelectedText.Substring(0, i));
		}
	}
}
