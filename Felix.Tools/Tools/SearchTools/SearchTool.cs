namespace Felix.Tools.Tools.SearchTools
{

	abstract class SearchTool : ITool
	{
		public void Start()
		{
			string keyword = AppContext.SelectedText;
			StartSearch(keyword);

		}

		protected abstract void StartSearch(string keyword);
	}
}
