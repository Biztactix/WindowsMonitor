using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.ISCSI
{
    /// <summary>
    /// </summary>
    public sealed class ISCSI_TargetMapping
    {
		public bool FromPersistentLogin { get; private set; }
		public uint LUNCount { get; private set; }
		public dynamic[] LUNList { get; private set; }
		public uint OSBus { get; private set; }
		public uint OSTarget { get; private set; }
		public ulong Reserved { get; private set; }
		public string TargetName { get; private set; }
		public ulong UniqueSessionId { get; private set; }

        public static IEnumerable<ISCSI_TargetMapping> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ISCSI_TargetMapping> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ISCSI_TargetMapping> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ISCSI_TargetMapping");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ISCSI_TargetMapping
                {
                     FromPersistentLogin = (bool) (managementObject.Properties["FromPersistentLogin"]?.Value ?? default(bool)),
		 LUNCount = (uint) (managementObject.Properties["LUNCount"]?.Value ?? default(uint)),
		 LUNList = (dynamic[]) (managementObject.Properties["LUNList"]?.Value ?? new dynamic[0]),
		 OSBus = (uint) (managementObject.Properties["OSBus"]?.Value ?? default(uint)),
		 OSTarget = (uint) (managementObject.Properties["OSTarget"]?.Value ?? default(uint)),
		 Reserved = (ulong) (managementObject.Properties["Reserved"]?.Value ?? default(ulong)),
		 TargetName = (string) (managementObject.Properties["TargetName"]?.Value ?? default(string)),
		 UniqueSessionId = (ulong) (managementObject.Properties["UniqueSessionId"]?.Value ?? default(ulong))
                };
        }
    }
}