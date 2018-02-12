using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseMirroring
                {
                     BytesReceivedPersec = (ulong) (managementObject.Properties["BytesReceivedPersec"]?.Value ?? default(ulong)),
		 BytesSentPersec = (ulong) (managementObject.Properties["BytesSentPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 LogBytesReceivedPersec = (ulong) (managementObject.Properties["LogBytesReceivedPersec"]?.Value ?? default(ulong)),
		 LogBytesRedonefromCachePersec = (ulong) (managementObject.Properties["LogBytesRedonefromCachePersec"]?.Value ?? default(ulong)),
		 LogBytesSentfromCachePersec = (ulong) (managementObject.Properties["LogBytesSentfromCachePersec"]?.Value ?? default(ulong)),
		 LogBytesSentPersec = (ulong) (managementObject.Properties["LogBytesSentPersec"]?.Value ?? default(ulong)),
		 LogCompressedBytesRcvdPersec = (ulong) (managementObject.Properties["LogCompressedBytesRcvdPersec"]?.Value ?? default(ulong)),
		 LogCompressedBytesSentPersec = (ulong) (managementObject.Properties["LogCompressedBytesSentPersec"]?.Value ?? default(ulong)),
		 LogHardenTimems = (ulong) (managementObject.Properties["LogHardenTimems"]?.Value ?? default(ulong)),
		 LogRemainingforUndoKB = (ulong) (managementObject.Properties["LogRemainingforUndoKB"]?.Value ?? default(ulong)),
		 LogScannedforUndoKB = (ulong) (managementObject.Properties["LogScannedforUndoKB"]?.Value ?? default(ulong)),
		 LogSendFlowControlTimems = (ulong) (managementObject.Properties["LogSendFlowControlTimems"]?.Value ?? default(ulong)),
		 LogSendQueueKB = (ulong) (managementObject.Properties["LogSendQueueKB"]?.Value ?? default(ulong)),
		 MirroredWriteTransactionsPersec = (ulong) (managementObject.Properties["MirroredWriteTransactionsPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PagesSentPersec = (ulong) (managementObject.Properties["PagesSentPersec"]?.Value ?? default(ulong)),
		 ReceivesPersec = (ulong) (managementObject.Properties["ReceivesPersec"]?.Value ?? default(ulong)),
		 RedoBytesPersec = (ulong) (managementObject.Properties["RedoBytesPersec"]?.Value ?? default(ulong)),
		 RedoQueueKB = (ulong) (managementObject.Properties["RedoQueueKB"]?.Value ?? default(ulong)),
		 SendPerReceiveAckTime = (ulong) (managementObject.Properties["SendPerReceiveAckTime"]?.Value ?? default(ulong)),
		 SendsPersec = (ulong) (managementObject.Properties["SendsPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TransactionDelay = (ulong) (managementObject.Properties["TransactionDelay"]?.Value ?? default(ulong))
                };
        }
    }
}