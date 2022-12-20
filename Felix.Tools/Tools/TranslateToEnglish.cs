using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.Tools
{
	[Tool("En", "Translate")]
	class TranslateToEnglish : SyncTool
	{
		const string urlFormat = "https://fanyi.baidu.com/?aldtype=16047#zh/en/{0}";
		protected override void Start()
		{
			UrlHelper.Open(string.Format(urlFormat, AppContext.SelectedText));
		}
	}
}
