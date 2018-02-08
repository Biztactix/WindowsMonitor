using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSERVER_SQLServerWorkloadGroupStats
    {
        public ulong Activeparallelthreads { get; private set; }
        public ulong Activerequests { get; private set; }
        public ulong Blockedtasks { get; private set; }
        public string Caption { get; private set; }
        public ulong CPUdelayedPercent { get; private set; }
        public ulong CPUdelayedPercent_Base { get; private set; }
        public ulong CPUeffectivePercent { get; private set; }
        public ulong CPUeffectivePercent_Base { get; private set; }
        public ulong CPUusagePercent { get; private set; }
        public ulong CPUusagePercent_Base { get; private set; }
        public ulong CPUviolatedPercent { get; private set; }
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

        public static PerfRawData_MSSQLSERVER_SQLServerWorkloadGroupStats[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSSQLSERVER_SQLServerWorkloadGroupStats[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSERVER_SQLServerWorkloadGroupStats[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerWorkloadGroupStats");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSERVER_SQLServerWorkloadGroupStats>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSERVER_SQLServerWorkloadGroupStats
                {
                    Activeparallelthreads = (ulong) managementObject.Properties["Activeparallelthreads"].Value,
                    Activerequests = (ulong) managementObject.Properties["Activerequests"].Value,
                    Blockedtasks = (ulong) managementObject.Properties["Blockedtasks"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CPUdelayedPercent = (ulong) managementObject.Properties["CPUdelayedPercent"].Value,
                    CPUdelayedPercent_Base = (ulong) managementObject.Properties["CPUdelayedPercent_Base"].Value,
                    CPUeffectivePercent = (ulong) managementObject.Properties["CPUeffectivePercent"].Value,
                    CPUeffectivePercent_Base = (ulong) managementObject.Properties["CPUeffectivePercent_Base"].Value,
                    CPUusagePercent = (ulong) managementObject.Properties["CPUusagePercent"].Value,
                    CPUusagePercent_Base = (ulong) managementObject.Properties["CPUusagePercent_Base"].Value,
                    CPUviolatedPercent = (ulong) managementObject.Properties["CPUviolatedPercent"].Value,
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