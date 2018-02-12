using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class MSDTC_DistributedTransactionCoordinator
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

        public static IEnumerable<MSDTC_DistributedTransactionCoordinator> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSDTC_DistributedTransactionCoordinator> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSDTC_DistributedTransactionCoordinator> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSDTC_DistributedTransactionCoordinator");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSDTC_DistributedTransactionCoordinator
                {
                     AbortedTransactions = (uint) (managementObject.Properties["AbortedTransactions"]?.Value ?? default(uint)),
		 AbortedTransactionsPersec = (uint) (managementObject.Properties["AbortedTransactionsPersec"]?.Value ?? default(uint)),
		 ActiveTransactions = (uint) (managementObject.Properties["ActiveTransactions"]?.Value ?? default(uint)),
		 ActiveTransactionsMaximum = (uint) (managementObject.Properties["ActiveTransactionsMaximum"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CommittedTransactions = (uint) (managementObject.Properties["CommittedTransactions"]?.Value ?? default(uint)),
		 CommittedTransactionsPersec = (uint) (managementObject.Properties["CommittedTransactionsPersec"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 ForceAbortedTransactions = (uint) (managementObject.Properties["ForceAbortedTransactions"]?.Value ?? default(uint)),
		 ForceCommittedTransactions = (uint) (managementObject.Properties["ForceCommittedTransactions"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 InDoubtTransactions = (uint) (managementObject.Properties["InDoubtTransactions"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ResponseTimeAverage = (uint) (managementObject.Properties["ResponseTimeAverage"]?.Value ?? default(uint)),
		 ResponseTimeMaximum = (uint) (managementObject.Properties["ResponseTimeMaximum"]?.Value ?? default(uint)),
		 ResponseTimeMinimum = (uint) (managementObject.Properties["ResponseTimeMinimum"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TransactionsPersec = (uint) (managementObject.Properties["TransactionsPersec"]?.Value ?? default(uint))
                };
        }
    }
}