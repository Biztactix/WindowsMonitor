using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_StorageSpacesWriteCache
    {
        public ulong AvgCacheBytesPerEvict { get; private set; }
        public uint AvgCacheBytesPerEvict_Base { get; private set; }
        public ulong AvgCacheBytesPerOverwrite { get; private set; }
        public uint AvgCacheBytesPerOverwrite_Base { get; private set; }
        public ulong AvgCacheBytesPerWrite { get; private set; }
        public uint AvgCacheBytesPerWrite_Base { get; private set; }
        public ulong AvgDestageBytesPerEvict { get; private set; }
        public uint AvgDestageBytesPerEvict_Base { get; private set; }
        public ulong AvgDestageBytesPerTransfer { get; private set; }
        public uint AvgDestageBytesPerTransfer_Base { get; private set; }
        public ulong AvgDestageEvictBytesPerOperation { get; private set; }
        public uint AvgDestageEvictBytesPerOperation_Base { get; private set; }
        public ulong AvgDestageEvictsPerOperation { get; private set; }
        public uint AvgDestageEvictsPerOperation_Base { get; private set; }
        public ulong AvgDestageQueueLength { get; private set; }
        public uint AvgDestagesecPerOperation { get; private set; }
        public uint AvgDestagesecPerOperation_Base { get; private set; }
        public ulong AvgDestageTransferBytesPerOperation { get; private set; }
        public uint AvgDestageTransferBytesPerOperation_Base { get; private set; }
        public ulong AvgDestageTransfersPerEvict { get; private set; }
        public uint AvgDestageTransfersPerEvict_Base { get; private set; }
        public ulong AvgDestageTransfersPerOperation { get; private set; }
        public uint AvgDestageTransfersPerOperation_Base { get; private set; }
        public ulong BytesCached { get; private set; }
        public ulong BytesReclaimable { get; private set; }
        public ulong BytesReserved { get; private set; }
        public ulong BytesUsed { get; private set; }
        public ulong CacheEvictBytesPersec { get; private set; }
        public ulong CacheEvictsPersec { get; private set; }
        public ulong CacheOverwriteBytesPersec { get; private set; }
        public ulong CacheOverwritesPersec { get; private set; }
        public ulong CacheSize { get; private set; }
        public ulong CacheWriteBytesPersec { get; private set; }
        public ulong CacheWritesPersec { get; private set; }
        public string Caption { get; private set; }
        public uint CurrentDestageQueueLength { get; private set; }
        public string Description { get; private set; }
        public ulong DestageEvictBytesPersec { get; private set; }
        public ulong DestageEvictsPersec { get; private set; }
        public ulong DestageOperationsPersec { get; private set; }
        public ulong DestageOptimizedOperationsPersec { get; private set; }
        public ulong DestageTransferBytesPersec { get; private set; }
        public ulong DestageTransfersPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_StorageSpacesWriteCache[] Retrieve(string remote, string username,
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

        public static PerfRawData_Counters_StorageSpacesWriteCache[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_StorageSpacesWriteCache[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_StorageSpacesWriteCache");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_StorageSpacesWriteCache>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_StorageSpacesWriteCache
                {
                    AvgCacheBytesPerEvict = (ulong) managementObject.Properties["AvgCacheBytesPerEvict"].Value,
                    AvgCacheBytesPerEvict_Base = (uint) managementObject.Properties["AvgCacheBytesPerEvict_Base"].Value,
                    AvgCacheBytesPerOverwrite = (ulong) managementObject.Properties["AvgCacheBytesPerOverwrite"].Value,
                    AvgCacheBytesPerOverwrite_Base =
                        (uint) managementObject.Properties["AvgCacheBytesPerOverwrite_Base"].Value,
                    AvgCacheBytesPerWrite = (ulong) managementObject.Properties["AvgCacheBytesPerWrite"].Value,
                    AvgCacheBytesPerWrite_Base = (uint) managementObject.Properties["AvgCacheBytesPerWrite_Base"].Value,
                    AvgDestageBytesPerEvict = (ulong) managementObject.Properties["AvgDestageBytesPerEvict"].Value,
                    AvgDestageBytesPerEvict_Base = (uint) managementObject.Properties["AvgDestageBytesPerEvict_Base"]
                        .Value,
                    AvgDestageBytesPerTransfer =
                        (ulong) managementObject.Properties["AvgDestageBytesPerTransfer"].Value,
                    AvgDestageBytesPerTransfer_Base =
                        (uint) managementObject.Properties["AvgDestageBytesPerTransfer_Base"].Value,
                    AvgDestageEvictBytesPerOperation =
                        (ulong) managementObject.Properties["AvgDestageEvictBytesPerOperation"].Value,
                    AvgDestageEvictBytesPerOperation_Base = (uint) managementObject
                        .Properties["AvgDestageEvictBytesPerOperation_Base"].Value,
                    AvgDestageEvictsPerOperation = (ulong) managementObject.Properties["AvgDestageEvictsPerOperation"]
                        .Value,
                    AvgDestageEvictsPerOperation_Base =
                        (uint) managementObject.Properties["AvgDestageEvictsPerOperation_Base"].Value,
                    AvgDestageQueueLength = (ulong) managementObject.Properties["AvgDestageQueueLength"].Value,
                    AvgDestagesecPerOperation = (uint) managementObject.Properties["AvgDestagesecPerOperation"].Value,
                    AvgDestagesecPerOperation_Base =
                        (uint) managementObject.Properties["AvgDestagesecPerOperation_Base"].Value,
                    AvgDestageTransferBytesPerOperation =
                        (ulong) managementObject.Properties["AvgDestageTransferBytesPerOperation"].Value,
                    AvgDestageTransferBytesPerOperation_Base = (uint) managementObject
                        .Properties["AvgDestageTransferBytesPerOperation_Base"].Value,
                    AvgDestageTransfersPerEvict = (ulong) managementObject.Properties["AvgDestageTransfersPerEvict"]
                        .Value,
                    AvgDestageTransfersPerEvict_Base =
                        (uint) managementObject.Properties["AvgDestageTransfersPerEvict_Base"].Value,
                    AvgDestageTransfersPerOperation =
                        (ulong) managementObject.Properties["AvgDestageTransfersPerOperation"].Value,
                    AvgDestageTransfersPerOperation_Base = (uint) managementObject
                        .Properties["AvgDestageTransfersPerOperation_Base"].Value,
                    BytesCached = (ulong) managementObject.Properties["BytesCached"].Value,
                    BytesReclaimable = (ulong) managementObject.Properties["BytesReclaimable"].Value,
                    BytesReserved = (ulong) managementObject.Properties["BytesReserved"].Value,
                    BytesUsed = (ulong) managementObject.Properties["BytesUsed"].Value,
                    CacheEvictBytesPersec = (ulong) managementObject.Properties["CacheEvictBytesPersec"].Value,
                    CacheEvictsPersec = (ulong) managementObject.Properties["CacheEvictsPersec"].Value,
                    CacheOverwriteBytesPersec = (ulong) managementObject.Properties["CacheOverwriteBytesPersec"].Value,
                    CacheOverwritesPersec = (ulong) managementObject.Properties["CacheOverwritesPersec"].Value,
                    CacheSize = (ulong) managementObject.Properties["CacheSize"].Value,
                    CacheWriteBytesPersec = (ulong) managementObject.Properties["CacheWriteBytesPersec"].Value,
                    CacheWritesPersec = (ulong) managementObject.Properties["CacheWritesPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentDestageQueueLength = (uint) managementObject.Properties["CurrentDestageQueueLength"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DestageEvictBytesPersec = (ulong) managementObject.Properties["DestageEvictBytesPersec"].Value,
                    DestageEvictsPersec = (ulong) managementObject.Properties["DestageEvictsPersec"].Value,
                    DestageOperationsPersec = (ulong) managementObject.Properties["DestageOperationsPersec"].Value,
                    DestageOptimizedOperationsPersec =
                        (ulong) managementObject.Properties["DestageOptimizedOperationsPersec"].Value,
                    DestageTransferBytesPersec =
                        (ulong) managementObject.Properties["DestageTransferBytesPersec"].Value,
                    DestageTransfersPersec = (ulong) managementObject.Properties["DestageTransfersPersec"].Value,
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