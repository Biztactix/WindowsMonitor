using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSERVER_SQLServerTraceEventStatistics_Costly
    {
        public ulong BytesPersec { get; private set; }
        public string Caption { get; private set; }
        public ulong CPUTicksPersec { get; private set; }
        public string Description { get; private set; }
        public ulong EventsFilteredPersec { get; private set; }
        public ulong EventsFiredPersec { get; private set; }
        public ulong EventsPrefilteredPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_MSSQLSERVER_SQLServerTraceEventStatistics_Costly[] Retrieve(string remote,
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

        public static PerfFormattedData_MSSQLSERVER_SQLServerTraceEventStatistics_Costly[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSERVER_SQLServerTraceEventStatistics_Costly[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerTraceEventStatistics_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSERVER_SQLServerTraceEventStatistics_Costly>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSERVER_SQLServerTraceEventStatistics_Costly
                {
                    BytesPersec = (ulong) managementObject.Properties["BytesPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CPUTicksPersec = (ulong) managementObject.Properties["CPUTicksPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    EventsFilteredPersec = (ulong) managementObject.Properties["EventsFilteredPersec"].Value,
                    EventsFiredPersec = (ulong) managementObject.Properties["EventsFiredPersec"].Value,
                    EventsPrefilteredPersec = (ulong) managementObject.Properties["EventsPrefilteredPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}