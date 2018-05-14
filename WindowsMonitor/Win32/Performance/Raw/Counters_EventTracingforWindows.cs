using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_EventTracingforWindows
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint TotalMemoryUsageNonPagedPool { get; private set; }
		public uint TotalMemoryUsagePagedPool { get; private set; }
		public uint TotalNumberofActiveSessions { get; private set; }
		public uint TotalNumberofDistinctDisabledProviders { get; private set; }
		public uint TotalNumberofDistinctEnabledProviders { get; private set; }
		public uint TotalNumberofDistinctPreEnabledProviders { get; private set; }

        public static IEnumerable<Counters_EventTracingforWindows> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_EventTracingforWindows> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_EventTracingforWindows> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_EventTracingforWindows");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_EventTracingforWindows
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalMemoryUsageNonPagedPool = (uint) (managementObject.Properties["TotalMemoryUsageNonPagedPool"]?.Value ?? default(uint)),
		 TotalMemoryUsagePagedPool = (uint) (managementObject.Properties["TotalMemoryUsagePagedPool"]?.Value ?? default(uint)),
		 TotalNumberofActiveSessions = (uint) (managementObject.Properties["TotalNumberofActiveSessions"]?.Value ?? default(uint)),
		 TotalNumberofDistinctDisabledProviders = (uint) (managementObject.Properties["TotalNumberofDistinctDisabledProviders"]?.Value ?? default(uint)),
		 TotalNumberofDistinctEnabledProviders = (uint) (managementObject.Properties["TotalNumberofDistinctEnabledProviders"]?.Value ?? default(uint)),
		 TotalNumberofDistinctPreEnabledProviders = (uint) (managementObject.Properties["TotalNumberofDistinctPreEnabledProviders"]?.Value ?? default(uint))
                };
        }
    }
}