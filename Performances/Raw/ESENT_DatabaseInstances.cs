using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_ESENT_DatabaseInstances
    {
        public string Caption { get; private set; }
        public ulong DatabaseCacheMissAttachedAverageLatency { get; private set; }
        public uint DatabaseCacheMissAttachedAverageLatency_Base { get; private set; }
        public uint DatabaseCacheMissesPersec { get; private set; }
        public uint DatabaseCachePercentHit { get; private set; }
        public uint DatabaseCachePercentHit_Base { get; private set; }
        public uint DatabaseCachePercentHitUncorrelated { get; private set; }
        public uint DatabaseCachePercentHitUncorrelated_Base { get; private set; }
        public uint DatabaseCacheRequestsPersec { get; private set; }
        public ulong DatabaseCacheSizeMB { get; private set; }
        public uint DatabaseMaintenanceDuration { get; private set; }
        public uint DatabaseMaintenancePagesBadChecksums { get; private set; }
        public uint DefragmentationTasks { get; private set; }
        public uint DefragmentationTasksPending { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong IODatabaseReadsAttachedAverageLatency { get; private set; }
        public uint IODatabaseReadsAttachedAverageLatency_Base { get; private set; }
        public uint IODatabaseReadsAttachedPersec { get; private set; }
        public ulong IODatabaseReadsAverageLatency { get; private set; }
        public uint IODatabaseReadsAverageLatency_Base { get; private set; }
        public uint IODatabaseReadsPersec { get; private set; }
        public ulong IODatabaseReadsRecoveryAverageLatency { get; private set; }
        public uint IODatabaseReadsRecoveryAverageLatency_Base { get; private set; }
        public uint IODatabaseReadsRecoveryPersec { get; private set; }
        public ulong IODatabaseWritesAttachedAverageLatency { get; private set; }
        public uint IODatabaseWritesAttachedAverageLatency_Base { get; private set; }
        public uint IODatabaseWritesAttachedPersec { get; private set; }
        public ulong IODatabaseWritesAverageLatency { get; private set; }
        public uint IODatabaseWritesAverageLatency_Base { get; private set; }
        public uint IODatabaseWritesPersec { get; private set; }
        public ulong IODatabaseWritesRecoveryAverageLatency { get; private set; }
        public uint IODatabaseWritesRecoveryAverageLatency_Base { get; private set; }
        public uint IODatabaseWritesRecoveryPersec { get; private set; }
        public ulong IOFlushMapWritesAverageLatency { get; private set; }
        public uint IOFlushMapWritesAverageLatency_Base { get; private set; }
        public uint IOFlushMapWritesPersec { get; private set; }
        public ulong IOLogReadsAverageLatency { get; private set; }
        public uint IOLogReadsAverageLatency_Base { get; private set; }
        public uint IOLogReadsPersec { get; private set; }
        public ulong IOLogWritesAverageLatency { get; private set; }
        public uint IOLogWritesAverageLatency_Base { get; private set; }
        public uint IOLogWritesPersec { get; private set; }
        public uint LogBytesGeneratedPersec { get; private set; }
        public uint LogBytesWritePersec { get; private set; }
        public uint LogCheckpointDepthasaPercentofTarget { get; private set; }
        public uint LogCheckpointDepthasaPercentofTarget_Base { get; private set; }
        public uint LogFileCurrentGeneration { get; private set; }
        public uint LogFilesGenerated { get; private set; }
        public uint LogFilesGeneratedPrematurely { get; private set; }
        public uint LogGenerationCheckpointDepth { get; private set; }
        public uint LogGenerationCheckpointDepthMax { get; private set; }
        public uint LogGenerationCheckpointDepthTarget { get; private set; }
        public uint LogGenerationLossResiliencyDepth { get; private set; }
        public uint LogRecordStallsPersec { get; private set; }
        public uint LogThreadsWaiting { get; private set; }
        public uint LogWritesPersec { get; private set; }
        public string Name { get; private set; }
        public uint SessionsInUse { get; private set; }
        public uint SessionsPercentUsed { get; private set; }
        public uint SessionsPercentUsed_Base { get; private set; }
        public uint StreamingBackupPagesReadPersec { get; private set; }
        public uint TableClosesPersec { get; private set; }
        public uint TableOpenCacheHitsPersec { get; private set; }
        public uint TableOpenCacheMissesPersec { get; private set; }
        public uint TableOpenCachePercentHit { get; private set; }
        public uint TableOpenCachePercentHit_Base { get; private set; }
        public uint TableOpensPersec { get; private set; }
        public uint TablesOpen { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint Versionbucketsallocated { get; private set; }

        public static PerfRawData_ESENT_DatabaseInstances[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_ESENT_DatabaseInstances[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_ESENT_DatabaseInstances[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_ESENT_DatabaseInstances");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_ESENT_DatabaseInstances>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_ESENT_DatabaseInstances
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    DatabaseCacheMissAttachedAverageLatency = (ulong) managementObject
                        .Properties["DatabaseCacheMissAttachedAverageLatency"].Value,
                    DatabaseCacheMissAttachedAverageLatency_Base = (uint) managementObject
                        .Properties["DatabaseCacheMissAttachedAverageLatency_Base"].Value,
                    DatabaseCacheMissesPersec = (uint) managementObject.Properties["DatabaseCacheMissesPersec"].Value,
                    DatabaseCachePercentHit = (uint) managementObject.Properties["DatabaseCachePercentHit"].Value,
                    DatabaseCachePercentHit_Base = (uint) managementObject.Properties["DatabaseCachePercentHit_Base"]
                        .Value,
                    DatabaseCachePercentHitUncorrelated =
                        (uint) managementObject.Properties["DatabaseCachePercentHitUncorrelated"].Value,
                    DatabaseCachePercentHitUncorrelated_Base = (uint) managementObject
                        .Properties["DatabaseCachePercentHitUncorrelated_Base"].Value,
                    DatabaseCacheRequestsPersec = (uint) managementObject.Properties["DatabaseCacheRequestsPersec"]
                        .Value,
                    DatabaseCacheSizeMB = (ulong) managementObject.Properties["DatabaseCacheSizeMB"].Value,
                    DatabaseMaintenanceDuration = (uint) managementObject.Properties["DatabaseMaintenanceDuration"]
                        .Value,
                    DatabaseMaintenancePagesBadChecksums = (uint) managementObject
                        .Properties["DatabaseMaintenancePagesBadChecksums"].Value,
                    DefragmentationTasks = (uint) managementObject.Properties["DefragmentationTasks"].Value,
                    DefragmentationTasksPending = (uint) managementObject.Properties["DefragmentationTasksPending"]
                        .Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IODatabaseReadsAttachedAverageLatency = (ulong) managementObject
                        .Properties["IODatabaseReadsAttachedAverageLatency"].Value,
                    IODatabaseReadsAttachedAverageLatency_Base = (uint) managementObject
                        .Properties["IODatabaseReadsAttachedAverageLatency_Base"].Value,
                    IODatabaseReadsAttachedPersec = (uint) managementObject.Properties["IODatabaseReadsAttachedPersec"]
                        .Value,
                    IODatabaseReadsAverageLatency =
                        (ulong) managementObject.Properties["IODatabaseReadsAverageLatency"].Value,
                    IODatabaseReadsAverageLatency_Base =
                        (uint) managementObject.Properties["IODatabaseReadsAverageLatency_Base"].Value,
                    IODatabaseReadsPersec = (uint) managementObject.Properties["IODatabaseReadsPersec"].Value,
                    IODatabaseReadsRecoveryAverageLatency = (ulong) managementObject
                        .Properties["IODatabaseReadsRecoveryAverageLatency"].Value,
                    IODatabaseReadsRecoveryAverageLatency_Base = (uint) managementObject
                        .Properties["IODatabaseReadsRecoveryAverageLatency_Base"].Value,
                    IODatabaseReadsRecoveryPersec = (uint) managementObject.Properties["IODatabaseReadsRecoveryPersec"]
                        .Value,
                    IODatabaseWritesAttachedAverageLatency = (ulong) managementObject
                        .Properties["IODatabaseWritesAttachedAverageLatency"].Value,
                    IODatabaseWritesAttachedAverageLatency_Base = (uint) managementObject
                        .Properties["IODatabaseWritesAttachedAverageLatency_Base"].Value,
                    IODatabaseWritesAttachedPersec =
                        (uint) managementObject.Properties["IODatabaseWritesAttachedPersec"].Value,
                    IODatabaseWritesAverageLatency =
                        (ulong) managementObject.Properties["IODatabaseWritesAverageLatency"].Value,
                    IODatabaseWritesAverageLatency_Base =
                        (uint) managementObject.Properties["IODatabaseWritesAverageLatency_Base"].Value,
                    IODatabaseWritesPersec = (uint) managementObject.Properties["IODatabaseWritesPersec"].Value,
                    IODatabaseWritesRecoveryAverageLatency = (ulong) managementObject
                        .Properties["IODatabaseWritesRecoveryAverageLatency"].Value,
                    IODatabaseWritesRecoveryAverageLatency_Base = (uint) managementObject
                        .Properties["IODatabaseWritesRecoveryAverageLatency_Base"].Value,
                    IODatabaseWritesRecoveryPersec =
                        (uint) managementObject.Properties["IODatabaseWritesRecoveryPersec"].Value,
                    IOFlushMapWritesAverageLatency =
                        (ulong) managementObject.Properties["IOFlushMapWritesAverageLatency"].Value,
                    IOFlushMapWritesAverageLatency_Base =
                        (uint) managementObject.Properties["IOFlushMapWritesAverageLatency_Base"].Value,
                    IOFlushMapWritesPersec = (uint) managementObject.Properties["IOFlushMapWritesPersec"].Value,
                    IOLogReadsAverageLatency = (ulong) managementObject.Properties["IOLogReadsAverageLatency"].Value,
                    IOLogReadsAverageLatency_Base = (uint) managementObject.Properties["IOLogReadsAverageLatency_Base"]
                        .Value,
                    IOLogReadsPersec = (uint) managementObject.Properties["IOLogReadsPersec"].Value,
                    IOLogWritesAverageLatency = (ulong) managementObject.Properties["IOLogWritesAverageLatency"].Value,
                    IOLogWritesAverageLatency_Base =
                        (uint) managementObject.Properties["IOLogWritesAverageLatency_Base"].Value,
                    IOLogWritesPersec = (uint) managementObject.Properties["IOLogWritesPersec"].Value,
                    LogBytesGeneratedPersec = (uint) managementObject.Properties["LogBytesGeneratedPersec"].Value,
                    LogBytesWritePersec = (uint) managementObject.Properties["LogBytesWritePersec"].Value,
                    LogCheckpointDepthasaPercentofTarget = (uint) managementObject
                        .Properties["LogCheckpointDepthasaPercentofTarget"].Value,
                    LogCheckpointDepthasaPercentofTarget_Base = (uint) managementObject
                        .Properties["LogCheckpointDepthasaPercentofTarget_Base"].Value,
                    LogFileCurrentGeneration = (uint) managementObject.Properties["LogFileCurrentGeneration"].Value,
                    LogFilesGenerated = (uint) managementObject.Properties["LogFilesGenerated"].Value,
                    LogFilesGeneratedPrematurely = (uint) managementObject.Properties["LogFilesGeneratedPrematurely"]
                        .Value,
                    LogGenerationCheckpointDepth = (uint) managementObject.Properties["LogGenerationCheckpointDepth"]
                        .Value,
                    LogGenerationCheckpointDepthMax =
                        (uint) managementObject.Properties["LogGenerationCheckpointDepthMax"].Value,
                    LogGenerationCheckpointDepthTarget =
                        (uint) managementObject.Properties["LogGenerationCheckpointDepthTarget"].Value,
                    LogGenerationLossResiliencyDepth =
                        (uint) managementObject.Properties["LogGenerationLossResiliencyDepth"].Value,
                    LogRecordStallsPersec = (uint) managementObject.Properties["LogRecordStallsPersec"].Value,
                    LogThreadsWaiting = (uint) managementObject.Properties["LogThreadsWaiting"].Value,
                    LogWritesPersec = (uint) managementObject.Properties["LogWritesPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SessionsInUse = (uint) managementObject.Properties["SessionsInUse"].Value,
                    SessionsPercentUsed = (uint) managementObject.Properties["SessionsPercentUsed"].Value,
                    SessionsPercentUsed_Base = (uint) managementObject.Properties["SessionsPercentUsed_Base"].Value,
                    StreamingBackupPagesReadPersec =
                        (uint) managementObject.Properties["StreamingBackupPagesReadPersec"].Value,
                    TableClosesPersec = (uint) managementObject.Properties["TableClosesPersec"].Value,
                    TableOpenCacheHitsPersec = (uint) managementObject.Properties["TableOpenCacheHitsPersec"].Value,
                    TableOpenCacheMissesPersec = (uint) managementObject.Properties["TableOpenCacheMissesPersec"].Value,
                    TableOpenCachePercentHit = (uint) managementObject.Properties["TableOpenCachePercentHit"].Value,
                    TableOpenCachePercentHit_Base = (uint) managementObject.Properties["TableOpenCachePercentHit_Base"]
                        .Value,
                    TableOpensPersec = (uint) managementObject.Properties["TableOpensPersec"].Value,
                    TablesOpen = (uint) managementObject.Properties["TablesOpen"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    Versionbucketsallocated = (uint) managementObject.Properties["Versionbucketsallocated"].Value
                });

            return list.ToArray();
        }
    }
}