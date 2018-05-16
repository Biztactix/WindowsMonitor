using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Storage
{
    /// <summary>
    /// </summary>
    public sealed class LogicalDiskRootDirectory
    {
		public short GroupComponent { get; private set; }
		public short PartComponent { get; private set; }

        public static IEnumerable<LogicalDiskRootDirectory> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<LogicalDiskRootDirectory> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<LogicalDiskRootDirectory> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_LogicalDiskRootDirectory");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new LogicalDiskRootDirectory
                {
                     GroupComponent = (short) (managementObject.Properties["GroupComponent"]?.Value ?? default(short)),
		 PartComponent = (short) (managementObject.Properties["PartComponent"]?.Value ?? default(short))
                };
        }
    }
}