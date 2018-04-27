using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_PerProcessorNetworkActivityCycles
    {
		public ulong BuildScatterGatherCyclesPersec { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong InterruptCyclesPersec { get; private set; }
		public ulong InterruptDPCCyclesPersec { get; private set; }
		public ulong InterruptDPCLatencyCyclesPersec { get; private set; }
		public ulong MiniportReturnPacketCyclesPersec { get; private set; }
		public ulong MiniportRSSIndirectionTableChangeCycles { get; private set; }
		public ulong MiniportSendCyclesPersec { get; private set; }
		public string Name { get; private set; }
		public ulong NDISReceiveIndicationCyclesPersec { get; private set; }
		public ulong NDISReturnPacketCyclesPersec { get; private set; }
		public ulong NDISSendCompleteCyclesPersec { get; private set; }
		public ulong NDISSendCyclesPersec { get; private set; }
		public ulong StackReceiveIndicationCyclesPersec { get; private set; }
		public ulong StackSendCompleteCyclesPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_PerProcessorNetworkActivityCycles> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_PerProcessorNetworkActivityCycles> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_PerProcessorNetworkActivityCycles> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_PerProcessorNetworkActivityCycles");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_PerProcessorNetworkActivityCycles
                {
                     BuildScatterGatherCyclesPersec = (ulong) (managementObject.Properties["BuildScatterGatherCyclesPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 InterruptCyclesPersec = (ulong) (managementObject.Properties["InterruptCyclesPersec"]?.Value ?? default(ulong)),
		 InterruptDPCCyclesPersec = (ulong) (managementObject.Properties["InterruptDPCCyclesPersec"]?.Value ?? default(ulong)),
		 InterruptDPCLatencyCyclesPersec = (ulong) (managementObject.Properties["InterruptDPCLatencyCyclesPersec"]?.Value ?? default(ulong)),
		 MiniportReturnPacketCyclesPersec = (ulong) (managementObject.Properties["MiniportReturnPacketCyclesPersec"]?.Value ?? default(ulong)),
		 MiniportRSSIndirectionTableChangeCycles = (ulong) (managementObject.Properties["MiniportRSSIndirectionTableChangeCycles"]?.Value ?? default(ulong)),
		 MiniportSendCyclesPersec = (ulong) (managementObject.Properties["MiniportSendCyclesPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NDISReceiveIndicationCyclesPersec = (ulong) (managementObject.Properties["NDISReceiveIndicationCyclesPersec"]?.Value ?? default(ulong)),
		 NDISReturnPacketCyclesPersec = (ulong) (managementObject.Properties["NDISReturnPacketCyclesPersec"]?.Value ?? default(ulong)),
		 NDISSendCompleteCyclesPersec = (ulong) (managementObject.Properties["NDISSendCompleteCyclesPersec"]?.Value ?? default(ulong)),
		 NDISSendCyclesPersec = (ulong) (managementObject.Properties["NDISSendCyclesPersec"]?.Value ?? default(ulong)),
		 StackReceiveIndicationCyclesPersec = (ulong) (managementObject.Properties["StackReceiveIndicationCyclesPersec"]?.Value ?? default(ulong)),
		 StackSendCompleteCyclesPersec = (ulong) (managementObject.Properties["StackSendCompleteCyclesPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}