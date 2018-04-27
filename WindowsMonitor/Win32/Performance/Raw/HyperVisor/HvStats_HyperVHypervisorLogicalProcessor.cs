using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class HvStats_HyperVHypervisorLogicalProcessor
    {
		public ulong C1TransitionsPersec { get; private set; }
		public ulong C2TransitionsPersec { get; private set; }
		public ulong C3TransitionsPersec { get; private set; }
		public string Caption { get; private set; }
		public ulong ContextSwitchesPersec { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong HardwareInterruptsPersec { get; private set; }
		public ulong InterProcessorInterruptsPersec { get; private set; }
		public ulong InterProcessorInterruptsSentPersec { get; private set; }
		public ulong MonitorTransitionCost { get; private set; }
		public string Name { get; private set; }
		public ulong ParkingStatus { get; private set; }
		public ulong PercentC1Time { get; private set; }
		public ulong PercentC1Time_Base { get; private set; }
		public ulong PercentC2Time { get; private set; }
		public ulong PercentC2Time_Base { get; private set; }
		public ulong PercentC3Time { get; private set; }
		public ulong PercentC3Time_Base { get; private set; }
		public ulong PercentGuestRunTime { get; private set; }
		public ulong PercentGuestRunTime_Base { get; private set; }
		public ulong PercentHypervisorRunTime { get; private set; }
		public ulong PercentHypervisorRunTime_Base { get; private set; }
		public ulong PercentIdleTime { get; private set; }
		public ulong PercentIdleTime_Base { get; private set; }
		public ulong PercentofMaxFrequency { get; private set; }
		public ulong PercentTotalRunTime { get; private set; }
		public ulong PercentTotalRunTime_Base { get; private set; }
		public ulong ProcessorStateFlags { get; private set; }
		public ulong RootVpIndex { get; private set; }
		public ulong SchedulerInterruptsPersec { get; private set; }
		public ulong TimerInterruptsPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong TotalInterruptsPersec { get; private set; }

        public static IEnumerable<HvStats_HyperVHypervisorLogicalProcessor> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HvStats_HyperVHypervisorLogicalProcessor> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HvStats_HyperVHypervisorLogicalProcessor> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_HvStats_HyperVHypervisorLogicalProcessor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HvStats_HyperVHypervisorLogicalProcessor
                {
                     C1TransitionsPersec = (ulong) (managementObject.Properties["C1TransitionsPersec"]?.Value ?? default(ulong)),
		 C2TransitionsPersec = (ulong) (managementObject.Properties["C2TransitionsPersec"]?.Value ?? default(ulong)),
		 C3TransitionsPersec = (ulong) (managementObject.Properties["C3TransitionsPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ContextSwitchesPersec = (ulong) (managementObject.Properties["ContextSwitchesPersec"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency = (ulong) (managementObject.Properties["Frequency"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 HardwareInterruptsPersec = (ulong) (managementObject.Properties["HardwareInterruptsPersec"]?.Value ?? default(ulong)),
		 InterProcessorInterruptsPersec = (ulong) (managementObject.Properties["InterProcessorInterruptsPersec"]?.Value ?? default(ulong)),
		 InterProcessorInterruptsSentPersec = (ulong) (managementObject.Properties["InterProcessorInterruptsSentPersec"]?.Value ?? default(ulong)),
		 MonitorTransitionCost = (ulong) (managementObject.Properties["MonitorTransitionCost"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ParkingStatus = (ulong) (managementObject.Properties["ParkingStatus"]?.Value ?? default(ulong)),
		 PercentC1Time = (ulong) (managementObject.Properties["PercentC1Time"]?.Value ?? default(ulong)),
		 PercentC1Time_Base = (ulong) (managementObject.Properties["PercentC1Time_Base"]?.Value ?? default(ulong)),
		 PercentC2Time = (ulong) (managementObject.Properties["PercentC2Time"]?.Value ?? default(ulong)),
		 PercentC2Time_Base = (ulong) (managementObject.Properties["PercentC2Time_Base"]?.Value ?? default(ulong)),
		 PercentC3Time = (ulong) (managementObject.Properties["PercentC3Time"]?.Value ?? default(ulong)),
		 PercentC3Time_Base = (ulong) (managementObject.Properties["PercentC3Time_Base"]?.Value ?? default(ulong)),
		 PercentGuestRunTime = (ulong) (managementObject.Properties["PercentGuestRunTime"]?.Value ?? default(ulong)),
		 PercentGuestRunTime_Base = (ulong) (managementObject.Properties["PercentGuestRunTime_Base"]?.Value ?? default(ulong)),
		 PercentHypervisorRunTime = (ulong) (managementObject.Properties["PercentHypervisorRunTime"]?.Value ?? default(ulong)),
		 PercentHypervisorRunTime_Base = (ulong) (managementObject.Properties["PercentHypervisorRunTime_Base"]?.Value ?? default(ulong)),
		 PercentIdleTime = (ulong) (managementObject.Properties["PercentIdleTime"]?.Value ?? default(ulong)),
		 PercentIdleTime_Base = (ulong) (managementObject.Properties["PercentIdleTime_Base"]?.Value ?? default(ulong)),
		 PercentofMaxFrequency = (ulong) (managementObject.Properties["PercentofMaxFrequency"]?.Value ?? default(ulong)),
		 PercentTotalRunTime = (ulong) (managementObject.Properties["PercentTotalRunTime"]?.Value ?? default(ulong)),
		 PercentTotalRunTime_Base = (ulong) (managementObject.Properties["PercentTotalRunTime_Base"]?.Value ?? default(ulong)),
		 ProcessorStateFlags = (ulong) (managementObject.Properties["ProcessorStateFlags"]?.Value ?? default(ulong)),
		 RootVpIndex = (ulong) (managementObject.Properties["RootVpIndex"]?.Value ?? default(ulong)),
		 SchedulerInterruptsPersec = (ulong) (managementObject.Properties["SchedulerInterruptsPersec"]?.Value ?? default(ulong)),
		 TimerInterruptsPersec = (ulong) (managementObject.Properties["TimerInterruptsPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalInterruptsPersec = (ulong) (managementObject.Properties["TotalInterruptsPersec"]?.Value ?? default(ulong))
                };
        }
    }
}