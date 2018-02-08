using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_PerfOS_Processor
    {
        public ulong C1TransitionsPersec { get; private set; }
        public ulong C2TransitionsPersec { get; private set; }
        public ulong C3TransitionsPersec { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint DPCRate { get; private set; }
        public uint DPCsQueuedPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint InterruptsPersec { get; private set; }
        public string Name { get; private set; }
        public ulong PercentC1Time { get; private set; }
        public ulong PercentC2Time { get; private set; }
        public ulong PercentC3Time { get; private set; }
        public ulong PercentDPCTime { get; private set; }
        public ulong PercentIdleTime { get; private set; }
        public ulong PercentInterruptTime { get; private set; }
        public ulong PercentPrivilegedTime { get; private set; }
        public ulong PercentProcessorTime { get; private set; }
        public ulong PercentUserTime { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_PerfOS_Processor[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_PerfOS_Processor[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_PerfOS_Processor[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_PerfOS_Processor>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_PerfOS_Processor
                {
                    C1TransitionsPersec = (ulong) managementObject.Properties["C1TransitionsPersec"].Value,
                    C2TransitionsPersec = (ulong) managementObject.Properties["C2TransitionsPersec"].Value,
                    C3TransitionsPersec = (ulong) managementObject.Properties["C3TransitionsPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DPCRate = (uint) managementObject.Properties["DPCRate"].Value,
                    DPCsQueuedPersec = (uint) managementObject.Properties["DPCsQueuedPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InterruptsPersec = (uint) managementObject.Properties["InterruptsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PercentC1Time = (ulong) managementObject.Properties["PercentC1Time"].Value,
                    PercentC2Time = (ulong) managementObject.Properties["PercentC2Time"].Value,
                    PercentC3Time = (ulong) managementObject.Properties["PercentC3Time"].Value,
                    PercentDPCTime = (ulong) managementObject.Properties["PercentDPCTime"].Value,
                    PercentIdleTime = (ulong) managementObject.Properties["PercentIdleTime"].Value,
                    PercentInterruptTime = (ulong) managementObject.Properties["PercentInterruptTime"].Value,
                    PercentPrivilegedTime = (ulong) managementObject.Properties["PercentPrivilegedTime"].Value,
                    PercentProcessorTime = (ulong) managementObject.Properties["PercentProcessorTime"].Value,
                    PercentUserTime = (ulong) managementObject.Properties["PercentUserTime"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}