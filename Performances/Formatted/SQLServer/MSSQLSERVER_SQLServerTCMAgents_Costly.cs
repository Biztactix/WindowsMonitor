using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSERVER_SQLServerTCMAgents_Costly
    {
        public ulong Averagecommitwaittime { get; private set; }
        public ulong Averagetranpreparetime { get; private set; }
        public ulong AvgAGEprocessingtime { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TransactionbranchesPersec { get; private set; }
        public ulong TransactionparticipantsPersec { get; private set; }
        public ulong TransactionrequestsperAGE { get; private set; }
        public ulong TransactionscommittedperAGE { get; private set; }
        public ulong TransactionscommittedPersec { get; private set; }
        public ulong TransactionsrolledbackPersec { get; private set; }
        public ulong TransactionsStartedPersec { get; private set; }

        public static PerfFormattedData_MSSQLSERVER_SQLServerTCMAgents_Costly[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_MSSQLSERVER_SQLServerTCMAgents_Costly[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSERVER_SQLServerTCMAgents_Costly[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerTCMAgents_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSERVER_SQLServerTCMAgents_Costly>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSERVER_SQLServerTCMAgents_Costly
                {
                    Averagecommitwaittime = (ulong) managementObject.Properties["Averagecommitwaittime"].Value,
                    Averagetranpreparetime = (ulong) managementObject.Properties["Averagetranpreparetime"].Value,
                    AvgAGEprocessingtime = (ulong) managementObject.Properties["AvgAGEprocessingtime"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TransactionbranchesPersec = (ulong) managementObject.Properties["TransactionbranchesPersec"].Value,
                    TransactionparticipantsPersec =
                        (ulong) managementObject.Properties["TransactionparticipantsPersec"].Value,
                    TransactionrequestsperAGE = (ulong) managementObject.Properties["TransactionrequestsperAGE"].Value,
                    TransactionscommittedperAGE = (ulong) managementObject.Properties["TransactionscommittedperAGE"]
                        .Value,
                    TransactionscommittedPersec = (ulong) managementObject.Properties["TransactionscommittedPersec"]
                        .Value,
                    TransactionsrolledbackPersec = (ulong) managementObject.Properties["TransactionsrolledbackPersec"]
                        .Value,
                    TransactionsStartedPersec = (ulong) managementObject.Properties["TransactionsStartedPersec"].Value
                });

            return list.ToArray();
        }
    }
}