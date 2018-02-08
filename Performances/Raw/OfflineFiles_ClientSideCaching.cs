using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_OfflineFiles_ClientSideCaching
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

        public static PerfRawData_OfflineFiles_ClientSideCaching[] Retrieve(string remote, string username,
            string password)
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

        public static PerfRawData_OfflineFiles_ClientSideCaching[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_OfflineFiles_ClientSideCaching[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_OfflineFiles_ClientSideCaching");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_OfflineFiles_ClientSideCaching>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_OfflineFiles_ClientSideCaching
                {
                    ApplicationBytesReadFromCache =
                        (ulong) managementObject.Properties["ApplicationBytesReadFromCache"].Value,
                    ApplicationBytesReadFromServer =
                        (ulong) managementObject.Properties["ApplicationBytesReadFromServer"].Value,
                    ApplicationBytesReadFromServerNotCached = (ulong) managementObject
                        .Properties["ApplicationBytesReadFromServerNotCached"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PrefetchBytesReadFromCache =
                        (ulong) managementObject.Properties["PrefetchBytesReadFromCache"].Value,
                    PrefetchBytesReadFromServer = (ulong) managementObject.Properties["PrefetchBytesReadFromServer"]
                        .Value,
                    PrefetchOperationsQueued = (uint) managementObject.Properties["PrefetchOperationsQueued"].Value,
                    SMBBranchCacheBytesPublished = (ulong) managementObject.Properties["SMBBranchCacheBytesPublished"]
                        .Value,
                    SMBBranchCacheBytesReceived = (ulong) managementObject.Properties["SMBBranchCacheBytesReceived"]
                        .Value,
                    SMBBranchCacheBytesRequested = (ulong) managementObject.Properties["SMBBranchCacheBytesRequested"]
                        .Value,
                    SMBBranchCacheBytesRequestedFromServer = (ulong) managementObject
                        .Properties["SMBBranchCacheBytesRequestedFromServer"].Value,
                    SMBBranchCacheHashBytesReceived =
                        (ulong) managementObject.Properties["SMBBranchCacheHashBytesReceived"].Value,
                    SMBBranchCacheHashesReceived = (uint) managementObject.Properties["SMBBranchCacheHashesReceived"]
                        .Value,
                    SMBBranchCacheHashesRequested = (uint) managementObject.Properties["SMBBranchCacheHashesRequested"]
                        .Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}