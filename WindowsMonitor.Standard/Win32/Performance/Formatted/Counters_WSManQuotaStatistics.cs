using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_WSManQuotaStatistics
    {
		public uint ActiveOperations { get; private set; }
		public uint ActiveShells { get; private set; }
		public uint ActiveUsers { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint ProcessID { get; private set; }
		public uint SystemQuotaViolationsPerSecond { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint TotalRequestsPerSecond { get; private set; }
		public uint UserQuotaViolationsPerSecond { get; private set; }

        public static IEnumerable<Counters_WSManQuotaStatistics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_WSManQuotaStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_WSManQuotaStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_WSManQuotaStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_WSManQuotaStatistics
                {
                     ActiveOperations = (uint) (managementObject.Properties["ActiveOperations"]?.Value ?? default(uint)),
		 ActiveShells = (uint) (managementObject.Properties["ActiveShells"]?.Value ?? default(uint)),
		 ActiveUsers = (uint) (managementObject.Properties["ActiveUsers"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ProcessID = (uint) (managementObject.Properties["ProcessID"]?.Value ?? default(uint)),
		 SystemQuotaViolationsPerSecond = (uint) (managementObject.Properties["SystemQuotaViolationsPerSecond"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalRequestsPerSecond = (uint) (managementObject.Properties["TotalRequestsPerSecond"]?.Value ?? default(uint)),
		 UserQuotaViolationsPerSecond = (uint) (managementObject.Properties["UserQuotaViolationsPerSecond"]?.Value ?? default(uint))
                };
        }
    }
}