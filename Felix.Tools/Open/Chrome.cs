using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix.Tools.Open
{
    [Tool("Chrome", "Open")]
    internal class Chrome : ITool
    {
        record Profile(string ProfileName, string UserName);

        const string PathToChrome = @"C:\Users\Felix.Fei\AppData\Local\Google\Chrome\Application\chrome.exe";
        const string PathToUserData = @"C:\Users\Felix.Fei\AppData\Local\Google\Chrome\User Data";

        readonly LazySlim<IEnumerable<Profile>> Profiles = new(() =>
        {
            var dirs = System.IO.Directory.GetDirectories(PathToUserData);
            return dirs.Select(dir => Path.Combine(dir, "Preferences"))
                        .Where(p => System.IO.File.Exists(p))
                        .Select(ConvertToProfileInfo);

        });

        static Profile ConvertToProfileInfo(string pathToPreferences)
        {
            string content = File.ReadAllText(pathToPreferences);
            int j = content.LastIndexOf("\",\"password_account_storage_settings\"");
            int i = content.LastIndexOf("\"", j - 1);
            string userName = content.Substring(i + 1, j - i - 1);
            return new Profile(Path.GetFileName(Path.GetDirectoryName(pathToPreferences)!), userName);
        }

        // C:\Users\Felix.Fei\AppData\Local\Google\Chrome\Application\chrome.exe --profile-directory="Profile 1"

        public void Start()
        {
            var selectedProfile = ChooesForm<Profile>.Show("Select Profile", Profiles.Value.ToMap(x => (x.UserName, x)), new Profile("Default", "Default"));
            Process.Start(PathToChrome, $"--profile-directory=\"{selectedProfile.ProfileName}\"");
        }
    }
}
