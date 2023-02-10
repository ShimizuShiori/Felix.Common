using Felix.Tools.Attributes;
using System.Diagnostics;

namespace Felix.Tools.Tools.TestTools
{
	[Tool("StringAnalyzer", "Tests")]
	class GlowResourceStringAnalyzer : ITool
	{
		public void Start()
		{
			using (var p = new Process())
			{
				p.StartInfo.FileName = @"C:\git\wtg\Glow\Glow\Language\Bin\Analyzer\net472\ResourceStringAnalyzer.exe";
				p.StartInfo.Arguments = @"C:\git\wtg\Glow\Glow\DotNet";
				p.Start();

				p.WaitForExit();
			}
			using (var p = new Process())
			{
				p.StartInfo.FileName = @"C:\git\wtg\Glow\Glow\DotNet\Bin\UncaptionedStrings.xml";
				p.StartInfo.UseShellExecute = true;
				p.Start();
			}
		}
	}
}
