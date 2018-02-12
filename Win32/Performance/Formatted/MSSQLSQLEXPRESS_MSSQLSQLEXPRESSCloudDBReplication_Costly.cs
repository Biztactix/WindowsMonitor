using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCloudDBReplication_Costly
    {
		public ulong Activelogcatchupscans { get; private set; }
		public ulong Activepartitioncopyscans { get; private set; }
		public ulong Activepartitiondeletescans { get; private set; }
		public string Caption { get; private set; }
		public ulong Combinedqueuessizebytes { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong Pendingpartitioncopyscans { get; private set; }
		public ulong Pendingpartitiondeletescans { get; private set; }
		public ulong Primarycommittedtransrate { get; private set; }
		public ulong Secondarycommittedtransrate { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCloudDBReplication_Costly> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCloudDBReplication_Costly> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCloudDBReplication_Costly> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCloudDBReplication_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSQLEXPRESS_MSSQLSQLEXPRESSCloudDBReplication_Costly
                {
                     Activelogcatchupscans = (ulong) (managementObject.Properties["Activelogcatchupscans"]?.Value ?? default(ulong)),
		 Activepartitioncopyscans = (ulong) (managementObject.Properties["Activepartitioncopyscans"]?.Value ?? default(ulong)),
		 Activepartitiondeletescans = (ulong) (managementObject.Properties["Activepartitiondeletescans"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Combinedqueuessizebytes = (ulong) (managementObject.Properties["Combinedqueuessizebytes"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Pendingpartitioncopyscans = (ulong) (managementObject.Properties["Pendingpartitioncopyscans"]?.Value ?? default(ulong)),
		 Pendingpartitiondeletescans = (ulong) (managementObject.Properties["Pendingpartitiondeletescans"]?.Value ?? default(ulong)),
		 Primarycommittedtransrate = (ulong) (managementObject.Properties["Primarycommittedtransrate"]?.Value ?? default(ulong)),
		 Secondarycommittedtransrate = (ulong) (managementObject.Properties["Secondarycommittedtransrate"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}