using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class HvStats_HyperVHypervisor
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

        public static IEnumerable<HvStats_HyperVHypervisor> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HvStats_HyperVHypervisor> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HvStats_HyperVHypervisor> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_HvStats_HyperVHypervisor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HvStats_HyperVHypervisor
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 HypervisorStartupCost = (ulong) (managementObject.Properties["HypervisorStartupCost"]?.Value ?? default(ulong)),
		 LogicalProcessors = (ulong) (managementObject.Properties["LogicalProcessors"]?.Value ?? default(ulong)),
		 ModernStandbyEntries = (ulong) (managementObject.Properties["ModernStandbyEntries"]?.Value ?? default(ulong)),
		 MonitoredNotifications = (ulong) (managementObject.Properties["MonitoredNotifications"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Partitions = (ulong) (managementObject.Properties["Partitions"]?.Value ?? default(ulong)),
		 PlatformIdleTransitions = (ulong) (managementObject.Properties["PlatformIdleTransitions"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalPages = (ulong) (managementObject.Properties["TotalPages"]?.Value ?? default(ulong)),
		 VirtualProcessors = (ulong) (managementObject.Properties["VirtualProcessors"]?.Value ?? default(ulong))
                };
        }
    }
}