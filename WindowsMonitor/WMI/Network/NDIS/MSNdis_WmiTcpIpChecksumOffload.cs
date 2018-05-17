using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_WmiTcpIpChecksumOffload
    {
		public dynamic IPv4Receive { get; private set; }
		public dynamic IPv4Transmit { get; private set; }
		public dynamic IPv6Receive { get; private set; }
		public dynamic IPv6Transmit { get; private set; }

        public static IEnumerable<MSNdis_WmiTcpIpChecksumOffload> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_WmiTcpIpChecksumOffload> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_WmiTcpIpChecksumOffload> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_WmiTcpIpChecksumOffload");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_WmiTcpIpChecksumOffload
                {
                     IPv4Receive = (dynamic) (managementObject.Properties["IPv4Receive"]?.Value ?? default(dynamic)),
		 IPv4Transmit = (dynamic) (managementObject.Properties["IPv4Transmit"]?.Value ?? default(dynamic)),
		 IPv6Receive = (dynamic) (managementObject.Properties["IPv6Receive"]?.Value ?? default(dynamic)),
		 IPv6Transmit = (dynamic) (managementObject.Properties["IPv6Transmit"]?.Value ?? default(dynamic))
                };
        }
    }
}