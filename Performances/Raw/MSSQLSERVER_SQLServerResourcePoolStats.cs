using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSERVER_SQLServerResourcePoolStats
    {
        public ulong ActivememorygrantamountKB { get; private set; }
        public ulong Activememorygrantscount { get; private set; }
        public ulong AvgDiskReadIOms { get; private set; }
        public uint AvgDiskReadIOms_Base { get; private set; }
        public ulong AvgDiskWriteIOms { get; private set; }
        public uint AvgDiskWriteIOms_Base { get; private set; }
        public ulong CachememorytargetKB { get; private set; }
        public string Caption { get; private set; }
        public ulong CompilememorytargetKB { get; private set; }
        public ulong CPUcontroleffectPercent { get; private set; }
        public ulong CPUdelayedPercent { get; private set; }
        public ulong CPUdelayedPercent_Base { get; private set; }
        public ulong CPUeffectivePercent { get; private set; }
        public ulong CPUeffectivePercent_Base { get; private set; }
        public ulong CPUusagePercent { get; private set; }
        public ulong CPUusagePercent_Base { get; private set; }
        public ulong CPUusagetargetPercent { get; private set; }
        public ulong CPUviolatedPercent { get; private set; }
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

        public static PerfRawData_MSSQLSERVER_SQLServerResourcePoolStats[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSSQLSERVER_SQLServerResourcePoolStats[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSERVER_SQLServerResourcePoolStats[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerResourcePoolStats");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSERVER_SQLServerResourcePoolStats>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSERVER_SQLServerResourcePoolStats
                {
                    ActivememorygrantamountKB = (ulong) managementObject.Properties["ActivememorygrantamountKB"].Value,
                    Activememorygrantscount = (ulong) managementObject.Properties["Activememorygrantscount"].Value,
                    AvgDiskReadIOms = (ulong) managementObject.Properties["AvgDiskReadIOms"].Value,
                    AvgDiskReadIOms_Base = (uint) managementObject.Properties["AvgDiskReadIOms_Base"].Value,
                    AvgDiskWriteIOms = (ulong) managementObject.Properties["AvgDiskWriteIOms"].Value,
                    AvgDiskWriteIOms_Base = (uint) managementObject.Properties["AvgDiskWriteIOms_Base"].Value,
                    CachememorytargetKB = (ulong) managementObject.Properties["CachememorytargetKB"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CompilememorytargetKB = (ulong) managementObject.Properties["CompilememorytargetKB"].Value,
                    CPUcontroleffectPercent = (ulong) managementObject.Properties["CPUcontroleffectPercent"].Value,
                    CPUdelayedPercent = (ulong) managementObject.Properties["CPUdelayedPercent"].Value,
                    CPUdelayedPercent_Base = (ulong) managementObject.Properties["CPUdelayedPercent_Base"].Value,
                    CPUeffectivePercent = (ulong) managementObject.Properties["CPUeffectivePercent"].Value,
                    CPUeffectivePercent_Base = (ulong) managementObject.Properties["CPUeffectivePercent_Base"].Value,
                    CPUusagePercent = (ulong) managementObject.Properties["CPUusagePercent"].Value,
                    CPUusagePercent_Base = (ulong) managementObject.Properties["CPUusagePercent_Base"].Value,
                    CPUusagetargetPercent = (ulong) managementObject.Properties["CPUusagetargetPercent"].Value,
                    CPUviolatedPercent = (ulong) managementObject.Properties["CPUviolatedPercent"].Value,
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