using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.Fs
{
    /// <summary>
    /// </summary>
    public sealed class FolderRedirectionHealthConfiguration
    {
		public uint LastSyncDurationCautionInHours { get; private set; }
		public uint LastSyncDurationUnhealthyInHours { get; private set; }

        public static IEnumerable<FolderRedirectionHealthConfiguration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FolderRedirectionHealthConfiguration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FolderRedirectionHealthConfiguration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_FolderRedirectionHealthConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FolderRedirectionHealthConfiguration
                {
                     LastSyncDurationCautionInHours = (uint) (managementObject.Properties["LastSyncDurationCautionInHours"]?.Value ?? default(uint)),
		 LastSyncDurationUnhealthyInHours = (uint) (managementObject.Properties["LastSyncDurationUnhealthyInHours"]?.Value ?? default(uint))
                };
        }
    }
}