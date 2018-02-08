using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_PerfOS_Memory
    {
        public ulong AvailableBytes { get; private set; }
        public ulong AvailableKBytes { get; private set; }
        public ulong AvailableMBytes { get; private set; }
        public ulong CacheBytes { get; private set; }
        public ulong CacheBytesPeak { get; private set; }
        public uint CacheFaultsPersec { get; private set; }
        public string Caption { get; private set; }
        public ulong CommitLimit { get; private set; }
        public ulong CommittedBytes { get; private set; }
        public uint DemandZeroFaultsPersec { get; private set; }
        public string Description { get; private set; }
        public ulong FreeAndZeroPageListBytes { get; private set; }
        public uint FreeSystemPageTableEntries { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint LongTermAverageStandbyCacheLifetimes { get; private set; }
        public ulong ModifiedPageListBytes { get; private set; }
        public string Name { get; private set; }
        public uint PageFaultsPersec { get; private set; }
        public uint PageReadsPersec { get; private set; }
        public uint PagesInputPersec { get; private set; }
        public uint PagesOutputPersec { get; private set; }
        public uint PagesPersec { get; private set; }
        public uint PageWritesPersec { get; private set; }
        public uint PercentCommittedBytesInUse { get; private set; }
        public uint PercentCommittedBytesInUse_Base { get; private set; }
        public uint PoolNonpagedAllocs { get; private set; }
        public ulong PoolNonpagedBytes { get; private set; }
        public uint PoolPagedAllocs { get; private set; }
        public ulong PoolPagedBytes { get; private set; }
        public ulong PoolPagedResidentBytes { get; private set; }
        public ulong StandbyCacheCoreBytes { get; private set; }
        public ulong StandbyCacheNormalPriorityBytes { get; private set; }
        public ulong StandbyCacheReserveBytes { get; private set; }
        public ulong SystemCacheResidentBytes { get; private set; }
        public ulong SystemCodeResidentBytes { get; private set; }
        public ulong SystemCodeTotalBytes { get; private set; }
        public ulong SystemDriverResidentBytes { get; private set; }
        public ulong SystemDriverTotalBytes { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TransitionFaultsPersec { get; private set; }
        public uint TransitionPagesRePurposedPersec { get; private set; }
        public uint WriteCopiesPersec { get; private set; }

        public static PerfRawData_PerfOS_Memory[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_PerfOS_Memory[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_PerfOS_Memory[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PerfOS_Memory");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_PerfOS_Memory>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_PerfOS_Memory
                {
                    AvailableBytes = (ulong) managementObject.Properties["AvailableBytes"].Value,
                    AvailableKBytes = (ulong) managementObject.Properties["AvailableKBytes"].Value,
                    AvailableMBytes = (ulong) managementObject.Properties["AvailableMBytes"].Value,
                    CacheBytes = (ulong) managementObject.Properties["CacheBytes"].Value,
                    CacheBytesPeak = (ulong) managementObject.Properties["CacheBytesPeak"].Value,
                    CacheFaultsPersec = (uint) managementObject.Properties["CacheFaultsPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CommitLimit = (ulong) managementObject.Properties["CommitLimit"].Value,
                    CommittedBytes = (ulong) managementObject.Properties["CommittedBytes"].Value,
                    DemandZeroFaultsPersec = (uint) managementObject.Properties["DemandZeroFaultsPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FreeAndZeroPageListBytes = (ulong) managementObject.Properties["FreeAndZeroPageListBytes"].Value,
                    FreeSystemPageTableEntries = (uint) managementObject.Properties["FreeSystemPageTableEntries"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    LongTermAverageStandbyCacheLifetimes = (uint) managementObject
                        .Properties["LongTermAverageStandbyCacheLifetimes"].Value,
                    ModifiedPageListBytes = (ulong) managementObject.Properties["ModifiedPageListBytes"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PageFaultsPersec = (uint) managementObject.Properties["PageFaultsPersec"].Value,
                    PageReadsPersec = (uint) managementObject.Properties["PageReadsPersec"].Value,
                    PagesInputPersec = (uint) managementObject.Properties["PagesInputPersec"].Value,
                    PagesOutputPersec = (uint) managementObject.Properties["PagesOutputPersec"].Value,
                    PagesPersec = (uint) managementObject.Properties["PagesPersec"].Value,
                    PageWritesPersec = (uint) managementObject.Properties["PageWritesPersec"].Value,
                    PercentCommittedBytesInUse = (uint) managementObject.Properties["PercentCommittedBytesInUse"].Value,
                    PercentCommittedBytesInUse_Base =
                        (uint) managementObject.Properties["PercentCommittedBytesInUse_Base"].Value,
                    PoolNonpagedAllocs = (uint) managementObject.Properties["PoolNonpagedAllocs"].Value,
                    PoolNonpagedBytes = (ulong) managementObject.Properties["PoolNonpagedBytes"].Value,
                    PoolPagedAllocs = (uint) managementObject.Properties["PoolPagedAllocs"].Value,
                    PoolPagedBytes = (ulong) managementObject.Properties["PoolPagedBytes"].Value,
                    PoolPagedResidentBytes = (ulong) managementObject.Properties["PoolPagedResidentBytes"].Value,
                    StandbyCacheCoreBytes = (ulong) managementObject.Properties["StandbyCacheCoreBytes"].Value,
                    StandbyCacheNormalPriorityBytes =
                        (ulong) managementObject.Properties["StandbyCacheNormalPriorityBytes"].Value,
                    StandbyCacheReserveBytes = (ulong) managementObject.Properties["StandbyCacheReserveBytes"].Value,
                    SystemCacheResidentBytes = (ulong) managementObject.Properties["SystemCacheResidentBytes"].Value,
                    SystemCodeResidentBytes = (ulong) managementObject.Properties["SystemCodeResidentBytes"].Value,
                    SystemCodeTotalBytes = (ulong) managementObject.Properties["SystemCodeTotalBytes"].Value,
                    SystemDriverResidentBytes = (ulong) managementObject.Properties["SystemDriverResidentBytes"].Value,
                    SystemDriverTotalBytes = (ulong) managementObject.Properties["SystemDriverTotalBytes"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TransitionFaultsPersec = (uint) managementObject.Properties["TransitionFaultsPersec"].Value,
                    TransitionPagesRePurposedPersec =
                        (uint) managementObject.Properties["TransitionPagesRePurposedPersec"].Value,
                    WriteCopiesPersec = (uint) managementObject.Properties["WriteCopiesPersec"].Value
                });

            return list.ToArray();
        }
    }
}