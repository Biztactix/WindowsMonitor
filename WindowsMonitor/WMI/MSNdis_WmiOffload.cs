using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_WmiOffload
    {
		public dynamic Checksum { get; private set; }
		public uint Flags { get; private set; }
		public dynamic Header { get; private set; }
		public dynamic IPsecV1 { get; private set; }
		public dynamic LsoV1 { get; private set; }
		public dynamic LsoV2 { get; private set; }

        public static IEnumerable<MSNdis_WmiOffload> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_WmiOffload> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_WmiOffload> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_WmiOffload");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_WmiOffload
                {
                     Checksum = (dynamic) (managementObject.Properties["Checksum"]?.Value ?? default(dynamic)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Header = (dynamic) (managementObject.Properties["Header"]?.Value ?? default(dynamic)),
		 IPsecV1 = (dynamic) (managementObject.Properties["IPsecV1"]?.Value ?? default(dynamic)),
		 LsoV1 = (dynamic) (managementObject.Properties["LsoV1"]?.Value ?? default(dynamic)),
		 LsoV2 = (dynamic) (managementObject.Properties["LsoV2"]?.Value ?? default(dynamic))
                };
        }
    }
}