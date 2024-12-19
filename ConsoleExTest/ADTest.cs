using System.DirectoryServices;

namespace ConsoleExTest
{

    internal class ADTest
    {
        public static void Start()
        {
            DirectoryEntry root = new DirectoryEntry("LDAP://wtg.zone", "Felix.Fei", "@kimi12345678", (AuthenticationTypes)193);
            DirectorySearcher directorySearcher = new DirectorySearcher()
            {
                Filter = "(&(objectCategory=CargoWiseOne-Instance)(cargoWiseOne-ServerName=hyetip.db.sand.wtg.zone)(cargoWiseOne-DatabaseName=OdysseyHYETIP))",
                SearchRoot = root,
                SearchScope = SearchScope.Subtree,
                PageSize = 500,
                ClientTimeout = TimeSpan.FromMinutes(5),
            };
            directorySearcher.PropertiesToLoad.Add("name");
            directorySearcher.PropertiesToLoad.Add("cargoWiseOne-ServerName");
            directorySearcher.PropertiesToLoad.Add("cargoWiseOne-DatabaseName");
            directorySearcher.PropertiesToLoad.Add("Flags");
            directorySearcher.PropertiesToLoad.Add("cargoWiseOne-BlazorUrlAuthority");

            using(directorySearcher)
            {
                var r =directorySearcher.FindOne();
            }
        }
    }
}
