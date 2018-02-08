using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases
    {
        public ulong AvgTransactionSegmentLargeDataSize { get; private set; }
        public uint AvgTransactionSegmentLargeDataSize_Base { get; private set; }
        public ulong AvgTransactionSegmentSize { get; private set; }
        public uint AvgTransactionSegmentSize_Base { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint FlushThread256KQueueDepth { get; private set; }
        public uint FlushThread4KQueueDepth { get; private set; }
        public uint FlushThread64KQueueDepth { get; private set; }
        public uint FlushThreadFrozenIOsPersec256K { get; private set; }
        public uint FlushThreadFrozenIOsPersec4K { get; private set; }
        public uint FlushThreadFrozenIOsPersec64K { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint IoPagePool256KFreeListCount { get; private set; }
        public uint IoPagePool256KTotalAllocated { get; private set; }
        public uint IoPagePool4KFreeListCount { get; private set; }
        public uint IoPagePool4KTotalAllocated { get; private set; }
        public uint IoPagePool64KFreeListCount { get; private set; }
        public uint IoPagePool64KTotalAllocated { get; private set; }
        public uint MtLog256KExpandCount { get; private set; }
        public uint MtLog256KIOsOutstanding { get; private set; }
        public ulong MtLog256KPageFillPercentPerPageFlushed { get; private set; }
        public uint MtLog256KPageFillPercentPerPageFlushed_Base { get; private set; }
        public uint MtLog256KWriteBytesPersec { get; private set; }
        public uint MtLog4KExpandCount { get; private set; }
        public uint MtLog4KIOsOutstanding { get; private set; }
        public ulong MtLog4KPageFillPercentPerPageFlushed { get; private set; }
        public uint MtLog4KPageFillPercentPerPageFlushed_Base { get; private set; }
        public uint MtLog4KWriteBytesPersec { get; private set; }
        public uint MtLog64KExpandCount { get; private set; }
        public uint MtLog64KIOsOutstanding { get; private set; }
        public ulong MtLog64KPageFillPercentPerPageFlushed { get; private set; }
        public uint MtLog64KPageFillPercentPerPageFlushed_Base { get; private set; }
        public uint MtLog64KWriteBytesPersec { get; private set; }
        public string Name { get; private set; }
        public uint NumMerges { get; private set; }
        public uint NumMergesPersec { get; private set; }
        public uint NumSerializations { get; private set; }
        public uint NumSerializationsPersec { get; private set; }
        public uint TailCachePageCount { get; private set; }
        public uint TailCachePageCountPeak { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases[] Retrieve(string remote,
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

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases
                {
                    AvgTransactionSegmentLargeDataSize =
                        (ulong) managementObject.Properties["AvgTransactionSegmentLargeDataSize"].Value,
                    AvgTransactionSegmentLargeDataSize_Base = (uint) managementObject
                        .Properties["AvgTransactionSegmentLargeDataSize_Base"].Value,
                    AvgTransactionSegmentSize = (ulong) managementObject.Properties["AvgTransactionSegmentSize"].Value,
                    AvgTransactionSegmentSize_Base =
                        (uint) managementObject.Properties["AvgTransactionSegmentSize_Base"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FlushThread256KQueueDepth = (uint) managementObject.Properties["FlushThread256KQueueDepth"].Value,
                    FlushThread4KQueueDepth = (uint) managementObject.Properties["FlushThread4KQueueDepth"].Value,
                    FlushThread64KQueueDepth = (uint) managementObject.Properties["FlushThread64KQueueDepth"].Value,
                    FlushThreadFrozenIOsPersec256K =
                        (uint) managementObject.Properties["FlushThreadFrozenIOsPersec256K"].Value,
                    FlushThreadFrozenIOsPersec4K = (uint) managementObject.Properties["FlushThreadFrozenIOsPersec4K"]
                        .Value,
                    FlushThreadFrozenIOsPersec64K = (uint) managementObject.Properties["FlushThreadFrozenIOsPersec64K"]
                        .Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IoPagePool256KFreeListCount = (uint) managementObject.Properties["IoPagePool256KFreeListCount"]
                        .Value,
                    IoPagePool256KTotalAllocated = (uint) managementObject.Properties["IoPagePool256KTotalAllocated"]
                        .Value,
                    IoPagePool4KFreeListCount = (uint) managementObject.Properties["IoPagePool4KFreeListCount"].Value,
                    IoPagePool4KTotalAllocated = (uint) managementObject.Properties["IoPagePool4KTotalAllocated"].Value,
                    IoPagePool64KFreeListCount = (uint) managementObject.Properties["IoPagePool64KFreeListCount"].Value,
                    IoPagePool64KTotalAllocated = (uint) managementObject.Properties["IoPagePool64KTotalAllocated"]
                        .Value,
                    MtLog256KExpandCount = (uint) managementObject.Properties["MtLog256KExpandCount"].Value,
                    MtLog256KIOsOutstanding = (uint) managementObject.Properties["MtLog256KIOsOutstanding"].Value,
                    MtLog256KPageFillPercentPerPageFlushed = (ulong) managementObject
                        .Properties["MtLog256KPageFillPercentPerPageFlushed"].Value,
                    MtLog256KPageFillPercentPerPageFlushed_Base = (uint) managementObject
                        .Properties["MtLog256KPageFillPercentPerPageFlushed_Base"].Value,
                    MtLog256KWriteBytesPersec = (uint) managementObject.Properties["MtLog256KWriteBytesPersec"].Value,
                    MtLog4KExpandCount = (uint) managementObject.Properties["MtLog4KExpandCount"].Value,
                    MtLog4KIOsOutstanding = (uint) managementObject.Properties["MtLog4KIOsOutstanding"].Value,
                    MtLog4KPageFillPercentPerPageFlushed = (ulong) managementObject
                        .Properties["MtLog4KPageFillPercentPerPageFlushed"].Value,
                    MtLog4KPageFillPercentPerPageFlushed_Base = (uint) managementObject
                        .Properties["MtLog4KPageFillPercentPerPageFlushed_Base"].Value,
                    MtLog4KWriteBytesPersec = (uint) managementObject.Properties["MtLog4KWriteBytesPersec"].Value,
                    MtLog64KExpandCount = (uint) managementObject.Properties["MtLog64KExpandCount"].Value,
                    MtLog64KIOsOutstanding = (uint) managementObject.Properties["MtLog64KIOsOutstanding"].Value,
                    MtLog64KPageFillPercentPerPageFlushed = (ulong) managementObject
                        .Properties["MtLog64KPageFillPercentPerPageFlushed"].Value,
                    MtLog64KPageFillPercentPerPageFlushed_Base = (uint) managementObject
                        .Properties["MtLog64KPageFillPercentPerPageFlushed_Base"].Value,
                    MtLog64KWriteBytesPersec = (uint) managementObject.Properties["MtLog64KWriteBytesPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumMerges = (uint) managementObject.Properties["NumMerges"].Value,
                    NumMergesPersec = (uint) managementObject.Properties["NumMergesPersec"].Value,
                    NumSerializations = (uint) managementObject.Properties["NumSerializations"].Value,
                    NumSerializationsPersec = (uint) managementObject.Properties["NumSerializationsPersec"].Value,
                    TailCachePageCount = (uint) managementObject.Properties["TailCachePageCount"].Value,
                    TailCachePageCountPeak = (uint) managementObject.Properties["TailCachePageCountPeak"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}