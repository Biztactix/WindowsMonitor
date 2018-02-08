using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_W3SVCW3WPCounterProvider_W3SVCW3WP
    {
        public uint ActiveFlushedEntries { get; private set; }
        public uint ActiveRequests { get; private set; }
        public uint ActiveThreadsCount { get; private set; }
        public string Caption { get; private set; }
        public ulong CurrentFileCacheMemoryUsage { get; private set; }
        public uint CurrentFilesCached { get; private set; }
        public uint CurrentMetadataCached { get; private set; }
        public uint CurrentURIsCached { get; private set; }
        public string Description { get; private set; }
        public uint FileCacheFlushes { get; private set; }
        public uint FileCacheHits { get; private set; }
        public uint FileCacheHitsPersec { get; private set; }
        public uint FileCacheMisses { get; private set; }
        public uint FileCacheMissesPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong MaximumFileCacheMemoryUsage { get; private set; }
        public uint MaximumThreadsCount { get; private set; }
        public uint MetadataCacheFlushes { get; private set; }
        public uint MetadataCacheHits { get; private set; }
        public uint MetadataCacheHitsPersec { get; private set; }
        public uint MetadataCacheMisses { get; private set; }
        public uint MetadataCacheMissesPersec { get; private set; }
        public string Name { get; private set; }
        public uint OutputCacheCurrentFlushedItems { get; private set; }
        public uint OutputCacheCurrentItems { get; private set; }
        public ulong OutputCacheCurrentMemoryUsage { get; private set; }
        public uint OutputCacheHitsPersec { get; private set; }
        public uint OutputCacheMissesPersec { get; private set; }
        public uint OutputCacheTotalFlushedItems { get; private set; }
        public uint OutputCacheTotalFlushes { get; private set; }
        public uint OutputCacheTotalHits { get; private set; }
        public uint OutputCacheTotalMisses { get; private set; }
        public uint Percent401HTTPResponseSent { get; private set; }
        public uint Percent403HTTPResponseSent { get; private set; }
        public uint Percent404HTTPResponseSent { get; private set; }
        public uint Percent500HTTPResponseSent { get; private set; }
        public uint RequestsPerSec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalFilesCached { get; private set; }
        public uint TotalFlushedFiles { get; private set; }
        public uint TotalFlushedMetadata { get; private set; }
        public uint TotalFlushedURIs { get; private set; }
        public uint TotalHTTPRequestsServed { get; private set; }
        public uint TotalMetadataCached { get; private set; }
        public uint TotalThreads { get; private set; }
        public uint TotalURIsCached { get; private set; }
        public uint URICacheFlushes { get; private set; }
        public uint URICacheHits { get; private set; }
        public uint UriCacheHitsPersec { get; private set; }
        public uint URICacheMisses { get; private set; }
        public uint UriCacheMissesPersec { get; private set; }
        public uint WebSocketActiveRequests { get; private set; }
        public uint WebSocketConnectionAttemptsPerSec { get; private set; }
        public uint WebSocketConnectionsAcceptedPerSec { get; private set; }
        public uint WebSocketConnectionsRejectedPerSec { get; private set; }

        public static PerfFormattedData_W3SVCW3WPCounterProvider_W3SVCW3WP[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_W3SVCW3WPCounterProvider_W3SVCW3WP[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_W3SVCW3WPCounterProvider_W3SVCW3WP[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_W3SVCW3WPCounterProvider_W3SVCW3WP");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_W3SVCW3WPCounterProvider_W3SVCW3WP>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_W3SVCW3WPCounterProvider_W3SVCW3WP
                {
                    ActiveFlushedEntries = (uint) managementObject.Properties["ActiveFlushedEntries"].Value,
                    ActiveRequests = (uint) managementObject.Properties["ActiveRequests"].Value,
                    ActiveThreadsCount = (uint) managementObject.Properties["ActiveThreadsCount"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentFileCacheMemoryUsage = (ulong) managementObject.Properties["CurrentFileCacheMemoryUsage"]
                        .Value,
                    CurrentFilesCached = (uint) managementObject.Properties["CurrentFilesCached"].Value,
                    CurrentMetadataCached = (uint) managementObject.Properties["CurrentMetadataCached"].Value,
                    CurrentURIsCached = (uint) managementObject.Properties["CurrentURIsCached"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FileCacheFlushes = (uint) managementObject.Properties["FileCacheFlushes"].Value,
                    FileCacheHits = (uint) managementObject.Properties["FileCacheHits"].Value,
                    FileCacheHitsPersec = (uint) managementObject.Properties["FileCacheHitsPersec"].Value,
                    FileCacheMisses = (uint) managementObject.Properties["FileCacheMisses"].Value,
                    FileCacheMissesPersec = (uint) managementObject.Properties["FileCacheMissesPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MaximumFileCacheMemoryUsage = (ulong) managementObject.Properties["MaximumFileCacheMemoryUsage"]
                        .Value,
                    MaximumThreadsCount = (uint) managementObject.Properties["MaximumThreadsCount"].Value,
                    MetadataCacheFlushes = (uint) managementObject.Properties["MetadataCacheFlushes"].Value,
                    MetadataCacheHits = (uint) managementObject.Properties["MetadataCacheHits"].Value,
                    MetadataCacheHitsPersec = (uint) managementObject.Properties["MetadataCacheHitsPersec"].Value,
                    MetadataCacheMisses = (uint) managementObject.Properties["MetadataCacheMisses"].Value,
                    MetadataCacheMissesPersec = (uint) managementObject.Properties["MetadataCacheMissesPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OutputCacheCurrentFlushedItems =
                        (uint) managementObject.Properties["OutputCacheCurrentFlushedItems"].Value,
                    OutputCacheCurrentItems = (uint) managementObject.Properties["OutputCacheCurrentItems"].Value,
                    OutputCacheCurrentMemoryUsage =
                        (ulong) managementObject.Properties["OutputCacheCurrentMemoryUsage"].Value,
                    OutputCacheHitsPersec = (uint) managementObject.Properties["OutputCacheHitsPersec"].Value,
                    OutputCacheMissesPersec = (uint) managementObject.Properties["OutputCacheMissesPersec"].Value,
                    OutputCacheTotalFlushedItems = (uint) managementObject.Properties["OutputCacheTotalFlushedItems"]
                        .Value,
                    OutputCacheTotalFlushes = (uint) managementObject.Properties["OutputCacheTotalFlushes"].Value,
                    OutputCacheTotalHits = (uint) managementObject.Properties["OutputCacheTotalHits"].Value,
                    OutputCacheTotalMisses = (uint) managementObject.Properties["OutputCacheTotalMisses"].Value,
                    Percent401HTTPResponseSent = (uint) managementObject.Properties["Percent401HTTPResponseSent"].Value,
                    Percent403HTTPResponseSent = (uint) managementObject.Properties["Percent403HTTPResponseSent"].Value,
                    Percent404HTTPResponseSent = (uint) managementObject.Properties["Percent404HTTPResponseSent"].Value,
                    Percent500HTTPResponseSent = (uint) managementObject.Properties["Percent500HTTPResponseSent"].Value,
                    RequestsPerSec = (uint) managementObject.Properties["RequestsPerSec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalFilesCached = (uint) managementObject.Properties["TotalFilesCached"].Value,
                    TotalFlushedFiles = (uint) managementObject.Properties["TotalFlushedFiles"].Value,
                    TotalFlushedMetadata = (uint) managementObject.Properties["TotalFlushedMetadata"].Value,
                    TotalFlushedURIs = (uint) managementObject.Properties["TotalFlushedURIs"].Value,
                    TotalHTTPRequestsServed = (uint) managementObject.Properties["TotalHTTPRequestsServed"].Value,
                    TotalMetadataCached = (uint) managementObject.Properties["TotalMetadataCached"].Value,
                    TotalThreads = (uint) managementObject.Properties["TotalThreads"].Value,
                    TotalURIsCached = (uint) managementObject.Properties["TotalURIsCached"].Value,
                    URICacheFlushes = (uint) managementObject.Properties["URICacheFlushes"].Value,
                    URICacheHits = (uint) managementObject.Properties["URICacheHits"].Value,
                    UriCacheHitsPersec = (uint) managementObject.Properties["UriCacheHitsPersec"].Value,
                    URICacheMisses = (uint) managementObject.Properties["URICacheMisses"].Value,
                    UriCacheMissesPersec = (uint) managementObject.Properties["UriCacheMissesPersec"].Value,
                    WebSocketActiveRequests = (uint) managementObject.Properties["WebSocketActiveRequests"].Value,
                    WebSocketConnectionAttemptsPerSec =
                        (uint) managementObject.Properties["WebSocketConnectionAttemptsPerSec"].Value,
                    WebSocketConnectionsAcceptedPerSec =
                        (uint) managementObject.Properties["WebSocketConnectionsAcceptedPerSec"].Value,
                    WebSocketConnectionsRejectedPerSec =
                        (uint) managementObject.Properties["WebSocketConnectionsRejectedPerSec"].Value
                });

            return list.ToArray();
        }
    }
}