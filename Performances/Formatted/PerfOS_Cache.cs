using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_PerfOS_Cache
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

        public static PerfFormattedData_PerfOS_Cache[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_PerfOS_Cache[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_PerfOS_Cache[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Cache");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_PerfOS_Cache>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_PerfOS_Cache
                {
                    AsyncCopyReadsPersec = (uint) managementObject.Properties["AsyncCopyReadsPersec"].Value,
                    AsyncDataMapsPersec = (uint) managementObject.Properties["AsyncDataMapsPersec"].Value,
                    AsyncFastReadsPersec = (uint) managementObject.Properties["AsyncFastReadsPersec"].Value,
                    AsyncMDLReadsPersec = (uint) managementObject.Properties["AsyncMDLReadsPersec"].Value,
                    AsyncPinReadsPersec = (uint) managementObject.Properties["AsyncPinReadsPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CopyReadHitsPercent = (uint) managementObject.Properties["CopyReadHitsPercent"].Value,
                    CopyReadsPersec = (uint) managementObject.Properties["CopyReadsPersec"].Value,
                    DataFlushesPersec = (uint) managementObject.Properties["DataFlushesPersec"].Value,
                    DataFlushPagesPersec = (uint) managementObject.Properties["DataFlushPagesPersec"].Value,
                    DataMapHitsPercent = (uint) managementObject.Properties["DataMapHitsPercent"].Value,
                    DataMapPinsPersec = (uint) managementObject.Properties["DataMapPinsPersec"].Value,
                    DataMapsPersec = (uint) managementObject.Properties["DataMapsPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DirtyPages = (ulong) managementObject.Properties["DirtyPages"].Value,
                    DirtyPageThreshold = (ulong) managementObject.Properties["DirtyPageThreshold"].Value,
                    FastReadNotPossiblesPersec = (uint) managementObject.Properties["FastReadNotPossiblesPersec"].Value,
                    FastReadResourceMissesPersec = (uint) managementObject.Properties["FastReadResourceMissesPersec"]
                        .Value,
                    FastReadsPersec = (uint) managementObject.Properties["FastReadsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    LazyWriteFlushesPersec = (uint) managementObject.Properties["LazyWriteFlushesPersec"].Value,
                    LazyWritePagesPersec = (uint) managementObject.Properties["LazyWritePagesPersec"].Value,
                    MDLReadHitsPercent = (uint) managementObject.Properties["MDLReadHitsPercent"].Value,
                    MDLReadsPersec = (uint) managementObject.Properties["MDLReadsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PinReadHitsPercent = (uint) managementObject.Properties["PinReadHitsPercent"].Value,
                    PinReadsPersec = (uint) managementObject.Properties["PinReadsPersec"].Value,
                    ReadAheadsPersec = (uint) managementObject.Properties["ReadAheadsPersec"].Value,
                    SyncCopyReadsPersec = (uint) managementObject.Properties["SyncCopyReadsPersec"].Value,
                    SyncDataMapsPersec = (uint) managementObject.Properties["SyncDataMapsPersec"].Value,
                    SyncFastReadsPersec = (uint) managementObject.Properties["SyncFastReadsPersec"].Value,
                    SyncMDLReadsPersec = (uint) managementObject.Properties["SyncMDLReadsPersec"].Value,
                    SyncPinReadsPersec = (uint) managementObject.Properties["SyncPinReadsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}