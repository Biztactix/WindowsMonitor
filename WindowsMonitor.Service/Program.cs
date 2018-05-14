using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsMonitor.Win32;

namespace WindowsMonitor.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var os = Win32.OperatingSystem.Retrieve().ToArray();


                Console.ReadLine();
            }
            catch (Exception e)
            {
                var n = e.GetType().Name;
                Console.WriteLine(n);
                throw;
            }

        }
    }
}
