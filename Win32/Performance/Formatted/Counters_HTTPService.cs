using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_HTTPService
    {
		public string Caption { get; private set; }
		public uint CurrentUrisCached { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint TotalFlushedUris { get; private set; }
		public uint TotalUrisCached { get; private set; }
		public uint UriCacheFlushes { get; private set; }
		public uint UriCacheHits { get; private set; }
		public uint UriCacheMisses { get; private set; }

        public static IEnumerable<Counters_HTTPService> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_HTTPService> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_HTTPService> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_HTTPService");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_HTTPService
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CurrentUrisCached = (uint) (managementObject.Properties["CurrentUrisCached"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalFlushedUris = (uint) (managementObject.Properties["TotalFlushedUris"]?.Value ?? default(uint)),
		 TotalUrisCached = (uint) (managementObject.Properties["TotalUrisCached"]?.Value ?? default(uint)),
		 UriCacheFlushes = (uint) (managementObject.Properties["UriCacheFlushes"]?.Value ?? default(uint)),
		 UriCacheHits = (uint) (managementObject.Properties["UriCacheHits"]?.Value ?? default(uint)),
		 UriCacheMisses = (uint) (managementObject.Properties["UriCacheMisses"]?.Value ?? default(uint))
                };
        }
    }
}