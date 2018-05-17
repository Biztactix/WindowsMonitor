using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSIInitiator_PortalGroup
    {
		public uint Index { get; private set; }
		public dynamic[] Portals { get; private set; }

        public static IEnumerable<MSiSCSIInitiator_PortalGroup> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSIInitiator_PortalGroup> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSIInitiator_PortalGroup> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSIInitiator_PortalGroup");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSIInitiator_PortalGroup
                {
                     Index = (uint) (managementObject.Properties["Index"]?.Value ?? default(uint)),
		 Portals = (dynamic[]) (managementObject.Properties["Portals"]?.Value ?? new dynamic[0])
                };
        }
    }
}