using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.Fs
{
    /// <summary>
    /// </summary>
    public sealed class FolderRedirectionHealth
    {
		public byte HealthStatus { get; private set; }
		public DateTime LastSuccessfulSyncTime { get; private set; }
		public byte LastSyncStatus { get; private set; }
		public DateTime LastSyncTime { get; private set; }
		public bool OfflineAccessEnabled { get; private set; }
		public string OfflineFileNameFolderGUID { get; private set; }
		public bool Redirected { get; private set; }

        public static IEnumerable<FolderRedirectionHealth> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FolderRedirectionHealth> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FolderRedirectionHealth> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_FolderRedirectionHealth");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FolderRedirectionHealth
                {
                     HealthStatus = (byte) (managementObject.Properties["HealthStatus"]?.Value ?? default(byte)),
		 LastSuccessfulSyncTime = ManagementDateTimeConverter.ToDateTime (managementObject.Properties["LastSuccessfulSyncTime"]?.Value as string ?? "00010102000000.000000+060"),
		 LastSyncStatus = (byte) (managementObject.Properties["LastSyncStatus"]?.Value ?? default(byte)),
		 LastSyncTime = ManagementDateTimeConverter.ToDateTime (managementObject.Properties["LastSyncTime"]?.Value as string ?? "00010102000000.000000+060"),
		 OfflineAccessEnabled = (bool) (managementObject.Properties["OfflineAccessEnabled"]?.Value ?? default(bool)),
		 OfflineFileNameFolderGUID = (string) (managementObject.Properties["OfflineFileNameFolderGUID"]?.Value),
		 Redirected = (bool) (managementObject.Properties["Redirected"]?.Value ?? default(bool))
                };
        }
    }
}