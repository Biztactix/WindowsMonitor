using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSQLEXPRESS_MSSQLSQLEXPRESSTCMAgents_Costly
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSTCMAgents_Costly> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSTCMAgents_Costly> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSTCMAgents_Costly> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSTCMAgents_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSQLEXPRESS_MSSQLSQLEXPRESSTCMAgents_Costly
                {
                     Averagecommitwaittime = (ulong) (managementObject.Properties["Averagecommitwaittime"]?.Value ?? default(ulong)),
		 Averagetranpreparetime = (ulong) (managementObject.Properties["Averagetranpreparetime"]?.Value ?? default(ulong)),
		 AvgAGEprocessingtime = (ulong) (managementObject.Properties["AvgAGEprocessingtime"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TransactionbranchesPersec = (ulong) (managementObject.Properties["TransactionbranchesPersec"]?.Value ?? default(ulong)),
		 TransactionparticipantsPersec = (ulong) (managementObject.Properties["TransactionparticipantsPersec"]?.Value ?? default(ulong)),
		 TransactionrequestsperAGE = (ulong) (managementObject.Properties["TransactionrequestsperAGE"]?.Value ?? default(ulong)),
		 TransactionscommittedperAGE = (ulong) (managementObject.Properties["TransactionscommittedperAGE"]?.Value ?? default(ulong)),
		 TransactionscommittedPersec = (ulong) (managementObject.Properties["TransactionscommittedPersec"]?.Value ?? default(ulong)),
		 TransactionsrolledbackPersec = (ulong) (managementObject.Properties["TransactionsrolledbackPersec"]?.Value ?? default(ulong)),
		 TransactionsStartedPersec = (ulong) (managementObject.Properties["TransactionsStartedPersec"]?.Value ?? default(ulong))
                };
        }
    }
}