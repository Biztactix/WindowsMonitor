using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_NetworkLinkSpeed
    {
		public uint Inbound { get; private set; }
		public uint Outbound { get; private set; }

        public static IEnumerable<MSNdis_NetworkLinkSpeed> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_NetworkLinkSpeed> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_NetworkLinkSpeed> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_NetworkLinkSpeed");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_NetworkLinkSpeed
                {
                     Inbound = (uint) (managementObject.Properties["Inbound"]?.Value ?? default(uint)),
		 Outbound = (uint) (managementObject.Properties["Outbound"]?.Value ?? default(uint))
                };
        }
    }
}