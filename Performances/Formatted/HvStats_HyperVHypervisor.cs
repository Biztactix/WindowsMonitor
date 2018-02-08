using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_HvStats_HyperVHypervisor
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong HypervisorStartupCost { get; private set; }
        public ulong LogicalProcessors { get; private set; }
        public ulong ModernStandbyEntries { get; private set; }
        public ulong MonitoredNotifications { get; private set; }
        public string Name { get; private set; }
        public ulong Partitions { get; private set; }
        public ulong PlatformIdleTransitions { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalPages { get; private set; }
        public ulong VirtualProcessors { get; private set; }

        public static PerfFormattedData_HvStats_HyperVHypervisor[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_HvStats_HyperVHypervisor[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_HvStats_HyperVHypervisor[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_HvStats_HyperVHypervisor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_HvStats_HyperVHypervisor>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_HvStats_HyperVHypervisor
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    HypervisorStartupCost = (ulong) managementObject.Properties["HypervisorStartupCost"].Value,
                    LogicalProcessors = (ulong) managementObject.Properties["LogicalProcessors"].Value,
                    ModernStandbyEntries = (ulong) managementObject.Properties["ModernStandbyEntries"].Value,
                    MonitoredNotifications = (ulong) managementObject.Properties["MonitoredNotifications"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Partitions = (ulong) managementObject.Properties["Partitions"].Value,
                    PlatformIdleTransitions = (ulong) managementObject.Properties["PlatformIdleTransitions"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalPages = (ulong) managementObject.Properties["TotalPages"].Value,
                    VirtualProcessors = (ulong) managementObject.Properties["VirtualProcessors"].Value
                });

            return list.ToArray();
        }
    }
}