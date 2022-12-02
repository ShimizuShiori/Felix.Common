using Felix.Common;

namespace Felix.Tools.Tools
{
	[Tool("To EN", "Translate")]
	class TranslateToEnglish : SyncTool
	{
		const string urlFormat = "https://fanyi.baidu.com/?aldtype=16047#zh/en/{0}";
		protected override void Start()
		{
			UrlHelper.Open(string.Format(urlFormat, AppContext.SelectedText));
		}
	}
}
