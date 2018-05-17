using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ISCSI_RedirectSessionInfo
    {
		public uint ConnectionCount { get; private set; }
		public dynamic[] RedirectPortalList { get; private set; }
		public uint TargetPortalGroupTag { get; private set; }
		public ulong UniqueSessionId { get; private set; }

        public static IEnumerable<ISCSI_RedirectSessionInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ISCSI_RedirectSessionInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ISCSI_RedirectSessionInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ISCSI_RedirectSessionInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ISCSI_RedirectSessionInfo
                {
                     ConnectionCount = (uint) (managementObject.Properties["ConnectionCount"]?.Value ?? default(uint)),
		 RedirectPortalList = (dynamic[]) (managementObject.Properties["RedirectPortalList"]?.Value ?? new dynamic[0]),
		 TargetPortalGroupTag = (uint) (managementObject.Properties["TargetPortalGroupTag"]?.Value ?? default(uint)),
		 UniqueSessionId = (ulong) (managementObject.Properties["UniqueSessionId"]?.Value ?? default(ulong))
                };
        }
    }
}