using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_80211_ConfigurationInfo
    {
		public uint ATIMWindow { get; private set; }
		public uint BeaconPeriod { get; private set; }
		public uint ConfigLength { get; private set; }
		public uint DSConfig { get; private set; }
		public dynamic FHConfig { get; private set; }

        public static IEnumerable<MSNdis_80211_ConfigurationInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_80211_ConfigurationInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_80211_ConfigurationInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_80211_ConfigurationInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_80211_ConfigurationInfo
                {
                     ATIMWindow = (uint) (managementObject.Properties["ATIMWindow"]?.Value ?? default(uint)),
		 BeaconPeriod = (uint) (managementObject.Properties["BeaconPeriod"]?.Value ?? default(uint)),
		 ConfigLength = (uint) (managementObject.Properties["ConfigLength"]?.Value ?? default(uint)),
		 DSConfig = (uint) (managementObject.Properties["DSConfig"]?.Value ?? default(uint)),
		 FHConfig = (dynamic) (managementObject.Properties["FHConfig"]?.Value ?? default(dynamic))
                };
        }
    }
}