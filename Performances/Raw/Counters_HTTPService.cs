using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_HTTPService
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

        public static PerfRawData_Counters_HTTPService[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_HTTPService[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_HTTPService[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_HTTPService");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_HTTPService>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_HTTPService
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentUrisCached = (uint) managementObject.Properties["CurrentUrisCached"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalFlushedUris = (uint) managementObject.Properties["TotalFlushedUris"].Value,
                    TotalUrisCached = (uint) managementObject.Properties["TotalUrisCached"].Value,
                    UriCacheFlushes = (uint) managementObject.Properties["UriCacheFlushes"].Value,
                    UriCacheHits = (uint) managementObject.Properties["UriCacheHits"].Value,
                    UriCacheMisses = (uint) managementObject.Properties["UriCacheMisses"].Value
                });

            return list.ToArray();
        }
    }
}