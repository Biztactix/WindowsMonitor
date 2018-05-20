using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.ISCSI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSIInitiator_MethodClass
    {
		public string iSCSINodeName { get; private set; }

        public static IEnumerable<MSiSCSIInitiator_MethodClass> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSIInitiator_MethodClass> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSIInitiator_MethodClass> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSIInitiator_MethodClass");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSIInitiator_MethodClass
                {
                     iSCSINodeName = (string) (managementObject.Properties["iSCSINodeName"]?.Value ?? default(string))
                };
        }
    }
}