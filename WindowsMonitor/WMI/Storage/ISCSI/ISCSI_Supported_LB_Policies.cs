using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ISCSI_Supported_LB_Policies
    {
		public uint iSCSI_PathCount { get; private set; }
		public dynamic[] iSCSI_Paths { get; private set; }
		public uint LoadBalancePolicy { get; private set; }
		public ulong UniqueSessionId { get; private set; }

        public static IEnumerable<ISCSI_Supported_LB_Policies> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ISCSI_Supported_LB_Policies> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ISCSI_Supported_LB_Policies> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ISCSI_Supported_LB_Policies");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ISCSI_Supported_LB_Policies
                {
                     iSCSI_PathCount = (uint) (managementObject.Properties["iSCSI_PathCount"]?.Value ?? default(uint)),
		 iSCSI_Paths = (dynamic[]) (managementObject.Properties["iSCSI_Paths"]?.Value ?? new dynamic[0]),
		 LoadBalancePolicy = (uint) (managementObject.Properties["LoadBalancePolicy"]?.Value ?? default(uint)),
		 UniqueSessionId = (ulong) (managementObject.Properties["UniqueSessionId"]?.Value ?? default(ulong))
                };
        }
    }
}