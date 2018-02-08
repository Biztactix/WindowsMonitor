using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSERVER_SQLServerExternalScripts
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong ExecutionErrors { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong ImpliedAuthLogins { get; private set; }
        public string Name { get; private set; }
        public ulong ParallelExecutions { get; private set; }
        public ulong SQLCCExecutions { get; private set; }
        public ulong StreamingExecutions { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalExecutions { get; private set; }
        public ulong TotalExecutionTimems { get; private set; }

        public static PerfFormattedData_MSSQLSERVER_SQLServerExternalScripts[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_MSSQLSERVER_SQLServerExternalScripts[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSERVER_SQLServerExternalScripts[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerExternalScripts");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSERVER_SQLServerExternalScripts>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSERVER_SQLServerExternalScripts
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ExecutionErrors = (ulong) managementObject.Properties["ExecutionErrors"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    ImpliedAuthLogins = (ulong) managementObject.Properties["ImpliedAuthLogins"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ParallelExecutions = (ulong) managementObject.Properties["ParallelExecutions"].Value,
                    SQLCCExecutions = (ulong) managementObject.Properties["SQLCCExecutions"].Value,
                    StreamingExecutions = (ulong) managementObject.Properties["StreamingExecutions"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalExecutions = (ulong) managementObject.Properties["TotalExecutions"].Value,
                    TotalExecutionTimems = (ulong) managementObject.Properties["TotalExecutionTimems"].Value
                });

            return list.ToArray();
        }
    }
}