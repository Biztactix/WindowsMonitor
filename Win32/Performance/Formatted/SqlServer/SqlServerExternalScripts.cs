using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class SqlServerExternalScripts
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

        public static IEnumerable<SqlServerExternalScripts> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlServerExternalScripts> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlServerExternalScripts> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerExternalScripts");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlServerExternalScripts
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 ExecutionErrors = (ulong) (managementObject.Properties["ExecutionErrors"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 ImpliedAuthLogins = (ulong) (managementObject.Properties["ImpliedAuthLogins"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ParallelExecutions = (ulong) (managementObject.Properties["ParallelExecutions"]?.Value ?? default(ulong)),
		 SQLCCExecutions = (ulong) (managementObject.Properties["SQLCCExecutions"]?.Value ?? default(ulong)),
		 StreamingExecutions = (ulong) (managementObject.Properties["StreamingExecutions"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalExecutions = (ulong) (managementObject.Properties["TotalExecutions"]?.Value ?? default(ulong)),
		 TotalExecutionTimems = (ulong) (managementObject.Properties["TotalExecutionTimems"]?.Value ?? default(ulong))
                };
        }
    }
}