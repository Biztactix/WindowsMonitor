using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_PhysicalNetworkInterfaceCardActivity
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public uint DevicePowerState { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint LowPowerTransitionsLifetime { get; private set; }
		public string Name { get; private set; }
		public ulong PercentTimeSuspendedInstantaneous { get; private set; }
		public ulong PercentTimeSuspendedLifetime { get; private set; }
		public ulong PercentTimeSuspendedLifetime_Base { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_PhysicalNetworkInterfaceCardActivity> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_PhysicalNetworkInterfaceCardActivity> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_PhysicalNetworkInterfaceCardActivity> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_PhysicalNetworkInterfaceCardActivity");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_PhysicalNetworkInterfaceCardActivity
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 DevicePowerState = (uint) (managementObject.Properties["DevicePowerState"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 LowPowerTransitionsLifetime = (uint) (managementObject.Properties["LowPowerTransitionsLifetime"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 PercentTimeSuspendedInstantaneous = (ulong) (managementObject.Properties["PercentTimeSuspendedInstantaneous"]?.Value ?? default(ulong)),
		 PercentTimeSuspendedLifetime = (ulong) (managementObject.Properties["PercentTimeSuspendedLifetime"]?.Value ?? default(ulong)),
		 PercentTimeSuspendedLifetime_Base = (ulong) (managementObject.Properties["PercentTimeSuspendedLifetime_Base"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}