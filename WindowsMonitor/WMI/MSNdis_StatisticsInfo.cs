using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_StatisticsInfo
    {
		public dynamic Header { get; private set; }
		public ulong ifHCInBroadcastOctets { get; private set; }
		public ulong ifHCInBroadcastPkts { get; private set; }
		public ulong ifHCInMulticastOctets { get; private set; }
		public ulong ifHCInMulticastPkts { get; private set; }
		public ulong ifHCInOctets { get; private set; }
		public ulong ifHCInUcastOctets { get; private set; }
		public ulong ifHCInUcastPkts { get; private set; }
		public ulong ifHCOutBroadcastOctets { get; private set; }
		public ulong ifHCOutBroadcastPkts { get; private set; }
		public ulong ifHCOutMulticastOctets { get; private set; }
		public ulong ifHCOutMulticastPkts { get; private set; }
		public ulong ifHCOutOctets { get; private set; }
		public ulong ifHCOutUcastOctets { get; private set; }
		public ulong ifHCOutUcastPkts { get; private set; }
		public ulong ifInDiscards { get; private set; }
		public ulong ifInErrors { get; private set; }
		public ulong ifOutDiscards { get; private set; }
		public ulong ifOutErrors { get; private set; }
		public uint SupportedStatistics { get; private set; }

        public static IEnumerable<MSNdis_StatisticsInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_StatisticsInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_StatisticsInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_StatisticsInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_StatisticsInfo
                {
                     Header = (dynamic) (managementObject.Properties["Header"]?.Value ?? default(dynamic)),
		 ifHCInBroadcastOctets = (ulong) (managementObject.Properties["ifHCInBroadcastOctets"]?.Value ?? default(ulong)),
		 ifHCInBroadcastPkts = (ulong) (managementObject.Properties["ifHCInBroadcastPkts"]?.Value ?? default(ulong)),
		 ifHCInMulticastOctets = (ulong) (managementObject.Properties["ifHCInMulticastOctets"]?.Value ?? default(ulong)),
		 ifHCInMulticastPkts = (ulong) (managementObject.Properties["ifHCInMulticastPkts"]?.Value ?? default(ulong)),
		 ifHCInOctets = (ulong) (managementObject.Properties["ifHCInOctets"]?.Value ?? default(ulong)),
		 ifHCInUcastOctets = (ulong) (managementObject.Properties["ifHCInUcastOctets"]?.Value ?? default(ulong)),
		 ifHCInUcastPkts = (ulong) (managementObject.Properties["ifHCInUcastPkts"]?.Value ?? default(ulong)),
		 ifHCOutBroadcastOctets = (ulong) (managementObject.Properties["ifHCOutBroadcastOctets"]?.Value ?? default(ulong)),
		 ifHCOutBroadcastPkts = (ulong) (managementObject.Properties["ifHCOutBroadcastPkts"]?.Value ?? default(ulong)),
		 ifHCOutMulticastOctets = (ulong) (managementObject.Properties["ifHCOutMulticastOctets"]?.Value ?? default(ulong)),
		 ifHCOutMulticastPkts = (ulong) (managementObject.Properties["ifHCOutMulticastPkts"]?.Value ?? default(ulong)),
		 ifHCOutOctets = (ulong) (managementObject.Properties["ifHCOutOctets"]?.Value ?? default(ulong)),
		 ifHCOutUcastOctets = (ulong) (managementObject.Properties["ifHCOutUcastOctets"]?.Value ?? default(ulong)),
		 ifHCOutUcastPkts = (ulong) (managementObject.Properties["ifHCOutUcastPkts"]?.Value ?? default(ulong)),
		 ifInDiscards = (ulong) (managementObject.Properties["ifInDiscards"]?.Value ?? default(ulong)),
		 ifInErrors = (ulong) (managementObject.Properties["ifInErrors"]?.Value ?? default(ulong)),
		 ifOutDiscards = (ulong) (managementObject.Properties["ifOutDiscards"]?.Value ?? default(ulong)),
		 ifOutErrors = (ulong) (managementObject.Properties["ifOutErrors"]?.Value ?? default(ulong)),
		 SupportedStatistics = (uint) (managementObject.Properties["SupportedStatistics"]?.Value ?? default(uint))
                };
        }
    }
}