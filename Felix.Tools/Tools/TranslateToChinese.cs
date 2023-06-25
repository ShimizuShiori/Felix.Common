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
			UriHelper.Open(string.Format(urlFormat, AppContext.SelectedText));
		}
	}
}
