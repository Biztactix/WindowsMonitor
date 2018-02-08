using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics
    {
        public ulong AvgLengthofBatchedWrites { get; private set; }
        public ulong AvgTimeBetweenBatchesms { get; private set; }
        public ulong AvgTimetoWriteBatchms { get; private set; }
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

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics[] Retrieve(string remote,
            string username, string password)
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

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics
                {
                    AvgLengthofBatchedWrites = (ulong) managementObject.Properties["AvgLengthofBatchedWrites"].Value,
                    AvgTimeBetweenBatchesms = (ulong) managementObject.Properties["AvgTimeBetweenBatchesms"].Value,
                    AvgTimetoWriteBatchms = (ulong) managementObject.Properties["AvgTimetoWriteBatchms"].Value,
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