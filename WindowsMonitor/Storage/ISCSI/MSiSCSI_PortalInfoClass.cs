using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.ISCSI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSI_PortalInfoClass
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public uint PortalInfoCount { get; private set; }
		public dynamic[] PortalInformation { get; private set; }

        public static IEnumerable<MSiSCSI_PortalInfoClass> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSI_PortalInfoClass> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSI_PortalInfoClass> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSI_PortalInfoClass");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSI_PortalInfoClass
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 PortalInfoCount = (uint) (managementObject.Properties["PortalInfoCount"]?.Value ?? default(uint)),
		 PortalInformation = (dynamic[]) (managementObject.Properties["PortalInformation"]?.Value ?? new dynamic[0])
                };
        }
    }
}