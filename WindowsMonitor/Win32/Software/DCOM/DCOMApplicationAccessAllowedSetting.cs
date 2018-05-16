using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Software.DCOM
{
    /// <summary>
    /// </summary>
    public sealed class DCOMApplicationAccessAllowedSetting
    {
		public string Element { get; private set; }
		public string Setting { get; private set; }

        public static IEnumerable<DCOMApplicationAccessAllowedSetting> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<DCOMApplicationAccessAllowedSetting> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<DCOMApplicationAccessAllowedSetting> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DCOMApplicationAccessAllowedSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new DCOMApplicationAccessAllowedSetting
                {
                     Element =  (managementObject.Properties["Element"]?.Value?.ToString()),
		 Setting =  (managementObject.Properties["Setting"]?.Value?.ToString())
                };
        }
    }
}