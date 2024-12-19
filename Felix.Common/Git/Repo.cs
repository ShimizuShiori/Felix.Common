namespace Felix.Common.Git
{
    public class Repo : IRepo
    {
        readonly DirectoryInfo rootDirectory;

        public Repo(string rootPath)
        {
            this.rootDirectory = new DirectoryInfo(rootPath);
        }

        public DirectoryInfo RootDirectory => rootDirectory;

        public string CurrentBranch => throw new NotImplementedException();

        public void RunCommand(string command, Stream outputStream, Stream errorStream)
        {
            throw new NotImplementedException();
        }
    }
}
