using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_DeviceWakeOnMagicPacketOnly
    {
		public bool Active { get; private set; }
		public bool EnableWakeOnMagicPacketOnly { get; private set; }
		public string InstanceName { get; private set; }

        public static IEnumerable<MSNdis_DeviceWakeOnMagicPacketOnly> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_DeviceWakeOnMagicPacketOnly> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_DeviceWakeOnMagicPacketOnly> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_DeviceWakeOnMagicPacketOnly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_DeviceWakeOnMagicPacketOnly
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 EnableWakeOnMagicPacketOnly = (bool) (managementObject.Properties["EnableWakeOnMagicPacketOnly"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string))
                };
        }
    }
}