using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_WmiIPSecOffloadV1
    {
		public dynamic WmiIPv4AH { get; private set; }
		public dynamic WmiIPv4ESP { get; private set; }
		public dynamic WmiSupported { get; private set; }

        public static IEnumerable<MSNdis_WmiIPSecOffloadV1> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_WmiIPSecOffloadV1> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_WmiIPSecOffloadV1> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_WmiIPSecOffloadV1");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_WmiIPSecOffloadV1
                {
                     WmiIPv4AH = (dynamic) (managementObject.Properties["WmiIPv4AH"]?.Value ?? default(dynamic)),
		 WmiIPv4ESP = (dynamic) (managementObject.Properties["WmiIPv4ESP"]?.Value ?? default(dynamic)),
		 WmiSupported = (dynamic) (managementObject.Properties["WmiSupported"]?.Value ?? default(dynamic))
                };
        }
    }
}