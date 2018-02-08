using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_SMBClientShares
    {
        public ulong AvgBytesPerRead { get; private set; }
        public uint AvgBytesPerRead_Base { get; private set; }
        public ulong AvgBytesPerWrite { get; private set; }
        public uint AvgBytesPerWrite_Base { get; private set; }
        public ulong AvgDataBytesPerRequest { get; private set; }
        public uint AvgDataBytesPerRequest_Base { get; private set; }
        public ulong AvgDataQueueLength { get; private set; }
        public ulong AvgReadQueueLength { get; private set; }
        public uint AvgsecPerDataRequest { get; private set; }
        public uint AvgsecPerDataRequest_Base { get; private set; }
        public uint AvgsecPerRead { get; private set; }
        public uint AvgsecPerRead_Base { get; private set; }
        public uint AvgsecPerWrite { get; private set; }
        public uint AvgsecPerWrite_Base { get; private set; }
        public ulong AvgWriteQueueLength { get; private set; }
        public string Caption { get; private set; }
        public uint CreditStallsPersec { get; private set; }
        public uint CurrentDataQueueLength { get; private set; }
        public ulong DataBytesPersec { get; private set; }
        public uint DataRequestsPersec { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint MetadataRequestsPersec { get; private set; }
        public string Name { get; private set; }
        public ulong ReadBytesPersec { get; private set; }
        public uint ReadRequestsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong WriteBytesPersec { get; private set; }
        public uint WriteRequestsPersec { get; private set; }

        public static PerfRawData_Counters_SMBClientShares[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_SMBClientShares[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_SMBClientShares[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_SMBClientShares");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_SMBClientShares>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_SMBClientShares
                {
                    AvgBytesPerRead = (ulong) managementObject.Properties["AvgBytesPerRead"].Value,
                    AvgBytesPerRead_Base = (uint) managementObject.Properties["AvgBytesPerRead_Base"].Value,
                    AvgBytesPerWrite = (ulong) managementObject.Properties["AvgBytesPerWrite"].Value,
                    AvgBytesPerWrite_Base = (uint) managementObject.Properties["AvgBytesPerWrite_Base"].Value,
                    AvgDataBytesPerRequest = (ulong) managementObject.Properties["AvgDataBytesPerRequest"].Value,
                    AvgDataBytesPerRequest_Base = (uint) managementObject.Properties["AvgDataBytesPerRequest_Base"]
                        .Value,
                    AvgDataQueueLength = (ulong) managementObject.Properties["AvgDataQueueLength"].Value,
                    AvgReadQueueLength = (ulong) managementObject.Properties["AvgReadQueueLength"].Value,
                    AvgsecPerDataRequest = (uint) managementObject.Properties["AvgsecPerDataRequest"].Value,
                    AvgsecPerDataRequest_Base = (uint) managementObject.Properties["AvgsecPerDataRequest_Base"].Value,
                    AvgsecPerRead = (uint) managementObject.Properties["AvgsecPerRead"].Value,
                    AvgsecPerRead_Base = (uint) managementObject.Properties["AvgsecPerRead_Base"].Value,
                    AvgsecPerWrite = (uint) managementObject.Properties["AvgsecPerWrite"].Value,
                    AvgsecPerWrite_Base = (uint) managementObject.Properties["AvgsecPerWrite_Base"].Value,
                    AvgWriteQueueLength = (ulong) managementObject.Properties["AvgWriteQueueLength"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CreditStallsPersec = (uint) managementObject.Properties["CreditStallsPersec"].Value,
                    CurrentDataQueueLength = (uint) managementObject.Properties["CurrentDataQueueLength"].Value,
                    DataBytesPersec = (ulong) managementObject.Properties["DataBytesPersec"].Value,
                    DataRequestsPersec = (uint) managementObject.Properties["DataRequestsPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MetadataRequestsPersec = (uint) managementObject.Properties["MetadataRequestsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ReadBytesPersec = (ulong) managementObject.Properties["ReadBytesPersec"].Value,
                    ReadRequestsPersec = (uint) managementObject.Properties["ReadRequestsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    WriteBytesPersec = (ulong) managementObject.Properties["WriteBytesPersec"].Value,
                    WriteRequestsPersec = (uint) managementObject.Properties["WriteRequestsPersec"].Value
                });

            return list.ToArray();
        }
    }
}