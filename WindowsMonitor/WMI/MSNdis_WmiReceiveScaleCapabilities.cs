using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_WmiReceiveScaleCapabilities
    {
		public uint CapabilitiesFlags { get; private set; }
		public dynamic Header { get; private set; }
		public uint NumberOfInterruptMessages { get; private set; }
		public uint NumberOfReceiveQueues { get; private set; }

        public static IEnumerable<MSNdis_WmiReceiveScaleCapabilities> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_WmiReceiveScaleCapabilities> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_WmiReceiveScaleCapabilities> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_WmiReceiveScaleCapabilities");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_WmiReceiveScaleCapabilities
                {
                     CapabilitiesFlags = (uint) (managementObject.Properties["CapabilitiesFlags"]?.Value ?? default(uint)),
		 Header = (dynamic) (managementObject.Properties["Header"]?.Value ?? default(dynamic)),
		 NumberOfInterruptMessages = (uint) (managementObject.Properties["NumberOfInterruptMessages"]?.Value ?? default(uint)),
		 NumberOfReceiveQueues = (uint) (managementObject.Properties["NumberOfReceiveQueues"]?.Value ?? default(uint))
                };
        }
    }
}