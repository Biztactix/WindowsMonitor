using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class PerfProc_Heap_Costly
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

        public static IEnumerable<PerfProc_Heap_Costly> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PerfProc_Heap_Costly> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PerfProc_Heap_Costly> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PerfProc_Heap_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PerfProc_Heap_Costly
                {
                     Allocs18KPersec = (uint) (managementObject.Properties["Allocs18KPersec"]?.Value ?? default(uint)),
		 Allocs1KPersec = (uint) (managementObject.Properties["Allocs1KPersec"]?.Value ?? default(uint)),
		 AllocsFrees = (uint) (managementObject.Properties["AllocsFrees"]?.Value ?? default(uint)),
		 Allocsover8KPersec = (uint) (managementObject.Properties["Allocsover8KPersec"]?.Value ?? default(uint)),
		 Avgallocrate = (ulong) (managementObject.Properties["Avgallocrate"]?.Value ?? default(ulong)),
		 Avgfreerate = (ulong) (managementObject.Properties["Avgfreerate"]?.Value ?? default(ulong)),
		 BlocksinHeapCache = (uint) (managementObject.Properties["BlocksinHeapCache"]?.Value ?? default(uint)),
		 CachedAllocsPersec = (uint) (managementObject.Properties["CachedAllocsPersec"]?.Value ?? default(uint)),
		 CachedFreesPersec = (uint) (managementObject.Properties["CachedFreesPersec"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CommittedBytes = (ulong) (managementObject.Properties["CommittedBytes"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FreeBytes = (ulong) (managementObject.Properties["FreeBytes"]?.Value ?? default(ulong)),
		 FreeListLength = (uint) (managementObject.Properties["FreeListLength"]?.Value ?? default(uint)),
		 Frees18KPersec = (uint) (managementObject.Properties["Frees18KPersec"]?.Value ?? default(uint)),
		 Frees1KPersec = (uint) (managementObject.Properties["Frees1KPersec"]?.Value ?? default(uint)),
		 Freesover8KPersec = (uint) (managementObject.Properties["Freesover8KPersec"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 HeapLockcontention = (uint) (managementObject.Properties["HeapLockcontention"]?.Value ?? default(uint)),
		 LargestCacheDepth = (uint) (managementObject.Properties["LargestCacheDepth"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PercentFragmentation = (uint) (managementObject.Properties["PercentFragmentation"]?.Value ?? default(uint)),
		 PercentVAFragmentation = (uint) (managementObject.Properties["PercentVAFragmentation"]?.Value ?? default(uint)),
		 ReservedBytes = (ulong) (managementObject.Properties["ReservedBytes"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalAllocsPersec = (uint) (managementObject.Properties["TotalAllocsPersec"]?.Value ?? default(uint)),
		 TotalFreesPersec = (uint) (managementObject.Properties["TotalFreesPersec"]?.Value ?? default(uint)),
		 UncommittedRangesLength = (uint) (managementObject.Properties["UncommittedRangesLength"]?.Value ?? default(uint)),
		 VirtualBytes = (ulong) (managementObject.Properties["VirtualBytes"]?.Value ?? default(ulong))
                };
        }
    }
}