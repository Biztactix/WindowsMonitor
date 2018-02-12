using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using WindowsMonitor;
using DiskDrive = WindowsMonitor.Win32.DiskDrive;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = typeof(__ACE).Assembly.GetTypes();

            foreach (var type in types)
            {
                var info = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                var method = info.First(x => x.Name == "Retrieve" && x.GetParameters().Length == 0);

                var returnValue = method.Invoke(null, new object[] { }) as IEnumerable;
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(returnValue);
            }

            var probes = WindowsMonitor.CIM.Process.Retrieve();
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
