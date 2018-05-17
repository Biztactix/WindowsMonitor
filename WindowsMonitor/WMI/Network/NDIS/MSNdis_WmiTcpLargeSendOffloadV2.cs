using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_WmiTcpLargeSendOffloadV2
    {
		public dynamic WmiIPv4 { get; private set; }
		public dynamic WmiIPv6 { get; private set; }

        public static IEnumerable<MSNdis_WmiTcpLargeSendOffloadV2> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_WmiTcpLargeSendOffloadV2> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_WmiTcpLargeSendOffloadV2> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_WmiTcpLargeSendOffloadV2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_WmiTcpLargeSendOffloadV2
                {
                     WmiIPv4 = (dynamic) (managementObject.Properties["WmiIPv4"]?.Value ?? default(dynamic)),
		 WmiIPv6 = (dynamic) (managementObject.Properties["WmiIPv6"]?.Value ?? default(dynamic))
                };
        }
    }
}