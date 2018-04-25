using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class HvStats_HyperVHypervisorRootPartition
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

        public static IEnumerable<HvStats_HyperVHypervisorRootPartition> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HvStats_HyperVHypervisorRootPartition> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HvStats_HyperVHypervisorRootPartition> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_HvStats_HyperVHypervisorRootPartition");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HvStats_HyperVHypervisorRootPartition
                {
                     AddressSpaces = (ulong) (managementObject.Properties["AddressSpaces"]?.Value ?? default(ulong)),
		 AttachedDevices = (ulong) (managementObject.Properties["AttachedDevices"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 DepositedPages = (ulong) (managementObject.Properties["DepositedPages"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DeviceDMAErrors = (ulong) (managementObject.Properties["DeviceDMAErrors"]?.Value ?? default(ulong)),
		 DeviceInterruptErrors = (ulong) (managementObject.Properties["DeviceInterruptErrors"]?.Value ?? default(ulong)),
		 DeviceInterruptMappings = (ulong) (managementObject.Properties["DeviceInterruptMappings"]?.Value ?? default(ulong)),
		 DeviceInterruptThrottleEvents = (ulong) (managementObject.Properties["DeviceInterruptThrottleEvents"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 GPAPages = (ulong) (managementObject.Properties["GPAPages"]?.Value ?? default(ulong)),
		 GPASpaceModificationsPersec = (ulong) (managementObject.Properties["GPASpaceModificationsPersec"]?.Value ?? default(ulong)),
		 IOTLBFlushCost = (ulong) (managementObject.Properties["IOTLBFlushCost"]?.Value ?? default(ulong)),
		 IOTLBFlushesPersec = (ulong) (managementObject.Properties["IOTLBFlushesPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NestedTLBFreeListSize = (ulong) (managementObject.Properties["NestedTLBFreeListSize"]?.Value ?? default(ulong)),
		 NestedTLBSize = (ulong) (managementObject.Properties["NestedTLBSize"]?.Value ?? default(ulong)),
		 NestedTLBTrimmedPagesPersec = (ulong) (managementObject.Properties["NestedTLBTrimmedPagesPersec"]?.Value ?? default(ulong)),
		 RecommendedNestedTLBSize = (ulong) (managementObject.Properties["RecommendedNestedTLBSize"]?.Value ?? default(ulong)),
		 RecommendedVirtualTLBSize = (ulong) (managementObject.Properties["RecommendedVirtualTLBSize"]?.Value ?? default(ulong)),
		 SkippedTimerTicks = (ulong) (managementObject.Properties["SkippedTimerTicks"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 Value1Gdevicepages = (ulong) (managementObject.Properties["Value1Gdevicepages"]?.Value ?? default(ulong)),
		 Value1GGPApages = (ulong) (managementObject.Properties["Value1GGPApages"]?.Value ?? default(ulong)),
		 Value2Mdevicepages = (ulong) (managementObject.Properties["Value2Mdevicepages"]?.Value ?? default(ulong)),
		 Value2MGPApages = (ulong) (managementObject.Properties["Value2MGPApages"]?.Value ?? default(ulong)),
		 Value4Kdevicepages = (ulong) (managementObject.Properties["Value4Kdevicepages"]?.Value ?? default(ulong)),
		 Value4KGPApages = (ulong) (managementObject.Properties["Value4KGPApages"]?.Value ?? default(ulong)),
		 VirtualProcessors = (ulong) (managementObject.Properties["VirtualProcessors"]?.Value ?? default(ulong)),
		 VirtualTLBFlushEntiresPersec = (ulong) (managementObject.Properties["VirtualTLBFlushEntiresPersec"]?.Value ?? default(ulong)),
		 VirtualTLBPages = (ulong) (managementObject.Properties["VirtualTLBPages"]?.Value ?? default(ulong))
                };
        }
    }
}