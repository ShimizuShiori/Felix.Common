namespace Felix.Tools.SharedInfos
{
    static class TFSInfos
    {
        public static IEnumerable<string> GetProjects()
        {
            return Directory.GetDirectories(@"C:\git\wtg").Select(x => Path.GetFileName(x)).Except(new string[] { "Github" }).OrderBy(x => x);
        }

        public static IEnumerable<string> GetRepos(string project)
        {
            return Directory.GetDirectories($@"C:\git\wtg\{project}").Select(x => Path.GetFileName(x)).OrderBy(x => x);
        }
    }
}
