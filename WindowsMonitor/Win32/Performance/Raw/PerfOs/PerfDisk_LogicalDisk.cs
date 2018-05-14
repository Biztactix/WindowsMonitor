using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Raw.PerfOs
{
    /// <summary>
    /// </summary>
    public sealed class PerfDisk_LogicalDisk
    {
		public ulong AvgDiskBytesPerRead { get; private set; }
		public uint AvgDiskBytesPerRead_Base { get; private set; }
		public ulong AvgDiskBytesPerTransfer { get; private set; }
		public uint AvgDiskBytesPerTransfer_Base { get; private set; }
		public ulong AvgDiskBytesPerWrite { get; private set; }
		public uint AvgDiskBytesPerWrite_Base { get; private set; }
		public ulong AvgDiskQueueLength { get; private set; }
		public ulong AvgDiskReadQueueLength { get; private set; }
		public uint AvgDisksecPerRead { get; private set; }
		public uint AvgDisksecPerRead_Base { get; private set; }
		public uint AvgDisksecPerTransfer { get; private set; }
		public uint AvgDisksecPerTransfer_Base { get; private set; }
		public uint AvgDisksecPerWrite { get; private set; }
		public uint AvgDisksecPerWrite_Base { get; private set; }
		public ulong AvgDiskWriteQueueLength { get; private set; }
		public string Caption { get; private set; }
		public uint CurrentDiskQueueLength { get; private set; }
		public string Description { get; private set; }
		public ulong DiskBytesPersec { get; private set; }
		public ulong DiskReadBytesPersec { get; private set; }
		public uint DiskReadsPersec { get; private set; }
		public uint DiskTransfersPersec { get; private set; }
		public ulong DiskWriteBytesPersec { get; private set; }
		public uint DiskWritesPersec { get; private set; }
		public uint FreeMegabytes { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong PercentDiskReadTime { get; private set; }
		public ulong PercentDiskReadTime_Base { get; private set; }
		public ulong PercentDiskTime { get; private set; }
		public ulong PercentDiskTime_Base { get; private set; }
		public ulong PercentDiskWriteTime { get; private set; }
		public ulong PercentDiskWriteTime_Base { get; private set; }
		public uint PercentFreeSpace { get; private set; }
		public uint PercentFreeSpace_Base { get; private set; }
		public ulong PercentIdleTime { get; private set; }
		public ulong PercentIdleTime_Base { get; private set; }
		public uint SplitIOPerSec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<PerfDisk_LogicalDisk> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PerfDisk_LogicalDisk> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PerfDisk_LogicalDisk> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PerfDisk_LogicalDisk");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PerfDisk_LogicalDisk
                {
                     AvgDiskBytesPerRead = (ulong) (managementObject.Properties["AvgDiskBytesPerRead"]?.Value ?? default(ulong)),
		 AvgDiskBytesPerRead_Base = (uint) (managementObject.Properties["AvgDiskBytesPerRead_Base"]?.Value ?? default(uint)),
		 AvgDiskBytesPerTransfer = (ulong) (managementObject.Properties["AvgDiskBytesPerTransfer"]?.Value ?? default(ulong)),
		 AvgDiskBytesPerTransfer_Base = (uint) (managementObject.Properties["AvgDiskBytesPerTransfer_Base"]?.Value ?? default(uint)),
		 AvgDiskBytesPerWrite = (ulong) (managementObject.Properties["AvgDiskBytesPerWrite"]?.Value ?? default(ulong)),
		 AvgDiskBytesPerWrite_Base = (uint) (managementObject.Properties["AvgDiskBytesPerWrite_Base"]?.Value ?? default(uint)),
		 AvgDiskQueueLength = (ulong) (managementObject.Properties["AvgDiskQueueLength"]?.Value ?? default(ulong)),
		 AvgDiskReadQueueLength = (ulong) (managementObject.Properties["AvgDiskReadQueueLength"]?.Value ?? default(ulong)),
		 AvgDisksecPerRead = (uint) (managementObject.Properties["AvgDisksecPerRead"]?.Value ?? default(uint)),
		 AvgDisksecPerRead_Base = (uint) (managementObject.Properties["AvgDisksecPerRead_Base"]?.Value ?? default(uint)),
		 AvgDisksecPerTransfer = (uint) (managementObject.Properties["AvgDisksecPerTransfer"]?.Value ?? default(uint)),
		 AvgDisksecPerTransfer_Base = (uint) (managementObject.Properties["AvgDisksecPerTransfer_Base"]?.Value ?? default(uint)),
		 AvgDisksecPerWrite = (uint) (managementObject.Properties["AvgDisksecPerWrite"]?.Value ?? default(uint)),
		 AvgDisksecPerWrite_Base = (uint) (managementObject.Properties["AvgDisksecPerWrite_Base"]?.Value ?? default(uint)),
		 AvgDiskWriteQueueLength = (ulong) (managementObject.Properties["AvgDiskWriteQueueLength"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CurrentDiskQueueLength = (uint) (managementObject.Properties["CurrentDiskQueueLength"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 DiskBytesPersec = (ulong) (managementObject.Properties["DiskBytesPersec"]?.Value ?? default(ulong)),
		 DiskReadBytesPersec = (ulong) (managementObject.Properties["DiskReadBytesPersec"]?.Value ?? default(ulong)),
		 DiskReadsPersec = (uint) (managementObject.Properties["DiskReadsPersec"]?.Value ?? default(uint)),
		 DiskTransfersPersec = (uint) (managementObject.Properties["DiskTransfersPersec"]?.Value ?? default(uint)),
		 DiskWriteBytesPersec = (ulong) (managementObject.Properties["DiskWriteBytesPersec"]?.Value ?? default(ulong)),
		 DiskWritesPersec = (uint) (managementObject.Properties["DiskWritesPersec"]?.Value ?? default(uint)),
		 FreeMegabytes = (uint) (managementObject.Properties["FreeMegabytes"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 PercentDiskReadTime = (ulong) (managementObject.Properties["PercentDiskReadTime"]?.Value ?? default(ulong)),
		 PercentDiskReadTime_Base = (ulong) (managementObject.Properties["PercentDiskReadTime_Base"]?.Value ?? default(ulong)),
		 PercentDiskTime = (ulong) (managementObject.Properties["PercentDiskTime"]?.Value ?? default(ulong)),
		 PercentDiskTime_Base = (ulong) (managementObject.Properties["PercentDiskTime_Base"]?.Value ?? default(ulong)),
		 PercentDiskWriteTime = (ulong) (managementObject.Properties["PercentDiskWriteTime"]?.Value ?? default(ulong)),
		 PercentDiskWriteTime_Base = (ulong) (managementObject.Properties["PercentDiskWriteTime_Base"]?.Value ?? default(ulong)),
		 PercentFreeSpace = (uint) (managementObject.Properties["PercentFreeSpace"]?.Value ?? default(uint)),
		 PercentFreeSpace_Base = (uint) (managementObject.Properties["PercentFreeSpace_Base"]?.Value ?? default(uint)),
		 PercentIdleTime = (ulong) (managementObject.Properties["PercentIdleTime"]?.Value ?? default(ulong)),
		 PercentIdleTime_Base = (ulong) (managementObject.Properties["PercentIdleTime_Base"]?.Value ?? default(ulong)),
		 SplitIOPerSec = (uint) (managementObject.Properties["SplitIOPerSec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}