using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_StorageSpacesTier
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

        public static PerfRawData_Counters_StorageSpacesTier[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_StorageSpacesTier[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_StorageSpacesTier[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_StorageSpacesTier");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_StorageSpacesTier>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_StorageSpacesTier
                {
                    AvgTierBytesPerRead = (ulong) managementObject.Properties["AvgTierBytesPerRead"].Value,
                    AvgTierBytesPerRead_Base = (uint) managementObject.Properties["AvgTierBytesPerRead_Base"].Value,
                    AvgTierBytesPerTransfer = (ulong) managementObject.Properties["AvgTierBytesPerTransfer"].Value,
                    AvgTierBytesPerTransfer_Base = (uint) managementObject.Properties["AvgTierBytesPerTransfer_Base"]
                        .Value,
                    AvgTierBytesPerWrite = (ulong) managementObject.Properties["AvgTierBytesPerWrite"].Value,
                    AvgTierBytesPerWrite_Base = (uint) managementObject.Properties["AvgTierBytesPerWrite_Base"].Value,
                    AvgTierQueueLength = (ulong) managementObject.Properties["AvgTierQueueLength"].Value,
                    AvgTierReadQueueLength = (ulong) managementObject.Properties["AvgTierReadQueueLength"].Value,
                    AvgTiersecPerRead = (uint) managementObject.Properties["AvgTiersecPerRead"].Value,
                    AvgTiersecPerRead_Base = (uint) managementObject.Properties["AvgTiersecPerRead_Base"].Value,
                    AvgTiersecPerTransfer = (uint) managementObject.Properties["AvgTiersecPerTransfer"].Value,
                    AvgTiersecPerTransfer_Base = (uint) managementObject.Properties["AvgTiersecPerTransfer_Base"].Value,
                    AvgTiersecPerWrite = (uint) managementObject.Properties["AvgTiersecPerWrite"].Value,
                    AvgTiersecPerWrite_Base = (uint) managementObject.Properties["AvgTiersecPerWrite_Base"].Value,
                    AvgTierWriteQueueLength = (ulong) managementObject.Properties["AvgTierWriteQueueLength"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentTierQueueLength = (uint) managementObject.Properties["CurrentTierQueueLength"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    TierReadBytesPersec = (ulong) managementObject.Properties["TierReadBytesPersec"].Value,
                    TierReadsPersec = (ulong) managementObject.Properties["TierReadsPersec"].Value,
                    TierTransferBytesPersec = (ulong) managementObject.Properties["TierTransferBytesPersec"].Value,
                    TierTransfersPersec = (ulong) managementObject.Properties["TierTransfersPersec"].Value,
                    TierWriteBytesPersec = (ulong) managementObject.Properties["TierWriteBytesPersec"].Value,
                    TierWritesPersec = (ulong) managementObject.Properties["TierWritesPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}