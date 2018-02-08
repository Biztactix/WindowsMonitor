using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSPlanCache
    {
        public ulong CacheHitRatio { get; private set; }
        public ulong CacheHitRatio_Base { get; private set; }
        public ulong CacheObjectCounts { get; private set; }
        public ulong CacheObjectsinuse { get; private set; }
        public ulong CachePages { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSPlanCache[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSPlanCache[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSPlanCache[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSPlanCache");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSPlanCache>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSPlanCache
                {
                    CacheHitRatio = (ulong) managementObject.Properties["CacheHitRatio"].Value,
                    CacheHitRatio_Base = (ulong) managementObject.Properties["CacheHitRatio_Base"].Value,
                    CacheObjectCounts = (ulong) managementObject.Properties["CacheObjectCounts"].Value,
                    CacheObjectsinuse = (ulong) managementObject.Properties["CacheObjectsinuse"].Value,
                    CachePages = (ulong) managementObject.Properties["CachePages"].Value,
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