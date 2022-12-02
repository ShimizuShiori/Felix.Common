using Felix.Common;

namespace Felix.Tools.Tools
{
	[Tool("To CH", "Translate")]
	class TranslateToChinese : SyncTool
	{
		const string urlFormat = "https://fanyi.baidu.com/?aldtype=16047#en/zh/{0}";
		protected override void Start()
		{
			UrlHelper.Open(string.Format(urlFormat, AppContext.SelectedText));
		}
	}
}
