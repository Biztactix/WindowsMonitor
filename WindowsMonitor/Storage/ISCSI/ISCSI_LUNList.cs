using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.ISCSI
{
    /// <summary>
    /// </summary>
    public sealed class ISCSI_LUNList
    {
		public uint OSLUN { get; private set; }
		public uint Reserved { get; private set; }
		public ulong TargetLUN { get; private set; }

        public static IEnumerable<ISCSI_LUNList> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ISCSI_LUNList> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ISCSI_LUNList> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ISCSI_LUNList");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ISCSI_LUNList
                {
                     OSLUN = (uint) (managementObject.Properties["OSLUN"]?.Value ?? default(uint)),
		 Reserved = (uint) (managementObject.Properties["Reserved"]?.Value ?? default(uint)),
		 TargetLUN = (ulong) (managementObject.Properties["TargetLUN"]?.Value ?? default(ulong))
                };
        }
    }
}