using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_ESENT_Database
    {
        public string Caption { get; private set; }
        public ulong DatabaseCacheMemoryCommitted { get; private set; }
        public ulong DatabaseCacheMemoryCommittedMB { get; private set; }
        public ulong DatabaseCacheMemoryReserved { get; private set; }
        public ulong DatabaseCacheMemoryReservedMB { get; private set; }
        public ulong DatabaseCacheMissAttachedAverageLatency { get; private set; }
        public uint DatabaseCacheMissesPersec { get; private set; }
        public uint DatabaseCachePercentDehydrated { get; private set; }
        public uint DatabaseCachePercentHit { get; private set; }
        public uint DatabaseCachePercentHitUncorrelated { get; private set; }
        public uint DatabaseCacheRequestsPersec { get; private set; }
        public ulong DatabaseCacheSize { get; private set; }
        public ulong DatabaseCacheSizeEffective { get; private set; }
        public ulong DatabaseCacheSizeEffectiveMB { get; private set; }
        public ulong DatabaseCacheSizeMB { get; private set; }
        public ulong DatabaseCacheSizeResident { get; private set; }
        public ulong DatabaseCacheSizeResidentMB { get; private set; }
        public uint DatabaseMaintenanceDuration { get; private set; }
        public uint DatabaseMaintenancePagesBadChecksums { get; private set; }
        public uint DatabasePageEvictionsPersec { get; private set; }
        public uint DatabasePageFaultsPersec { get; private set; }
        public uint DatabasePageFaultStallsPersec { get; private set; }
        public uint DefragmentationTasks { get; private set; }
        public uint DefragmentationTasksPending { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong IODatabaseReadsAttachedAverageLatency { get; private set; }
        public uint IODatabaseReadsAttachedPersec { get; private set; }
        public ulong IODatabaseReadsAverageLatency { get; private set; }
        public uint IODatabaseReadsPersec { get; private set; }
        public ulong IODatabaseReadsRecoveryAverageLatency { get; private set; }
        public uint IODatabaseReadsRecoveryPersec { get; private set; }
        public ulong IODatabaseWritesAttachedAverageLatency { get; private set; }
        public uint IODatabaseWritesAttachedPersec { get; private set; }
        public ulong IODatabaseWritesAverageLatency { get; private set; }
        public uint IODatabaseWritesPersec { get; private set; }
        public ulong IODatabaseWritesRecoveryAverageLatency { get; private set; }
        public uint IODatabaseWritesRecoveryPersec { get; private set; }
        public ulong IOFlushMapWritesAverageLatency { get; private set; }
        public uint IOFlushMapWritesPersec { get; private set; }
        public ulong IOLogReadsAverageLatency { get; private set; }
        public uint IOLogReadsPersec { get; private set; }
        public ulong IOLogWritesAverageLatency { get; private set; }
        public uint IOLogWritesPersec { get; private set; }
        public uint LogBytesGeneratedPersec { get; private set; }
        public uint LogBytesWritePersec { get; private set; }
        public uint LogRecordStallsPersec { get; private set; }
        public uint LogThreadsWaiting { get; private set; }
        public uint LogWritesPersec { get; private set; }
        public string Name { get; private set; }
        public uint SessionsInUse { get; private set; }
        public uint SessionsPercentUsed { get; private set; }
        public uint TableClosesPersec { get; private set; }
        public uint TableOpenCacheHitsPersec { get; private set; }
        public uint TableOpenCacheMissesPersec { get; private set; }
        public uint TableOpenCachePercentHit { get; private set; }
        public uint TableOpensPersec { get; private set; }
        public uint TablesOpen { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint VersionBucketsAllocated { get; private set; }

        public static PerfFormattedData_ESENT_Database[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_ESENT_Database[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_ESENT_Database[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_ESENT_Database");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_ESENT_Database>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_ESENT_Database
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    DatabaseCacheMemoryCommitted = (ulong) managementObject.Properties["DatabaseCacheMemoryCommitted"]
                        .Value,
                    DatabaseCacheMemoryCommittedMB =
                        (ulong) managementObject.Properties["DatabaseCacheMemoryCommittedMB"].Value,
                    DatabaseCacheMemoryReserved = (ulong) managementObject.Properties["DatabaseCacheMemoryReserved"]
                        .Value,
                    DatabaseCacheMemoryReservedMB =
                        (ulong) managementObject.Properties["DatabaseCacheMemoryReservedMB"].Value,
                    DatabaseCacheMissAttachedAverageLatency = (ulong) managementObject
                        .Properties["DatabaseCacheMissAttachedAverageLatency"].Value,
                    DatabaseCacheMissesPersec = (uint) managementObject.Properties["DatabaseCacheMissesPersec"].Value,
                    DatabaseCachePercentDehydrated =
                        (uint) managementObject.Properties["DatabaseCachePercentDehydrated"].Value,
                    DatabaseCachePercentHit = (uint) managementObject.Properties["DatabaseCachePercentHit"].Value,
                    DatabaseCachePercentHitUncorrelated =
                        (uint) managementObject.Properties["DatabaseCachePercentHitUncorrelated"].Value,
                    DatabaseCacheRequestsPersec = (uint) managementObject.Properties["DatabaseCacheRequestsPersec"]
                        .Value,
                    DatabaseCacheSize = (ulong) managementObject.Properties["DatabaseCacheSize"].Value,
                    DatabaseCacheSizeEffective =
                        (ulong) managementObject.Properties["DatabaseCacheSizeEffective"].Value,
                    DatabaseCacheSizeEffectiveMB = (ulong) managementObject.Properties["DatabaseCacheSizeEffectiveMB"]
                        .Value,
                    DatabaseCacheSizeMB = (ulong) managementObject.Properties["DatabaseCacheSizeMB"].Value,
                    DatabaseCacheSizeResident = (ulong) managementObject.Properties["DatabaseCacheSizeResident"].Value,
                    DatabaseCacheSizeResidentMB = (ulong) managementObject.Properties["DatabaseCacheSizeResidentMB"]
                        .Value,
                    DatabaseMaintenanceDuration = (uint) managementObject.Properties["DatabaseMaintenanceDuration"]
                        .Value,
                    DatabaseMaintenancePagesBadChecksums = (uint) managementObject
                        .Properties["DatabaseMaintenancePagesBadChecksums"].Value,
                    DatabasePageEvictionsPersec = (uint) managementObject.Properties["DatabasePageEvictionsPersec"]
                        .Value,
                    DatabasePageFaultsPersec = (uint) managementObject.Properties["DatabasePageFaultsPersec"].Value,
                    DatabasePageFaultStallsPersec = (uint) managementObject.Properties["DatabasePageFaultStallsPersec"]
                        .Value,
                    DefragmentationTasks = (uint) managementObject.Properties["DefragmentationTasks"].Value,
                    DefragmentationTasksPending = (uint) managementObject.Properties["DefragmentationTasksPending"]
                        .Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IODatabaseReadsAttachedAverageLatency = (ulong) managementObject
                        .Properties["IODatabaseReadsAttachedAverageLatency"].Value,
                    IODatabaseReadsAttachedPersec = (uint) managementObject.Properties["IODatabaseReadsAttachedPersec"]
                        .Value,
                    IODatabaseReadsAverageLatency =
                        (ulong) managementObject.Properties["IODatabaseReadsAverageLatency"].Value,
                    IODatabaseReadsPersec = (uint) managementObject.Properties["IODatabaseReadsPersec"].Value,
                    IODatabaseReadsRecoveryAverageLatency = (ulong) managementObject
                        .Properties["IODatabaseReadsRecoveryAverageLatency"].Value,
                    IODatabaseReadsRecoveryPersec = (uint) managementObject.Properties["IODatabaseReadsRecoveryPersec"]
                        .Value,
                    IODatabaseWritesAttachedAverageLatency = (ulong) managementObject
                        .Properties["IODatabaseWritesAttachedAverageLatency"].Value,
                    IODatabaseWritesAttachedPersec =
                        (uint) managementObject.Properties["IODatabaseWritesAttachedPersec"].Value,
                    IODatabaseWritesAverageLatency =
                        (ulong) managementObject.Properties["IODatabaseWritesAverageLatency"].Value,
                    IODatabaseWritesPersec = (uint) managementObject.Properties["IODatabaseWritesPersec"].Value,
                    IODatabaseWritesRecoveryAverageLatency = (ulong) managementObject
                        .Properties["IODatabaseWritesRecoveryAverageLatency"].Value,
                    IODatabaseWritesRecoveryPersec =
                        (uint) managementObject.Properties["IODatabaseWritesRecoveryPersec"].Value,
                    IOFlushMapWritesAverageLatency =
                        (ulong) managementObject.Properties["IOFlushMapWritesAverageLatency"].Value,
                    IOFlushMapWritesPersec = (uint) managementObject.Properties["IOFlushMapWritesPersec"].Value,
                    IOLogReadsAverageLatency = (ulong) managementObject.Properties["IOLogReadsAverageLatency"].Value,
                    IOLogReadsPersec = (uint) managementObject.Properties["IOLogReadsPersec"].Value,
                    IOLogWritesAverageLatency = (ulong) managementObject.Properties["IOLogWritesAverageLatency"].Value,
                    IOLogWritesPersec = (uint) managementObject.Properties["IOLogWritesPersec"].Value,
                    LogBytesGeneratedPersec = (uint) managementObject.Properties["LogBytesGeneratedPersec"].Value,
                    LogBytesWritePersec = (uint) managementObject.Properties["LogBytesWritePersec"].Value,
                    LogRecordStallsPersec = (uint) managementObject.Properties["LogRecordStallsPersec"].Value,
                    LogThreadsWaiting = (uint) managementObject.Properties["LogThreadsWaiting"].Value,
                    LogWritesPersec = (uint) managementObject.Properties["LogWritesPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SessionsInUse = (uint) managementObject.Properties["SessionsInUse"].Value,
                    SessionsPercentUsed = (uint) managementObject.Properties["SessionsPercentUsed"].Value,
                    TableClosesPersec = (uint) managementObject.Properties["TableClosesPersec"].Value,
                    TableOpenCacheHitsPersec = (uint) managementObject.Properties["TableOpenCacheHitsPersec"].Value,
                    TableOpenCacheMissesPersec = (uint) managementObject.Properties["TableOpenCacheMissesPersec"].Value,
                    TableOpenCachePercentHit = (uint) managementObject.Properties["TableOpenCachePercentHit"].Value,
                    TableOpensPersec = (uint) managementObject.Properties["TableOpensPersec"].Value,
                    TablesOpen = (uint) managementObject.Properties["TablesOpen"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    VersionBucketsAllocated = (uint) managementObject.Properties["VersionBucketsAllocated"].Value
                });

            return list.ToArray();
        }
    }
}