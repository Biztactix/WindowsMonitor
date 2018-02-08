using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics
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

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics[] Retrieve(string remote,
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

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBatchRespStatistics
                {
                    Batches000000msAnd000001ms =
                        (ulong) managementObject.Properties["Batches000000msAnd000001ms"].Value,
                    Batches000001msAnd000002ms =
                        (ulong) managementObject.Properties["Batches000001msAnd000002ms"].Value,
                    Batches000002msAnd000005ms =
                        (ulong) managementObject.Properties["Batches000002msAnd000005ms"].Value,
                    Batches000005msAnd000010ms =
                        (ulong) managementObject.Properties["Batches000005msAnd000010ms"].Value,
                    Batches000010msAnd000020ms =
                        (ulong) managementObject.Properties["Batches000010msAnd000020ms"].Value,
                    Batches000020msAnd000050ms =
                        (ulong) managementObject.Properties["Batches000020msAnd000050ms"].Value,
                    Batches000050msAnd000100ms =
                        (ulong) managementObject.Properties["Batches000050msAnd000100ms"].Value,
                    Batches000100msAnd000200ms =
                        (ulong) managementObject.Properties["Batches000100msAnd000200ms"].Value,
                    Batches000200msAnd000500ms =
                        (ulong) managementObject.Properties["Batches000200msAnd000500ms"].Value,
                    Batches000500msAnd001000ms =
                        (ulong) managementObject.Properties["Batches000500msAnd001000ms"].Value,
                    Batches001000msAnd002000ms =
                        (ulong) managementObject.Properties["Batches001000msAnd002000ms"].Value,
                    Batches002000msAnd005000ms =
                        (ulong) managementObject.Properties["Batches002000msAnd005000ms"].Value,
                    Batches005000msAnd010000ms =
                        (ulong) managementObject.Properties["Batches005000msAnd010000ms"].Value,
                    Batches010000msAnd020000ms =
                        (ulong) managementObject.Properties["Batches010000msAnd020000ms"].Value,
                    Batches020000msAnd050000ms =
                        (ulong) managementObject.Properties["Batches020000msAnd050000ms"].Value,
                    Batches050000msAnd100000ms =
                        (ulong) managementObject.Properties["Batches050000msAnd100000ms"].Value,
                    Batches100000ms = (ulong) managementObject.Properties["Batches100000ms"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}