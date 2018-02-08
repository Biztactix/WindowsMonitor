using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_PeerDistSvc_BranchCache
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

        public static PerfRawData_PeerDistSvc_BranchCache[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_PeerDistSvc_BranchCache[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_PeerDistSvc_BranchCache[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PeerDistSvc_BranchCache");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_PeerDistSvc_BranchCache>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_PeerDistSvc_BranchCache
                {
                    BITSBytesfromcache = (ulong) managementObject.Properties["BITSBytesfromcache"].Value,
                    BITSBytesfromserver = (ulong) managementObject.Properties["BITSBytesfromserver"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DiscoveryAttempteddiscoveries = (uint) managementObject.Properties["DiscoveryAttempteddiscoveries"]
                        .Value,
                    DiscoverySuccessfuldiscoveries =
                        (uint) managementObject.Properties["DiscoverySuccessfuldiscoveries"].Value,
                    DiscoveryWeightedaveragediscoverytime = (uint) managementObject
                        .Properties["DiscoveryWeightedaveragediscoverytime"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    HostedCacheClientfilesegmentoffersmade = (uint) managementObject
                        .Properties["HostedCacheClientfilesegmentoffersmade"].Value,
                    HostedCacheSegmentoffersqueuesize =
                        (uint) managementObject.Properties["HostedCacheSegmentoffersqueuesize"].Value,
                    LocalCacheAverageaccesstime = (uint) managementObject.Properties["LocalCacheAverageaccesstime"]
                        .Value,
                    LocalCacheCachecompletefilesegments =
                        (uint) managementObject.Properties["LocalCacheCachecompletefilesegments"].Value,
                    LocalCacheCachepartialfilesegments =
                        (uint) managementObject.Properties["LocalCacheCachepartialfilesegments"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OTHERBytesfromcache = (ulong) managementObject.Properties["OTHERBytesfromcache"].Value,
                    OTHERBytesfromserver = (ulong) managementObject.Properties["OTHERBytesfromserver"].Value,
                    PublicationCachePublishedcontents =
                        (uint) managementObject.Properties["PublicationCachePublishedcontents"].Value,
                    RetrievalAveragebranchrate =
                        (ulong) managementObject.Properties["RetrievalAveragebranchrate"].Value,
                    RetrievalBytesfromcache = (ulong) managementObject.Properties["RetrievalBytesfromcache"].Value,
                    RetrievalBytesfromserver = (ulong) managementObject.Properties["RetrievalBytesfromserver"].Value,
                    RetrievalBytesserved = (ulong) managementObject.Properties["RetrievalBytesserved"].Value,
                    SMBBytesfromcache = (ulong) managementObject.Properties["SMBBytesfromcache"].Value,
                    SMBBytesfromserver = (ulong) managementObject.Properties["SMBBytesfromserver"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    WINHTTPBytesfromcache = (ulong) managementObject.Properties["WINHTTPBytesfromcache"].Value,
                    WINHTTPBytesfromserver = (ulong) managementObject.Properties["WINHTTPBytesfromserver"].Value,
                    WININETBytesfromcache = (ulong) managementObject.Properties["WININETBytesfromcache"].Value,
                    WININETBytesfromserver = (ulong) managementObject.Properties["WININETBytesfromserver"].Value
                });

            return list.ToArray();
        }
    }
}