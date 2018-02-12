using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class NETMemoryCache40_NETMemoryCache40
    {
		public uint CacheEntries { get; private set; }
		public uint CacheHitRatio { get; private set; }
		public uint CacheHitRatio_Base { get; private set; }
		public uint CacheHits { get; private set; }
		public uint CacheMisses { get; private set; }
		public uint CacheTrims { get; private set; }
		public uint CacheTurnoverRate { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<NETMemoryCache40_NETMemoryCache40> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NETMemoryCache40_NETMemoryCache40> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NETMemoryCache40_NETMemoryCache40> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_NETMemoryCache40_NETMemoryCache40");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NETMemoryCache40_NETMemoryCache40
                {
                     CacheEntries = (uint) (managementObject.Properties["CacheEntries"]?.Value ?? default(uint)),
		 CacheHitRatio = (uint) (managementObject.Properties["CacheHitRatio"]?.Value ?? default(uint)),
		 CacheHitRatio_Base = (uint) (managementObject.Properties["CacheHitRatio_Base"]?.Value ?? default(uint)),
		 CacheHits = (uint) (managementObject.Properties["CacheHits"]?.Value ?? default(uint)),
		 CacheMisses = (uint) (managementObject.Properties["CacheMisses"]?.Value ?? default(uint)),
		 CacheTrims = (uint) (managementObject.Properties["CacheTrims"]?.Value ?? default(uint)),
		 CacheTurnoverRate = (uint) (managementObject.Properties["CacheTurnoverRate"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}