using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_PerfNet_Server
    {
        public uint BlockingRequestsRejected { get; private set; }
        public ulong BytesReceivedPersec { get; private set; }
        public ulong BytesTotalPersec { get; private set; }
        public ulong BytesTransmittedPersec { get; private set; }
        public string Caption { get; private set; }
        public uint ContextBlocksQueuedPersec { get; private set; }
        public string Description { get; private set; }
        public uint ErrorsAccessPermissions { get; private set; }
        public uint ErrorsGrantedAccess { get; private set; }
        public uint ErrorsLogon { get; private set; }
        public uint ErrorsSystem { get; private set; }
        public uint FileDirectorySearches { get; private set; }
        public uint FilesOpen { get; private set; }
        public uint FilesOpenedTotal { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint LogonPersec { get; private set; }
        public uint LogonTotal { get; private set; }
        public string Name { get; private set; }
        public uint PoolNonpagedBytes { get; private set; }
        public uint PoolNonpagedFailures { get; private set; }
        public uint PoolNonpagedPeak { get; private set; }
        public uint PoolPagedBytes { get; private set; }
        public uint PoolPagedFailures { get; private set; }
        public uint PoolPagedPeak { get; private set; }
        public uint ReconnectedDurableHandles { get; private set; }
        public uint ReconnectedResilientHandles { get; private set; }
        public uint ServerSessions { get; private set; }
        public uint SessionsErroredOut { get; private set; }
        public uint SessionsForcedOff { get; private set; }
        public uint SessionsLoggedOff { get; private set; }
        public uint SessionsTimedOut { get; private set; }
        public ulong SMBBranchCacheHashBytesSent { get; private set; }
        public uint SMBBranchCacheHashGenerationRequests { get; private set; }
        public uint SMBBranchCacheHashHeaderRequests { get; private set; }
        public uint SMBBranchCacheHashRequestsReceived { get; private set; }
        public uint SMBBranchCacheHashResponsesSent { get; private set; }
        public ulong SMBBranchCacheHashV2BytesSent { get; private set; }
        public uint SMBBranchCacheHashV2GenerationRequests { get; private set; }
        public uint SMBBranchCacheHashV2HeaderRequests { get; private set; }
        public uint SMBBranchCacheHashV2RequestsReceived { get; private set; }
        public uint SMBBranchCacheHashV2RequestsServedFromDedup { get; private set; }
        public uint SMBBranchCacheHashV2ResponsesSent { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalDurableHandles { get; private set; }
        public uint TotalResilientHandles { get; private set; }
        public uint WorkItemShortages { get; private set; }

        public static PerfFormattedData_PerfNet_Server[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_PerfNet_Server[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_PerfNet_Server[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfNet_Server");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_PerfNet_Server>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_PerfNet_Server
                {
                    BlockingRequestsRejected = (uint) managementObject.Properties["BlockingRequestsRejected"].Value,
                    BytesReceivedPersec = (ulong) managementObject.Properties["BytesReceivedPersec"].Value,
                    BytesTotalPersec = (ulong) managementObject.Properties["BytesTotalPersec"].Value,
                    BytesTransmittedPersec = (ulong) managementObject.Properties["BytesTransmittedPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ContextBlocksQueuedPersec = (uint) managementObject.Properties["ContextBlocksQueuedPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ErrorsAccessPermissions = (uint) managementObject.Properties["ErrorsAccessPermissions"].Value,
                    ErrorsGrantedAccess = (uint) managementObject.Properties["ErrorsGrantedAccess"].Value,
                    ErrorsLogon = (uint) managementObject.Properties["ErrorsLogon"].Value,
                    ErrorsSystem = (uint) managementObject.Properties["ErrorsSystem"].Value,
                    FileDirectorySearches = (uint) managementObject.Properties["FileDirectorySearches"].Value,
                    FilesOpen = (uint) managementObject.Properties["FilesOpen"].Value,
                    FilesOpenedTotal = (uint) managementObject.Properties["FilesOpenedTotal"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    LogonPersec = (uint) managementObject.Properties["LogonPersec"].Value,
                    LogonTotal = (uint) managementObject.Properties["LogonTotal"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PoolNonpagedBytes = (uint) managementObject.Properties["PoolNonpagedBytes"].Value,
                    PoolNonpagedFailures = (uint) managementObject.Properties["PoolNonpagedFailures"].Value,
                    PoolNonpagedPeak = (uint) managementObject.Properties["PoolNonpagedPeak"].Value,
                    PoolPagedBytes = (uint) managementObject.Properties["PoolPagedBytes"].Value,
                    PoolPagedFailures = (uint) managementObject.Properties["PoolPagedFailures"].Value,
                    PoolPagedPeak = (uint) managementObject.Properties["PoolPagedPeak"].Value,
                    ReconnectedDurableHandles = (uint) managementObject.Properties["ReconnectedDurableHandles"].Value,
                    ReconnectedResilientHandles = (uint) managementObject.Properties["ReconnectedResilientHandles"]
                        .Value,
                    ServerSessions = (uint) managementObject.Properties["ServerSessions"].Value,
                    SessionsErroredOut = (uint) managementObject.Properties["SessionsErroredOut"].Value,
                    SessionsForcedOff = (uint) managementObject.Properties["SessionsForcedOff"].Value,
                    SessionsLoggedOff = (uint) managementObject.Properties["SessionsLoggedOff"].Value,
                    SessionsTimedOut = (uint) managementObject.Properties["SessionsTimedOut"].Value,
                    SMBBranchCacheHashBytesSent = (ulong) managementObject.Properties["SMBBranchCacheHashBytesSent"]
                        .Value,
                    SMBBranchCacheHashGenerationRequests = (uint) managementObject
                        .Properties["SMBBranchCacheHashGenerationRequests"].Value,
                    SMBBranchCacheHashHeaderRequests =
                        (uint) managementObject.Properties["SMBBranchCacheHashHeaderRequests"].Value,
                    SMBBranchCacheHashRequestsReceived =
                        (uint) managementObject.Properties["SMBBranchCacheHashRequestsReceived"].Value,
                    SMBBranchCacheHashResponsesSent =
                        (uint) managementObject.Properties["SMBBranchCacheHashResponsesSent"].Value,
                    SMBBranchCacheHashV2BytesSent =
                        (ulong) managementObject.Properties["SMBBranchCacheHashV2BytesSent"].Value,
                    SMBBranchCacheHashV2GenerationRequests = (uint) managementObject
                        .Properties["SMBBranchCacheHashV2GenerationRequests"].Value,
                    SMBBranchCacheHashV2HeaderRequests =
                        (uint) managementObject.Properties["SMBBranchCacheHashV2HeaderRequests"].Value,
                    SMBBranchCacheHashV2RequestsReceived = (uint) managementObject
                        .Properties["SMBBranchCacheHashV2RequestsReceived"].Value,
                    SMBBranchCacheHashV2RequestsServedFromDedup = (uint) managementObject
                        .Properties["SMBBranchCacheHashV2RequestsServedFromDedup"].Value,
                    SMBBranchCacheHashV2ResponsesSent =
                        (uint) managementObject.Properties["SMBBranchCacheHashV2ResponsesSent"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalDurableHandles = (uint) managementObject.Properties["TotalDurableHandles"].Value,
                    TotalResilientHandles = (uint) managementObject.Properties["TotalResilientHandles"].Value,
                    WorkItemShortages = (uint) managementObject.Properties["WorkItemShortages"].Value
                });

            return list.ToArray();
        }
    }
}