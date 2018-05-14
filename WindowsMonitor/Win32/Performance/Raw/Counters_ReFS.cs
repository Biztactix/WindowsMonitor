using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_ReFS
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

        public static IEnumerable<Counters_ReFS> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_ReFS> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_ReFS> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_ReFS");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_ReFS
                {
                     BytesCached = (ulong) (managementObject.Properties["BytesCached"]?.Value ?? default(ulong)),
		 BytesReadfromCachePersec = (ulong) (managementObject.Properties["BytesReadfromCachePersec"]?.Value ?? default(ulong)),
		 BytesReadMissingCachePersec = (ulong) (managementObject.Properties["BytesReadMissingCachePersec"]?.Value ?? default(ulong)),
		 CacheAllocated = (ulong) (managementObject.Properties["CacheAllocated"]?.Value ?? default(ulong)),
		 CacheAllocationsPersec = (ulong) (managementObject.Properties["CacheAllocationsPersec"]?.Value ?? default(ulong)),
		 CacheAllocationUnitSize = (uint) (managementObject.Properties["CacheAllocationUnitSize"]?.Value ?? default(uint)),
		 CacheHitsPersec = (ulong) (managementObject.Properties["CacheHitsPersec"]?.Value ?? default(ulong)),
		 CacheInError = (ulong) (managementObject.Properties["CacheInError"]?.Value ?? default(ulong)),
		 CacheInvalidationsinBytesPersec = (ulong) (managementObject.Properties["CacheInvalidationsinBytesPersec"]?.Value ?? default(ulong)),
		 CacheInvalidationsPersec = (ulong) (managementObject.Properties["CacheInvalidationsPersec"]?.Value ?? default(ulong)),
		 CacheLinesFree = (uint) (managementObject.Properties["CacheLinesFree"]?.Value ?? default(uint)),
		 CacheLinesInError = (uint) (managementObject.Properties["CacheLinesInError"]?.Value ?? default(uint)),
		 CacheMetadataWrittenBytesPersec = (ulong) (managementObject.Properties["CacheMetadataWrittenBytesPersec"]?.Value ?? default(ulong)),
		 CacheMissesPersec = (ulong) (managementObject.Properties["CacheMissesPersec"]?.Value ?? default(ulong)),
		 CachePopulationsBytesPersec = (ulong) (managementObject.Properties["CachePopulationsBytesPersec"]?.Value ?? default(ulong)),
		 CachePopulationsPersec = (ulong) (managementObject.Properties["CachePopulationsPersec"]?.Value ?? default(ulong)),
		 CacheSize = (ulong) (managementObject.Properties["CacheSize"]?.Value ?? default(ulong)),
		 CacheWriteThroughUpdatesBytesPersec = (ulong) (managementObject.Properties["CacheWriteThroughUpdatesBytesPersec"]?.Value ?? default(ulong)),
		 CacheWriteThroughUpdatesPersec = (ulong) (managementObject.Properties["CacheWriteThroughUpdatesPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Checkpointlatency100ns = (ulong) (managementObject.Properties["Checkpointlatency100ns"]?.Value ?? default(ulong)),
		 Checkpointlatency100ns_Base = (uint) (managementObject.Properties["Checkpointlatency100ns_Base"]?.Value ?? default(uint)),
		 CheckpointsPersec = (ulong) (managementObject.Properties["CheckpointsPersec"]?.Value ?? default(ulong)),
		 Compactionreadlatency100ns = (ulong) (managementObject.Properties["Compactionreadlatency100ns"]?.Value ?? default(ulong)),
		 Compactionreadlatency100ns_Base = (uint) (managementObject.Properties["Compactionreadlatency100ns_Base"]?.Value ?? default(uint)),
		 Compactionwritelatency100ns = (ulong) (managementObject.Properties["Compactionwritelatency100ns"]?.Value ?? default(ulong)),
		 Compactionwritelatency100ns_Base = (uint) (managementObject.Properties["Compactionwritelatency100ns_Base"]?.Value ?? default(uint)),
		 ContainerDestagesFromFastTierPersec = (ulong) (managementObject.Properties["ContainerDestagesFromFastTierPersec"]?.Value ?? default(ulong)),
		 ContainerDestagesFromSlowTierPersec = (ulong) (managementObject.Properties["ContainerDestagesFromSlowTierPersec"]?.Value ?? default(ulong)),
		 DataAllocationsFastTierPersec = (ulong) (managementObject.Properties["DataAllocationsFastTierPersec"]?.Value ?? default(ulong)),
		 DataAllocationsSlowTierPersec = (ulong) (managementObject.Properties["DataAllocationsSlowTierPersec"]?.Value ?? default(ulong)),
		 DataCompactionsPersec = (ulong) (managementObject.Properties["DataCompactionsPersec"]?.Value ?? default(ulong)),
		 DataInPlaceWritesPersec = (ulong) (managementObject.Properties["DataInPlaceWritesPersec"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Fasttierdatadestagecriteriapercentage = (uint) (managementObject.Properties["Fasttierdatadestagecriteriapercentage"]?.Value ?? default(uint)),
		 FastTierDestagedContainerFillRatioPercent = (ulong) (managementObject.Properties["FastTierDestagedContainerFillRatioPercent"]?.Value ?? default(ulong)),
		 FastTierDestagedContainerFillRatioPercent_Base = (uint) (managementObject.Properties["FastTierDestagedContainerFillRatioPercent_Base"]?.Value ?? default(uint)),
		 Fasttierdestagereadlatency100ns = (ulong) (managementObject.Properties["Fasttierdestagereadlatency100ns"]?.Value ?? default(ulong)),
		 Fasttierdestagereadlatency100ns_Base = (uint) (managementObject.Properties["Fasttierdestagereadlatency100ns_Base"]?.Value ?? default(uint)),
		 Fasttierdestagewritelatency100ns = (ulong) (managementObject.Properties["Fasttierdestagewritelatency100ns"]?.Value ?? default(ulong)),
		 Fasttierdestagewritelatency100ns_Base = (uint) (managementObject.Properties["Fasttierdestagewritelatency100ns_Base"]?.Value ?? default(uint)),
		 Fasttiermetadatadestagecriteriapercentage = (uint) (managementObject.Properties["Fasttiermetadatadestagecriteriapercentage"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Logfillpercentage = (uint) (managementObject.Properties["Logfillpercentage"]?.Value ?? default(uint)),
		 LogwritesPersec = (ulong) (managementObject.Properties["LogwritesPersec"]?.Value ?? default(ulong)),
		 MaxTransactionsOutstanding = (uint) (managementObject.Properties["MaxTransactionsOutstanding"]?.Value ?? default(uint)),
		 MemoryUsed = (ulong) (managementObject.Properties["MemoryUsed"]?.Value ?? default(ulong)),
		 MetadataAllocationsFastTierPersec = (ulong) (managementObject.Properties["MetadataAllocationsFastTierPersec"]?.Value ?? default(ulong)),
		 MetadataAllocationsSlowTierPersec = (ulong) (managementObject.Properties["MetadataAllocationsSlowTierPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Slowtierdatadestagecriteriapercentage = (uint) (managementObject.Properties["Slowtierdatadestagecriteriapercentage"]?.Value ?? default(uint)),
		 SlowTierDestagedContainerFillRatioPercent = (ulong) (managementObject.Properties["SlowTierDestagedContainerFillRatioPercent"]?.Value ?? default(ulong)),
		 SlowTierDestagedContainerFillRatioPercent_Base = (uint) (managementObject.Properties["SlowTierDestagedContainerFillRatioPercent_Base"]?.Value ?? default(uint)),
		 Slowtierdestagereadlatency100ns = (ulong) (managementObject.Properties["Slowtierdestagereadlatency100ns"]?.Value ?? default(ulong)),
		 Slowtierdestagereadlatency100ns_Base = (uint) (managementObject.Properties["Slowtierdestagereadlatency100ns_Base"]?.Value ?? default(uint)),
		 Slowtierdestagewritelatency100ns = (ulong) (managementObject.Properties["Slowtierdestagewritelatency100ns"]?.Value ?? default(ulong)),
		 Slowtierdestagewritelatency100ns_Base = (uint) (managementObject.Properties["Slowtierdestagewritelatency100ns_Base"]?.Value ?? default(uint)),
		 Slowtiermetadatadestagecriteriapercentage = (uint) (managementObject.Properties["Slowtiermetadatadestagecriteriapercentage"]?.Value ?? default(uint)),
		 SpeculativeBytesReadtoCachePersec = (ulong) (managementObject.Properties["SpeculativeBytesReadtoCachePersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalAllocationsPersec = (ulong) (managementObject.Properties["TotalAllocationsPersec"]?.Value ?? default(ulong)),
		 TransactionsOutstanding = (uint) (managementObject.Properties["TransactionsOutstanding"]?.Value ?? default(uint)),
		 Treeupdatelatency100ns = (ulong) (managementObject.Properties["Treeupdatelatency100ns"]?.Value ?? default(ulong)),
		 Treeupdatelatency100ns_Base = (uint) (managementObject.Properties["Treeupdatelatency100ns_Base"]?.Value ?? default(uint)),
		 TreeupdatesPersec = (ulong) (managementObject.Properties["TreeupdatesPersec"]?.Value ?? default(ulong)),
		 Trimlatency100ns = (ulong) (managementObject.Properties["Trimlatency100ns"]?.Value ?? default(ulong)),
		 Trimlatency100ns_Base = (uint) (managementObject.Properties["Trimlatency100ns_Base"]?.Value ?? default(uint))
                };
        }
    }
}