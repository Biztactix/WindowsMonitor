using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_PerfProc_Heap_Costly
    {
        public uint Allocs18KPersec { get; private set; }
        public uint Allocs1KPersec { get; private set; }
        public uint AllocsFrees { get; private set; }
        public uint Allocsover8KPersec { get; private set; }
        public ulong Avgallocrate { get; private set; }
        public ulong Avgfreerate { get; private set; }
        public uint BlocksinHeapCache { get; private set; }
        public uint CachedAllocsPersec { get; private set; }
        public uint CachedFreesPersec { get; private set; }
        public string Caption { get; private set; }
        public ulong CommittedBytes { get; private set; }
        public string Description { get; private set; }
        public ulong FreeBytes { get; private set; }
        public uint FreeListLength { get; private set; }
        public uint Frees18KPersec { get; private set; }
        public uint Frees1KPersec { get; private set; }
        public uint Freesover8KPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint HeapLockcontention { get; private set; }
        public uint LargestCacheDepth { get; private set; }
        public string Name { get; private set; }
        public uint PercentFragmentation { get; private set; }
        public uint PercentVAFragmentation { get; private set; }
        public ulong ReservedBytes { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalAllocsPersec { get; private set; }
        public uint TotalFreesPersec { get; private set; }
        public uint UncommittedRangesLength { get; private set; }
        public ulong VirtualBytes { get; private set; }

        public static PerfRawData_PerfProc_Heap_Costly[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_PerfProc_Heap_Costly[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_PerfProc_Heap_Costly[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PerfProc_Heap_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_PerfProc_Heap_Costly>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_PerfProc_Heap_Costly
                {
                    Allocs18KPersec = (uint) managementObject.Properties["Allocs18KPersec"].Value,
                    Allocs1KPersec = (uint) managementObject.Properties["Allocs1KPersec"].Value,
                    AllocsFrees = (uint) managementObject.Properties["AllocsFrees"].Value,
                    Allocsover8KPersec = (uint) managementObject.Properties["Allocsover8KPersec"].Value,
                    Avgallocrate = (ulong) managementObject.Properties["Avgallocrate"].Value,
                    Avgfreerate = (ulong) managementObject.Properties["Avgfreerate"].Value,
                    BlocksinHeapCache = (uint) managementObject.Properties["BlocksinHeapCache"].Value,
                    CachedAllocsPersec = (uint) managementObject.Properties["CachedAllocsPersec"].Value,
                    CachedFreesPersec = (uint) managementObject.Properties["CachedFreesPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CommittedBytes = (ulong) managementObject.Properties["CommittedBytes"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FreeBytes = (ulong) managementObject.Properties["FreeBytes"].Value,
                    FreeListLength = (uint) managementObject.Properties["FreeListLength"].Value,
                    Frees18KPersec = (uint) managementObject.Properties["Frees18KPersec"].Value,
                    Frees1KPersec = (uint) managementObject.Properties["Frees1KPersec"].Value,
                    Freesover8KPersec = (uint) managementObject.Properties["Freesover8KPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    HeapLockcontention = (uint) managementObject.Properties["HeapLockcontention"].Value,
                    LargestCacheDepth = (uint) managementObject.Properties["LargestCacheDepth"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PercentFragmentation = (uint) managementObject.Properties["PercentFragmentation"].Value,
                    PercentVAFragmentation = (uint) managementObject.Properties["PercentVAFragmentation"].Value,
                    ReservedBytes = (ulong) managementObject.Properties["ReservedBytes"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalAllocsPersec = (uint) managementObject.Properties["TotalAllocsPersec"].Value,
                    TotalFreesPersec = (uint) managementObject.Properties["TotalFreesPersec"].Value,
                    UncommittedRangesLength = (uint) managementObject.Properties["UncommittedRangesLength"].Value,
                    VirtualBytes = (ulong) managementObject.Properties["VirtualBytes"].Value
                });

            return list.ToArray();
        }
    }
}