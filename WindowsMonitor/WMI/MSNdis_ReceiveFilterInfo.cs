using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_ReceiveFilterInfo
    {
		public uint FilterId { get; private set; }
		public uint FilterType { get; private set; }
		public uint Flags { get; private set; }
		public dynamic Header { get; private set; }

        public static IEnumerable<MSNdis_ReceiveFilterInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_ReceiveFilterInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_ReceiveFilterInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_ReceiveFilterInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_ReceiveFilterInfo
                {
                     FilterId = (uint) (managementObject.Properties["FilterId"]?.Value ?? default(uint)),
		 FilterType = (uint) (managementObject.Properties["FilterType"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Header = (dynamic) (managementObject.Properties["Header"]?.Value ?? default(dynamic))
                };
        }
    }
}