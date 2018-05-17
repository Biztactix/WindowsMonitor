using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSIInitiator_TargetAddress
    {
		public uint OSBusNumber { get; private set; }
		public string OSDeviceName { get; private set; }
		public uint OSLunNumber { get; private set; }
		public uint OSTargetNumber { get; private set; }

        public static IEnumerable<MSiSCSIInitiator_TargetAddress> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSIInitiator_TargetAddress> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSIInitiator_TargetAddress> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSIInitiator_TargetAddress");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSIInitiator_TargetAddress
                {
                     OSBusNumber = (uint) (managementObject.Properties["OSBusNumber"]?.Value ?? default(uint)),
		 OSDeviceName = (string) (managementObject.Properties["OSDeviceName"]?.Value ?? default(string)),
		 OSLunNumber = (uint) (managementObject.Properties["OSLunNumber"]?.Value ?? default(uint)),
		 OSTargetNumber = (uint) (managementObject.Properties["OSTargetNumber"]?.Value ?? default(uint))
                };
        }
    }
}