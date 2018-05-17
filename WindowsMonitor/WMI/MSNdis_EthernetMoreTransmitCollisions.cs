using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_EthernetMoreTransmitCollisions
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public uint NdisEthernetMoreTransmitCollisions { get; private set; }

        public static IEnumerable<MSNdis_EthernetMoreTransmitCollisions> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_EthernetMoreTransmitCollisions> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_EthernetMoreTransmitCollisions> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_EthernetMoreTransmitCollisions");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_EthernetMoreTransmitCollisions
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 NdisEthernetMoreTransmitCollisions = (uint) (managementObject.Properties["NdisEthernetMoreTransmitCollisions"]?.Value ?? default(uint))
                };
        }
    }
}