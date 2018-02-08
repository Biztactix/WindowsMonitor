using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_W3SVC_WebServiceCache
    {
        public uint ActiveFlushedEntries { get; private set; }
        public string Caption { get; private set; }
        public ulong CurrentFileCacheMemoryUsage { get; private set; }
        public uint CurrentFilesCached { get; private set; }
        public uint CurrentMetadataCached { get; private set; }
        public uint CurrentURIsCached { get; private set; }
        public string Description { get; private set; }
        public uint FileCacheFlushes { get; private set; }
        public uint FileCacheHits { get; private set; }
        public uint FileCacheHitsPercent { get; private set; }
        public uint FileCacheMisses { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint KernelCurrentURIsCached { get; private set; }
        public uint KernelTotalFlushedURIs { get; private set; }
        public uint KernelTotalURIsCached { get; private set; }
        public uint KernelURICacheFlushes { get; private set; }
        public uint KernelURICacheHits { get; private set; }
        public uint KernelURICacheHitsPercent { get; private set; }
        public uint KernelUriCacheHitsPersec { get; private set; }
        public uint KernelURICacheMisses { get; private set; }
        public ulong MaximumFileCacheMemoryUsage { get; private set; }
        public uint MetadataCacheFlushes { get; private set; }
        public uint MetadataCacheHits { get; private set; }
        public uint MetadataCacheHitsPercent { get; private set; }
        public uint MetadataCacheMisses { get; private set; }
        public string Name { get; private set; }
        public uint OutputCacheCurrentFlushedItems { get; private set; }
        public uint OutputCacheCurrentHitsPercent { get; private set; }
        public uint OutputCacheCurrentItems { get; private set; }
        public ulong OutputCacheCurrentMemoryUsage { get; private set; }
        public uint OutputCacheTotalFlushedItems { get; private set; }
        public uint OutputCacheTotalFlushes { get; private set; }
        public uint OutputCacheTotalHits { get; private set; }
        public uint OutputCacheTotalMisses { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalFilesCached { get; private set; }
        public uint TotalFlushedFiles { get; private set; }
        public uint TotalFlushedMetadata { get; private set; }
        public uint TotalFlushedURIs { get; private set; }
        public uint TotalMetadataCached { get; private set; }
        public uint TotalURIsCached { get; private set; }
        public uint URICacheFlushes { get; private set; }
        public uint URICacheHits { get; private set; }
        public uint URICacheHitsPercent { get; private set; }
        public uint URICacheMisses { get; private set; }

        public static PerfFormattedData_W3SVC_WebServiceCache[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_W3SVC_WebServiceCache[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_W3SVC_WebServiceCache[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_W3SVC_WebServiceCache");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_W3SVC_WebServiceCache>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_W3SVC_WebServiceCache
                {
                    ActiveFlushedEntries = (uint) managementObject.Properties["ActiveFlushedEntries"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentFileCacheMemoryUsage = (ulong) managementObject.Properties["CurrentFileCacheMemoryUsage"]
                        .Value,
                    CurrentFilesCached = (uint) managementObject.Properties["CurrentFilesCached"].Value,
                    CurrentMetadataCached = (uint) managementObject.Properties["CurrentMetadataCached"].Value,
                    CurrentURIsCached = (uint) managementObject.Properties["CurrentURIsCached"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FileCacheFlushes = (uint) managementObject.Properties["FileCacheFlushes"].Value,
                    FileCacheHits = (uint) managementObject.Properties["FileCacheHits"].Value,
                    FileCacheHitsPercent = (uint) managementObject.Properties["FileCacheHitsPercent"].Value,
                    FileCacheMisses = (uint) managementObject.Properties["FileCacheMisses"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    KernelCurrentURIsCached = (uint) managementObject.Properties["KernelCurrentURIsCached"].Value,
                    KernelTotalFlushedURIs = (uint) managementObject.Properties["KernelTotalFlushedURIs"].Value,
                    KernelTotalURIsCached = (uint) managementObject.Properties["KernelTotalURIsCached"].Value,
                    KernelURICacheFlushes = (uint) managementObject.Properties["KernelURICacheFlushes"].Value,
                    KernelURICacheHits = (uint) managementObject.Properties["KernelURICacheHits"].Value,
                    KernelURICacheHitsPercent = (uint) managementObject.Properties["KernelURICacheHitsPercent"].Value,
                    KernelUriCacheHitsPersec = (uint) managementObject.Properties["KernelUriCacheHitsPersec"].Value,
                    KernelURICacheMisses = (uint) managementObject.Properties["KernelURICacheMisses"].Value,
                    MaximumFileCacheMemoryUsage = (ulong) managementObject.Properties["MaximumFileCacheMemoryUsage"]
                        .Value,
                    MetadataCacheFlushes = (uint) managementObject.Properties["MetadataCacheFlushes"].Value,
                    MetadataCacheHits = (uint) managementObject.Properties["MetadataCacheHits"].Value,
                    MetadataCacheHitsPercent = (uint) managementObject.Properties["MetadataCacheHitsPercent"].Value,
                    MetadataCacheMisses = (uint) managementObject.Properties["MetadataCacheMisses"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OutputCacheCurrentFlushedItems =
                        (uint) managementObject.Properties["OutputCacheCurrentFlushedItems"].Value,
                    OutputCacheCurrentHitsPercent = (uint) managementObject.Properties["OutputCacheCurrentHitsPercent"]
                        .Value,
                    OutputCacheCurrentItems = (uint) managementObject.Properties["OutputCacheCurrentItems"].Value,
                    OutputCacheCurrentMemoryUsage =
                        (ulong) managementObject.Properties["OutputCacheCurrentMemoryUsage"].Value,
                    OutputCacheTotalFlushedItems = (uint) managementObject.Properties["OutputCacheTotalFlushedItems"]
                        .Value,
                    OutputCacheTotalFlushes = (uint) managementObject.Properties["OutputCacheTotalFlushes"].Value,
                    OutputCacheTotalHits = (uint) managementObject.Properties["OutputCacheTotalHits"].Value,
                    OutputCacheTotalMisses = (uint) managementObject.Properties["OutputCacheTotalMisses"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalFilesCached = (uint) managementObject.Properties["TotalFilesCached"].Value,
                    TotalFlushedFiles = (uint) managementObject.Properties["TotalFlushedFiles"].Value,
                    TotalFlushedMetadata = (uint) managementObject.Properties["TotalFlushedMetadata"].Value,
                    TotalFlushedURIs = (uint) managementObject.Properties["TotalFlushedURIs"].Value,
                    TotalMetadataCached = (uint) managementObject.Properties["TotalMetadataCached"].Value,
                    TotalURIsCached = (uint) managementObject.Properties["TotalURIsCached"].Value,
                    URICacheFlushes = (uint) managementObject.Properties["URICacheFlushes"].Value,
                    URICacheHits = (uint) managementObject.Properties["URICacheHits"].Value,
                    URICacheHitsPercent = (uint) managementObject.Properties["URICacheHitsPercent"].Value,
                    URICacheMisses = (uint) managementObject.Properties["URICacheMisses"].Value
                });

            return list.ToArray();
        }
    }
}