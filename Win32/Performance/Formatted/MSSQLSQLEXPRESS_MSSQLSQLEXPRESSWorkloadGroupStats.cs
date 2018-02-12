using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats
    {
		public ulong Activeparallelthreads { get; private set; }
		public ulong Activerequests { get; private set; }
		public ulong Blockedtasks { get; private set; }
		public string Caption { get; private set; }
		public ulong CPUusagePercent { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong Maxrequestcputimems { get; private set; }
		public ulong MaxrequestmemorygrantKB { get; private set; }
		public string Name { get; private set; }
		public ulong QueryoptimizationsPersec { get; private set; }
		public ulong Queuedrequests { get; private set; }
		public ulong ReducedmemorygrantsPersec { get; private set; }
		public ulong RequestscompletedPersec { get; private set; }
		public ulong SuboptimalplansPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats
                {
                     Activeparallelthreads = (ulong) (managementObject.Properties["Activeparallelthreads"]?.Value ?? default(ulong)),
		 Activerequests = (ulong) (managementObject.Properties["Activerequests"]?.Value ?? default(ulong)),
		 Blockedtasks = (ulong) (managementObject.Properties["Blockedtasks"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CPUusagePercent = (ulong) (managementObject.Properties["CPUusagePercent"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Maxrequestcputimems = (ulong) (managementObject.Properties["Maxrequestcputimems"]?.Value ?? default(ulong)),
		 MaxrequestmemorygrantKB = (ulong) (managementObject.Properties["MaxrequestmemorygrantKB"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 QueryoptimizationsPersec = (ulong) (managementObject.Properties["QueryoptimizationsPersec"]?.Value ?? default(ulong)),
		 Queuedrequests = (ulong) (managementObject.Properties["Queuedrequests"]?.Value ?? default(ulong)),
		 ReducedmemorygrantsPersec = (ulong) (managementObject.Properties["ReducedmemorygrantsPersec"]?.Value ?? default(ulong)),
		 RequestscompletedPersec = (ulong) (managementObject.Properties["RequestscompletedPersec"]?.Value ?? default(ulong)),
		 SuboptimalplansPersec = (ulong) (managementObject.Properties["SuboptimalplansPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}