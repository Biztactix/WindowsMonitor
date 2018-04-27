using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class PerfOS_Cache
    {
		public uint AsyncCopyReadsPersec { get; private set; }
		public uint AsyncDataMapsPersec { get; private set; }
		public uint AsyncFastReadsPersec { get; private set; }
		public uint AsyncMDLReadsPersec { get; private set; }
		public uint AsyncPinReadsPersec { get; private set; }
		public string Caption { get; private set; }
		public uint CopyReadHitsPercent { get; private set; }
		public uint CopyReadsPersec { get; private set; }
		public uint DataFlushesPersec { get; private set; }
		public uint DataFlushPagesPersec { get; private set; }
		public uint DataMapHitsPercent { get; private set; }
		public uint DataMapPinsPersec { get; private set; }
		public uint DataMapsPersec { get; private set; }
		public string Description { get; private set; }
		public ulong DirtyPages { get; private set; }
		public ulong DirtyPageThreshold { get; private set; }
		public uint FastReadNotPossiblesPersec { get; private set; }
		public uint FastReadResourceMissesPersec { get; private set; }
		public uint FastReadsPersec { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint LazyWriteFlushesPersec { get; private set; }
		public uint LazyWritePagesPersec { get; private set; }
		public uint MDLReadHitsPercent { get; private set; }
		public uint MDLReadsPersec { get; private set; }
		public string Name { get; private set; }
		public uint PinReadHitsPercent { get; private set; }
		public uint PinReadsPersec { get; private set; }
		public uint ReadAheadsPersec { get; private set; }
		public uint SyncCopyReadsPersec { get; private set; }
		public uint SyncDataMapsPersec { get; private set; }
		public uint SyncFastReadsPersec { get; private set; }
		public uint SyncMDLReadsPersec { get; private set; }
		public uint SyncPinReadsPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<PerfOS_Cache> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PerfOS_Cache> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PerfOS_Cache> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Cache");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PerfOS_Cache
                {
                     AsyncCopyReadsPersec = (uint) (managementObject.Properties["AsyncCopyReadsPersec"]?.Value ?? default(uint)),
		 AsyncDataMapsPersec = (uint) (managementObject.Properties["AsyncDataMapsPersec"]?.Value ?? default(uint)),
		 AsyncFastReadsPersec = (uint) (managementObject.Properties["AsyncFastReadsPersec"]?.Value ?? default(uint)),
		 AsyncMDLReadsPersec = (uint) (managementObject.Properties["AsyncMDLReadsPersec"]?.Value ?? default(uint)),
		 AsyncPinReadsPersec = (uint) (managementObject.Properties["AsyncPinReadsPersec"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CopyReadHitsPercent = (uint) (managementObject.Properties["CopyReadHitsPercent"]?.Value ?? default(uint)),
		 CopyReadsPersec = (uint) (managementObject.Properties["CopyReadsPersec"]?.Value ?? default(uint)),
		 DataFlushesPersec = (uint) (managementObject.Properties["DataFlushesPersec"]?.Value ?? default(uint)),
		 DataFlushPagesPersec = (uint) (managementObject.Properties["DataFlushPagesPersec"]?.Value ?? default(uint)),
		 DataMapHitsPercent = (uint) (managementObject.Properties["DataMapHitsPercent"]?.Value ?? default(uint)),
		 DataMapPinsPersec = (uint) (managementObject.Properties["DataMapPinsPersec"]?.Value ?? default(uint)),
		 DataMapsPersec = (uint) (managementObject.Properties["DataMapsPersec"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DirtyPages = (ulong) (managementObject.Properties["DirtyPages"]?.Value ?? default(ulong)),
		 DirtyPageThreshold = (ulong) (managementObject.Properties["DirtyPageThreshold"]?.Value ?? default(ulong)),
		 FastReadNotPossiblesPersec = (uint) (managementObject.Properties["FastReadNotPossiblesPersec"]?.Value ?? default(uint)),
		 FastReadResourceMissesPersec = (uint) (managementObject.Properties["FastReadResourceMissesPersec"]?.Value ?? default(uint)),
		 FastReadsPersec = (uint) (managementObject.Properties["FastReadsPersec"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 LazyWriteFlushesPersec = (uint) (managementObject.Properties["LazyWriteFlushesPersec"]?.Value ?? default(uint)),
		 LazyWritePagesPersec = (uint) (managementObject.Properties["LazyWritePagesPersec"]?.Value ?? default(uint)),
		 MDLReadHitsPercent = (uint) (managementObject.Properties["MDLReadHitsPercent"]?.Value ?? default(uint)),
		 MDLReadsPersec = (uint) (managementObject.Properties["MDLReadsPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PinReadHitsPercent = (uint) (managementObject.Properties["PinReadHitsPercent"]?.Value ?? default(uint)),
		 PinReadsPersec = (uint) (managementObject.Properties["PinReadsPersec"]?.Value ?? default(uint)),
		 ReadAheadsPersec = (uint) (managementObject.Properties["ReadAheadsPersec"]?.Value ?? default(uint)),
		 SyncCopyReadsPersec = (uint) (managementObject.Properties["SyncCopyReadsPersec"]?.Value ?? default(uint)),
		 SyncDataMapsPersec = (uint) (managementObject.Properties["SyncDataMapsPersec"]?.Value ?? default(uint)),
		 SyncFastReadsPersec = (uint) (managementObject.Properties["SyncFastReadsPersec"]?.Value ?? default(uint)),
		 SyncMDLReadsPersec = (uint) (managementObject.Properties["SyncMDLReadsPersec"]?.Value ?? default(uint)),
		 SyncPinReadsPersec = (uint) (managementObject.Properties["SyncPinReadsPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}