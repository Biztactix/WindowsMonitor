using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_HvStats_HyperVHypervisorLogicalProcessor
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
        public ulong PercentC2Time { get; private set; }
        public ulong PercentC3Time { get; private set; }
        public ulong PercentGuestRunTime { get; private set; }
        public ulong PercentHypervisorRunTime { get; private set; }
        public ulong PercentIdleTime { get; private set; }
        public ulong PercentofMaxFrequency { get; private set; }
        public ulong PercentTotalRunTime { get; private set; }
        public ulong ProcessorStateFlags { get; private set; }
        public ulong RootVpIndex { get; private set; }
        public ulong SchedulerInterruptsPersec { get; private set; }
        public ulong TimerInterruptsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalInterruptsPersec { get; private set; }

        public static PerfFormattedData_HvStats_HyperVHypervisorLogicalProcessor[] Retrieve(string remote,
            string username, string password)
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

        public static PerfFormattedData_HvStats_HyperVHypervisorLogicalProcessor[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_HvStats_HyperVHypervisorLogicalProcessor[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_HvStats_HyperVHypervisorLogicalProcessor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_HvStats_HyperVHypervisorLogicalProcessor>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_HvStats_HyperVHypervisorLogicalProcessor
                {
                    C1TransitionsPersec = (ulong) managementObject.Properties["C1TransitionsPersec"].Value,
                    C2TransitionsPersec = (ulong) managementObject.Properties["C2TransitionsPersec"].Value,
                    C3TransitionsPersec = (ulong) managementObject.Properties["C3TransitionsPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ContextSwitchesPersec = (ulong) managementObject.Properties["ContextSwitchesPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency = (ulong) managementObject.Properties["Frequency"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    HardwareInterruptsPersec = (ulong) managementObject.Properties["HardwareInterruptsPersec"].Value,
                    InterProcessorInterruptsPersec =
                        (ulong) managementObject.Properties["InterProcessorInterruptsPersec"].Value,
                    InterProcessorInterruptsSentPersec =
                        (ulong) managementObject.Properties["InterProcessorInterruptsSentPersec"].Value,
                    MonitorTransitionCost = (ulong) managementObject.Properties["MonitorTransitionCost"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ParkingStatus = (ulong) managementObject.Properties["ParkingStatus"].Value,
                    PercentC1Time = (ulong) managementObject.Properties["PercentC1Time"].Value,
                    PercentC2Time = (ulong) managementObject.Properties["PercentC2Time"].Value,
                    PercentC3Time = (ulong) managementObject.Properties["PercentC3Time"].Value,
                    PercentGuestRunTime = (ulong) managementObject.Properties["PercentGuestRunTime"].Value,
                    PercentHypervisorRunTime = (ulong) managementObject.Properties["PercentHypervisorRunTime"].Value,
                    PercentIdleTime = (ulong) managementObject.Properties["PercentIdleTime"].Value,
                    PercentofMaxFrequency = (ulong) managementObject.Properties["PercentofMaxFrequency"].Value,
                    PercentTotalRunTime = (ulong) managementObject.Properties["PercentTotalRunTime"].Value,
                    ProcessorStateFlags = (ulong) managementObject.Properties["ProcessorStateFlags"].Value,
                    RootVpIndex = (ulong) managementObject.Properties["RootVpIndex"].Value,
                    SchedulerInterruptsPersec = (ulong) managementObject.Properties["SchedulerInterruptsPersec"].Value,
                    TimerInterruptsPersec = (ulong) managementObject.Properties["TimerInterruptsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalInterruptsPersec = (ulong) managementObject.Properties["TotalInterruptsPersec"].Value
                });

            return list.ToArray();
        }
    }
}