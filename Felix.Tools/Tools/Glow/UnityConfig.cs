using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.Tools.Glow
{
	[Tool("unity.config", "Glow")]
	class UnityConfig : ITool
	{
		static readonly Dictionary<string, string> pathMapping = new Dictionary<string, string>()
			{
				{ "CW1", "C:\\git\\wtg\\Glow\\Glow\\DotNet\\Service\\Common\\Service\\unity.config" },
				{ "Nexus", "C:\\git\\wtg\\Glow\\Glow\\DotNet\\Service\\Common\\Service\\unity.config" },
				{ "PB", "C:\\git\\wtg\\Glow\\Glow\\DotNet\\Bin\\PlatformBuilder\\unity.config" }
			};
		public void Start()
		{
			var selectedPath = ChooesForm<string>.Show("", pathMapping, "CW1");
			VSCodeRunner.OpenFile(selectedPath);
		}
	}
}
