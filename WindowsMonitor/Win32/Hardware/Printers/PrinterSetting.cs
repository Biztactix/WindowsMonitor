using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.Printers
{
    /// <summary>
    /// </summary>
    public sealed class PrinterSetting
    {
		public string Element { get; private set; }
		public string Setting { get; private set; }

        public static IEnumerable<PrinterSetting> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<PrinterSetting> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PrinterSetting> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PrinterSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PrinterSetting
                {
                     Element =  (managementObject.Properties["Element"]?.Value?.ToString()),
		 Setting =  (managementObject.Properties["Setting"]?.Value?.ToString())
                };
        }
    }
}