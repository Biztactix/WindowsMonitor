using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_ESENT_DatabaseTableClasses
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

        public static PerfRawData_ESENT_DatabaseTableClasses[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_ESENT_DatabaseTableClasses[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_ESENT_DatabaseTableClasses[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_ESENT_DatabaseTableClasses");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_ESENT_DatabaseTableClasses>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_ESENT_DatabaseTableClasses
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    DatabaseCacheMissAttachedAverageLatency = (ulong) managementObject
                        .Properties["DatabaseCacheMissAttachedAverageLatency"].Value,
                    DatabaseCacheMissAttachedAverageLatency_Base = (uint) managementObject
                        .Properties["DatabaseCacheMissAttachedAverageLatency_Base"].Value,
                    DatabaseCacheMissesPersec = (uint) managementObject.Properties["DatabaseCacheMissesPersec"].Value,
                    DatabaseCachePercentHit = (uint) managementObject.Properties["DatabaseCachePercentHit"].Value,
                    DatabaseCachePercentHit_Base = (uint) managementObject.Properties["DatabaseCachePercentHit_Base"]
                        .Value,
                    DatabaseCachePercentHitUncorrelated =
                        (uint) managementObject.Properties["DatabaseCachePercentHitUncorrelated"].Value,
                    DatabaseCachePercentHitUncorrelated_Base = (uint) managementObject
                        .Properties["DatabaseCachePercentHitUncorrelated_Base"].Value,
                    DatabaseCacheRequestsPersec = (uint) managementObject.Properties["DatabaseCacheRequestsPersec"]
                        .Value,
                    DatabaseCacheSize = (ulong) managementObject.Properties["DatabaseCacheSize"].Value,
                    DatabaseCacheSizeMB = (ulong) managementObject.Properties["DatabaseCacheSizeMB"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}