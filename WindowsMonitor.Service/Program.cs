using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsMonitor.CIM.Hardware.Sensors;
using WindowsMonitor.Win32;
using WindowsMonitor.Win32.Hardware.Cooling;
using WindowsMonitor.Win32.Hardware.Probes;
using WindowsMonitor.Win32.Performance.Raw;

namespace WindowsMonitor.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var os = Win32.OperatingSystem.Retrieve().ToArray();
            var currents = CurrentSensor.Retrieve().ToArray();
            var voltages = VoltageSensor.Retrieve().ToArray();
            var temperatures = TemperatureSensor.Retrieve().ToArray();

            var kkk = CurrentProbe.Retrieve().ToArray();
            var temp = TemperatureProbe.Retrieve().ToArray();

            var power = CounterPowerMeter.Retrieve().ToArray();

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
