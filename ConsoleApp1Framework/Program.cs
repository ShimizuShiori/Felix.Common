using System;
using System.DirectoryServices;

namespace ConsoleApp1Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DirectoryEntry root = new DirectoryEntry("LDAP://wtg.zone", "corp\\felix.fei", "@kimi12345678", (AuthenticationTypes)193);
                DirectorySearcher directorySearcher = new DirectorySearcher()
                {
                    //       "(&(objectCategory=CargoWiseOne-Instance)(cargoWiseOne-ServerName=hyetip.db.sand.wtg.zone)(cargoWiseOne-DatabaseName=OdysseyHYETIP))"
                    Filter = "(&(objectCategory=CargoWiseOne-Instance)(cargoWiseOne-ServerName=ediprod.db.wtg.zone)(cargoWiseOne-DatabaseName=ediprod))",
                    SearchRoot = root,
                    SearchScope = SearchScope.Subtree,
                    PageSize = 500,
                    ClientTimeout = TimeSpan.FromMinutes(5),
                };
                directorySearcher.PropertiesToLoad.Add("name");
                //directorySearcher.PropertiesToLoad.Add("cargoWiseOne-ServerName");
                //directorySearcher.PropertiesToLoad.Add("cargoWiseOne-DatabaseName");
                //directorySearcher.PropertiesToLoad.Add("Flags");
                //directorySearcher.PropertiesToLoad.Add("cargoWiseOne-BlazorUrlAuthority");

                var r = directorySearcher.FindAll();
                Console.WriteLine(r.Count);
                if (r.Count > 0)
                {
                    Console.WriteLine(r[0].Properties["name"][0]);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
