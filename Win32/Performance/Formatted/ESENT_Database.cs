using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class ESENT_Database
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

        public static IEnumerable<ESENT_Database> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ESENT_Database> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ESENT_Database> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_ESENT_Database");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ESENT_Database
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 DatabaseCacheMemoryCommitted = (ulong) (managementObject.Properties["DatabaseCacheMemoryCommitted"]?.Value ?? default(ulong)),
		 DatabaseCacheMemoryCommittedMB = (ulong) (managementObject.Properties["DatabaseCacheMemoryCommittedMB"]?.Value ?? default(ulong)),
		 DatabaseCacheMemoryReserved = (ulong) (managementObject.Properties["DatabaseCacheMemoryReserved"]?.Value ?? default(ulong)),
		 DatabaseCacheMemoryReservedMB = (ulong) (managementObject.Properties["DatabaseCacheMemoryReservedMB"]?.Value ?? default(ulong)),
		 DatabaseCacheMissAttachedAverageLatency = (ulong) (managementObject.Properties["DatabaseCacheMissAttachedAverageLatency"]?.Value ?? default(ulong)),
		 DatabaseCacheMissesPersec = (uint) (managementObject.Properties["DatabaseCacheMissesPersec"]?.Value ?? default(uint)),
		 DatabaseCachePercentDehydrated = (uint) (managementObject.Properties["DatabaseCachePercentDehydrated"]?.Value ?? default(uint)),
		 DatabaseCachePercentHit = (uint) (managementObject.Properties["DatabaseCachePercentHit"]?.Value ?? default(uint)),
		 DatabaseCachePercentHitUncorrelated = (uint) (managementObject.Properties["DatabaseCachePercentHitUncorrelated"]?.Value ?? default(uint)),
		 DatabaseCacheRequestsPersec = (uint) (managementObject.Properties["DatabaseCacheRequestsPersec"]?.Value ?? default(uint)),
		 DatabaseCacheSize = (ulong) (managementObject.Properties["DatabaseCacheSize"]?.Value ?? default(ulong)),
		 DatabaseCacheSizeEffective = (ulong) (managementObject.Properties["DatabaseCacheSizeEffective"]?.Value ?? default(ulong)),
		 DatabaseCacheSizeEffectiveMB = (ulong) (managementObject.Properties["DatabaseCacheSizeEffectiveMB"]?.Value ?? default(ulong)),
		 DatabaseCacheSizeMB = (ulong) (managementObject.Properties["DatabaseCacheSizeMB"]?.Value ?? default(ulong)),
		 DatabaseCacheSizeResident = (ulong) (managementObject.Properties["DatabaseCacheSizeResident"]?.Value ?? default(ulong)),
		 DatabaseCacheSizeResidentMB = (ulong) (managementObject.Properties["DatabaseCacheSizeResidentMB"]?.Value ?? default(ulong)),
		 DatabaseMaintenanceDuration = (uint) (managementObject.Properties["DatabaseMaintenanceDuration"]?.Value ?? default(uint)),
		 DatabaseMaintenancePagesBadChecksums = (uint) (managementObject.Properties["DatabaseMaintenancePagesBadChecksums"]?.Value ?? default(uint)),
		 DatabasePageEvictionsPersec = (uint) (managementObject.Properties["DatabasePageEvictionsPersec"]?.Value ?? default(uint)),
		 DatabasePageFaultsPersec = (uint) (managementObject.Properties["DatabasePageFaultsPersec"]?.Value ?? default(uint)),
		 DatabasePageFaultStallsPersec = (uint) (managementObject.Properties["DatabasePageFaultStallsPersec"]?.Value ?? default(uint)),
		 DefragmentationTasks = (uint) (managementObject.Properties["DefragmentationTasks"]?.Value ?? default(uint)),
		 DefragmentationTasksPending = (uint) (managementObject.Properties["DefragmentationTasksPending"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IODatabaseReadsAttachedAverageLatency = (ulong) (managementObject.Properties["IODatabaseReadsAttachedAverageLatency"]?.Value ?? default(ulong)),
		 IODatabaseReadsAttachedPersec = (uint) (managementObject.Properties["IODatabaseReadsAttachedPersec"]?.Value ?? default(uint)),
		 IODatabaseReadsAverageLatency = (ulong) (managementObject.Properties["IODatabaseReadsAverageLatency"]?.Value ?? default(ulong)),
		 IODatabaseReadsPersec = (uint) (managementObject.Properties["IODatabaseReadsPersec"]?.Value ?? default(uint)),
		 IODatabaseReadsRecoveryAverageLatency = (ulong) (managementObject.Properties["IODatabaseReadsRecoveryAverageLatency"]?.Value ?? default(ulong)),
		 IODatabaseReadsRecoveryPersec = (uint) (managementObject.Properties["IODatabaseReadsRecoveryPersec"]?.Value ?? default(uint)),
		 IODatabaseWritesAttachedAverageLatency = (ulong) (managementObject.Properties["IODatabaseWritesAttachedAverageLatency"]?.Value ?? default(ulong)),
		 IODatabaseWritesAttachedPersec = (uint) (managementObject.Properties["IODatabaseWritesAttachedPersec"]?.Value ?? default(uint)),
		 IODatabaseWritesAverageLatency = (ulong) (managementObject.Properties["IODatabaseWritesAverageLatency"]?.Value ?? default(ulong)),
		 IODatabaseWritesPersec = (uint) (managementObject.Properties["IODatabaseWritesPersec"]?.Value ?? default(uint)),
		 IODatabaseWritesRecoveryAverageLatency = (ulong) (managementObject.Properties["IODatabaseWritesRecoveryAverageLatency"]?.Value ?? default(ulong)),
		 IODatabaseWritesRecoveryPersec = (uint) (managementObject.Properties["IODatabaseWritesRecoveryPersec"]?.Value ?? default(uint)),
		 IOFlushMapWritesAverageLatency = (ulong) (managementObject.Properties["IOFlushMapWritesAverageLatency"]?.Value ?? default(ulong)),
		 IOFlushMapWritesPersec = (uint) (managementObject.Properties["IOFlushMapWritesPersec"]?.Value ?? default(uint)),
		 IOLogReadsAverageLatency = (ulong) (managementObject.Properties["IOLogReadsAverageLatency"]?.Value ?? default(ulong)),
		 IOLogReadsPersec = (uint) (managementObject.Properties["IOLogReadsPersec"]?.Value ?? default(uint)),
		 IOLogWritesAverageLatency = (ulong) (managementObject.Properties["IOLogWritesAverageLatency"]?.Value ?? default(ulong)),
		 IOLogWritesPersec = (uint) (managementObject.Properties["IOLogWritesPersec"]?.Value ?? default(uint)),
		 LogBytesGeneratedPersec = (uint) (managementObject.Properties["LogBytesGeneratedPersec"]?.Value ?? default(uint)),
		 LogBytesWritePersec = (uint) (managementObject.Properties["LogBytesWritePersec"]?.Value ?? default(uint)),
		 LogRecordStallsPersec = (uint) (managementObject.Properties["LogRecordStallsPersec"]?.Value ?? default(uint)),
		 LogThreadsWaiting = (uint) (managementObject.Properties["LogThreadsWaiting"]?.Value ?? default(uint)),
		 LogWritesPersec = (uint) (managementObject.Properties["LogWritesPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 SessionsInUse = (uint) (managementObject.Properties["SessionsInUse"]?.Value ?? default(uint)),
		 SessionsPercentUsed = (uint) (managementObject.Properties["SessionsPercentUsed"]?.Value ?? default(uint)),
		 TableClosesPersec = (uint) (managementObject.Properties["TableClosesPersec"]?.Value ?? default(uint)),
		 TableOpenCacheHitsPersec = (uint) (managementObject.Properties["TableOpenCacheHitsPersec"]?.Value ?? default(uint)),
		 TableOpenCacheMissesPersec = (uint) (managementObject.Properties["TableOpenCacheMissesPersec"]?.Value ?? default(uint)),
		 TableOpenCachePercentHit = (uint) (managementObject.Properties["TableOpenCachePercentHit"]?.Value ?? default(uint)),
		 TableOpensPersec = (uint) (managementObject.Properties["TableOpensPersec"]?.Value ?? default(uint)),
		 TablesOpen = (uint) (managementObject.Properties["TablesOpen"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 VersionBucketsAllocated = (uint) (managementObject.Properties["VersionBucketsAllocated"]?.Value ?? default(uint))
                };
        }
    }
}