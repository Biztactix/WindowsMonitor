using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class PeerDistSvc_BranchCache
    {
		public ulong BITSBytesfromcache { get; private set; }
		public ulong BITSBytesfromserver { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public uint DiscoveryAttempteddiscoveries { get; private set; }
		public uint DiscoverySuccessfuldiscoveries { get; private set; }
		public uint DiscoveryWeightedaveragediscoverytime { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint HostedCacheClientfilesegmentoffersmade { get; private set; }
		public uint HostedCacheSegmentoffersqueuesize { get; private set; }
		public uint LocalCacheAverageaccesstime { get; private set; }
		public uint LocalCacheCachecompletefilesegments { get; private set; }
		public uint LocalCacheCachepartialfilesegments { get; private set; }
		public string Name { get; private set; }
		public ulong OTHERBytesfromcache { get; private set; }
		public ulong OTHERBytesfromserver { get; private set; }
		public uint PublicationCachePublishedcontents { get; private set; }
		public ulong RetrievalAveragebranchrate { get; private set; }
		public ulong RetrievalBytesfromcache { get; private set; }
		public ulong RetrievalBytesfromserver { get; private set; }
		public ulong RetrievalBytesserved { get; private set; }
		public ulong SMBBytesfromcache { get; private set; }
		public ulong SMBBytesfromserver { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong WINHTTPBytesfromcache { get; private set; }
		public ulong WINHTTPBytesfromserver { get; private set; }
		public ulong WININETBytesfromcache { get; private set; }
		public ulong WININETBytesfromserver { get; private set; }

        public static IEnumerable<PeerDistSvc_BranchCache> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PeerDistSvc_BranchCache> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PeerDistSvc_BranchCache> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PeerDistSvc_BranchCache");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PeerDistSvc_BranchCache
                {
                     BITSBytesfromcache = (ulong) (managementObject.Properties["BITSBytesfromcache"]?.Value ?? default(ulong)),
		 BITSBytesfromserver = (ulong) (managementObject.Properties["BITSBytesfromserver"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DiscoveryAttempteddiscoveries = (uint) (managementObject.Properties["DiscoveryAttempteddiscoveries"]?.Value ?? default(uint)),
		 DiscoverySuccessfuldiscoveries = (uint) (managementObject.Properties["DiscoverySuccessfuldiscoveries"]?.Value ?? default(uint)),
		 DiscoveryWeightedaveragediscoverytime = (uint) (managementObject.Properties["DiscoveryWeightedaveragediscoverytime"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 HostedCacheClientfilesegmentoffersmade = (uint) (managementObject.Properties["HostedCacheClientfilesegmentoffersmade"]?.Value ?? default(uint)),
		 HostedCacheSegmentoffersqueuesize = (uint) (managementObject.Properties["HostedCacheSegmentoffersqueuesize"]?.Value ?? default(uint)),
		 LocalCacheAverageaccesstime = (uint) (managementObject.Properties["LocalCacheAverageaccesstime"]?.Value ?? default(uint)),
		 LocalCacheCachecompletefilesegments = (uint) (managementObject.Properties["LocalCacheCachecompletefilesegments"]?.Value ?? default(uint)),
		 LocalCacheCachepartialfilesegments = (uint) (managementObject.Properties["LocalCacheCachepartialfilesegments"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OTHERBytesfromcache = (ulong) (managementObject.Properties["OTHERBytesfromcache"]?.Value ?? default(ulong)),
		 OTHERBytesfromserver = (ulong) (managementObject.Properties["OTHERBytesfromserver"]?.Value ?? default(ulong)),
		 PublicationCachePublishedcontents = (uint) (managementObject.Properties["PublicationCachePublishedcontents"]?.Value ?? default(uint)),
		 RetrievalAveragebranchrate = (ulong) (managementObject.Properties["RetrievalAveragebranchrate"]?.Value ?? default(ulong)),
		 RetrievalBytesfromcache = (ulong) (managementObject.Properties["RetrievalBytesfromcache"]?.Value ?? default(ulong)),
		 RetrievalBytesfromserver = (ulong) (managementObject.Properties["RetrievalBytesfromserver"]?.Value ?? default(ulong)),
		 RetrievalBytesserved = (ulong) (managementObject.Properties["RetrievalBytesserved"]?.Value ?? default(ulong)),
		 SMBBytesfromcache = (ulong) (managementObject.Properties["SMBBytesfromcache"]?.Value ?? default(ulong)),
		 SMBBytesfromserver = (ulong) (managementObject.Properties["SMBBytesfromserver"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 WINHTTPBytesfromcache = (ulong) (managementObject.Properties["WINHTTPBytesfromcache"]?.Value ?? default(ulong)),
		 WINHTTPBytesfromserver = (ulong) (managementObject.Properties["WINHTTPBytesfromserver"]?.Value ?? default(ulong)),
		 WININETBytesfromcache = (ulong) (managementObject.Properties["WININETBytesfromcache"]?.Value ?? default(ulong)),
		 WININETBytesfromserver = (ulong) (managementObject.Properties["WININETBytesfromserver"]?.Value ?? default(ulong))
                };
        }
    }
}