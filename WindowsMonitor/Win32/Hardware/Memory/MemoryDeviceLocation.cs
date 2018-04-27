using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.Memory
{
    /// <summary>
    /// </summary>
    public sealed class MemoryDeviceLocation
    {
		public short Antecedent { get; private set; }
		public short Dependent { get; private set; }

        public static IEnumerable<MemoryDeviceLocation> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MemoryDeviceLocation> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MemoryDeviceLocation> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_MemoryDeviceLocation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MemoryDeviceLocation
                {
                     Antecedent = (short) (managementObject.Properties["Antecedent"]?.Value ?? default(short)),
		 Dependent = (short) (managementObject.Properties["Dependent"]?.Value ?? default(short))
                };
        }
    }
}