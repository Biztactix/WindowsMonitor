using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_EthernetMaximumMulticastListSize
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public uint NdisEthernetMaximumMulticastListSize { get; private set; }

        public static IEnumerable<MSNdis_EthernetMaximumMulticastListSize> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_EthernetMaximumMulticastListSize> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_EthernetMaximumMulticastListSize> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_EthernetMaximumMulticastListSize");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_EthernetMaximumMulticastListSize
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 NdisEthernetMaximumMulticastListSize = (uint) (managementObject.Properties["NdisEthernetMaximumMulticastListSize"]?.Value ?? default(uint))
                };
        }
    }
}