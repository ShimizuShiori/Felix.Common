using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.Tools
{
	[Tool("En", "Translate")]
	class TranslateToEnglish : ITool
	{
		const string urlFormat = "https://fanyi.baidu.com/?aldtype=16047#zh/en/{0}";
		public void Start()
		{
			UriHelper.Open(string.Format(urlFormat, AppContext.SelectedText));
		}
	}
}
