using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_PerfDisk_LogicalDisk
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

        public static PerfRawData_PerfDisk_LogicalDisk[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_PerfDisk_LogicalDisk[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_PerfDisk_LogicalDisk[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PerfDisk_LogicalDisk");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_PerfDisk_LogicalDisk>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_PerfDisk_LogicalDisk
                {
                    AvgDiskBytesPerRead = (ulong) managementObject.Properties["AvgDiskBytesPerRead"].Value,
                    AvgDiskBytesPerRead_Base = (uint) managementObject.Properties["AvgDiskBytesPerRead_Base"].Value,
                    AvgDiskBytesPerTransfer = (ulong) managementObject.Properties["AvgDiskBytesPerTransfer"].Value,
                    AvgDiskBytesPerTransfer_Base = (uint) managementObject.Properties["AvgDiskBytesPerTransfer_Base"]
                        .Value,
                    AvgDiskBytesPerWrite = (ulong) managementObject.Properties["AvgDiskBytesPerWrite"].Value,
                    AvgDiskBytesPerWrite_Base = (uint) managementObject.Properties["AvgDiskBytesPerWrite_Base"].Value,
                    AvgDiskQueueLength = (ulong) managementObject.Properties["AvgDiskQueueLength"].Value,
                    AvgDiskReadQueueLength = (ulong) managementObject.Properties["AvgDiskReadQueueLength"].Value,
                    AvgDisksecPerRead = (uint) managementObject.Properties["AvgDisksecPerRead"].Value,
                    AvgDisksecPerRead_Base = (uint) managementObject.Properties["AvgDisksecPerRead_Base"].Value,
                    AvgDisksecPerTransfer = (uint) managementObject.Properties["AvgDisksecPerTransfer"].Value,
                    AvgDisksecPerTransfer_Base = (uint) managementObject.Properties["AvgDisksecPerTransfer_Base"].Value,
                    AvgDisksecPerWrite = (uint) managementObject.Properties["AvgDisksecPerWrite"].Value,
                    AvgDisksecPerWrite_Base = (uint) managementObject.Properties["AvgDisksecPerWrite_Base"].Value,
                    AvgDiskWriteQueueLength = (ulong) managementObject.Properties["AvgDiskWriteQueueLength"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentDiskQueueLength = (uint) managementObject.Properties["CurrentDiskQueueLength"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DiskBytesPersec = (ulong) managementObject.Properties["DiskBytesPersec"].Value,
                    DiskReadBytesPersec = (ulong) managementObject.Properties["DiskReadBytesPersec"].Value,
                    DiskReadsPersec = (uint) managementObject.Properties["DiskReadsPersec"].Value,
                    DiskTransfersPersec = (uint) managementObject.Properties["DiskTransfersPersec"].Value,
                    DiskWriteBytesPersec = (ulong) managementObject.Properties["DiskWriteBytesPersec"].Value,
                    DiskWritesPersec = (uint) managementObject.Properties["DiskWritesPersec"].Value,
                    FreeMegabytes = (uint) managementObject.Properties["FreeMegabytes"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PercentDiskReadTime = (ulong) managementObject.Properties["PercentDiskReadTime"].Value,
                    PercentDiskReadTime_Base = (ulong) managementObject.Properties["PercentDiskReadTime_Base"].Value,
                    PercentDiskTime = (ulong) managementObject.Properties["PercentDiskTime"].Value,
                    PercentDiskTime_Base = (ulong) managementObject.Properties["PercentDiskTime_Base"].Value,
                    PercentDiskWriteTime = (ulong) managementObject.Properties["PercentDiskWriteTime"].Value,
                    PercentDiskWriteTime_Base = (ulong) managementObject.Properties["PercentDiskWriteTime_Base"].Value,
                    PercentFreeSpace = (uint) managementObject.Properties["PercentFreeSpace"].Value,
                    PercentFreeSpace_Base = (uint) managementObject.Properties["PercentFreeSpace_Base"].Value,
                    PercentIdleTime = (ulong) managementObject.Properties["PercentIdleTime"].Value,
                    PercentIdleTime_Base = (ulong) managementObject.Properties["PercentIdleTime_Base"].Value,
                    SplitIOPerSec = (uint) managementObject.Properties["SplitIOPerSec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}