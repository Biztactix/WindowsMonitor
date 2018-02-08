using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_Netlogon
    {
        public uint AverageSemaphoreHoldTime { get; private set; }
        public uint AverageSemaphoreHoldTime_Base { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint LastAuthenticationTime { get; private set; }
        public uint LastAuthenticationTime_Base { get; private set; }
        public string Name { get; private set; }
        public ulong SemaphoreAcquires { get; private set; }
        public uint SemaphoreHolders { get; private set; }
        public ulong SemaphoreTimeouts { get; private set; }
        public uint SemaphoreWaiters { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_Netlogon[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_Netlogon[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_Netlogon[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_Netlogon");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_Netlogon>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_Netlogon
                {
                    AverageSemaphoreHoldTime = (uint) managementObject.Properties["AverageSemaphoreHoldTime"].Value,
                    AverageSemaphoreHoldTime_Base = (uint) managementObject.Properties["AverageSemaphoreHoldTime_Base"]
                        .Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    LastAuthenticationTime = (uint) managementObject.Properties["LastAuthenticationTime"].Value,
                    LastAuthenticationTime_Base = (uint) managementObject.Properties["LastAuthenticationTime_Base"]
                        .Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SemaphoreAcquires = (ulong) managementObject.Properties["SemaphoreAcquires"].Value,
                    SemaphoreHolders = (uint) managementObject.Properties["SemaphoreHolders"].Value,
                    SemaphoreTimeouts = (ulong) managementObject.Properties["SemaphoreTimeouts"].Value,
                    SemaphoreWaiters = (uint) managementObject.Properties["SemaphoreWaiters"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}