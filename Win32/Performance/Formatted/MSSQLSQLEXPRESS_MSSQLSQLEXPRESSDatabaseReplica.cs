using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong FileBytesReceivedPersec { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong LogBytesReceivedPersec { get; private set; }
		public ulong Logremainingforundo { get; private set; }
		public ulong LogSendQueue { get; private set; }
		public ulong MirroredWriteTransactionsPersec { get; private set; }
		public string Name { get; private set; }
		public ulong RecoveryQueue { get; private set; }
		public ulong RedoblockedPersec { get; private set; }
		public ulong RedoBytesRemaining { get; private set; }
		public ulong RedoneBytesPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong TotalLogrequiringundo { get; private set; }
		public ulong TransactionDelay { get; private set; }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FileBytesReceivedPersec = (ulong) (managementObject.Properties["FileBytesReceivedPersec"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 LogBytesReceivedPersec = (ulong) (managementObject.Properties["LogBytesReceivedPersec"]?.Value ?? default(ulong)),
		 Logremainingforundo = (ulong) (managementObject.Properties["Logremainingforundo"]?.Value ?? default(ulong)),
		 LogSendQueue = (ulong) (managementObject.Properties["LogSendQueue"]?.Value ?? default(ulong)),
		 MirroredWriteTransactionsPersec = (ulong) (managementObject.Properties["MirroredWriteTransactionsPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 RecoveryQueue = (ulong) (managementObject.Properties["RecoveryQueue"]?.Value ?? default(ulong)),
		 RedoblockedPersec = (ulong) (managementObject.Properties["RedoblockedPersec"]?.Value ?? default(ulong)),
		 RedoBytesRemaining = (ulong) (managementObject.Properties["RedoBytesRemaining"]?.Value ?? default(ulong)),
		 RedoneBytesPersec = (ulong) (managementObject.Properties["RedoneBytesPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalLogrequiringundo = (ulong) (managementObject.Properties["TotalLogrequiringundo"]?.Value ?? default(ulong)),
		 TransactionDelay = (ulong) (managementObject.Properties["TransactionDelay"]?.Value ?? default(ulong))
                };
        }
    }
}