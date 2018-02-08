using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica[] Retrieve(string remote,
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSDatabaseReplica
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FileBytesReceivedPersec = (ulong) managementObject.Properties["FileBytesReceivedPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    LogBytesReceivedPersec = (ulong) managementObject.Properties["LogBytesReceivedPersec"].Value,
                    Logremainingforundo = (ulong) managementObject.Properties["Logremainingforundo"].Value,
                    LogSendQueue = (ulong) managementObject.Properties["LogSendQueue"].Value,
                    MirroredWriteTransactionsPersec =
                        (ulong) managementObject.Properties["MirroredWriteTransactionsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    RecoveryQueue = (ulong) managementObject.Properties["RecoveryQueue"].Value,
                    RedoblockedPersec = (ulong) managementObject.Properties["RedoblockedPersec"].Value,
                    RedoBytesRemaining = (ulong) managementObject.Properties["RedoBytesRemaining"].Value,
                    RedoneBytesPersec = (ulong) managementObject.Properties["RedoneBytesPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalLogrequiringundo = (ulong) managementObject.Properties["TotalLogrequiringundo"].Value,
                    TransactionDelay = (ulong) managementObject.Properties["TransactionDelay"].Value
                });

            return list.ToArray();
        }
    }
}