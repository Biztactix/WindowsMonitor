using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class ESENT_DatabaseTableClasses
    {
		public string Caption { get; private set; }
		public ulong DatabaseCacheMissAttachedAverageLatency { get; private set; }
		public uint DatabaseCacheMissAttachedAverageLatency_Base { get; private set; }
		public uint DatabaseCacheMissesPersec { get; private set; }
		public uint DatabaseCachePercentHit { get; private set; }
		public uint DatabaseCachePercentHit_Base { get; private set; }
		public uint DatabaseCachePercentHitUncorrelated { get; private set; }
		public uint DatabaseCachePercentHitUncorrelated_Base { get; private set; }
		public uint DatabaseCacheRequestsPersec { get; private set; }
		public ulong DatabaseCacheSize { get; private set; }
		public ulong DatabaseCacheSizeMB { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<ESENT_DatabaseTableClasses> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ESENT_DatabaseTableClasses> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ESENT_DatabaseTableClasses> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_ESENT_DatabaseTableClasses");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ESENT_DatabaseTableClasses
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 DatabaseCacheMissAttachedAverageLatency = (ulong) (managementObject.Properties["DatabaseCacheMissAttachedAverageLatency"]?.Value ?? default(ulong)),
		 DatabaseCacheMissAttachedAverageLatency_Base = (uint) (managementObject.Properties["DatabaseCacheMissAttachedAverageLatency_Base"]?.Value ?? default(uint)),
		 DatabaseCacheMissesPersec = (uint) (managementObject.Properties["DatabaseCacheMissesPersec"]?.Value ?? default(uint)),
		 DatabaseCachePercentHit = (uint) (managementObject.Properties["DatabaseCachePercentHit"]?.Value ?? default(uint)),
		 DatabaseCachePercentHit_Base = (uint) (managementObject.Properties["DatabaseCachePercentHit_Base"]?.Value ?? default(uint)),
		 DatabaseCachePercentHitUncorrelated = (uint) (managementObject.Properties["DatabaseCachePercentHitUncorrelated"]?.Value ?? default(uint)),
		 DatabaseCachePercentHitUncorrelated_Base = (uint) (managementObject.Properties["DatabaseCachePercentHitUncorrelated_Base"]?.Value ?? default(uint)),
		 DatabaseCacheRequestsPersec = (uint) (managementObject.Properties["DatabaseCacheRequestsPersec"]?.Value ?? default(uint)),
		 DatabaseCacheSize = (ulong) (managementObject.Properties["DatabaseCacheSize"]?.Value ?? default(ulong)),
		 DatabaseCacheSizeMB = (ulong) (managementObject.Properties["DatabaseCacheSizeMB"]?.Value ?? default(ulong)),
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