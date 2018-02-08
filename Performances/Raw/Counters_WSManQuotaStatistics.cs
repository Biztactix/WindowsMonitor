using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_WSManQuotaStatistics
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

        public static PerfRawData_Counters_WSManQuotaStatistics[] Retrieve(string remote, string username,
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

        public static PerfRawData_Counters_WSManQuotaStatistics[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_WSManQuotaStatistics[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_WSManQuotaStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_WSManQuotaStatistics>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_WSManQuotaStatistics
                {
                    ActiveOperations = (uint) managementObject.Properties["ActiveOperations"].Value,
                    ActiveShells = (uint) managementObject.Properties["ActiveShells"].Value,
                    ActiveUsers = (uint) managementObject.Properties["ActiveUsers"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ProcessID = (uint) managementObject.Properties["ProcessID"].Value,
                    SystemQuotaViolationsPerSecond =
                        (uint) managementObject.Properties["SystemQuotaViolationsPerSecond"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalRequestsPerSecond = (uint) managementObject.Properties["TotalRequestsPerSecond"].Value,
                    UserQuotaViolationsPerSecond = (uint) managementObject.Properties["UserQuotaViolationsPerSecond"]
                        .Value
                });

            return list.ToArray();
        }
    }
}