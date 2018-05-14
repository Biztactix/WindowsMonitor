using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class SqlServerBrokerTOStatistics
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

        public static IEnumerable<SqlServerBrokerTOStatistics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlServerBrokerTOStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlServerBrokerTOStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerBrokerTOStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlServerBrokerTOStatistics
                {
                     AvgLengthofBatchedWrites = (ulong) (managementObject.Properties["AvgLengthofBatchedWrites"]?.Value ?? default(ulong)),
		 AvgLengthofBatchedWrites_Base = (uint) (managementObject.Properties["AvgLengthofBatchedWrites_Base"]?.Value ?? default(uint)),
		 AvgTimeBetweenBatchesms = (ulong) (managementObject.Properties["AvgTimeBetweenBatchesms"]?.Value ?? default(ulong)),
		 AvgTimeBetweenBatchesms_Base = (uint) (managementObject.Properties["AvgTimeBetweenBatchesms_Base"]?.Value ?? default(uint)),
		 AvgTimetoWriteBatchms = (ulong) (managementObject.Properties["AvgTimetoWriteBatchms"]?.Value ?? default(ulong)),
		 AvgTimetoWriteBatchms_Base = (uint) (managementObject.Properties["AvgTimetoWriteBatchms_Base"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TransmissionObjGetsPerSec = (ulong) (managementObject.Properties["TransmissionObjGetsPerSec"]?.Value ?? default(ulong)),
		 TransmissionObjSetDirtyPerSec = (ulong) (managementObject.Properties["TransmissionObjSetDirtyPerSec"]?.Value ?? default(ulong)),
		 TransmissionObjWritesPerSec = (ulong) (managementObject.Properties["TransmissionObjWritesPerSec"]?.Value ?? default(ulong))
                };
        }
    }
}