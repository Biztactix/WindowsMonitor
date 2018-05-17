using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_MediaSupported
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public uint[] NdisMediaSupported { get; private set; }
		public uint NumberElements { get; private set; }

        public static IEnumerable<MSNdis_MediaSupported> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_MediaSupported> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_MediaSupported> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_MediaSupported");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_MediaSupported
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 NdisMediaSupported = (uint[]) (managementObject.Properties["NdisMediaSupported"]?.Value ?? new uint[0]),
		 NumberElements = (uint) (managementObject.Properties["NumberElements"]?.Value ?? default(uint))
                };
        }
    }
}