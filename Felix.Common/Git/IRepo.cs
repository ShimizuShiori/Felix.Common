namespace Felix.Common.Git
{
    public interface IRepo
    {
        DirectoryInfo RootDirectory { get; }

        string CurrentBranch { get; }

        void RunCommand(string command, Stream outputStream, Stream errorStream);
    }
}
