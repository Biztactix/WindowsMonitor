using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSERVER_SQLServerAccessMethods
    {
        public ulong AUcleanupbatchesPersec { get; private set; }
        public ulong AUcleanupsPersec { get; private set; }
        public ulong ByreferenceLobCreateCount { get; private set; }
        public ulong ByreferenceLobUseCount { get; private set; }
        public string Caption { get; private set; }
        public ulong CountLobReadahead { get; private set; }
        public ulong CountPullInRow { get; private set; }
        public ulong CountPushOffRow { get; private set; }
        public ulong DeferreddroppedAUs { get; private set; }
        public ulong DeferredDroppedrowsets { get; private set; }
        public string Description { get; private set; }
        public ulong DroppedrowsetcleanupsPersec { get; private set; }
        public ulong DroppedrowsetsskippedPersec { get; private set; }
        public ulong ExtentDeallocationsPersec { get; private set; }
        public ulong ExtentsAllocatedPersec { get; private set; }
        public ulong FailedAUcleanupbatchesPersec { get; private set; }
        public ulong Failedleafpagecookie { get; private set; }
        public ulong Failedtreepagecookie { get; private set; }
        public ulong ForwardedRecordsPersec { get; private set; }
        public ulong FreeSpacePageFetchesPersec { get; private set; }
        public ulong FreeSpaceScansPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong FullScansPersec { get; private set; }
        public ulong IndexSearchesPersec { get; private set; }
        public ulong InSysXactwaitsPersec { get; private set; }
        public ulong LobHandleCreateCount { get; private set; }
        public ulong LobHandleDestroyCount { get; private set; }
        public ulong LobSSProviderCreateCount { get; private set; }
        public ulong LobSSProviderDestroyCount { get; private set; }
        public ulong LobSSProviderTruncationCount { get; private set; }
        public ulong MixedpageallocationsPersec { get; private set; }
        public string Name { get; private set; }
        public ulong PagecompressionattemptsPersec { get; private set; }
        public ulong PageDeallocationsPersec { get; private set; }
        public ulong PagesAllocatedPersec { get; private set; }
        public ulong PagescompressedPersec { get; private set; }
        public ulong PageSplitsPersec { get; private set; }
        public ulong ProbeScansPersec { get; private set; }
        public ulong RangeScansPersec { get; private set; }
        public ulong ScanPointRevalidationsPersec { get; private set; }
        public ulong SkippedGhostedRecordsPersec { get; private set; }
        public ulong TableLockEscalationsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong Usedleafpagecookie { get; private set; }
        public ulong Usedtreepagecookie { get; private set; }
        public ulong WorkfilesCreatedPersec { get; private set; }
        public ulong WorktablesCreatedPersec { get; private set; }
        public ulong WorktablesFromCacheRatio { get; private set; }

        public static PerfFormattedData_MSSQLSERVER_SQLServerAccessMethods[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_MSSQLSERVER_SQLServerAccessMethods[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSERVER_SQLServerAccessMethods[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerAccessMethods");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSERVER_SQLServerAccessMethods>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSERVER_SQLServerAccessMethods
                {
                    AUcleanupbatchesPersec = (ulong) managementObject.Properties["AUcleanupbatchesPersec"].Value,
                    AUcleanupsPersec = (ulong) managementObject.Properties["AUcleanupsPersec"].Value,
                    ByreferenceLobCreateCount = (ulong) managementObject.Properties["ByreferenceLobCreateCount"].Value,
                    ByreferenceLobUseCount = (ulong) managementObject.Properties["ByreferenceLobUseCount"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CountLobReadahead = (ulong) managementObject.Properties["CountLobReadahead"].Value,
                    CountPullInRow = (ulong) managementObject.Properties["CountPullInRow"].Value,
                    CountPushOffRow = (ulong) managementObject.Properties["CountPushOffRow"].Value,
                    DeferreddroppedAUs = (ulong) managementObject.Properties["DeferreddroppedAUs"].Value,
                    DeferredDroppedrowsets = (ulong) managementObject.Properties["DeferredDroppedrowsets"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DroppedrowsetcleanupsPersec = (ulong) managementObject.Properties["DroppedrowsetcleanupsPersec"]
                        .Value,
                    DroppedrowsetsskippedPersec = (ulong) managementObject.Properties["DroppedrowsetsskippedPersec"]
                        .Value,
                    ExtentDeallocationsPersec = (ulong) managementObject.Properties["ExtentDeallocationsPersec"].Value,
                    ExtentsAllocatedPersec = (ulong) managementObject.Properties["ExtentsAllocatedPersec"].Value,
                    FailedAUcleanupbatchesPersec = (ulong) managementObject.Properties["FailedAUcleanupbatchesPersec"]
                        .Value,
                    Failedleafpagecookie = (ulong) managementObject.Properties["Failedleafpagecookie"].Value,
                    Failedtreepagecookie = (ulong) managementObject.Properties["Failedtreepagecookie"].Value,
                    ForwardedRecordsPersec = (ulong) managementObject.Properties["ForwardedRecordsPersec"].Value,
                    FreeSpacePageFetchesPersec =
                        (ulong) managementObject.Properties["FreeSpacePageFetchesPersec"].Value,
                    FreeSpaceScansPersec = (ulong) managementObject.Properties["FreeSpaceScansPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    FullScansPersec = (ulong) managementObject.Properties["FullScansPersec"].Value,
                    IndexSearchesPersec = (ulong) managementObject.Properties["IndexSearchesPersec"].Value,
                    InSysXactwaitsPersec = (ulong) managementObject.Properties["InSysXactwaitsPersec"].Value,
                    LobHandleCreateCount = (ulong) managementObject.Properties["LobHandleCreateCount"].Value,
                    LobHandleDestroyCount = (ulong) managementObject.Properties["LobHandleDestroyCount"].Value,
                    LobSSProviderCreateCount = (ulong) managementObject.Properties["LobSSProviderCreateCount"].Value,
                    LobSSProviderDestroyCount = (ulong) managementObject.Properties["LobSSProviderDestroyCount"].Value,
                    LobSSProviderTruncationCount = (ulong) managementObject.Properties["LobSSProviderTruncationCount"]
                        .Value,
                    MixedpageallocationsPersec =
                        (ulong) managementObject.Properties["MixedpageallocationsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PagecompressionattemptsPersec =
                        (ulong) managementObject.Properties["PagecompressionattemptsPersec"].Value,
                    PageDeallocationsPersec = (ulong) managementObject.Properties["PageDeallocationsPersec"].Value,
                    PagesAllocatedPersec = (ulong) managementObject.Properties["PagesAllocatedPersec"].Value,
                    PagescompressedPersec = (ulong) managementObject.Properties["PagescompressedPersec"].Value,
                    PageSplitsPersec = (ulong) managementObject.Properties["PageSplitsPersec"].Value,
                    ProbeScansPersec = (ulong) managementObject.Properties["ProbeScansPersec"].Value,
                    RangeScansPersec = (ulong) managementObject.Properties["RangeScansPersec"].Value,
                    ScanPointRevalidationsPersec = (ulong) managementObject.Properties["ScanPointRevalidationsPersec"]
                        .Value,
                    SkippedGhostedRecordsPersec = (ulong) managementObject.Properties["SkippedGhostedRecordsPersec"]
                        .Value,
                    TableLockEscalationsPersec =
                        (ulong) managementObject.Properties["TableLockEscalationsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    Usedleafpagecookie = (ulong) managementObject.Properties["Usedleafpagecookie"].Value,
                    Usedtreepagecookie = (ulong) managementObject.Properties["Usedtreepagecookie"].Value,
                    WorkfilesCreatedPersec = (ulong) managementObject.Properties["WorkfilesCreatedPersec"].Value,
                    WorktablesCreatedPersec = (ulong) managementObject.Properties["WorktablesCreatedPersec"].Value,
                    WorktablesFromCacheRatio = (ulong) managementObject.Properties["WorktablesFromCacheRatio"].Value
                });

            return list.ToArray();
        }
    }
}