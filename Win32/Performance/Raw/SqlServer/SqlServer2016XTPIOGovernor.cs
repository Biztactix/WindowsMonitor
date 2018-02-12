using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class SqlServer2016XTPIOGovernor
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint InsufficientCreditsWaitsPersec { get; private set; }
		public uint IoIssuedPersec { get; private set; }
		public uint LogBlocksPersec { get; private set; }
		public ulong MissedCreditSlots { get; private set; }
		public string Name { get; private set; }
		public uint StaleRateObjectWaitsPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong TotalRateObjectsPublished { get; private set; }

        public static IEnumerable<SqlServer2016XTPIOGovernor> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlServer2016XTPIOGovernor> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlServer2016XTPIOGovernor> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPIOGovernor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlServer2016XTPIOGovernor
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 InsufficientCreditsWaitsPersec = (uint) (managementObject.Properties["InsufficientCreditsWaitsPersec"]?.Value ?? default(uint)),
		 IoIssuedPersec = (uint) (managementObject.Properties["IoIssuedPersec"]?.Value ?? default(uint)),
		 LogBlocksPersec = (uint) (managementObject.Properties["LogBlocksPersec"]?.Value ?? default(uint)),
		 MissedCreditSlots = (ulong) (managementObject.Properties["MissedCreditSlots"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 StaleRateObjectWaitsPersec = (uint) (managementObject.Properties["StaleRateObjectWaitsPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalRateObjectsPublished = (ulong) (managementObject.Properties["TotalRateObjectsPublished"]?.Value ?? default(ulong))
                };
        }
    }
}