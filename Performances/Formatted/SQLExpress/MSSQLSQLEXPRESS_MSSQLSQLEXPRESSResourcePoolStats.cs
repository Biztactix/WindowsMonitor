using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSResourcePoolStats
    {
        public ulong ActivememorygrantamountKB { get; private set; }
        public ulong Activememorygrantscount { get; private set; }
        public ulong AvgDiskReadIOms { get; private set; }
        public ulong AvgDiskWriteIOms { get; private set; }
        public ulong CachememorytargetKB { get; private set; }
        public string Caption { get; private set; }
        public ulong CompilememorytargetKB { get; private set; }
        public ulong CPUcontroleffectPercent { get; private set; }
        public ulong CPUusagePercent { get; private set; }
        public ulong CPUusagetargetPercent { get; private set; }
        public string Description { get; private set; }
        public ulong DiskReadBytesPersec { get; private set; }
        public ulong DiskReadIOPersec { get; private set; }
        public ulong DiskReadIOThrottledPersec { get; private set; }
        public ulong DiskWriteBytesPersec { get; private set; }
        public ulong DiskWriteIOPersec { get; private set; }
        public ulong DiskWriteIOThrottledPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong MaxmemoryKB { get; private set; }
        public ulong MemorygrantsPersec { get; private set; }
        public ulong MemorygranttimeoutsPersec { get; private set; }
        public string Name { get; private set; }
        public ulong Pendingmemorygrantscount { get; private set; }
        public ulong QueryexecmemorytargetKB { get; private set; }
        public ulong TargetmemoryKB { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong UsedmemoryKB { get; private set; }

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSResourcePoolStats[] Retrieve(string remote,
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

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSResourcePoolStats[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSResourcePoolStats[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSResourcePoolStats");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSResourcePoolStats>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSResourcePoolStats
                {
                    ActivememorygrantamountKB = (ulong) managementObject.Properties["ActivememorygrantamountKB"].Value,
                    Activememorygrantscount = (ulong) managementObject.Properties["Activememorygrantscount"].Value,
                    AvgDiskReadIOms = (ulong) managementObject.Properties["AvgDiskReadIOms"].Value,
                    AvgDiskWriteIOms = (ulong) managementObject.Properties["AvgDiskWriteIOms"].Value,
                    CachememorytargetKB = (ulong) managementObject.Properties["CachememorytargetKB"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CompilememorytargetKB = (ulong) managementObject.Properties["CompilememorytargetKB"].Value,
                    CPUcontroleffectPercent = (ulong) managementObject.Properties["CPUcontroleffectPercent"].Value,
                    CPUusagePercent = (ulong) managementObject.Properties["CPUusagePercent"].Value,
                    CPUusagetargetPercent = (ulong) managementObject.Properties["CPUusagetargetPercent"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DiskReadBytesPersec = (ulong) managementObject.Properties["DiskReadBytesPersec"].Value,
                    DiskReadIOPersec = (ulong) managementObject.Properties["DiskReadIOPersec"].Value,
                    DiskReadIOThrottledPersec = (ulong) managementObject.Properties["DiskReadIOThrottledPersec"].Value,
                    DiskWriteBytesPersec = (ulong) managementObject.Properties["DiskWriteBytesPersec"].Value,
                    DiskWriteIOPersec = (ulong) managementObject.Properties["DiskWriteIOPersec"].Value,
                    DiskWriteIOThrottledPersec =
                        (ulong) managementObject.Properties["DiskWriteIOThrottledPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MaxmemoryKB = (ulong) managementObject.Properties["MaxmemoryKB"].Value,
                    MemorygrantsPersec = (ulong) managementObject.Properties["MemorygrantsPersec"].Value,
                    MemorygranttimeoutsPersec = (ulong) managementObject.Properties["MemorygranttimeoutsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Pendingmemorygrantscount = (ulong) managementObject.Properties["Pendingmemorygrantscount"].Value,
                    QueryexecmemorytargetKB = (ulong) managementObject.Properties["QueryexecmemorytargetKB"].Value,
                    TargetmemoryKB = (ulong) managementObject.Properties["TargetmemoryKB"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    UsedmemoryKB = (ulong) managementObject.Properties["UsedmemoryKB"].Value
                });

            return list.ToArray();
        }
    }
}