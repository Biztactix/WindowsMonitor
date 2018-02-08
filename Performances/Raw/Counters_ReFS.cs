using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_ReFS
    {
        public ulong BytesCached { get; private set; }
        public ulong BytesReadfromCachePersec { get; private set; }
        public ulong BytesReadMissingCachePersec { get; private set; }
        public ulong CacheAllocated { get; private set; }
        public ulong CacheAllocationsPersec { get; private set; }
        public uint CacheAllocationUnitSize { get; private set; }
        public ulong CacheHitsPersec { get; private set; }
        public ulong CacheInError { get; private set; }
        public ulong CacheInvalidationsinBytesPersec { get; private set; }
        public ulong CacheInvalidationsPersec { get; private set; }
        public uint CacheLinesFree { get; private set; }
        public uint CacheLinesInError { get; private set; }
        public ulong CacheMetadataWrittenBytesPersec { get; private set; }
        public ulong CacheMissesPersec { get; private set; }
        public ulong CachePopulationsBytesPersec { get; private set; }
        public ulong CachePopulationsPersec { get; private set; }
        public ulong CacheSize { get; private set; }
        public ulong CacheWriteThroughUpdatesBytesPersec { get; private set; }
        public ulong CacheWriteThroughUpdatesPersec { get; private set; }
        public string Caption { get; private set; }
        public ulong Checkpointlatency100ns { get; private set; }
        public uint Checkpointlatency100ns_Base { get; private set; }
        public ulong CheckpointsPersec { get; private set; }
        public ulong Compactionreadlatency100ns { get; private set; }
        public uint Compactionreadlatency100ns_Base { get; private set; }
        public ulong Compactionwritelatency100ns { get; private set; }
        public uint Compactionwritelatency100ns_Base { get; private set; }
        public ulong ContainerDestagesFromFastTierPersec { get; private set; }
        public ulong ContainerDestagesFromSlowTierPersec { get; private set; }
        public ulong DataAllocationsFastTierPersec { get; private set; }
        public ulong DataAllocationsSlowTierPersec { get; private set; }
        public ulong DataCompactionsPersec { get; private set; }
        public ulong DataInPlaceWritesPersec { get; private set; }
        public string Description { get; private set; }
        public uint Fasttierdatadestagecriteriapercentage { get; private set; }
        public ulong FastTierDestagedContainerFillRatioPercent { get; private set; }
        public uint FastTierDestagedContainerFillRatioPercent_Base { get; private set; }
        public ulong Fasttierdestagereadlatency100ns { get; private set; }
        public uint Fasttierdestagereadlatency100ns_Base { get; private set; }
        public ulong Fasttierdestagewritelatency100ns { get; private set; }
        public uint Fasttierdestagewritelatency100ns_Base { get; private set; }
        public uint Fasttiermetadatadestagecriteriapercentage { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint Logfillpercentage { get; private set; }
        public ulong LogwritesPersec { get; private set; }
        public uint MaxTransactionsOutstanding { get; private set; }
        public ulong MemoryUsed { get; private set; }
        public ulong MetadataAllocationsFastTierPersec { get; private set; }
        public ulong MetadataAllocationsSlowTierPersec { get; private set; }
        public string Name { get; private set; }
        public uint Slowtierdatadestagecriteriapercentage { get; private set; }
        public ulong SlowTierDestagedContainerFillRatioPercent { get; private set; }
        public uint SlowTierDestagedContainerFillRatioPercent_Base { get; private set; }
        public ulong Slowtierdestagereadlatency100ns { get; private set; }
        public uint Slowtierdestagereadlatency100ns_Base { get; private set; }
        public ulong Slowtierdestagewritelatency100ns { get; private set; }
        public uint Slowtierdestagewritelatency100ns_Base { get; private set; }
        public uint Slowtiermetadatadestagecriteriapercentage { get; private set; }
        public ulong SpeculativeBytesReadtoCachePersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalAllocationsPersec { get; private set; }
        public uint TransactionsOutstanding { get; private set; }
        public ulong Treeupdatelatency100ns { get; private set; }
        public uint Treeupdatelatency100ns_Base { get; private set; }
        public ulong TreeupdatesPersec { get; private set; }
        public ulong Trimlatency100ns { get; private set; }
        public uint Trimlatency100ns_Base { get; private set; }

        public static PerfRawData_Counters_ReFS[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_ReFS[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_ReFS[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_ReFS");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_ReFS>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_ReFS
                {
                    BytesCached = (ulong) managementObject.Properties["BytesCached"].Value,
                    BytesReadfromCachePersec = (ulong) managementObject.Properties["BytesReadfromCachePersec"].Value,
                    BytesReadMissingCachePersec = (ulong) managementObject.Properties["BytesReadMissingCachePersec"]
                        .Value,
                    CacheAllocated = (ulong) managementObject.Properties["CacheAllocated"].Value,
                    CacheAllocationsPersec = (ulong) managementObject.Properties["CacheAllocationsPersec"].Value,
                    CacheAllocationUnitSize = (uint) managementObject.Properties["CacheAllocationUnitSize"].Value,
                    CacheHitsPersec = (ulong) managementObject.Properties["CacheHitsPersec"].Value,
                    CacheInError = (ulong) managementObject.Properties["CacheInError"].Value,
                    CacheInvalidationsinBytesPersec =
                        (ulong) managementObject.Properties["CacheInvalidationsinBytesPersec"].Value,
                    CacheInvalidationsPersec = (ulong) managementObject.Properties["CacheInvalidationsPersec"].Value,
                    CacheLinesFree = (uint) managementObject.Properties["CacheLinesFree"].Value,
                    CacheLinesInError = (uint) managementObject.Properties["CacheLinesInError"].Value,
                    CacheMetadataWrittenBytesPersec =
                        (ulong) managementObject.Properties["CacheMetadataWrittenBytesPersec"].Value,
                    CacheMissesPersec = (ulong) managementObject.Properties["CacheMissesPersec"].Value,
                    CachePopulationsBytesPersec = (ulong) managementObject.Properties["CachePopulationsBytesPersec"]
                        .Value,
                    CachePopulationsPersec = (ulong) managementObject.Properties["CachePopulationsPersec"].Value,
                    CacheSize = (ulong) managementObject.Properties["CacheSize"].Value,
                    CacheWriteThroughUpdatesBytesPersec =
                        (ulong) managementObject.Properties["CacheWriteThroughUpdatesBytesPersec"].Value,
                    CacheWriteThroughUpdatesPersec =
                        (ulong) managementObject.Properties["CacheWriteThroughUpdatesPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Checkpointlatency100ns = (ulong) managementObject.Properties["Checkpointlatency100ns"].Value,
                    Checkpointlatency100ns_Base = (uint) managementObject.Properties["Checkpointlatency100ns_Base"]
                        .Value,
                    CheckpointsPersec = (ulong) managementObject.Properties["CheckpointsPersec"].Value,
                    Compactionreadlatency100ns =
                        (ulong) managementObject.Properties["Compactionreadlatency100ns"].Value,
                    Compactionreadlatency100ns_Base =
                        (uint) managementObject.Properties["Compactionreadlatency100ns_Base"].Value,
                    Compactionwritelatency100ns = (ulong) managementObject.Properties["Compactionwritelatency100ns"]
                        .Value,
                    Compactionwritelatency100ns_Base =
                        (uint) managementObject.Properties["Compactionwritelatency100ns_Base"].Value,
                    ContainerDestagesFromFastTierPersec =
                        (ulong) managementObject.Properties["ContainerDestagesFromFastTierPersec"].Value,
                    ContainerDestagesFromSlowTierPersec =
                        (ulong) managementObject.Properties["ContainerDestagesFromSlowTierPersec"].Value,
                    DataAllocationsFastTierPersec =
                        (ulong) managementObject.Properties["DataAllocationsFastTierPersec"].Value,
                    DataAllocationsSlowTierPersec =
                        (ulong) managementObject.Properties["DataAllocationsSlowTierPersec"].Value,
                    DataCompactionsPersec = (ulong) managementObject.Properties["DataCompactionsPersec"].Value,
                    DataInPlaceWritesPersec = (ulong) managementObject.Properties["DataInPlaceWritesPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Fasttierdatadestagecriteriapercentage = (uint) managementObject
                        .Properties["Fasttierdatadestagecriteriapercentage"].Value,
                    FastTierDestagedContainerFillRatioPercent = (ulong) managementObject
                        .Properties["FastTierDestagedContainerFillRatioPercent"].Value,
                    FastTierDestagedContainerFillRatioPercent_Base = (uint) managementObject
                        .Properties["FastTierDestagedContainerFillRatioPercent_Base"].Value,
                    Fasttierdestagereadlatency100ns =
                        (ulong) managementObject.Properties["Fasttierdestagereadlatency100ns"].Value,
                    Fasttierdestagereadlatency100ns_Base = (uint) managementObject
                        .Properties["Fasttierdestagereadlatency100ns_Base"].Value,
                    Fasttierdestagewritelatency100ns =
                        (ulong) managementObject.Properties["Fasttierdestagewritelatency100ns"].Value,
                    Fasttierdestagewritelatency100ns_Base = (uint) managementObject
                        .Properties["Fasttierdestagewritelatency100ns_Base"].Value,
                    Fasttiermetadatadestagecriteriapercentage = (uint) managementObject
                        .Properties["Fasttiermetadatadestagecriteriapercentage"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Logfillpercentage = (uint) managementObject.Properties["Logfillpercentage"].Value,
                    LogwritesPersec = (ulong) managementObject.Properties["LogwritesPersec"].Value,
                    MaxTransactionsOutstanding = (uint) managementObject.Properties["MaxTransactionsOutstanding"].Value,
                    MemoryUsed = (ulong) managementObject.Properties["MemoryUsed"].Value,
                    MetadataAllocationsFastTierPersec =
                        (ulong) managementObject.Properties["MetadataAllocationsFastTierPersec"].Value,
                    MetadataAllocationsSlowTierPersec =
                        (ulong) managementObject.Properties["MetadataAllocationsSlowTierPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Slowtierdatadestagecriteriapercentage = (uint) managementObject
                        .Properties["Slowtierdatadestagecriteriapercentage"].Value,
                    SlowTierDestagedContainerFillRatioPercent = (ulong) managementObject
                        .Properties["SlowTierDestagedContainerFillRatioPercent"].Value,
                    SlowTierDestagedContainerFillRatioPercent_Base = (uint) managementObject
                        .Properties["SlowTierDestagedContainerFillRatioPercent_Base"].Value,
                    Slowtierdestagereadlatency100ns =
                        (ulong) managementObject.Properties["Slowtierdestagereadlatency100ns"].Value,
                    Slowtierdestagereadlatency100ns_Base = (uint) managementObject
                        .Properties["Slowtierdestagereadlatency100ns_Base"].Value,
                    Slowtierdestagewritelatency100ns =
                        (ulong) managementObject.Properties["Slowtierdestagewritelatency100ns"].Value,
                    Slowtierdestagewritelatency100ns_Base = (uint) managementObject
                        .Properties["Slowtierdestagewritelatency100ns_Base"].Value,
                    Slowtiermetadatadestagecriteriapercentage = (uint) managementObject
                        .Properties["Slowtiermetadatadestagecriteriapercentage"].Value,
                    SpeculativeBytesReadtoCachePersec =
                        (ulong) managementObject.Properties["SpeculativeBytesReadtoCachePersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalAllocationsPersec = (ulong) managementObject.Properties["TotalAllocationsPersec"].Value,
                    TransactionsOutstanding = (uint) managementObject.Properties["TransactionsOutstanding"].Value,
                    Treeupdatelatency100ns = (ulong) managementObject.Properties["Treeupdatelatency100ns"].Value,
                    Treeupdatelatency100ns_Base = (uint) managementObject.Properties["Treeupdatelatency100ns_Base"]
                        .Value,
                    TreeupdatesPersec = (ulong) managementObject.Properties["TreeupdatesPersec"].Value,
                    Trimlatency100ns = (ulong) managementObject.Properties["Trimlatency100ns"].Value,
                    Trimlatency100ns_Base = (uint) managementObject.Properties["Trimlatency100ns_Base"].Value
                });

            return list.ToArray();
        }
    }
}