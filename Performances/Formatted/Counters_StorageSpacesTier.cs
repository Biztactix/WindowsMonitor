using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_StorageSpacesTier
    {
        public ulong AvgTierBytesPerRead { get; private set; }
        public ulong AvgTierBytesPerTransfer { get; private set; }
        public ulong AvgTierBytesPerWrite { get; private set; }
        public ulong AvgTierQueueLength { get; private set; }
        public ulong AvgTierReadQueueLength { get; private set; }
        public uint AvgTiersecPerRead { get; private set; }
        public uint AvgTiersecPerTransfer { get; private set; }
        public uint AvgTiersecPerWrite { get; private set; }
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

        public static PerfFormattedData_Counters_StorageSpacesTier[] Retrieve(string remote, string username,
            string password)
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

        public static PerfFormattedData_Counters_StorageSpacesTier[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_StorageSpacesTier[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_StorageSpacesTier");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_StorageSpacesTier>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_StorageSpacesTier
                {
                    AvgTierBytesPerRead = (ulong) managementObject.Properties["AvgTierBytesPerRead"].Value,
                    AvgTierBytesPerTransfer = (ulong) managementObject.Properties["AvgTierBytesPerTransfer"].Value,
                    AvgTierBytesPerWrite = (ulong) managementObject.Properties["AvgTierBytesPerWrite"].Value,
                    AvgTierQueueLength = (ulong) managementObject.Properties["AvgTierQueueLength"].Value,
                    AvgTierReadQueueLength = (ulong) managementObject.Properties["AvgTierReadQueueLength"].Value,
                    AvgTiersecPerRead = (uint) managementObject.Properties["AvgTiersecPerRead"].Value,
                    AvgTiersecPerTransfer = (uint) managementObject.Properties["AvgTiersecPerTransfer"].Value,
                    AvgTiersecPerWrite = (uint) managementObject.Properties["AvgTiersecPerWrite"].Value,
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