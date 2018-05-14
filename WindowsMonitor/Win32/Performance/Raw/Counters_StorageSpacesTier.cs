using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_StorageSpacesTier
    {
		public ulong AvgTierBytesPerRead { get; private set; }
		public uint AvgTierBytesPerRead_Base { get; private set; }
		public ulong AvgTierBytesPerTransfer { get; private set; }
		public uint AvgTierBytesPerTransfer_Base { get; private set; }
		public ulong AvgTierBytesPerWrite { get; private set; }
		public uint AvgTierBytesPerWrite_Base { get; private set; }
		public ulong AvgTierQueueLength { get; private set; }
		public ulong AvgTierReadQueueLength { get; private set; }
		public uint AvgTiersecPerRead { get; private set; }
		public uint AvgTiersecPerRead_Base { get; private set; }
		public uint AvgTiersecPerTransfer { get; private set; }
		public uint AvgTiersecPerTransfer_Base { get; private set; }
		public uint AvgTiersecPerWrite { get; private set; }
		public uint AvgTiersecPerWrite_Base { get; private set; }
		public ulong AvgTierWriteQueueLength { get; private set; }
		public string Caption { get; private set; }
		public uint CurrentTierQueueLength { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong TierReadBytesPersec { get; private set; }
		public ulong TierReadsPersec { get; private set; }
		public ulong TierTransferBytesPersec { get; private set; }
		public ulong TierTransfersPersec { get; private set; }
		public ulong TierWriteBytesPersec { get; private set; }
		public ulong TierWritesPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_StorageSpacesTier> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_StorageSpacesTier> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_StorageSpacesTier> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_StorageSpacesTier");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_StorageSpacesTier
                {
                     AvgTierBytesPerRead = (ulong) (managementObject.Properties["AvgTierBytesPerRead"]?.Value ?? default(ulong)),
		 AvgTierBytesPerRead_Base = (uint) (managementObject.Properties["AvgTierBytesPerRead_Base"]?.Value ?? default(uint)),
		 AvgTierBytesPerTransfer = (ulong) (managementObject.Properties["AvgTierBytesPerTransfer"]?.Value ?? default(ulong)),
		 AvgTierBytesPerTransfer_Base = (uint) (managementObject.Properties["AvgTierBytesPerTransfer_Base"]?.Value ?? default(uint)),
		 AvgTierBytesPerWrite = (ulong) (managementObject.Properties["AvgTierBytesPerWrite"]?.Value ?? default(ulong)),
		 AvgTierBytesPerWrite_Base = (uint) (managementObject.Properties["AvgTierBytesPerWrite_Base"]?.Value ?? default(uint)),
		 AvgTierQueueLength = (ulong) (managementObject.Properties["AvgTierQueueLength"]?.Value ?? default(ulong)),
		 AvgTierReadQueueLength = (ulong) (managementObject.Properties["AvgTierReadQueueLength"]?.Value ?? default(ulong)),
		 AvgTiersecPerRead = (uint) (managementObject.Properties["AvgTiersecPerRead"]?.Value ?? default(uint)),
		 AvgTiersecPerRead_Base = (uint) (managementObject.Properties["AvgTiersecPerRead_Base"]?.Value ?? default(uint)),
		 AvgTiersecPerTransfer = (uint) (managementObject.Properties["AvgTiersecPerTransfer"]?.Value ?? default(uint)),
		 AvgTiersecPerTransfer_Base = (uint) (managementObject.Properties["AvgTiersecPerTransfer_Base"]?.Value ?? default(uint)),
		 AvgTiersecPerWrite = (uint) (managementObject.Properties["AvgTiersecPerWrite"]?.Value ?? default(uint)),
		 AvgTiersecPerWrite_Base = (uint) (managementObject.Properties["AvgTiersecPerWrite_Base"]?.Value ?? default(uint)),
		 AvgTierWriteQueueLength = (ulong) (managementObject.Properties["AvgTierWriteQueueLength"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CurrentTierQueueLength = (uint) (managementObject.Properties["CurrentTierQueueLength"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 TierReadBytesPersec = (ulong) (managementObject.Properties["TierReadBytesPersec"]?.Value ?? default(ulong)),
		 TierReadsPersec = (ulong) (managementObject.Properties["TierReadsPersec"]?.Value ?? default(ulong)),
		 TierTransferBytesPersec = (ulong) (managementObject.Properties["TierTransferBytesPersec"]?.Value ?? default(ulong)),
		 TierTransfersPersec = (ulong) (managementObject.Properties["TierTransfersPersec"]?.Value ?? default(ulong)),
		 TierWriteBytesPersec = (ulong) (managementObject.Properties["TierWriteBytesPersec"]?.Value ?? default(ulong)),
		 TierWritesPersec = (ulong) (managementObject.Properties["TierWritesPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}