using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCursorManagerbyType
    {
        public ulong Activecursors { get; private set; }
        public ulong CachedCursorCounts { get; private set; }
        public ulong CacheHitRatio { get; private set; }
        public string Caption { get; private set; }
        public ulong CursorCacheUseCountsPersec { get; private set; }
        public ulong Cursormemoryusage { get; private set; }
        public ulong CursorRequestsPersec { get; private set; }
        public ulong Cursorworktableusage { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Numberofactivecursorplans { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCursorManagerbyType[] Retrieve(string remote,
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

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCursorManagerbyType[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCursorManagerbyType[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCursorManagerbyType");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCursorManagerbyType>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCursorManagerbyType
                {
                    Activecursors = (ulong) managementObject.Properties["Activecursors"].Value,
                    CachedCursorCounts = (ulong) managementObject.Properties["CachedCursorCounts"].Value,
                    CacheHitRatio = (ulong) managementObject.Properties["CacheHitRatio"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CursorCacheUseCountsPersec =
                        (ulong) managementObject.Properties["CursorCacheUseCountsPersec"].Value,
                    Cursormemoryusage = (ulong) managementObject.Properties["Cursormemoryusage"].Value,
                    CursorRequestsPersec = (ulong) managementObject.Properties["CursorRequestsPersec"].Value,
                    Cursorworktableusage = (ulong) managementObject.Properties["Cursorworktableusage"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Numberofactivecursorplans = (ulong) managementObject.Properties["Numberofactivecursorplans"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}