using Felix.Common;

namespace Felix.Tools.Tools
{
	[Tool("To CH", "Translate")]
	class TranslateToChinese : ITool
	{
		const string urlFormat = "https://fanyi.baidu.com/?aldtype=16047#en/zh/{0}";
		public void Start()
		{
			UrlHelper.Open(string.Format(urlFormat, AppContext.SelectedText));
		}
	}
}
