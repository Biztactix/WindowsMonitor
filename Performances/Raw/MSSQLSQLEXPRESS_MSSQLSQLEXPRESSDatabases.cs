using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabases
    {
        public ulong ActiveTransactions { get; private set; }
        public ulong BackupPerRestoreThroughputPersec { get; private set; }
        public ulong BulkCopyRowsPersec { get; private set; }
        public ulong BulkCopyThroughputPersec { get; private set; }
        public string Caption { get; private set; }
        public ulong Committableentries { get; private set; }
        public ulong DataFilesSizeKB { get; private set; }
        public ulong DBCCLogicalScanBytesPersec { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong GroupCommitTimePersec { get; private set; }
        public ulong LogBytesFlushedPersec { get; private set; }
        public ulong LogCacheHitRatio { get; private set; }
        public ulong LogCacheHitRatio_Base { get; private set; }
        public ulong LogCacheReadsPersec { get; private set; }
        public ulong LogFilesSizeKB { get; private set; }
        public ulong LogFilesUsedSizeKB { get; private set; }
        public ulong LogFlushesPersec { get; private set; }
        public ulong LogFlushWaitsPersec { get; private set; }
        public ulong LogFlushWaitTime { get; private set; }
        public ulong LogFlushWriteTimems { get; private set; }
        public ulong LogGrowths { get; private set; }
        public ulong LogPoolCacheMissesPersec { get; private set; }
        public ulong LogPoolDiskReadsPersec { get; private set; }
        public ulong LogPoolRequestsPersec { get; private set; }
        public ulong LogShrinks { get; private set; }
        public ulong LogTruncations { get; private set; }
        public string Name { get; private set; }
        public ulong PercentLogUsed { get; private set; }
        public ulong ReplPendingXacts { get; private set; }
        public ulong ReplTransRate { get; private set; }
        public ulong ShrinkDataMovementBytesPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TrackedtransactionsPersec { get; private set; }
        public ulong TransactionsPersec { get; private set; }
        public ulong WriteTransactionsPersec { get; private set; }
        public ulong XTPMemoryUsedKB { get; private set; }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabases[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabases[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabases[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabases");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabases>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabases
                {
                    ActiveTransactions = (ulong) managementObject.Properties["ActiveTransactions"].Value,
                    BackupPerRestoreThroughputPersec =
                        (ulong) managementObject.Properties["BackupPerRestoreThroughputPersec"].Value,
                    BulkCopyRowsPersec = (ulong) managementObject.Properties["BulkCopyRowsPersec"].Value,
                    BulkCopyThroughputPersec = (ulong) managementObject.Properties["BulkCopyThroughputPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Committableentries = (ulong) managementObject.Properties["Committableentries"].Value,
                    DataFilesSizeKB = (ulong) managementObject.Properties["DataFilesSizeKB"].Value,
                    DBCCLogicalScanBytesPersec =
                        (ulong) managementObject.Properties["DBCCLogicalScanBytesPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    GroupCommitTimePersec = (ulong) managementObject.Properties["GroupCommitTimePersec"].Value,
                    LogBytesFlushedPersec = (ulong) managementObject.Properties["LogBytesFlushedPersec"].Value,
                    LogCacheHitRatio = (ulong) managementObject.Properties["LogCacheHitRatio"].Value,
                    LogCacheHitRatio_Base = (ulong) managementObject.Properties["LogCacheHitRatio_Base"].Value,
                    LogCacheReadsPersec = (ulong) managementObject.Properties["LogCacheReadsPersec"].Value,
                    LogFilesSizeKB = (ulong) managementObject.Properties["LogFilesSizeKB"].Value,
                    LogFilesUsedSizeKB = (ulong) managementObject.Properties["LogFilesUsedSizeKB"].Value,
                    LogFlushesPersec = (ulong) managementObject.Properties["LogFlushesPersec"].Value,
                    LogFlushWaitsPersec = (ulong) managementObject.Properties["LogFlushWaitsPersec"].Value,
                    LogFlushWaitTime = (ulong) managementObject.Properties["LogFlushWaitTime"].Value,
                    LogFlushWriteTimems = (ulong) managementObject.Properties["LogFlushWriteTimems"].Value,
                    LogGrowths = (ulong) managementObject.Properties["LogGrowths"].Value,
                    LogPoolCacheMissesPersec = (ulong) managementObject.Properties["LogPoolCacheMissesPersec"].Value,
                    LogPoolDiskReadsPersec = (ulong) managementObject.Properties["LogPoolDiskReadsPersec"].Value,
                    LogPoolRequestsPersec = (ulong) managementObject.Properties["LogPoolRequestsPersec"].Value,
                    LogShrinks = (ulong) managementObject.Properties["LogShrinks"].Value,
                    LogTruncations = (ulong) managementObject.Properties["LogTruncations"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PercentLogUsed = (ulong) managementObject.Properties["PercentLogUsed"].Value,
                    ReplPendingXacts = (ulong) managementObject.Properties["ReplPendingXacts"].Value,
                    ReplTransRate = (ulong) managementObject.Properties["ReplTransRate"].Value,
                    ShrinkDataMovementBytesPersec =
                        (ulong) managementObject.Properties["ShrinkDataMovementBytesPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TrackedtransactionsPersec = (ulong) managementObject.Properties["TrackedtransactionsPersec"].Value,
                    TransactionsPersec = (ulong) managementObject.Properties["TransactionsPersec"].Value,
                    WriteTransactionsPersec = (ulong) managementObject.Properties["WriteTransactionsPersec"].Value,
                    XTPMemoryUsedKB = (ulong) managementObject.Properties["XTPMemoryUsedKB"].Value
                });

            return list.ToArray();
        }
    }
}