using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class SqlServerLatches
    {
		public ulong AverageLatchWaitTimems { get; private set; }
		public uint AverageLatchWaitTimems_Base { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong LatchWaitsPersec { get; private set; }
		public string Name { get; private set; }
		public ulong NumberofSuperLatches { get; private set; }
		public ulong SuperLatchDemotionsPersec { get; private set; }
		public ulong SuperLatchPromotionsPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong TotalLatchWaitTimems { get; private set; }

        public static IEnumerable<SqlServerLatches> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlServerLatches> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlServerLatches> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerLatches");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlServerLatches
                {
                     AverageLatchWaitTimems = (ulong) (managementObject.Properties["AverageLatchWaitTimems"]?.Value ?? default(ulong)),
		 AverageLatchWaitTimems_Base = (uint) (managementObject.Properties["AverageLatchWaitTimems_Base"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 LatchWaitsPersec = (ulong) (managementObject.Properties["LatchWaitsPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberofSuperLatches = (ulong) (managementObject.Properties["NumberofSuperLatches"]?.Value ?? default(ulong)),
		 SuperLatchDemotionsPersec = (ulong) (managementObject.Properties["SuperLatchDemotionsPersec"]?.Value ?? default(ulong)),
		 SuperLatchPromotionsPersec = (ulong) (managementObject.Properties["SuperLatchPromotionsPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalLatchWaitTimems = (ulong) (managementObject.Properties["TotalLatchWaitTimems"]?.Value ?? default(ulong))
                };
        }
    }
}