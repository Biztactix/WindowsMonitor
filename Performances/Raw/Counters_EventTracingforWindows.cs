using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_EventTracingforWindows
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

        public static PerfRawData_Counters_EventTracingforWindows[] Retrieve(string remote, string username,
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

        public static PerfRawData_Counters_EventTracingforWindows[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_EventTracingforWindows[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_EventTracingforWindows");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_EventTracingforWindows>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_EventTracingforWindows
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalMemoryUsageNonPagedPool = (uint) managementObject.Properties["TotalMemoryUsageNonPagedPool"]
                        .Value,
                    TotalMemoryUsagePagedPool = (uint) managementObject.Properties["TotalMemoryUsagePagedPool"].Value,
                    TotalNumberofActiveSessions = (uint) managementObject.Properties["TotalNumberofActiveSessions"]
                        .Value,
                    TotalNumberofDistinctDisabledProviders = (uint) managementObject
                        .Properties["TotalNumberofDistinctDisabledProviders"].Value,
                    TotalNumberofDistinctEnabledProviders = (uint) managementObject
                        .Properties["TotalNumberofDistinctEnabledProviders"].Value,
                    TotalNumberofDistinctPreEnabledProviders = (uint) managementObject
                        .Properties["TotalNumberofDistinctPreEnabledProviders"].Value
                });

            return list.ToArray();
        }
    }
}