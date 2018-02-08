using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_WSearchIdxPi_SearchIndexer
    {
        public uint ActiveConnections { get; private set; }
        public string Caption { get; private set; }
        public uint CleanWidSets { get; private set; }
        public string Description { get; private set; }
        public uint DirtyWidSets { get; private set; }
        public uint DocumentsFiltered { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint IndexSize { get; private set; }
        public uint L0IndexesWordlists { get; private set; }
        public uint L0MergeFlushCount { get; private set; }
        public uint L0MergeFlushSpeedAverage { get; private set; }
        public uint L0MergeFlushSpeedLast { get; private set; }
        public uint L0MergesflushesNow { get; private set; }
        public uint L1MergeCount { get; private set; }
        public uint L1MergesNow { get; private set; }
        public uint L1MergeSpeedaverage { get; private set; }
        public uint L1MergeSpeedlast { get; private set; }
        public uint L2MergeCount { get; private set; }
        public uint L2MergesNow { get; private set; }
        public uint L2MergeSpeedaverage { get; private set; }
        public uint L2MergeSpeedlast { get; private set; }
        public uint L3MergeCount { get; private set; }
        public uint L3MergesNow { get; private set; }
        public uint L3MergeSpeedaverage { get; private set; }
        public uint L3MergeSpeedlast { get; private set; }
        public uint L4MergeCount { get; private set; }
        public uint L4MergesNow { get; private set; }
        public uint L4MergeSpeedaverage { get; private set; }
        public uint L4MergeSpeedlast { get; private set; }
        public uint L5MergeCount { get; private set; }
        public uint L5MergesNow { get; private set; }
        public uint L5MergeSpeedaverage { get; private set; }
        public uint L5MergeSpeedlast { get; private set; }
        public uint L6MergeCount { get; private set; }
        public uint L6MergesNow { get; private set; }
        public uint L6MergeSpeedaverage { get; private set; }
        public uint L6MergeSpeedlast { get; private set; }
        public uint L7MergeCount { get; private set; }
        public uint L7MergesNow { get; private set; }
        public uint L7MergeSpeedaverage { get; private set; }
        public uint L7MergeSpeedlast { get; private set; }
        public uint L8MergeCount { get; private set; }
        public uint L8MergesNow { get; private set; }
        public uint L8MergeSpeedaverage { get; private set; }
        public uint L8MergeSpeedlast { get; private set; }
        public uint MasterIndexLevel { get; private set; }
        public uint MasterMergeProgress { get; private set; }
        public uint MasterMergesNow { get; private set; }
        public uint MasterMergestoDate { get; private set; }
        public string Name { get; private set; }
        public uint PersistentIndexes { get; private set; }
        public uint PersistentIndexesL1 { get; private set; }
        public uint PersistentIndexesL2 { get; private set; }
        public uint PersistentIndexesL3 { get; private set; }
        public uint PersistentIndexesL4 { get; private set; }
        public uint PersistentIndexesL5 { get; private set; }
        public uint PersistentIndexesL6 { get; private set; }
        public uint PersistentIndexesL7 { get; private set; }
        public uint PersistentIndexesL8 { get; private set; }
        public uint Queries { get; private set; }
        public uint QueriesFailed { get; private set; }
        public uint QueriesSucceeded { get; private set; }
        public uint ShadowMergeLevels { get; private set; }
        public uint ShadowMergeLevelsThreshold { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint UniqueKeys { get; private set; }
        public uint WorkItemsCreated { get; private set; }
        public uint WorkItemsDeleted { get; private set; }

        public static PerfFormattedData_WSearchIdxPi_SearchIndexer[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_WSearchIdxPi_SearchIndexer[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_WSearchIdxPi_SearchIndexer[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_WSearchIdxPi_SearchIndexer");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_WSearchIdxPi_SearchIndexer>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_WSearchIdxPi_SearchIndexer
                {
                    ActiveConnections = (uint) managementObject.Properties["ActiveConnections"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CleanWidSets = (uint) managementObject.Properties["CleanWidSets"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DirtyWidSets = (uint) managementObject.Properties["DirtyWidSets"].Value,
                    DocumentsFiltered = (uint) managementObject.Properties["DocumentsFiltered"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IndexSize = (uint) managementObject.Properties["IndexSize"].Value,
                    L0IndexesWordlists = (uint) managementObject.Properties["L0IndexesWordlists"].Value,
                    L0MergeFlushCount = (uint) managementObject.Properties["L0MergeFlushCount"].Value,
                    L0MergeFlushSpeedAverage = (uint) managementObject.Properties["L0MergeFlushSpeedAverage"].Value,
                    L0MergeFlushSpeedLast = (uint) managementObject.Properties["L0MergeFlushSpeedLast"].Value,
                    L0MergesflushesNow = (uint) managementObject.Properties["L0MergesflushesNow"].Value,
                    L1MergeCount = (uint) managementObject.Properties["L1MergeCount"].Value,
                    L1MergesNow = (uint) managementObject.Properties["L1MergesNow"].Value,
                    L1MergeSpeedaverage = (uint) managementObject.Properties["L1MergeSpeedaverage"].Value,
                    L1MergeSpeedlast = (uint) managementObject.Properties["L1MergeSpeedlast"].Value,
                    L2MergeCount = (uint) managementObject.Properties["L2MergeCount"].Value,
                    L2MergesNow = (uint) managementObject.Properties["L2MergesNow"].Value,
                    L2MergeSpeedaverage = (uint) managementObject.Properties["L2MergeSpeedaverage"].Value,
                    L2MergeSpeedlast = (uint) managementObject.Properties["L2MergeSpeedlast"].Value,
                    L3MergeCount = (uint) managementObject.Properties["L3MergeCount"].Value,
                    L3MergesNow = (uint) managementObject.Properties["L3MergesNow"].Value,
                    L3MergeSpeedaverage = (uint) managementObject.Properties["L3MergeSpeedaverage"].Value,
                    L3MergeSpeedlast = (uint) managementObject.Properties["L3MergeSpeedlast"].Value,
                    L4MergeCount = (uint) managementObject.Properties["L4MergeCount"].Value,
                    L4MergesNow = (uint) managementObject.Properties["L4MergesNow"].Value,
                    L4MergeSpeedaverage = (uint) managementObject.Properties["L4MergeSpeedaverage"].Value,
                    L4MergeSpeedlast = (uint) managementObject.Properties["L4MergeSpeedlast"].Value,
                    L5MergeCount = (uint) managementObject.Properties["L5MergeCount"].Value,
                    L5MergesNow = (uint) managementObject.Properties["L5MergesNow"].Value,
                    L5MergeSpeedaverage = (uint) managementObject.Properties["L5MergeSpeedaverage"].Value,
                    L5MergeSpeedlast = (uint) managementObject.Properties["L5MergeSpeedlast"].Value,
                    L6MergeCount = (uint) managementObject.Properties["L6MergeCount"].Value,
                    L6MergesNow = (uint) managementObject.Properties["L6MergesNow"].Value,
                    L6MergeSpeedaverage = (uint) managementObject.Properties["L6MergeSpeedaverage"].Value,
                    L6MergeSpeedlast = (uint) managementObject.Properties["L6MergeSpeedlast"].Value,
                    L7MergeCount = (uint) managementObject.Properties["L7MergeCount"].Value,
                    L7MergesNow = (uint) managementObject.Properties["L7MergesNow"].Value,
                    L7MergeSpeedaverage = (uint) managementObject.Properties["L7MergeSpeedaverage"].Value,
                    L7MergeSpeedlast = (uint) managementObject.Properties["L7MergeSpeedlast"].Value,
                    L8MergeCount = (uint) managementObject.Properties["L8MergeCount"].Value,
                    L8MergesNow = (uint) managementObject.Properties["L8MergesNow"].Value,
                    L8MergeSpeedaverage = (uint) managementObject.Properties["L8MergeSpeedaverage"].Value,
                    L8MergeSpeedlast = (uint) managementObject.Properties["L8MergeSpeedlast"].Value,
                    MasterIndexLevel = (uint) managementObject.Properties["MasterIndexLevel"].Value,
                    MasterMergeProgress = (uint) managementObject.Properties["MasterMergeProgress"].Value,
                    MasterMergesNow = (uint) managementObject.Properties["MasterMergesNow"].Value,
                    MasterMergestoDate = (uint) managementObject.Properties["MasterMergestoDate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PersistentIndexes = (uint) managementObject.Properties["PersistentIndexes"].Value,
                    PersistentIndexesL1 = (uint) managementObject.Properties["PersistentIndexesL1"].Value,
                    PersistentIndexesL2 = (uint) managementObject.Properties["PersistentIndexesL2"].Value,
                    PersistentIndexesL3 = (uint) managementObject.Properties["PersistentIndexesL3"].Value,
                    PersistentIndexesL4 = (uint) managementObject.Properties["PersistentIndexesL4"].Value,
                    PersistentIndexesL5 = (uint) managementObject.Properties["PersistentIndexesL5"].Value,
                    PersistentIndexesL6 = (uint) managementObject.Properties["PersistentIndexesL6"].Value,
                    PersistentIndexesL7 = (uint) managementObject.Properties["PersistentIndexesL7"].Value,
                    PersistentIndexesL8 = (uint) managementObject.Properties["PersistentIndexesL8"].Value,
                    Queries = (uint) managementObject.Properties["Queries"].Value,
                    QueriesFailed = (uint) managementObject.Properties["QueriesFailed"].Value,
                    QueriesSucceeded = (uint) managementObject.Properties["QueriesSucceeded"].Value,
                    ShadowMergeLevels = (uint) managementObject.Properties["ShadowMergeLevels"].Value,
                    ShadowMergeLevelsThreshold = (uint) managementObject.Properties["ShadowMergeLevelsThreshold"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    UniqueKeys = (uint) managementObject.Properties["UniqueKeys"].Value,
                    WorkItemsCreated = (uint) managementObject.Properties["WorkItemsCreated"].Value,
                    WorkItemsDeleted = (uint) managementObject.Properties["WorkItemsDeleted"].Value
                });

            return list.ToArray();
        }
    }
}