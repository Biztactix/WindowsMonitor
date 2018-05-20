using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.ISCSI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSIInitiator_TargetMappings
    {
		public string InitiatorName { get; private set; }
		public dynamic[] LUNList { get; private set; }
		public uint OSBusNumber { get; private set; }
		public string OSDeviceName { get; private set; }
		public uint OSTargetNumber { get; private set; }
		public string TargetName { get; private set; }

        public static IEnumerable<MSiSCSIInitiator_TargetMappings> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSIInitiator_TargetMappings> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSIInitiator_TargetMappings> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSIInitiator_TargetMappings");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSIInitiator_TargetMappings
                {
                     InitiatorName = (string) (managementObject.Properties["InitiatorName"]?.Value ?? default(string)),
		 LUNList = (dynamic[]) (managementObject.Properties["LUNList"]?.Value ?? new dynamic[0]),
		 OSBusNumber = (uint) (managementObject.Properties["OSBusNumber"]?.Value ?? default(uint)),
		 OSDeviceName = (string) (managementObject.Properties["OSDeviceName"]?.Value ?? default(string)),
		 OSTargetNumber = (uint) (managementObject.Properties["OSTargetNumber"]?.Value ?? default(uint)),
		 TargetName = (string) (managementObject.Properties["TargetName"]?.Value ?? default(string))
                };
        }
    }
}