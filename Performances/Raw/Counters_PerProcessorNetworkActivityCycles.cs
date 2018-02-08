using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_PerProcessorNetworkActivityCycles
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

        public static PerfRawData_Counters_PerProcessorNetworkActivityCycles[] Retrieve(string remote, string username,
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

        public static PerfRawData_Counters_PerProcessorNetworkActivityCycles[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_PerProcessorNetworkActivityCycles[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_PerProcessorNetworkActivityCycles");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_PerProcessorNetworkActivityCycles>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_PerProcessorNetworkActivityCycles
                {
                    BuildScatterGatherCyclesPersec =
                        (ulong) managementObject.Properties["BuildScatterGatherCyclesPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InterruptCyclesPersec = (ulong) managementObject.Properties["InterruptCyclesPersec"].Value,
                    InterruptDPCCyclesPersec = (ulong) managementObject.Properties["InterruptDPCCyclesPersec"].Value,
                    InterruptDPCLatencyCyclesPersec =
                        (ulong) managementObject.Properties["InterruptDPCLatencyCyclesPersec"].Value,
                    MiniportReturnPacketCyclesPersec =
                        (ulong) managementObject.Properties["MiniportReturnPacketCyclesPersec"].Value,
                    MiniportRSSIndirectionTableChangeCycles = (ulong) managementObject
                        .Properties["MiniportRSSIndirectionTableChangeCycles"].Value,
                    MiniportSendCyclesPersec = (ulong) managementObject.Properties["MiniportSendCyclesPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NDISReceiveIndicationCyclesPersec =
                        (ulong) managementObject.Properties["NDISReceiveIndicationCyclesPersec"].Value,
                    NDISReturnPacketCyclesPersec = (ulong) managementObject.Properties["NDISReturnPacketCyclesPersec"]
                        .Value,
                    NDISSendCompleteCyclesPersec = (ulong) managementObject.Properties["NDISSendCompleteCyclesPersec"]
                        .Value,
                    NDISSendCyclesPersec = (ulong) managementObject.Properties["NDISSendCyclesPersec"].Value,
                    StackReceiveIndicationCyclesPersec =
                        (ulong) managementObject.Properties["StackReceiveIndicationCyclesPersec"].Value,
                    StackSendCompleteCyclesPersec =
                        (ulong) managementObject.Properties["StackSendCompleteCyclesPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}