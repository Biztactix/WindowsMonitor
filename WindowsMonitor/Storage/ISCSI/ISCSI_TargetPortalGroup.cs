using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.ISCSI
{
    /// <summary>
    /// </summary>
    public sealed class ISCSI_TargetPortalGroup
    {
		public uint PortalCount { get; private set; }
		public dynamic[] Portals { get; private set; }

        public static IEnumerable<ISCSI_TargetPortalGroup> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ISCSI_TargetPortalGroup> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ISCSI_TargetPortalGroup> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ISCSI_TargetPortalGroup");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ISCSI_TargetPortalGroup
                {
                     PortalCount = (uint) (managementObject.Properties["PortalCount"]?.Value ?? default(uint)),
		 Portals = (dynamic[]) (managementObject.Properties["Portals"]?.Value ?? new dynamic[0])
                };
        }
    }
}