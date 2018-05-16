using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.DiskDrives
{
    /// <summary>
    /// </summary>
    public sealed class DiskDrivePhysicalMedia
    {
		public string Antecedent { get; private set; }
		public string Dependent { get; private set; }

        public static IEnumerable<DiskDrivePhysicalMedia> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<DiskDrivePhysicalMedia> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<DiskDrivePhysicalMedia> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DiskDrivePhysicalMedia");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
            {
                var media = new DiskDrivePhysicalMedia
                {
                    Antecedent = managementObject.Properties["Antecedent"]?.Value as string,
                    Dependent = managementObject.Properties["Dependent"]?.Value as string
                };
                yield return media;
            }
        }
    }
}