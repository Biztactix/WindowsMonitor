using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSDTC_DistributedTransactionCoordinator
    {
        public uint AbortedTransactions { get; private set; }
        public uint AbortedTransactionsPersec { get; private set; }
        public uint ActiveTransactions { get; private set; }
        public uint ActiveTransactionsMaximum { get; private set; }
        public string Caption { get; private set; }
        public uint CommittedTransactions { get; private set; }
        public uint CommittedTransactionsPersec { get; private set; }
        public string Description { get; private set; }
        public uint ForceAbortedTransactions { get; private set; }
        public uint ForceCommittedTransactions { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint InDoubtTransactions { get; private set; }
        public string Name { get; private set; }
        public uint ResponseTimeAverage { get; private set; }
        public uint ResponseTimeMaximum { get; private set; }
        public uint ResponseTimeMinimum { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TransactionsPersec { get; private set; }

        public static PerfRawData_MSDTC_DistributedTransactionCoordinator[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSDTC_DistributedTransactionCoordinator[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSDTC_DistributedTransactionCoordinator[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSDTC_DistributedTransactionCoordinator");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSDTC_DistributedTransactionCoordinator>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSDTC_DistributedTransactionCoordinator
                {
                    AbortedTransactions = (uint) managementObject.Properties["AbortedTransactions"].Value,
                    AbortedTransactionsPersec = (uint) managementObject.Properties["AbortedTransactionsPersec"].Value,
                    ActiveTransactions = (uint) managementObject.Properties["ActiveTransactions"].Value,
                    ActiveTransactionsMaximum = (uint) managementObject.Properties["ActiveTransactionsMaximum"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CommittedTransactions = (uint) managementObject.Properties["CommittedTransactions"].Value,
                    CommittedTransactionsPersec = (uint) managementObject.Properties["CommittedTransactionsPersec"]
                        .Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ForceAbortedTransactions = (uint) managementObject.Properties["ForceAbortedTransactions"].Value,
                    ForceCommittedTransactions = (uint) managementObject.Properties["ForceCommittedTransactions"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InDoubtTransactions = (uint) managementObject.Properties["InDoubtTransactions"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ResponseTimeAverage = (uint) managementObject.Properties["ResponseTimeAverage"].Value,
                    ResponseTimeMaximum = (uint) managementObject.Properties["ResponseTimeMaximum"].Value,
                    ResponseTimeMinimum = (uint) managementObject.Properties["ResponseTimeMinimum"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TransactionsPersec = (uint) managementObject.Properties["TransactionsPersec"].Value
                });

            return list.ToArray();
        }
    }
}