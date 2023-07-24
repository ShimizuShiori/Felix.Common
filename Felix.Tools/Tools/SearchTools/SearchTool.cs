namespace Felix.Tools.Tools.SearchTools
{

	abstract class SearchTool : ITool
	{
		public void Start()
		{
			string keyword = AppContext.SelectedText;
			string otherWord = InputBox.Show("Additional Words");
			StartSearch(keyword, otherWord);

		}

		protected abstract void StartSearch(string keyword, string otherWord);
	}
}
