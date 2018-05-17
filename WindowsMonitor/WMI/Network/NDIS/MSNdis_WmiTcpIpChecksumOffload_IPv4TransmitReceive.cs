using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_WmiTcpIpChecksumOffload_IPv4TransmitReceive
    {
		public uint Encapsulation { get; private set; }
		public uint IpChecksum { get; private set; }
		public uint IpOptionsSupported { get; private set; }
		public uint TcpChecksum { get; private set; }
		public uint TcpOptionsSupported { get; private set; }
		public uint UdpChecksum { get; private set; }

        public static IEnumerable<MSNdis_WmiTcpIpChecksumOffload_IPv4TransmitReceive> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_WmiTcpIpChecksumOffload_IPv4TransmitReceive> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_WmiTcpIpChecksumOffload_IPv4TransmitReceive> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_WmiTcpIpChecksumOffload_IPv4TransmitReceive");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_WmiTcpIpChecksumOffload_IPv4TransmitReceive
                {
                     Encapsulation = (uint) (managementObject.Properties["Encapsulation"]?.Value ?? default(uint)),
		 IpChecksum = (uint) (managementObject.Properties["IpChecksum"]?.Value ?? default(uint)),
		 IpOptionsSupported = (uint) (managementObject.Properties["IpOptionsSupported"]?.Value ?? default(uint)),
		 TcpChecksum = (uint) (managementObject.Properties["TcpChecksum"]?.Value ?? default(uint)),
		 TcpOptionsSupported = (uint) (managementObject.Properties["TcpOptionsSupported"]?.Value ?? default(uint)),
		 UdpChecksum = (uint) (managementObject.Properties["UdpChecksum"]?.Value ?? default(uint))
                };
        }
    }
}