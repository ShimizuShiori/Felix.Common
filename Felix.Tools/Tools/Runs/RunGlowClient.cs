using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.Tools.Runs
{
	[Tool("HtmlClient", "Glow")]
	class RunGlowClient : ITool
	{
		public void Start()
		{
			ProcessHelper.Start("dotnet", @"run --project C:\git\wtg\Glow\Glow\DotNet\HTML\Client\Client\Client.csproj");
			UriHelper.Open("https://localhost:59415/CST");
		}
	}
}
