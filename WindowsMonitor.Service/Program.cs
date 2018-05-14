using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsMonitor.CIM;

namespace WindowsMonitor.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var drives = DiskDrive.Retrieve().ToArray();
            var media = PhysicalMedia.Retrieve().ToArray();
            Console.WriteLine(media.Length);

            Console.ReadLine();
        }
    }
}
