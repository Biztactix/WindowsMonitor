using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class OfflineFiles_ClientSideCaching
    {
		public ulong ApplicationBytesReadFromCache { get; private set; }
		public ulong ApplicationBytesReadFromServer { get; private set; }
		public ulong ApplicationBytesReadFromServerNotCached { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong PrefetchBytesReadFromCache { get; private set; }
		public ulong PrefetchBytesReadFromServer { get; private set; }
		public uint PrefetchOperationsQueued { get; private set; }
		public ulong SMBBranchCacheBytesPublished { get; private set; }
		public ulong SMBBranchCacheBytesReceived { get; private set; }
		public ulong SMBBranchCacheBytesRequested { get; private set; }
		public ulong SMBBranchCacheBytesRequestedFromServer { get; private set; }
		public ulong SMBBranchCacheHashBytesReceived { get; private set; }
		public uint SMBBranchCacheHashesReceived { get; private set; }
		public uint SMBBranchCacheHashesRequested { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<OfflineFiles_ClientSideCaching> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<OfflineFiles_ClientSideCaching> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<OfflineFiles_ClientSideCaching> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_OfflineFiles_ClientSideCaching");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new OfflineFiles_ClientSideCaching
                {
                     ApplicationBytesReadFromCache = (ulong) (managementObject.Properties["ApplicationBytesReadFromCache"]?.Value ?? default(ulong)),
		 ApplicationBytesReadFromServer = (ulong) (managementObject.Properties["ApplicationBytesReadFromServer"]?.Value ?? default(ulong)),
		 ApplicationBytesReadFromServerNotCached = (ulong) (managementObject.Properties["ApplicationBytesReadFromServerNotCached"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PrefetchBytesReadFromCache = (ulong) (managementObject.Properties["PrefetchBytesReadFromCache"]?.Value ?? default(ulong)),
		 PrefetchBytesReadFromServer = (ulong) (managementObject.Properties["PrefetchBytesReadFromServer"]?.Value ?? default(ulong)),
		 PrefetchOperationsQueued = (uint) (managementObject.Properties["PrefetchOperationsQueued"]?.Value ?? default(uint)),
		 SMBBranchCacheBytesPublished = (ulong) (managementObject.Properties["SMBBranchCacheBytesPublished"]?.Value ?? default(ulong)),
		 SMBBranchCacheBytesReceived = (ulong) (managementObject.Properties["SMBBranchCacheBytesReceived"]?.Value ?? default(ulong)),
		 SMBBranchCacheBytesRequested = (ulong) (managementObject.Properties["SMBBranchCacheBytesRequested"]?.Value ?? default(ulong)),
		 SMBBranchCacheBytesRequestedFromServer = (ulong) (managementObject.Properties["SMBBranchCacheBytesRequestedFromServer"]?.Value ?? default(ulong)),
		 SMBBranchCacheHashBytesReceived = (ulong) (managementObject.Properties["SMBBranchCacheHashBytesReceived"]?.Value ?? default(ulong)),
		 SMBBranchCacheHashesReceived = (uint) (managementObject.Properties["SMBBranchCacheHashesReceived"]?.Value ?? default(uint)),
		 SMBBranchCacheHashesRequested = (uint) (managementObject.Properties["SMBBranchCacheHashesRequested"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}