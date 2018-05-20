using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.ISCSI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSI_DiscoveryConfig
    {
		public bool Active { get; private set; }
		public bool AutomaticiSNSDiscovery { get; private set; }
		public string InitiatorName { get; private set; }
		public string InstanceName { get; private set; }
		public dynamic iSNSServer { get; private set; }
		public bool PerformiSNSDiscovery { get; private set; }
		public bool PerformSLPDiscovery { get; private set; }

        public static IEnumerable<MSiSCSI_DiscoveryConfig> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSI_DiscoveryConfig> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSI_DiscoveryConfig> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSI_DiscoveryConfig");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSI_DiscoveryConfig
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 AutomaticiSNSDiscovery = (bool) (managementObject.Properties["AutomaticiSNSDiscovery"]?.Value ?? default(bool)),
		 InitiatorName = (string) (managementObject.Properties["InitiatorName"]?.Value ?? default(string)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 iSNSServer = (dynamic) (managementObject.Properties["iSNSServer"]?.Value ?? default(dynamic)),
		 PerformiSNSDiscovery = (bool) (managementObject.Properties["PerformiSNSDiscovery"]?.Value ?? default(bool)),
		 PerformSLPDiscovery = (bool) (managementObject.Properties["PerformSLPDiscovery"]?.Value ?? default(bool))
                };
        }
    }
}