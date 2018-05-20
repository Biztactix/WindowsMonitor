using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class NIC
    {
		public string DnsServerAddresses { get; private set; }
		public uint Flags { get; private set; }
		public string IpAddresses { get; private set; }
		public uint Ipv4Index { get; private set; }
		public uint Ipv6Index { get; private set; }
		public string NICDescription { get; private set; }
		public ulong PhysicalAddr { get; private set; }
		public uint PhysicalAddrLen { get; private set; }

        public static IEnumerable<NIC> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NIC> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NIC> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SystemConfig_V2_NIC");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NIC
                {
                     DnsServerAddresses = (string) (managementObject.Properties["DnsServerAddresses"]?.Value ?? default(string)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 IpAddresses = (string) (managementObject.Properties["IpAddresses"]?.Value ?? default(string)),
		 Ipv4Index = (uint) (managementObject.Properties["Ipv4Index"]?.Value ?? default(uint)),
		 Ipv6Index = (uint) (managementObject.Properties["Ipv6Index"]?.Value ?? default(uint)),
		 NICDescription = (string) (managementObject.Properties["NICDescription"]?.Value ?? default(string)),
		 PhysicalAddr = (ulong) (managementObject.Properties["PhysicalAddr"]?.Value ?? default(ulong)),
		 PhysicalAddrLen = (uint) (managementObject.Properties["PhysicalAddrLen"]?.Value ?? default(uint))
                };
        }
    }
}