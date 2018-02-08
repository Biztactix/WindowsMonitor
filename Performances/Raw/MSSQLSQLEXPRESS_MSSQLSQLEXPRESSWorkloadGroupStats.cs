using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats
    {
        public ulong Activeparallelthreads { get; private set; }
        public ulong Activerequests { get; private set; }
        public ulong Blockedtasks { get; private set; }
        public string Caption { get; private set; }
        public ulong CPUusagePercent { get; private set; }
        public ulong CPUusagePercent_Base { get; private set; }
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats[] Retrieve(string remote,
            string username, string password)
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWorkloadGroupStats
                {
                    Activeparallelthreads = (ulong) managementObject.Properties["Activeparallelthreads"].Value,
                    Activerequests = (ulong) managementObject.Properties["Activerequests"].Value,
                    Blockedtasks = (ulong) managementObject.Properties["Blockedtasks"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CPUusagePercent = (ulong) managementObject.Properties["CPUusagePercent"].Value,
                    CPUusagePercent_Base = (ulong) managementObject.Properties["CPUusagePercent_Base"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Maxrequestcputimems = (ulong) managementObject.Properties["Maxrequestcputimems"].Value,
                    MaxrequestmemorygrantKB = (ulong) managementObject.Properties["MaxrequestmemorygrantKB"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    QueryoptimizationsPersec = (ulong) managementObject.Properties["QueryoptimizationsPersec"].Value,
                    Queuedrequests = (ulong) managementObject.Properties["Queuedrequests"].Value,
                    ReducedmemorygrantsPersec = (ulong) managementObject.Properties["ReducedmemorygrantsPersec"].Value,
                    RequestscompletedPersec = (ulong) managementObject.Properties["RequestscompletedPersec"].Value,
                    SuboptimalplansPersec = (ulong) managementObject.Properties["SuboptimalplansPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}