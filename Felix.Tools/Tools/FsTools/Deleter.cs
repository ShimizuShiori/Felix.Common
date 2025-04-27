using Felix.Tools.Attributes;
using System.Diagnostics;

namespace Felix.Tools.Tools.FsTools
{
    [FileTool("Delete", "FS")]
    class Deleter : ITool
    {
        public void Start()
        {
            foreach (var file in AppContext.SelectedFilePathList)
            {
                DeleteForcely(file);
            }
            if (string.IsNullOrEmpty(AppContext.SelectedText))
                return;

            if (File.Exists(AppContext.SelectedText) || Directory.Exists(AppContext.SelectedText))
                DeleteForcely(AppContext.SelectedText);
        }

        void DeleteForcely(string path)
        {
            var psi = new ProcessStartInfo(@"C:\Program Files (x86)\IObit\IObit Unlocker\IObitUnlocker.exe");
            psi.Arguments = $"/Delete {path}";
            psi.UseShellExecute = true;
            using (var p = Process.Start(psi))
            {

            }
        }
    }
}
