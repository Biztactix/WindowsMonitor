using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_HvStats_HyperVHypervisorRootPartition
    {
        public ulong AddressSpaces { get; private set; }
        public ulong AttachedDevices { get; private set; }
        public string Caption { get; private set; }
        public ulong DepositedPages { get; private set; }
        public string Description { get; private set; }
        public ulong DeviceDMAErrors { get; private set; }
        public ulong DeviceInterruptErrors { get; private set; }
        public ulong DeviceInterruptMappings { get; private set; }
        public ulong DeviceInterruptThrottleEvents { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong GPAPages { get; private set; }
        public ulong GPASpaceModificationsPersec { get; private set; }
        public ulong IOTLBFlushCost { get; private set; }
        public ulong IOTLBFlushesPersec { get; private set; }
        public string Name { get; private set; }
        public ulong NestedTLBFreeListSize { get; private set; }
        public ulong NestedTLBSize { get; private set; }
        public ulong NestedTLBTrimmedPagesPersec { get; private set; }
        public ulong RecommendedNestedTLBSize { get; private set; }
        public ulong RecommendedVirtualTLBSize { get; private set; }
        public ulong SkippedTimerTicks { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong Value1Gdevicepages { get; private set; }
        public ulong Value1GGPApages { get; private set; }
        public ulong Value2Mdevicepages { get; private set; }
        public ulong Value2MGPApages { get; private set; }
        public ulong Value4Kdevicepages { get; private set; }
        public ulong Value4KGPApages { get; private set; }
        public ulong VirtualProcessors { get; private set; }
        public ulong VirtualTLBFlushEntiresPersec { get; private set; }
        public ulong VirtualTLBPages { get; private set; }

        public static PerfFormattedData_HvStats_HyperVHypervisorRootPartition[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_HvStats_HyperVHypervisorRootPartition[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_HvStats_HyperVHypervisorRootPartition[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_HvStats_HyperVHypervisorRootPartition");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_HvStats_HyperVHypervisorRootPartition>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_HvStats_HyperVHypervisorRootPartition
                {
                    AddressSpaces = (ulong) managementObject.Properties["AddressSpaces"].Value,
                    AttachedDevices = (ulong) managementObject.Properties["AttachedDevices"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    DepositedPages = (ulong) managementObject.Properties["DepositedPages"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceDMAErrors = (ulong) managementObject.Properties["DeviceDMAErrors"].Value,
                    DeviceInterruptErrors = (ulong) managementObject.Properties["DeviceInterruptErrors"].Value,
                    DeviceInterruptMappings = (ulong) managementObject.Properties["DeviceInterruptMappings"].Value,
                    DeviceInterruptThrottleEvents =
                        (ulong) managementObject.Properties["DeviceInterruptThrottleEvents"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    GPAPages = (ulong) managementObject.Properties["GPAPages"].Value,
                    GPASpaceModificationsPersec = (ulong) managementObject.Properties["GPASpaceModificationsPersec"]
                        .Value,
                    IOTLBFlushCost = (ulong) managementObject.Properties["IOTLBFlushCost"].Value,
                    IOTLBFlushesPersec = (ulong) managementObject.Properties["IOTLBFlushesPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NestedTLBFreeListSize = (ulong) managementObject.Properties["NestedTLBFreeListSize"].Value,
                    NestedTLBSize = (ulong) managementObject.Properties["NestedTLBSize"].Value,
                    NestedTLBTrimmedPagesPersec = (ulong) managementObject.Properties["NestedTLBTrimmedPagesPersec"]
                        .Value,
                    RecommendedNestedTLBSize = (ulong) managementObject.Properties["RecommendedNestedTLBSize"].Value,
                    RecommendedVirtualTLBSize = (ulong) managementObject.Properties["RecommendedVirtualTLBSize"].Value,
                    SkippedTimerTicks = (ulong) managementObject.Properties["SkippedTimerTicks"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    Value1Gdevicepages = (ulong) managementObject.Properties["Value1Gdevicepages"].Value,
                    Value1GGPApages = (ulong) managementObject.Properties["Value1GGPApages"].Value,
                    Value2Mdevicepages = (ulong) managementObject.Properties["Value2Mdevicepages"].Value,
                    Value2MGPApages = (ulong) managementObject.Properties["Value2MGPApages"].Value,
                    Value4Kdevicepages = (ulong) managementObject.Properties["Value4Kdevicepages"].Value,
                    Value4KGPApages = (ulong) managementObject.Properties["Value4KGPApages"].Value,
                    VirtualProcessors = (ulong) managementObject.Properties["VirtualProcessors"].Value,
                    VirtualTLBFlushEntiresPersec = (ulong) managementObject.Properties["VirtualTLBFlushEntiresPersec"]
                        .Value,
                    VirtualTLBPages = (ulong) managementObject.Properties["VirtualTLBPages"].Value
                });

            return list.ToArray();
        }
    }
}