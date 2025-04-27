namespace Felix.Tools.SharedInfos
{
    record GitHubRepoInfo(string fullName, string shortName, string path);

    static class GitHubRepos
    {
        static Dictionary<string, GitHubRepoInfo> repos;
        static DateTime lastReadTime = DateTime.MinValue;
        static TimeSpan cacheDuraion = TimeSpan.FromMinutes(5);

        public static Dictionary<string, GitHubRepoInfo> Repos
        {
            get
            {
                if (DateTime.Now - lastReadTime > cacheDuraion)
                {
                    InitRepos();
                    lastReadTime = DateTime.Now;
                }
                return repos;
            }
        }

        static void InitRepos()
        {
            repos = new Dictionary<string, GitHubRepoInfo>();
            var rootPath = @"C:\git\Github";

            foreach (var dir1 in Directory.GetDirectories(rootPath))
            {
                if (Directory.Exists(Path.Combine(dir1, ".git")))
                {
                    continue;
                }
                foreach (var dir2 in System.IO.Directory.GetDirectories(dir1))
                {
                    if (!Directory.Exists(Path.Combine(dir2, ".git")))
                    {
                        continue;
                    }
                    var fullName = $"{Path.GetFileName(dir1)}/{Path.GetFileName(dir2)}";
                    var shortName = Path.GetFileName(dir2);
                    var repoPath = Path.Combine(dir1, shortName);
                    repos[shortName] = new GitHubRepoInfo(fullName, shortName, repoPath);
                }
            }
        }
    }
}
