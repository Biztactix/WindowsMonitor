using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_NETMemoryCache40_NETMemoryCache40
    {
        public uint CacheEntries { get; private set; }
        public uint CacheHitRatio { get; private set; }
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

        public static PerfFormattedData_NETMemoryCache40_NETMemoryCache40[] Retrieve(string remote, string username,
            string password)
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

        public static PerfFormattedData_NETMemoryCache40_NETMemoryCache40[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_NETMemoryCache40_NETMemoryCache40[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_NETMemoryCache40_NETMemoryCache40");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_NETMemoryCache40_NETMemoryCache40>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_NETMemoryCache40_NETMemoryCache40
                {
                    CacheEntries = (uint) managementObject.Properties["CacheEntries"].Value,
                    CacheHitRatio = (uint) managementObject.Properties["CacheHitRatio"].Value,
                    CacheHits = (uint) managementObject.Properties["CacheHits"].Value,
                    CacheMisses = (uint) managementObject.Properties["CacheMisses"].Value,
                    CacheTrims = (uint) managementObject.Properties["CacheTrims"].Value,
                    CacheTurnoverRate = (uint) managementObject.Properties["CacheTurnoverRate"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
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