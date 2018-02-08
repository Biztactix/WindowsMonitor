using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring
    {
        public ulong BytesReceivedPersec { get; private set; }
        public ulong BytesSentPersec { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong LogBytesReceivedPersec { get; private set; }
        public ulong LogBytesRedonefromCachePersec { get; private set; }
        public ulong LogBytesSentfromCachePersec { get; private set; }
        public ulong LogBytesSentPersec { get; private set; }
        public ulong LogCompressedBytesRcvdPersec { get; private set; }
        public ulong LogCompressedBytesSentPersec { get; private set; }
        public ulong LogHardenTimems { get; private set; }
        public ulong LogRemainingforUndoKB { get; private set; }
        public ulong LogScannedforUndoKB { get; private set; }
        public ulong LogSendFlowControlTimems { get; private set; }
        public ulong LogSendQueueKB { get; private set; }
        public ulong MirroredWriteTransactionsPersec { get; private set; }
        public string Name { get; private set; }
        public ulong PagesSentPersec { get; private set; }
        public ulong ReceivesPersec { get; private set; }
        public ulong RedoBytesPersec { get; private set; }
        public ulong RedoQueueKB { get; private set; }
        public ulong SendPerReceiveAckTime { get; private set; }
        public ulong SendsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TransactionDelay { get; private set; }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring[] Retrieve(string remote,
            string username, string password)
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring
                {
                    BytesReceivedPersec = (ulong) managementObject.Properties["BytesReceivedPersec"].Value,
                    BytesSentPersec = (ulong) managementObject.Properties["BytesSentPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    LogBytesReceivedPersec = (ulong) managementObject.Properties["LogBytesReceivedPersec"].Value,
                    LogBytesRedonefromCachePersec =
                        (ulong) managementObject.Properties["LogBytesRedonefromCachePersec"].Value,
                    LogBytesSentfromCachePersec = (ulong) managementObject.Properties["LogBytesSentfromCachePersec"]
                        .Value,
                    LogBytesSentPersec = (ulong) managementObject.Properties["LogBytesSentPersec"].Value,
                    LogCompressedBytesRcvdPersec = (ulong) managementObject.Properties["LogCompressedBytesRcvdPersec"]
                        .Value,
                    LogCompressedBytesSentPersec = (ulong) managementObject.Properties["LogCompressedBytesSentPersec"]
                        .Value,
                    LogHardenTimems = (ulong) managementObject.Properties["LogHardenTimems"].Value,
                    LogRemainingforUndoKB = (ulong) managementObject.Properties["LogRemainingforUndoKB"].Value,
                    LogScannedforUndoKB = (ulong) managementObject.Properties["LogScannedforUndoKB"].Value,
                    LogSendFlowControlTimems = (ulong) managementObject.Properties["LogSendFlowControlTimems"].Value,
                    LogSendQueueKB = (ulong) managementObject.Properties["LogSendQueueKB"].Value,
                    MirroredWriteTransactionsPersec =
                        (ulong) managementObject.Properties["MirroredWriteTransactionsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PagesSentPersec = (ulong) managementObject.Properties["PagesSentPersec"].Value,
                    ReceivesPersec = (ulong) managementObject.Properties["ReceivesPersec"].Value,
                    RedoBytesPersec = (ulong) managementObject.Properties["RedoBytesPersec"].Value,
                    RedoQueueKB = (ulong) managementObject.Properties["RedoQueueKB"].Value,
                    SendPerReceiveAckTime = (ulong) managementObject.Properties["SendPerReceiveAckTime"].Value,
                    SendsPersec = (ulong) managementObject.Properties["SendsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TransactionDelay = (ulong) managementObject.Properties["TransactionDelay"].Value
                });

            return list.ToArray();
        }
    }
}