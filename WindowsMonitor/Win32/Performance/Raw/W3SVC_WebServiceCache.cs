using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class W3SVC_WebServiceCache
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
		public uint FileCacheHitsPercent_Base { get; private set; }
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
		public uint KernelURICacheHitsPercent_Base { get; private set; }
		public uint KernelUriCacheHitsPersec { get; private set; }
		public uint KernelURICacheMisses { get; private set; }
		public ulong MaximumFileCacheMemoryUsage { get; private set; }
		public uint MetadataCacheFlushes { get; private set; }
		public uint MetadataCacheHits { get; private set; }
		public uint MetadataCacheHitsPercent { get; private set; }
		public uint MetadataCacheHitsPercent_Base { get; private set; }
		public uint MetadataCacheMisses { get; private set; }
		public string Name { get; private set; }
		public uint OutputCacheCurrentFlushedItems { get; private set; }
		public uint OutputCacheCurrentHitsPercent { get; private set; }
		public uint OutputCacheCurrentHitsPercent_Base { get; private set; }
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
		public uint URICacheHitsPercent_Base { get; private set; }
		public uint URICacheMisses { get; private set; }

        public static IEnumerable<W3SVC_WebServiceCache> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<W3SVC_WebServiceCache> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<W3SVC_WebServiceCache> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_W3SVC_WebServiceCache");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new W3SVC_WebServiceCache
                {
                     ActiveFlushedEntries = (uint) (managementObject.Properties["ActiveFlushedEntries"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CurrentFileCacheMemoryUsage = (ulong) (managementObject.Properties["CurrentFileCacheMemoryUsage"]?.Value ?? default(ulong)),
		 CurrentFilesCached = (uint) (managementObject.Properties["CurrentFilesCached"]?.Value ?? default(uint)),
		 CurrentMetadataCached = (uint) (managementObject.Properties["CurrentMetadataCached"]?.Value ?? default(uint)),
		 CurrentURIsCached = (uint) (managementObject.Properties["CurrentURIsCached"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 FileCacheFlushes = (uint) (managementObject.Properties["FileCacheFlushes"]?.Value ?? default(uint)),
		 FileCacheHits = (uint) (managementObject.Properties["FileCacheHits"]?.Value ?? default(uint)),
		 FileCacheHitsPercent = (uint) (managementObject.Properties["FileCacheHitsPercent"]?.Value ?? default(uint)),
		 FileCacheHitsPercent_Base = (uint) (managementObject.Properties["FileCacheHitsPercent_Base"]?.Value ?? default(uint)),
		 FileCacheMisses = (uint) (managementObject.Properties["FileCacheMisses"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 KernelCurrentURIsCached = (uint) (managementObject.Properties["KernelCurrentURIsCached"]?.Value ?? default(uint)),
		 KernelTotalFlushedURIs = (uint) (managementObject.Properties["KernelTotalFlushedURIs"]?.Value ?? default(uint)),
		 KernelTotalURIsCached = (uint) (managementObject.Properties["KernelTotalURIsCached"]?.Value ?? default(uint)),
		 KernelURICacheFlushes = (uint) (managementObject.Properties["KernelURICacheFlushes"]?.Value ?? default(uint)),
		 KernelURICacheHits = (uint) (managementObject.Properties["KernelURICacheHits"]?.Value ?? default(uint)),
		 KernelURICacheHitsPercent = (uint) (managementObject.Properties["KernelURICacheHitsPercent"]?.Value ?? default(uint)),
		 KernelURICacheHitsPercent_Base = (uint) (managementObject.Properties["KernelURICacheHitsPercent_Base"]?.Value ?? default(uint)),
		 KernelUriCacheHitsPersec = (uint) (managementObject.Properties["KernelUriCacheHitsPersec"]?.Value ?? default(uint)),
		 KernelURICacheMisses = (uint) (managementObject.Properties["KernelURICacheMisses"]?.Value ?? default(uint)),
		 MaximumFileCacheMemoryUsage = (ulong) (managementObject.Properties["MaximumFileCacheMemoryUsage"]?.Value ?? default(ulong)),
		 MetadataCacheFlushes = (uint) (managementObject.Properties["MetadataCacheFlushes"]?.Value ?? default(uint)),
		 MetadataCacheHits = (uint) (managementObject.Properties["MetadataCacheHits"]?.Value ?? default(uint)),
		 MetadataCacheHitsPercent = (uint) (managementObject.Properties["MetadataCacheHitsPercent"]?.Value ?? default(uint)),
		 MetadataCacheHitsPercent_Base = (uint) (managementObject.Properties["MetadataCacheHitsPercent_Base"]?.Value ?? default(uint)),
		 MetadataCacheMisses = (uint) (managementObject.Properties["MetadataCacheMisses"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 OutputCacheCurrentFlushedItems = (uint) (managementObject.Properties["OutputCacheCurrentFlushedItems"]?.Value ?? default(uint)),
		 OutputCacheCurrentHitsPercent = (uint) (managementObject.Properties["OutputCacheCurrentHitsPercent"]?.Value ?? default(uint)),
		 OutputCacheCurrentHitsPercent_Base = (uint) (managementObject.Properties["OutputCacheCurrentHitsPercent_Base"]?.Value ?? default(uint)),
		 OutputCacheCurrentItems = (uint) (managementObject.Properties["OutputCacheCurrentItems"]?.Value ?? default(uint)),
		 OutputCacheCurrentMemoryUsage = (ulong) (managementObject.Properties["OutputCacheCurrentMemoryUsage"]?.Value ?? default(ulong)),
		 OutputCacheTotalFlushedItems = (uint) (managementObject.Properties["OutputCacheTotalFlushedItems"]?.Value ?? default(uint)),
		 OutputCacheTotalFlushes = (uint) (managementObject.Properties["OutputCacheTotalFlushes"]?.Value ?? default(uint)),
		 OutputCacheTotalHits = (uint) (managementObject.Properties["OutputCacheTotalHits"]?.Value ?? default(uint)),
		 OutputCacheTotalMisses = (uint) (managementObject.Properties["OutputCacheTotalMisses"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalFilesCached = (uint) (managementObject.Properties["TotalFilesCached"]?.Value ?? default(uint)),
		 TotalFlushedFiles = (uint) (managementObject.Properties["TotalFlushedFiles"]?.Value ?? default(uint)),
		 TotalFlushedMetadata = (uint) (managementObject.Properties["TotalFlushedMetadata"]?.Value ?? default(uint)),
		 TotalFlushedURIs = (uint) (managementObject.Properties["TotalFlushedURIs"]?.Value ?? default(uint)),
		 TotalMetadataCached = (uint) (managementObject.Properties["TotalMetadataCached"]?.Value ?? default(uint)),
		 TotalURIsCached = (uint) (managementObject.Properties["TotalURIsCached"]?.Value ?? default(uint)),
		 URICacheFlushes = (uint) (managementObject.Properties["URICacheFlushes"]?.Value ?? default(uint)),
		 URICacheHits = (uint) (managementObject.Properties["URICacheHits"]?.Value ?? default(uint)),
		 URICacheHitsPercent = (uint) (managementObject.Properties["URICacheHitsPercent"]?.Value ?? default(uint)),
		 URICacheHitsPercent_Base = (uint) (managementObject.Properties["URICacheHitsPercent_Base"]?.Value ?? default(uint)),
		 URICacheMisses = (uint) (managementObject.Properties["URICacheMisses"]?.Value ?? default(uint))
                };
        }
    }
}