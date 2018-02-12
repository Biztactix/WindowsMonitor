using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class SqlServerResourcePoolStats
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

        public static IEnumerable<SqlServerResourcePoolStats> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlServerResourcePoolStats> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlServerResourcePoolStats> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerResourcePoolStats");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlServerResourcePoolStats
                {
                     ActivememorygrantamountKB = (ulong) (managementObject.Properties["ActivememorygrantamountKB"]?.Value ?? default(ulong)),
		 Activememorygrantscount = (ulong) (managementObject.Properties["Activememorygrantscount"]?.Value ?? default(ulong)),
		 AvgDiskReadIOms = (ulong) (managementObject.Properties["AvgDiskReadIOms"]?.Value ?? default(ulong)),
		 AvgDiskReadIOms_Base = (uint) (managementObject.Properties["AvgDiskReadIOms_Base"]?.Value ?? default(uint)),
		 AvgDiskWriteIOms = (ulong) (managementObject.Properties["AvgDiskWriteIOms"]?.Value ?? default(ulong)),
		 AvgDiskWriteIOms_Base = (uint) (managementObject.Properties["AvgDiskWriteIOms_Base"]?.Value ?? default(uint)),
		 CachememorytargetKB = (ulong) (managementObject.Properties["CachememorytargetKB"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CompilememorytargetKB = (ulong) (managementObject.Properties["CompilememorytargetKB"]?.Value ?? default(ulong)),
		 CPUcontroleffectPercent = (ulong) (managementObject.Properties["CPUcontroleffectPercent"]?.Value ?? default(ulong)),
		 CPUdelayedPercent = (ulong) (managementObject.Properties["CPUdelayedPercent"]?.Value ?? default(ulong)),
		 CPUdelayedPercent_Base = (ulong) (managementObject.Properties["CPUdelayedPercent_Base"]?.Value ?? default(ulong)),
		 CPUeffectivePercent = (ulong) (managementObject.Properties["CPUeffectivePercent"]?.Value ?? default(ulong)),
		 CPUeffectivePercent_Base = (ulong) (managementObject.Properties["CPUeffectivePercent_Base"]?.Value ?? default(ulong)),
		 CPUusagePercent = (ulong) (managementObject.Properties["CPUusagePercent"]?.Value ?? default(ulong)),
		 CPUusagePercent_Base = (ulong) (managementObject.Properties["CPUusagePercent_Base"]?.Value ?? default(ulong)),
		 CPUusagetargetPercent = (ulong) (managementObject.Properties["CPUusagetargetPercent"]?.Value ?? default(ulong)),
		 CPUviolatedPercent = (ulong) (managementObject.Properties["CPUviolatedPercent"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DiskReadBytesPersec = (ulong) (managementObject.Properties["DiskReadBytesPersec"]?.Value ?? default(ulong)),
		 DiskReadIOPersec = (ulong) (managementObject.Properties["DiskReadIOPersec"]?.Value ?? default(ulong)),
		 DiskReadIOThrottledPersec = (ulong) (managementObject.Properties["DiskReadIOThrottledPersec"]?.Value ?? default(ulong)),
		 DiskWriteBytesPersec = (ulong) (managementObject.Properties["DiskWriteBytesPersec"]?.Value ?? default(ulong)),
		 DiskWriteIOPersec = (ulong) (managementObject.Properties["DiskWriteIOPersec"]?.Value ?? default(ulong)),
		 DiskWriteIOThrottledPersec = (ulong) (managementObject.Properties["DiskWriteIOThrottledPersec"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 MaxmemoryKB = (ulong) (managementObject.Properties["MaxmemoryKB"]?.Value ?? default(ulong)),
		 MemorygrantsPersec = (ulong) (managementObject.Properties["MemorygrantsPersec"]?.Value ?? default(ulong)),
		 MemorygranttimeoutsPersec = (ulong) (managementObject.Properties["MemorygranttimeoutsPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Pendingmemorygrantscount = (ulong) (managementObject.Properties["Pendingmemorygrantscount"]?.Value ?? default(ulong)),
		 QueryexecmemorytargetKB = (ulong) (managementObject.Properties["QueryexecmemorytargetKB"]?.Value ?? default(ulong)),
		 TargetmemoryKB = (ulong) (managementObject.Properties["TargetmemoryKB"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 UsedmemoryKB = (ulong) (managementObject.Properties["UsedmemoryKB"]?.Value ?? default(ulong))
                };
        }
    }
}