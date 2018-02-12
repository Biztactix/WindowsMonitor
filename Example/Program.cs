using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsMonitor.CIM;
using DiskDrive = WindowsMonitor.Win32.DiskDrive;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var probes = TemperatureSensor.Retrieve();
            foreach (var temp in probes)
            {
                Console.WriteLine(temp.Name);
            }


            var drives = DiskDrive.Retrieve();

            foreach (var drive in drives)
            {
                Console.WriteLine(drive.Name);
            }
        }
    }
}
