using System;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace Delete
{
    class Program
    {
        static void Main(string[] args)
        {
           Run();
        }
        const string dir = "C:\\Users\\cberman\\AppData";

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
     
        public static void Run()
        {           

            var first = new FileWatcher(dir);
            var second = new FileWatcher("C:\\Program Files\\Tecnomatix_13.0\\eMPower");

            // Wait for the user to quit the program.
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
            first.Stop();
            second.Stop();

        }

     
    }
}
