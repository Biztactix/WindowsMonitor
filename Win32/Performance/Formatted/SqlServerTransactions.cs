using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class SqlServerTransactions
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong FreeSpaceintempdbKB { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong LongestTransactionRunningTime { get; private set; }
		public string Name { get; private set; }
		public ulong NonSnapshotVersionTransactions { get; private set; }
		public ulong SnapshotTransactions { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong Transactions { get; private set; }
		public ulong Updateconflictratio { get; private set; }
		public ulong UpdateSnapshotTransactions { get; private set; }
		public ulong VersionCleanuprateKBPers { get; private set; }
		public ulong VersionGenerationrateKBPers { get; private set; }
		public ulong VersionStoreSizeKB { get; private set; }
		public ulong VersionStoreunitcount { get; private set; }
		public ulong VersionStoreunitcreation { get; private set; }
		public ulong VersionStoreunittruncation { get; private set; }

        public static IEnumerable<SqlServerTransactions> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlServerTransactions> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlServerTransactions> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerTransactions");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlServerTransactions
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FreeSpaceintempdbKB = (ulong) (managementObject.Properties["FreeSpaceintempdbKB"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 LongestTransactionRunningTime = (ulong) (managementObject.Properties["LongestTransactionRunningTime"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NonSnapshotVersionTransactions = (ulong) (managementObject.Properties["NonSnapshotVersionTransactions"]?.Value ?? default(ulong)),
		 SnapshotTransactions = (ulong) (managementObject.Properties["SnapshotTransactions"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 Transactions = (ulong) (managementObject.Properties["Transactions"]?.Value ?? default(ulong)),
		 Updateconflictratio = (ulong) (managementObject.Properties["Updateconflictratio"]?.Value ?? default(ulong)),
		 UpdateSnapshotTransactions = (ulong) (managementObject.Properties["UpdateSnapshotTransactions"]?.Value ?? default(ulong)),
		 VersionCleanuprateKBPers = (ulong) (managementObject.Properties["VersionCleanuprateKBPers"]?.Value ?? default(ulong)),
		 VersionGenerationrateKBPers = (ulong) (managementObject.Properties["VersionGenerationrateKBPers"]?.Value ?? default(ulong)),
		 VersionStoreSizeKB = (ulong) (managementObject.Properties["VersionStoreSizeKB"]?.Value ?? default(ulong)),
		 VersionStoreunitcount = (ulong) (managementObject.Properties["VersionStoreunitcount"]?.Value ?? default(ulong)),
		 VersionStoreunitcreation = (ulong) (managementObject.Properties["VersionStoreunitcreation"]?.Value ?? default(ulong)),
		 VersionStoreunittruncation = (ulong) (managementObject.Properties["VersionStoreunittruncation"]?.Value ?? default(ulong))
                };
        }
    }
}