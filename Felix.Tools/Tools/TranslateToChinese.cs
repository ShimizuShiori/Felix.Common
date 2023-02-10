using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.Tools
{
	[Tool("Ch", "Translate")]
	class TranslateToChinese : ITool
	{
		const string urlFormat = "https://fanyi.baidu.com/?aldtype=16047#en/zh/{0}";
		public void Start()
		{
			UrlHelper.Open(string.Format(urlFormat, AppContext.SelectedText));
		}
	}
}
