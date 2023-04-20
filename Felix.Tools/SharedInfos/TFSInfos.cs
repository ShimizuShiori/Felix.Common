namespace Felix.Tools.SharedInfos
{
	static class TFSInfos
	{
		static readonly IDictionary<string, IEnumerable<string>> repos;

		static TFSInfos()
		{
			repos = new Dictionary<string, IEnumerable<string>>();
			repos["CargoWise"] = new string[]
			{
				"Dev",
				"Shared"
			};
			repos["Glow"] = new string[]
			{
				"Glow",
				"Shared"
			};
			repos["Shared"] = new string[]
			{
				"WTG.Foundation",
				"WTG.ErrorReporting"
			};
		}

		public static IEnumerable<string> GetProjects()
		{
			return repos.Keys;
		}

		public static IEnumerable<string> GetRepos(string project)
		{
			return repos[project];
		}
	}
}
