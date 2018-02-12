using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerTOStatistics
                {
                     AvgLengthofBatchedWrites = (ulong) (managementObject.Properties["AvgLengthofBatchedWrites"]?.Value ?? default(ulong)),
		 AvgTimeBetweenBatchesms = (ulong) (managementObject.Properties["AvgTimeBetweenBatchesms"]?.Value ?? default(ulong)),
		 AvgTimetoWriteBatchms = (ulong) (managementObject.Properties["AvgTimetoWriteBatchms"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
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