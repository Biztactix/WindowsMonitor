using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Windows.Win32Reg
{
    /// <summary>
    /// </summary>
    public sealed class SMSAdvancedClientPorts
    {
		public uint HttpsPortName { get; private set; }
		public string InstanceKey { get; private set; }
		public uint PortName { get; private set; }

        public static IEnumerable<SMSAdvancedClientPorts> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SMSAdvancedClientPorts> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SMSAdvancedClientPorts> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32Reg_SMSAdvancedClientPorts");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SMSAdvancedClientPorts
                {
                     HttpsPortName = (uint) (managementObject.Properties["HttpsPortName"]?.Value ?? default(uint)),
		 InstanceKey = (string) (managementObject.Properties["InstanceKey"]?.Value),
		 PortName = (uint) (managementObject.Properties["PortName"]?.Value ?? default(uint))
                };
        }
    }
}