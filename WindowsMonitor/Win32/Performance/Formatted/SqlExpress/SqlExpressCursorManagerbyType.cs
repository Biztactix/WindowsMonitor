using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class SqlExpressCursorManagerbyType
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

        public static IEnumerable<SqlExpressCursorManagerbyType> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlExpressCursorManagerbyType> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlExpressCursorManagerbyType> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCursorManagerbyType");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlExpressCursorManagerbyType
                {
                     Activecursors = (ulong) (managementObject.Properties["Activecursors"]?.Value ?? default(ulong)),
		 CachedCursorCounts = (ulong) (managementObject.Properties["CachedCursorCounts"]?.Value ?? default(ulong)),
		 CacheHitRatio = (ulong) (managementObject.Properties["CacheHitRatio"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CursorCacheUseCountsPersec = (ulong) (managementObject.Properties["CursorCacheUseCountsPersec"]?.Value ?? default(ulong)),
		 Cursormemoryusage = (ulong) (managementObject.Properties["Cursormemoryusage"]?.Value ?? default(ulong)),
		 CursorRequestsPersec = (ulong) (managementObject.Properties["CursorRequestsPersec"]?.Value ?? default(ulong)),
		 Cursorworktableusage = (ulong) (managementObject.Properties["Cursorworktableusage"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Numberofactivecursorplans = (ulong) (managementObject.Properties["Numberofactivecursorplans"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}