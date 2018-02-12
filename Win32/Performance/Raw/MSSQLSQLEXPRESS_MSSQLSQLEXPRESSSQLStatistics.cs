using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics
    {
		public ulong AutoParamAttemptsPersec { get; private set; }
		public ulong BatchRequestsPersec { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong FailedAutoParamsPersec { get; private set; }
		public ulong ForcedParameterizationsPersec { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong GuidedplanexecutionsPersec { get; private set; }
		public ulong MisguidedplanexecutionsPersec { get; private set; }
		public string Name { get; private set; }
		public ulong SafeAutoParamsPersec { get; private set; }
		public ulong SQLAttentionrate { get; private set; }
		public ulong SQLCompilationsPersec { get; private set; }
		public ulong SQLReCompilationsPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong UnsafeAutoParamsPersec { get; private set; }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics
                {
                     AutoParamAttemptsPersec = (ulong) (managementObject.Properties["AutoParamAttemptsPersec"]?.Value ?? default(ulong)),
		 BatchRequestsPersec = (ulong) (managementObject.Properties["BatchRequestsPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FailedAutoParamsPersec = (ulong) (managementObject.Properties["FailedAutoParamsPersec"]?.Value ?? default(ulong)),
		 ForcedParameterizationsPersec = (ulong) (managementObject.Properties["ForcedParameterizationsPersec"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 GuidedplanexecutionsPersec = (ulong) (managementObject.Properties["GuidedplanexecutionsPersec"]?.Value ?? default(ulong)),
		 MisguidedplanexecutionsPersec = (ulong) (managementObject.Properties["MisguidedplanexecutionsPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 SafeAutoParamsPersec = (ulong) (managementObject.Properties["SafeAutoParamsPersec"]?.Value ?? default(ulong)),
		 SQLAttentionrate = (ulong) (managementObject.Properties["SQLAttentionrate"]?.Value ?? default(ulong)),
		 SQLCompilationsPersec = (ulong) (managementObject.Properties["SQLCompilationsPersec"]?.Value ?? default(ulong)),
		 SQLReCompilationsPersec = (ulong) (managementObject.Properties["SQLReCompilationsPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 UnsafeAutoParamsPersec = (ulong) (managementObject.Properties["UnsafeAutoParamsPersec"]?.Value ?? default(ulong))
                };
        }
    }
}