using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSERVER_SQLServerBrokerTOStatistics
    {
        public ulong AvgLengthofBatchedWrites { get; private set; }
        public uint AvgLengthofBatchedWrites_Base { get; private set; }
        public ulong AvgTimeBetweenBatchesms { get; private set; }
        public uint AvgTimeBetweenBatchesms_Base { get; private set; }
        public ulong AvgTimetoWriteBatchms { get; private set; }
        public uint AvgTimetoWriteBatchms_Base { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TransmissionObjGetsPerSec { get; private set; }
        public ulong TransmissionObjSetDirtyPerSec { get; private set; }
        public ulong TransmissionObjWritesPerSec { get; private set; }

        public static PerfRawData_MSSQLSERVER_SQLServerBrokerTOStatistics[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSSQLSERVER_SQLServerBrokerTOStatistics[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSERVER_SQLServerBrokerTOStatistics[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerBrokerTOStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSERVER_SQLServerBrokerTOStatistics>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSERVER_SQLServerBrokerTOStatistics
                {
                    AvgLengthofBatchedWrites = (ulong) managementObject.Properties["AvgLengthofBatchedWrites"].Value,
                    AvgLengthofBatchedWrites_Base = (uint) managementObject.Properties["AvgLengthofBatchedWrites_Base"]
                        .Value,
                    AvgTimeBetweenBatchesms = (ulong) managementObject.Properties["AvgTimeBetweenBatchesms"].Value,
                    AvgTimeBetweenBatchesms_Base = (uint) managementObject.Properties["AvgTimeBetweenBatchesms_Base"]
                        .Value,
                    AvgTimetoWriteBatchms = (ulong) managementObject.Properties["AvgTimetoWriteBatchms"].Value,
                    AvgTimetoWriteBatchms_Base = (uint) managementObject.Properties["AvgTimetoWriteBatchms_Base"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TransmissionObjGetsPerSec = (ulong) managementObject.Properties["TransmissionObjGetsPerSec"].Value,
                    TransmissionObjSetDirtyPerSec =
                        (ulong) managementObject.Properties["TransmissionObjSetDirtyPerSec"].Value,
                    TransmissionObjWritesPerSec = (ulong) managementObject.Properties["TransmissionObjWritesPerSec"]
                        .Value
                });

            return list.ToArray();
        }
    }
}