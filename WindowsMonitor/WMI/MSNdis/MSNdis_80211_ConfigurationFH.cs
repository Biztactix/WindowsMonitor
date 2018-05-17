using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_80211_ConfigurationFH
    {
		public uint DwellTime { get; private set; }
		public uint FHLength { get; private set; }
		public uint HopPattern { get; private set; }
		public uint HopSet { get; private set; }

        public static IEnumerable<MSNdis_80211_ConfigurationFH> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_80211_ConfigurationFH> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_80211_ConfigurationFH> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_80211_ConfigurationFH");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_80211_ConfigurationFH
                {
                     DwellTime = (uint) (managementObject.Properties["DwellTime"]?.Value ?? default(uint)),
		 FHLength = (uint) (managementObject.Properties["FHLength"]?.Value ?? default(uint)),
		 HopPattern = (uint) (managementObject.Properties["HopPattern"]?.Value ?? default(uint)),
		 HopSet = (uint) (managementObject.Properties["HopSet"]?.Value ?? default(uint))
                };
        }
    }
}