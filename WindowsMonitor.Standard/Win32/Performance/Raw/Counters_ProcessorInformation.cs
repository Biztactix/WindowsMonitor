using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_ProcessorInformation
    {
		public ulong AverageIdleTime { get; private set; }
		public ulong AverageIdleTime_Base { get; private set; }
		public ulong C1TransitionsPersec { get; private set; }
		public ulong C2TransitionsPersec { get; private set; }
		public ulong C3TransitionsPersec { get; private set; }
		public string Caption { get; private set; }
		public uint ClockInterruptsPersec { get; private set; }
		public string Description { get; private set; }
		public uint DPCRate { get; private set; }
		public uint DPCsQueuedPersec { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong IdleBreakEventsPersec { get; private set; }
		public uint InterruptsPersec { get; private set; }
		public string Name { get; private set; }
		public uint ParkingStatus { get; private set; }
		public ulong PercentC1Time { get; private set; }
		public ulong PercentC2Time { get; private set; }
		public ulong PercentC3Time { get; private set; }
		public ulong PercentDPCTime { get; private set; }
		public ulong PercentIdleTime { get; private set; }
		public ulong PercentInterruptTime { get; private set; }
		public uint PercentofMaximumFrequency { get; private set; }
		public uint PercentPerformanceLimit { get; private set; }
		public ulong PercentPriorityTime { get; private set; }
		public ulong PercentPrivilegedTime { get; private set; }
		public ulong PercentPrivilegedUtility { get; private set; }
		public uint PercentPrivilegedUtility_Base { get; private set; }
		public ulong PercentProcessorPerformance { get; private set; }
		public uint PercentProcessorPerformance_Base { get; private set; }
		public ulong PercentProcessorTime { get; private set; }
		public ulong PercentProcessorUtility { get; private set; }
		public uint PercentProcessorUtility_Base { get; private set; }
		public ulong PercentUserTime { get; private set; }
		public uint PerformanceLimitFlags { get; private set; }
		public uint ProcessorFrequency { get; private set; }
		public uint ProcessorStateFlags { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_ProcessorInformation> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_ProcessorInformation> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_ProcessorInformation> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_ProcessorInformation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_ProcessorInformation
                {
                     AverageIdleTime = (ulong) (managementObject.Properties["AverageIdleTime"]?.Value ?? default(ulong)),
		 AverageIdleTime_Base = (ulong) (managementObject.Properties["AverageIdleTime_Base"]?.Value ?? default(ulong)),
		 C1TransitionsPersec = (ulong) (managementObject.Properties["C1TransitionsPersec"]?.Value ?? default(ulong)),
		 C2TransitionsPersec = (ulong) (managementObject.Properties["C2TransitionsPersec"]?.Value ?? default(ulong)),
		 C3TransitionsPersec = (ulong) (managementObject.Properties["C3TransitionsPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ClockInterruptsPersec = (uint) (managementObject.Properties["ClockInterruptsPersec"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DPCRate = (uint) (managementObject.Properties["DPCRate"]?.Value ?? default(uint)),
		 DPCsQueuedPersec = (uint) (managementObject.Properties["DPCsQueuedPersec"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IdleBreakEventsPersec = (ulong) (managementObject.Properties["IdleBreakEventsPersec"]?.Value ?? default(ulong)),
		 InterruptsPersec = (uint) (managementObject.Properties["InterruptsPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ParkingStatus = (uint) (managementObject.Properties["ParkingStatus"]?.Value ?? default(uint)),
		 PercentC1Time = (ulong) (managementObject.Properties["PercentC1Time"]?.Value ?? default(ulong)),
		 PercentC2Time = (ulong) (managementObject.Properties["PercentC2Time"]?.Value ?? default(ulong)),
		 PercentC3Time = (ulong) (managementObject.Properties["PercentC3Time"]?.Value ?? default(ulong)),
		 PercentDPCTime = (ulong) (managementObject.Properties["PercentDPCTime"]?.Value ?? default(ulong)),
		 PercentIdleTime = (ulong) (managementObject.Properties["PercentIdleTime"]?.Value ?? default(ulong)),
		 PercentInterruptTime = (ulong) (managementObject.Properties["PercentInterruptTime"]?.Value ?? default(ulong)),
		 PercentofMaximumFrequency = (uint) (managementObject.Properties["PercentofMaximumFrequency"]?.Value ?? default(uint)),
		 PercentPerformanceLimit = (uint) (managementObject.Properties["PercentPerformanceLimit"]?.Value ?? default(uint)),
		 PercentPriorityTime = (ulong) (managementObject.Properties["PercentPriorityTime"]?.Value ?? default(ulong)),
		 PercentPrivilegedTime = (ulong) (managementObject.Properties["PercentPrivilegedTime"]?.Value ?? default(ulong)),
		 PercentPrivilegedUtility = (ulong) (managementObject.Properties["PercentPrivilegedUtility"]?.Value ?? default(ulong)),
		 PercentPrivilegedUtility_Base = (uint) (managementObject.Properties["PercentPrivilegedUtility_Base"]?.Value ?? default(uint)),
		 PercentProcessorPerformance = (ulong) (managementObject.Properties["PercentProcessorPerformance"]?.Value ?? default(ulong)),
		 PercentProcessorPerformance_Base = (uint) (managementObject.Properties["PercentProcessorPerformance_Base"]?.Value ?? default(uint)),
		 PercentProcessorTime = (ulong) (managementObject.Properties["PercentProcessorTime"]?.Value ?? default(ulong)),
		 PercentProcessorUtility = (ulong) (managementObject.Properties["PercentProcessorUtility"]?.Value ?? default(ulong)),
		 PercentProcessorUtility_Base = (uint) (managementObject.Properties["PercentProcessorUtility_Base"]?.Value ?? default(uint)),
		 PercentUserTime = (ulong) (managementObject.Properties["PercentUserTime"]?.Value ?? default(ulong)),
		 PerformanceLimitFlags = (uint) (managementObject.Properties["PerformanceLimitFlags"]?.Value ?? default(uint)),
		 ProcessorFrequency = (uint) (managementObject.Properties["ProcessorFrequency"]?.Value ?? default(uint)),
		 ProcessorStateFlags = (uint) (managementObject.Properties["ProcessorStateFlags"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}