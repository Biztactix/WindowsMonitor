using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSERVER_SQLServerTCMAgents_Costly
    {
        public ulong Averagecommitwaittime { get; private set; }
        public uint Averagecommitwaittime_Base { get; private set; }
        public ulong Averagetranpreparetime { get; private set; }
        public uint Averagetranpreparetime_Base { get; private set; }
        public ulong AvgAGEprocessingtime { get; private set; }
        public uint AvgAGEprocessingtime_Base { get; private set; }
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
        public uint TransactionrequestsperAGE_Base { get; private set; }
        public ulong TransactionscommittedperAGE { get; private set; }
        public uint TransactionscommittedperAGE_Base { get; private set; }
        public ulong TransactionscommittedPersec { get; private set; }
        public ulong TransactionsrolledbackPersec { get; private set; }
        public ulong TransactionsStartedPersec { get; private set; }

        public static PerfRawData_MSSQLSERVER_SQLServerTCMAgents_Costly[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSSQLSERVER_SQLServerTCMAgents_Costly[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSERVER_SQLServerTCMAgents_Costly[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerTCMAgents_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSERVER_SQLServerTCMAgents_Costly>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSERVER_SQLServerTCMAgents_Costly
                {
                    Averagecommitwaittime = (ulong) managementObject.Properties["Averagecommitwaittime"].Value,
                    Averagecommitwaittime_Base = (uint) managementObject.Properties["Averagecommitwaittime_Base"].Value,
                    Averagetranpreparetime = (ulong) managementObject.Properties["Averagetranpreparetime"].Value,
                    Averagetranpreparetime_Base = (uint) managementObject.Properties["Averagetranpreparetime_Base"]
                        .Value,
                    AvgAGEprocessingtime = (ulong) managementObject.Properties["AvgAGEprocessingtime"].Value,
                    AvgAGEprocessingtime_Base = (uint) managementObject.Properties["AvgAGEprocessingtime_Base"].Value,
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
                    TransactionrequestsperAGE_Base =
                        (uint) managementObject.Properties["TransactionrequestsperAGE_Base"].Value,
                    TransactionscommittedperAGE = (ulong) managementObject.Properties["TransactionscommittedperAGE"]
                        .Value,
                    TransactionscommittedperAGE_Base =
                        (uint) managementObject.Properties["TransactionscommittedperAGE_Base"].Value,
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