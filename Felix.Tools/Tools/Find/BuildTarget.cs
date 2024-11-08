using Felix.Tools.Attributes;
using System.Text;

namespace Felix.Tools.Tools.Find
{
    [FileTool("Build Target", "Find")]
    class BuildTarget : ITool
    {
        public void Start()
        {
            var builder = new StringBuilder();
            foreach (var file in AppContext.SelectedFilePathList)
            {
                if (TryFindBuildXml(file, out var targetName))
                {
                    builder.AppendLine(targetName);
                }
            }
            OutputBox.Show(builder.ToString());
        }

        static bool TryFindBuildXml(string path, out string targetName)
        {
            targetName = string.Empty;
            var folder = Path.GetDirectoryName(path);
            if (folder == null)
            {
                return false;
            }
            if (File.Exists(Path.Combine(folder, "Build.xml")))
            {
                targetName = folder;
                return true;
            }
            return TryFindBuildXml(folder, out targetName);
        }
    }
}
