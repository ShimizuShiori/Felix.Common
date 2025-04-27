using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.SharedInfos;

namespace Felix.Tools.Tools.Search
{
    [Tool("GitHubTools", "Repo")]
    class SearchInGithub : ITool
    {
        public void Start()
        {
            var actions = new List<string>
            {
                "PR",
            };
            if (!string.IsNullOrEmpty(AppContext.SelectedText))
            {
                actions.Add("Search");
            }

            var action = ChooesForm<string>.Show(actions);
            switch (action)
            {
                case "Search":
                    Search();
                    break;
                case "PR":
                    OpenPR();
                    break;
                default:
                    break;
            }
        }

        void Search()
        {
            var repo = ChooesForm<GitHubRepoInfo>.Show("Select a Repo", GitHubRepos.Repos, new GitHubRepoInfo("", "", ""));
            if (string.IsNullOrEmpty(repo.shortName))
                UriHelper.Open(@$"https://github.com/search?q=org%3AWiseTechGlobal%20{AppContext.SelectedText}&type=code");
            else
                UriHelper.Open(@$"https://github.com/search?q=org%3AWiseTechGlobal+repo:{repo.fullName}+{AppContext.SelectedText}&type=code");
        }

        void OpenPR()
        {
            var repo = ChooesForm<GitHubRepoInfo>.Show("Select a Repo", GitHubRepos.Repos, new GitHubRepoInfo("", "", ""));
            if (string.IsNullOrEmpty(repo.shortName))
                return;

            if (!string.IsNullOrEmpty(AppContext.SelectedText))
                UriHelper.Open($"https://github.com/{repo.fullName}/pulls?q=is%3Apr+is%3Aopen+{AppContext.SelectedText}+author%3AShimizuShiori");
            else
                UriHelper.Open($"https://github.com/{repo.fullName}/pulls/ShimizuShiori");
        }
    }
}
