using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics
    {
		public ulong Batches000000msAnd000001ms { get; private set; }
		public ulong Batches000001msAnd000002ms { get; private set; }
		public ulong Batches000002msAnd000005ms { get; private set; }
		public ulong Batches000005msAnd000010ms { get; private set; }
		public ulong Batches000010msAnd000020ms { get; private set; }
		public ulong Batches000020msAnd000050ms { get; private set; }
		public ulong Batches000050msAnd000100ms { get; private set; }
		public ulong Batches000100msAnd000200ms { get; private set; }
		public ulong Batches000200msAnd000500ms { get; private set; }
		public ulong Batches000500msAnd001000ms { get; private set; }
		public ulong Batches001000msAnd002000ms { get; private set; }
		public ulong Batches002000msAnd005000ms { get; private set; }
		public ulong Batches005000msAnd010000ms { get; private set; }
		public ulong Batches010000msAnd020000ms { get; private set; }
		public ulong Batches020000msAnd050000ms { get; private set; }
		public ulong Batches050000msAnd100000ms { get; private set; }
		public ulong Batches100000ms { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics
                {
                     Batches000000msAnd000001ms = (ulong) (managementObject.Properties["Batches000000msAnd000001ms"]?.Value ?? default(ulong)),
		 Batches000001msAnd000002ms = (ulong) (managementObject.Properties["Batches000001msAnd000002ms"]?.Value ?? default(ulong)),
		 Batches000002msAnd000005ms = (ulong) (managementObject.Properties["Batches000002msAnd000005ms"]?.Value ?? default(ulong)),
		 Batches000005msAnd000010ms = (ulong) (managementObject.Properties["Batches000005msAnd000010ms"]?.Value ?? default(ulong)),
		 Batches000010msAnd000020ms = (ulong) (managementObject.Properties["Batches000010msAnd000020ms"]?.Value ?? default(ulong)),
		 Batches000020msAnd000050ms = (ulong) (managementObject.Properties["Batches000020msAnd000050ms"]?.Value ?? default(ulong)),
		 Batches000050msAnd000100ms = (ulong) (managementObject.Properties["Batches000050msAnd000100ms"]?.Value ?? default(ulong)),
		 Batches000100msAnd000200ms = (ulong) (managementObject.Properties["Batches000100msAnd000200ms"]?.Value ?? default(ulong)),
		 Batches000200msAnd000500ms = (ulong) (managementObject.Properties["Batches000200msAnd000500ms"]?.Value ?? default(ulong)),
		 Batches000500msAnd001000ms = (ulong) (managementObject.Properties["Batches000500msAnd001000ms"]?.Value ?? default(ulong)),
		 Batches001000msAnd002000ms = (ulong) (managementObject.Properties["Batches001000msAnd002000ms"]?.Value ?? default(ulong)),
		 Batches002000msAnd005000ms = (ulong) (managementObject.Properties["Batches002000msAnd005000ms"]?.Value ?? default(ulong)),
		 Batches005000msAnd010000ms = (ulong) (managementObject.Properties["Batches005000msAnd010000ms"]?.Value ?? default(ulong)),
		 Batches010000msAnd020000ms = (ulong) (managementObject.Properties["Batches010000msAnd020000ms"]?.Value ?? default(ulong)),
		 Batches020000msAnd050000ms = (ulong) (managementObject.Properties["Batches020000msAnd050000ms"]?.Value ?? default(ulong)),
		 Batches050000msAnd100000ms = (ulong) (managementObject.Properties["Batches050000msAnd100000ms"]?.Value ?? default(ulong)),
		 Batches100000ms = (ulong) (managementObject.Properties["Batches100000ms"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}