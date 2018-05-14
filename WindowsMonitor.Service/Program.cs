using System;
using System.Linq;
using System.Security.Permissions;
using WindowsMonitor.CIM.Hardware;
using WindowsMonitor.CIM.Hardware.Sensors;
using WindowsMonitor.Win32.Hardware.Cooling;
using WindowsMonitor.Win32.Hardware.Probes;
using WindowsMonitor.Win32.Performance.Raw;

namespace WindowsMonitor.Service
{
    class Program
    {
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        static void Main(string[] args)
        {
            var os = Win32.OperatingSystem.Retrieve().ToArray();
            var currents = CurrentProbe.Retrieve().ToArray();
            var voltages = VoltageProbe.Retrieve().ToArray();
            var temperatures = TemperatureProbe.Retrieve().ToArray();

            var processors = Processor.Retrieve().ToArray();
            var processors2 = Win32.Hardware.Processor.Retrieve().ToArray();

            try
            {
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
