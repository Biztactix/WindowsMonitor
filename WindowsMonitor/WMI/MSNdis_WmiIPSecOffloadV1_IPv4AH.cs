using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_WmiIPSecOffloadV1_IPv4AH
    {
		public uint Md5 { get; private set; }
		public uint Receive { get; private set; }
		public uint Send { get; private set; }
		public uint Sha_1 { get; private set; }
		public uint Transport { get; private set; }
		public uint Tunnel { get; private set; }

        public static IEnumerable<MSNdis_WmiIPSecOffloadV1_IPv4AH> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_WmiIPSecOffloadV1_IPv4AH> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_WmiIPSecOffloadV1_IPv4AH> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_WmiIPSecOffloadV1_IPv4AH");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_WmiIPSecOffloadV1_IPv4AH
                {
                     Md5 = (uint) (managementObject.Properties["Md5"]?.Value ?? default(uint)),
		 Receive = (uint) (managementObject.Properties["Receive"]?.Value ?? default(uint)),
		 Send = (uint) (managementObject.Properties["Send"]?.Value ?? default(uint)),
		 Sha_1 = (uint) (managementObject.Properties["Sha_1"]?.Value ?? default(uint)),
		 Transport = (uint) (managementObject.Properties["Transport"]?.Value ?? default(uint)),
		 Tunnel = (uint) (managementObject.Properties["Tunnel"]?.Value ?? default(uint))
                };
        }
    }
}