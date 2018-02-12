using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases
    {
		public ulong AvgTransactionSegmentLargeDataSize { get; private set; }
		public ulong AvgTransactionSegmentSize { get; private set; }
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
		public uint MtLog256KWriteBytesPersec { get; private set; }
		public uint MtLog4KExpandCount { get; private set; }
		public uint MtLog4KIOsOutstanding { get; private set; }
		public ulong MtLog4KPageFillPercentPerPageFlushed { get; private set; }
		public uint MtLog4KWriteBytesPersec { get; private set; }
		public uint MtLog64KExpandCount { get; private set; }
		public uint MtLog64KIOsOutstanding { get; private set; }
		public ulong MtLog64KPageFillPercentPerPageFlushed { get; private set; }
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

        public static IEnumerable<SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SQLServer2016XTPDatabaseEngine_SQLServer2016XTPDatabases
                {
                     AvgTransactionSegmentLargeDataSize = (ulong) (managementObject.Properties["AvgTransactionSegmentLargeDataSize"]?.Value ?? default(ulong)),
		 AvgTransactionSegmentSize = (ulong) (managementObject.Properties["AvgTransactionSegmentSize"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FlushThread256KQueueDepth = (uint) (managementObject.Properties["FlushThread256KQueueDepth"]?.Value ?? default(uint)),
		 FlushThread4KQueueDepth = (uint) (managementObject.Properties["FlushThread4KQueueDepth"]?.Value ?? default(uint)),
		 FlushThread64KQueueDepth = (uint) (managementObject.Properties["FlushThread64KQueueDepth"]?.Value ?? default(uint)),
		 FlushThreadFrozenIOsPersec256K = (uint) (managementObject.Properties["FlushThreadFrozenIOsPersec256K"]?.Value ?? default(uint)),
		 FlushThreadFrozenIOsPersec4K = (uint) (managementObject.Properties["FlushThreadFrozenIOsPersec4K"]?.Value ?? default(uint)),
		 FlushThreadFrozenIOsPersec64K = (uint) (managementObject.Properties["FlushThreadFrozenIOsPersec64K"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IoPagePool256KFreeListCount = (uint) (managementObject.Properties["IoPagePool256KFreeListCount"]?.Value ?? default(uint)),
		 IoPagePool256KTotalAllocated = (uint) (managementObject.Properties["IoPagePool256KTotalAllocated"]?.Value ?? default(uint)),
		 IoPagePool4KFreeListCount = (uint) (managementObject.Properties["IoPagePool4KFreeListCount"]?.Value ?? default(uint)),
		 IoPagePool4KTotalAllocated = (uint) (managementObject.Properties["IoPagePool4KTotalAllocated"]?.Value ?? default(uint)),
		 IoPagePool64KFreeListCount = (uint) (managementObject.Properties["IoPagePool64KFreeListCount"]?.Value ?? default(uint)),
		 IoPagePool64KTotalAllocated = (uint) (managementObject.Properties["IoPagePool64KTotalAllocated"]?.Value ?? default(uint)),
		 MtLog256KExpandCount = (uint) (managementObject.Properties["MtLog256KExpandCount"]?.Value ?? default(uint)),
		 MtLog256KIOsOutstanding = (uint) (managementObject.Properties["MtLog256KIOsOutstanding"]?.Value ?? default(uint)),
		 MtLog256KPageFillPercentPerPageFlushed = (ulong) (managementObject.Properties["MtLog256KPageFillPercentPerPageFlushed"]?.Value ?? default(ulong)),
		 MtLog256KWriteBytesPersec = (uint) (managementObject.Properties["MtLog256KWriteBytesPersec"]?.Value ?? default(uint)),
		 MtLog4KExpandCount = (uint) (managementObject.Properties["MtLog4KExpandCount"]?.Value ?? default(uint)),
		 MtLog4KIOsOutstanding = (uint) (managementObject.Properties["MtLog4KIOsOutstanding"]?.Value ?? default(uint)),
		 MtLog4KPageFillPercentPerPageFlushed = (ulong) (managementObject.Properties["MtLog4KPageFillPercentPerPageFlushed"]?.Value ?? default(ulong)),
		 MtLog4KWriteBytesPersec = (uint) (managementObject.Properties["MtLog4KWriteBytesPersec"]?.Value ?? default(uint)),
		 MtLog64KExpandCount = (uint) (managementObject.Properties["MtLog64KExpandCount"]?.Value ?? default(uint)),
		 MtLog64KIOsOutstanding = (uint) (managementObject.Properties["MtLog64KIOsOutstanding"]?.Value ?? default(uint)),
		 MtLog64KPageFillPercentPerPageFlushed = (ulong) (managementObject.Properties["MtLog64KPageFillPercentPerPageFlushed"]?.Value ?? default(ulong)),
		 MtLog64KWriteBytesPersec = (uint) (managementObject.Properties["MtLog64KWriteBytesPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumMerges = (uint) (managementObject.Properties["NumMerges"]?.Value ?? default(uint)),
		 NumMergesPersec = (uint) (managementObject.Properties["NumMergesPersec"]?.Value ?? default(uint)),
		 NumSerializations = (uint) (managementObject.Properties["NumSerializations"]?.Value ?? default(uint)),
		 NumSerializationsPersec = (uint) (managementObject.Properties["NumSerializationsPersec"]?.Value ?? default(uint)),
		 TailCachePageCount = (uint) (managementObject.Properties["TailCachePageCount"]?.Value ?? default(uint)),
		 TailCachePageCountPeak = (uint) (managementObject.Properties["TailCachePageCountPeak"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}