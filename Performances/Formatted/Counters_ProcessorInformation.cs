using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_ProcessorInformation
    {
        public ulong AverageIdleTime { get; private set; }
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
        public ulong PercentProcessorPerformance { get; private set; }
        public ulong PercentProcessorTime { get; private set; }
        public ulong PercentProcessorUtility { get; private set; }
        public ulong PercentUserTime { get; private set; }
        public uint PerformanceLimitFlags { get; private set; }
        public uint ProcessorFrequency { get; private set; }
        public uint ProcessorStateFlags { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_Counters_ProcessorInformation[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_Counters_ProcessorInformation[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_ProcessorInformation[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_ProcessorInformation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_ProcessorInformation>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_ProcessorInformation
                {
                    AverageIdleTime = (ulong) managementObject.Properties["AverageIdleTime"].Value,
                    C1TransitionsPersec = (ulong) managementObject.Properties["C1TransitionsPersec"].Value,
                    C2TransitionsPersec = (ulong) managementObject.Properties["C2TransitionsPersec"].Value,
                    C3TransitionsPersec = (ulong) managementObject.Properties["C3TransitionsPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ClockInterruptsPersec = (uint) managementObject.Properties["ClockInterruptsPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DPCRate = (uint) managementObject.Properties["DPCRate"].Value,
                    DPCsQueuedPersec = (uint) managementObject.Properties["DPCsQueuedPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IdleBreakEventsPersec = (ulong) managementObject.Properties["IdleBreakEventsPersec"].Value,
                    InterruptsPersec = (uint) managementObject.Properties["InterruptsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ParkingStatus = (uint) managementObject.Properties["ParkingStatus"].Value,
                    PercentC1Time = (ulong) managementObject.Properties["PercentC1Time"].Value,
                    PercentC2Time = (ulong) managementObject.Properties["PercentC2Time"].Value,
                    PercentC3Time = (ulong) managementObject.Properties["PercentC3Time"].Value,
                    PercentDPCTime = (ulong) managementObject.Properties["PercentDPCTime"].Value,
                    PercentIdleTime = (ulong) managementObject.Properties["PercentIdleTime"].Value,
                    PercentInterruptTime = (ulong) managementObject.Properties["PercentInterruptTime"].Value,
                    PercentofMaximumFrequency = (uint) managementObject.Properties["PercentofMaximumFrequency"].Value,
                    PercentPerformanceLimit = (uint) managementObject.Properties["PercentPerformanceLimit"].Value,
                    PercentPriorityTime = (ulong) managementObject.Properties["PercentPriorityTime"].Value,
                    PercentPrivilegedTime = (ulong) managementObject.Properties["PercentPrivilegedTime"].Value,
                    PercentPrivilegedUtility = (ulong) managementObject.Properties["PercentPrivilegedUtility"].Value,
                    PercentProcessorPerformance = (ulong) managementObject.Properties["PercentProcessorPerformance"]
                        .Value,
                    PercentProcessorTime = (ulong) managementObject.Properties["PercentProcessorTime"].Value,
                    PercentProcessorUtility = (ulong) managementObject.Properties["PercentProcessorUtility"].Value,
                    PercentUserTime = (ulong) managementObject.Properties["PercentUserTime"].Value,
                    PerformanceLimitFlags = (uint) managementObject.Properties["PerformanceLimitFlags"].Value,
                    ProcessorFrequency = (uint) managementObject.Properties["ProcessorFrequency"].Value,
                    ProcessorStateFlags = (uint) managementObject.Properties["ProcessorStateFlags"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}