using Felix.Tools.Attributes;
using Felix.Tools.Messages;
using System.Text.RegularExpressions;

namespace Felix.Tools.Tools.Search
{
	[TextTool("Impl", "Search")]
	class SearchImplementor : ITool
	{
		public void Start()
		{
			ThreadPool.QueueUserWorkItem(FindImpl, AppContext.SelectedText);
		}

		static void FindImpl(object? state)
		{
			if (state == null || !(state is string interfaceName))
				return;

			var configPath = ChooesForm<string>.Show(string.Empty, new Dictionary<string, string>()
			{
				{ "CargoWiseOne.Test", @"C:\git\wtg\Glow\Glow\DotNet\Service\Security.IntegrationTesting\CargoWiseOne.Test\Unity.config"},
				{ "ServiceNexus", @"C:\git\wtg\Glow\Glow\DotNet\Service\Common\ServiceNexus\unity.config" },
				{ "Service", @"C:\git\wtg\Glow\Glow\DotNet\Service\Common\Service\unity.config" },
				{ "PlatformBuilder.Shell", @"C:\git\wtg\Glow\Glow\DotNet\Client\PlatformBuilder\Shell\PlatformBuilder.Shell\unity.config" },
			}, string.Empty);
			if (configPath == string.Empty)
				return;

			var allContent = File.ReadAllText(configPath);
			var regex = new Regex($@"\<register\s*type=\""[\w.]*{interfaceName}""[`\d]*,?");
			foreach (Match match in regex.Matches(allContent))
			{
				FindRegistion(allContent, match);
			}
		}

		private static void FindRegistion(string allContent, Match match)
		{
			const string endTag = "</register>";
			var index = match.Index;
			var endIndex = allContent.IndexOf(">", index);
			if (allContent[endIndex] == '/')
			{
				AppContext.PublishUiMessage(new ShowOutputMessage(allContent.Substring(index, endIndex + 1 - index)));
			}
			else
			{
				endIndex = allContent.IndexOf(endTag, index);
				endIndex = endIndex + endTag.Length;
				AppContext.PublishUiMessage(new ShowOutputMessage(allContent.Substring(index, endIndex - index)));
			}
		}
	}
}
