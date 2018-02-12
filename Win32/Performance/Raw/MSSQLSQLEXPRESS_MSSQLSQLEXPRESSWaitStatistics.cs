using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong Lockwaits { get; private set; }
		public ulong Logbufferwaits { get; private set; }
		public ulong Logwritewaits { get; private set; }
		public ulong Memorygrantqueuewaits { get; private set; }
		public string Name { get; private set; }
		public ulong NetworkIOwaits { get; private set; }
		public ulong NonPagelatchwaits { get; private set; }
		public ulong PageIOlatchwaits { get; private set; }
		public ulong Pagelatchwaits { get; private set; }
		public ulong Threadsafememoryobjectswaits { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong Transactionownershipwaits { get; private set; }
		public ulong Waitfortheworker { get; private set; }
		public ulong Workspacesynchronizationwaits { get; private set; }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Lockwaits = (ulong) (managementObject.Properties["Lockwaits"]?.Value ?? default(ulong)),
		 Logbufferwaits = (ulong) (managementObject.Properties["Logbufferwaits"]?.Value ?? default(ulong)),
		 Logwritewaits = (ulong) (managementObject.Properties["Logwritewaits"]?.Value ?? default(ulong)),
		 Memorygrantqueuewaits = (ulong) (managementObject.Properties["Memorygrantqueuewaits"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NetworkIOwaits = (ulong) (managementObject.Properties["NetworkIOwaits"]?.Value ?? default(ulong)),
		 NonPagelatchwaits = (ulong) (managementObject.Properties["NonPagelatchwaits"]?.Value ?? default(ulong)),
		 PageIOlatchwaits = (ulong) (managementObject.Properties["PageIOlatchwaits"]?.Value ?? default(ulong)),
		 Pagelatchwaits = (ulong) (managementObject.Properties["Pagelatchwaits"]?.Value ?? default(ulong)),
		 Threadsafememoryobjectswaits = (ulong) (managementObject.Properties["Threadsafememoryobjectswaits"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 Transactionownershipwaits = (ulong) (managementObject.Properties["Transactionownershipwaits"]?.Value ?? default(ulong)),
		 Waitfortheworker = (ulong) (managementObject.Properties["Waitfortheworker"]?.Value ?? default(ulong)),
		 Workspacesynchronizationwaits = (ulong) (managementObject.Properties["Workspacesynchronizationwaits"]?.Value ?? default(ulong))
                };
        }
    }
}