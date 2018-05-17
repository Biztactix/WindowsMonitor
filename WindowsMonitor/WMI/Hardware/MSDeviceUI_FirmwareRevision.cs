using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSDeviceUI_FirmwareRevision
    {
		public bool Active { get; private set; }
		public string FirmwareRevision { get; private set; }
		public string InstanceName { get; private set; }

        public static IEnumerable<MSDeviceUI_FirmwareRevision> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSDeviceUI_FirmwareRevision> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSDeviceUI_FirmwareRevision> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSDeviceUI_FirmwareRevision");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSDeviceUI_FirmwareRevision
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 FirmwareRevision = (string) (managementObject.Properties["FirmwareRevision"]?.Value ?? default(string)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string))
                };
        }
    }
}