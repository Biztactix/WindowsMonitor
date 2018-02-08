using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSERVER_SQLServerTransactions
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
        public uint Updateconflictratio_Base { get; private set; }
        public ulong UpdateSnapshotTransactions { get; private set; }
        public ulong VersionCleanuprateKBPers { get; private set; }
        public ulong VersionGenerationrateKBPers { get; private set; }
        public ulong VersionStoreSizeKB { get; private set; }
        public ulong VersionStoreunitcount { get; private set; }
        public ulong VersionStoreunitcreation { get; private set; }
        public ulong VersionStoreunittruncation { get; private set; }

        public static PerfRawData_MSSQLSERVER_SQLServerTransactions[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSSQLSERVER_SQLServerTransactions[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSERVER_SQLServerTransactions[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerTransactions");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSERVER_SQLServerTransactions>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSERVER_SQLServerTransactions
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FreeSpaceintempdbKB = (ulong) managementObject.Properties["FreeSpaceintempdbKB"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    LongestTransactionRunningTime =
                        (ulong) managementObject.Properties["LongestTransactionRunningTime"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NonSnapshotVersionTransactions =
                        (ulong) managementObject.Properties["NonSnapshotVersionTransactions"].Value,
                    SnapshotTransactions = (ulong) managementObject.Properties["SnapshotTransactions"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    Transactions = (ulong) managementObject.Properties["Transactions"].Value,
                    Updateconflictratio = (ulong) managementObject.Properties["Updateconflictratio"].Value,
                    Updateconflictratio_Base = (uint) managementObject.Properties["Updateconflictratio_Base"].Value,
                    UpdateSnapshotTransactions =
                        (ulong) managementObject.Properties["UpdateSnapshotTransactions"].Value,
                    VersionCleanuprateKBPers = (ulong) managementObject.Properties["VersionCleanuprateKBPers"].Value,
                    VersionGenerationrateKBPers = (ulong) managementObject.Properties["VersionGenerationrateKBPers"]
                        .Value,
                    VersionStoreSizeKB = (ulong) managementObject.Properties["VersionStoreSizeKB"].Value,
                    VersionStoreunitcount = (ulong) managementObject.Properties["VersionStoreunitcount"].Value,
                    VersionStoreunitcreation = (ulong) managementObject.Properties["VersionStoreunitcreation"].Value,
                    VersionStoreunittruncation = (ulong) managementObject.Properties["VersionStoreunittruncation"].Value
                });

            return list.ToArray();
        }
    }
}