using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class FolderRedirectionHealth
    {
        /// <summary>
        ///     The health status of this folder, based on the values that were set in the
        ///     Win32_FolderRedirectionHealthConfiguration properties.
        /// </summary>
        public byte HealthStatus { get; private set; }

        /// <summary>
        ///     The last time this folder was successfully synchronized to the Offline Files cache.
        /// </summary>
        public DateTime LastSuccessfulSyncTime { get; private set; }

        /// <summary>
        ///     The status of the last attempt to synchronize this folder to the Offline Files cache.
        /// </summary>
        public byte LastSyncStatus { get; private set; }

        /// <summary>
        ///     The last time an attempt was made to synchronized this folder to the Offline Files cache, even if it was
        ///     unsuccessful.
        /// </summary>
        public DateTime LastSyncTime { get; private set; }

        /// <summary>
        ///     If true, the Offline Files feature is enabled for this folder.
        /// </summary>
        public bool OfflineAccessEnabled { get; private set; }

        /// <summary>
        ///     known folder unique id (guid)
        /// </summary>
        public string OfflineFileNameFolderGUID { get; private set; }

        /// <summary>
        ///     If true, indicate if this folder is being redirected.
        /// </summary>
        public bool Redirected { get; private set; }

        public static FolderRedirectionHealth[] Retrieve(string remote, string username, string password)
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

        public static FolderRedirectionHealth[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static FolderRedirectionHealth[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_FolderRedirectionHealth");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<FolderRedirectionHealth>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new FolderRedirectionHealth
                {
                    HealthStatus = (byte) managementObject.Properties["HealthStatus"].Value,
                    LastSuccessfulSyncTime = (DateTime) managementObject.Properties["LastSuccessfulSyncTime"].Value,
                    LastSyncStatus = (byte) managementObject.Properties["LastSyncStatus"].Value,
                    LastSyncTime = (DateTime) managementObject.Properties["LastSyncTime"].Value,
                    OfflineAccessEnabled = (bool) managementObject.Properties["OfflineAccessEnabled"].Value,
                    OfflineFileNameFolderGUID = (string) managementObject.Properties["OfflineFileNameFolderGUID"].Value,
                    Redirected = (bool) managementObject.Properties["Redirected"].Value
                });

            return list.ToArray();
        }
    }
}