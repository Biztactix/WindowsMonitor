using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class HvStats_HyperVHypervisorRootVirtualProcessor
    {
		public ulong AddressDomainFlushesPersec { get; private set; }
		public ulong AddressSpaceEvictionsPersec { get; private set; }
		public ulong AddressSpaceFlushesPersec { get; private set; }
		public ulong AddressSpaceSwitchesPersec { get; private set; }
		public ulong APICEOIAccessesPersec { get; private set; }
		public ulong APICIPIsSentPersec { get; private set; }
		public ulong APICMMIOAccessesPersec { get; private set; }
		public ulong APICSelfIPIsSentPersec { get; private set; }
		public ulong APICTPRAccessesPersec { get; private set; }
		public string Caption { get; private set; }
		public ulong ControlRegisterAccessesCost { get; private set; }
		public ulong ControlRegisterAccessesForwardedPersec { get; private set; }
		public ulong ControlRegisterAccessesForwardingCost { get; private set; }
		public ulong ControlRegisterAccessesPersec { get; private set; }
		public ulong CPUIDInstructionsCost { get; private set; }
		public ulong CPUIDInstructionsForwardedPersec { get; private set; }
		public ulong CPUIDInstructionsForwardingCost { get; private set; }
		public ulong CPUIDInstructionsPersec { get; private set; }
		public ulong CPUWaitTimePerDispatch { get; private set; }
		public ulong DebugRegisterAccessesCost { get; private set; }
		public ulong DebugRegisterAccessesForwardedPersec { get; private set; }
		public ulong DebugRegisterAccessesForwardingCost { get; private set; }
		public ulong DebugRegisterAccessesPersec { get; private set; }
		public string Description { get; private set; }
		public ulong EmulatedInstructionsCost { get; private set; }
		public ulong EmulatedInstructionsForwardedPersec { get; private set; }
		public ulong EmulatedInstructionsForwardingCost { get; private set; }
		public ulong EmulatedInstructionsPersec { get; private set; }
		public ulong ExtendedHypercallInterceptMessagesPersec { get; private set; }
		public ulong ExtendedHypercallsPersec { get; private set; }
		public ulong ExternalInterruptsCost { get; private set; }
		public ulong ExternalInterruptsForwardedPersec { get; private set; }
		public ulong ExternalInterruptsPersec { get; private set; }
		public ulong FlushPhysicalAddressListHypercallsPersec { get; private set; }
		public ulong FlushPhysicalAddressSpaceHypercallsPersec { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong GlobalGVARangeFlushesPersec { get; private set; }
		public ulong GlobalIOTLBFlushCost { get; private set; }
		public ulong GlobalIOTLBFlushesPersec { get; private set; }
		public ulong GPASpaceHypercallsPersec { get; private set; }
		public ulong GuestPageTableMapsPersec { get; private set; }
		public ulong HardwareInterruptsPersec { get; private set; }
		public ulong HLTInstructionsCost { get; private set; }
		public ulong HLTInstructionsForwardedPersec { get; private set; }
		public ulong HLTInstructionsForwardingCost { get; private set; }
		public ulong HLTInstructionsPersec { get; private set; }
		public ulong HypercallsCost { get; private set; }
		public ulong HypercallsForwardedPersec { get; private set; }
		public ulong HypercallsForwardingCost { get; private set; }
		public ulong HypercallsPersec { get; private set; }
		public ulong InvEptAllContextEmulationInterceptsPersec { get; private set; }
		public ulong InvEptAllContextInstructionEmulationCost { get; private set; }
		public ulong InvEptSingleContextEmulationInterceptsPersec { get; private set; }
		public ulong InvEptSingleContextInstructionEmulationCost { get; private set; }
		public ulong InvVpidAllContextEmulationInterceptsPersec { get; private set; }
		public ulong InvVpidAllContextInstructionEmulationCost { get; private set; }
		public ulong InvVpidSingleAddressEmulationInterceptsPersec { get; private set; }
		public ulong InvVpidSingleAddressInstructionEmulationCost { get; private set; }
		public ulong InvVpidSingleContextEmulationInterceptsPersec { get; private set; }
		public ulong InvVpidSingleContextInstructionEmulationCost { get; private set; }
		public ulong IOInstructionsCost { get; private set; }
		public ulong IOInstructionsForwardedPersec { get; private set; }
		public ulong IOInstructionsForwardingCost { get; private set; }
		public ulong IOInstructionsPersec { get; private set; }
		public ulong IOInterceptMessagesPersec { get; private set; }
		public ulong LargePageTLBFillsPersec { get; private set; }
		public ulong LocalFlushedGVARangesPersec { get; private set; }
		public ulong LocalIOTLBFlushCost { get; private set; }
		public ulong LocalIOTLBFlushesPersec { get; private set; }
		public ulong LogicalProcessorDispatchesPersec { get; private set; }
		public ulong LogicalProcessorHypercallsPersec { get; private set; }
		public ulong LogicalProcessorMigrationsPersec { get; private set; }
		public ulong LongSpinWaitHypercallsPersec { get; private set; }
		public ulong MBECNestedPageTableSwitchesPersec { get; private set; }
		public ulong MemoryInterceptMessagesPersec { get; private set; }
		public ulong MSRAccessesCost { get; private set; }
		public ulong MSRAccessesForwardedPersec { get; private set; }
		public ulong MSRAccessesForwardingCost { get; private set; }
		public ulong MSRAccessesPersec { get; private set; }
		public ulong MWAITInstructionsCost { get; private set; }
		public ulong MWAITInstructionsForwardedPersec { get; private set; }
		public ulong MWAITInstructionsForwardingCost { get; private set; }
		public ulong MWAITInstructionsPersec { get; private set; }
		public string Name { get; private set; }
		public ulong NestedPageFaultInterceptsCost { get; private set; }
		public ulong NestedPageFaultInterceptsPersec { get; private set; }
		public ulong NestedSLATHardPageFaultsCost { get; private set; }
		public ulong NestedSLATHardPageFaultsPersec { get; private set; }
		public ulong NestedSLATSoftPageFaultsCost { get; private set; }
		public ulong NestedSLATSoftPageFaultsPersec { get; private set; }
		public ulong NestedTLBPageTableEvictionsPersec { get; private set; }
		public ulong NestedTLBPageTableReclamationsPersec { get; private set; }
		public ulong NestedVMEntriesCost { get; private set; }
		public ulong NestedVMEntriesPersec { get; private set; }
		public ulong OtherHypercallsPersec { get; private set; }
		public ulong OtherInterceptsCost { get; private set; }
		public ulong OtherInterceptsForwardedPersec { get; private set; }
		public ulong OtherInterceptsForwardingCost { get; private set; }
		public ulong OtherInterceptsPersec { get; private set; }
		public ulong OtherMessagesPersec { get; private set; }
		public ulong OtherReflectedGuestExceptionsPersec { get; private set; }
		public ulong PageFaultInterceptsCost { get; private set; }
		public ulong PageFaultInterceptsForwardedPersec { get; private set; }
		public ulong PageFaultInterceptsForwardingCost { get; private set; }
		public ulong PageFaultInterceptsPersec { get; private set; }
		public ulong PageInvalidationsCost { get; private set; }
		public ulong PageInvalidationsForwardedPersec { get; private set; }
		public ulong PageInvalidationsForwardingCost { get; private set; }
		public ulong PageInvalidationsPersec { get; private set; }
		public ulong PageTableAllocationsPersec { get; private set; }
		public ulong PageTableEvictionsPersec { get; private set; }
		public ulong PageTableReclamationsPersec { get; private set; }
		public ulong PageTableResetsPersec { get; private set; }
		public ulong PageTableValidationsPersec { get; private set; }
		public ulong PageTableWriteInterceptsPersec { get; private set; }
		public ulong PendingInterruptsCost { get; private set; }
		public ulong PendingInterruptsForwardedPersec { get; private set; }
		public ulong PendingInterruptsForwardingCost { get; private set; }
		public ulong PendingInterruptsPersec { get; private set; }
		public ulong PercentGuestRunTime { get; private set; }
		public ulong PercentHypervisorRunTime { get; private set; }
		public ulong PercentRemoteRunTime { get; private set; }
		public ulong PercentTotalRunTime { get; private set; }
		public ulong ReflectedGuestPageFaultsPersec { get; private set; }
		public ulong SmallPageTLBFillsPersec { get; private set; }
		public ulong SyntheticInterruptHypercallsPersec { get; private set; }
		public ulong SyntheticInterruptsPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong TotalInterceptsCost { get; private set; }
		public ulong TotalInterceptsPersec { get; private set; }
		public ulong TotalMessagesPersec { get; private set; }
		public ulong TotalVirtualizationInstructionsEmulatedPersec { get; private set; }
		public ulong TotalVirtualizationInstructionsEmulationCost { get; private set; }
		public ulong VirtualInterruptHypercallsPersec { get; private set; }
		public ulong VirtualInterruptsPersec { get; private set; }
		public ulong VirtualMMUHypercallsPersec { get; private set; }
		public ulong VirtualProcessorHypercallsPersec { get; private set; }
		public ulong VMCLEAREmulationInterceptsPersec { get; private set; }
		public ulong VMCLEARInstructionEmulationCost { get; private set; }
		public ulong VMPTRLDEmulationInterceptsPersec { get; private set; }
		public ulong VMPTRLDInstructionEmulationCost { get; private set; }
		public ulong VMPTRSTEmulationInterceptsPersec { get; private set; }
		public ulong VMPTRSTInstructionEmulationCost { get; private set; }
		public ulong VMREADEmulationInterceptsPersec { get; private set; }
		public ulong VMREADInstructionEmulationCost { get; private set; }
		public ulong VMWRITEEmulationInterceptsPersec { get; private set; }
		public ulong VMWRITEInstructionEmulationCost { get; private set; }
		public ulong VMXOFFEmulationInterceptsPersec { get; private set; }
		public ulong VMXOFFInstructionEmulationCost { get; private set; }
		public ulong VMXONEmulationInterceptsPersec { get; private set; }
		public ulong VMXONInstructionEmulationCost { get; private set; }

        public static IEnumerable<HvStats_HyperVHypervisorRootVirtualProcessor> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HvStats_HyperVHypervisorRootVirtualProcessor> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HvStats_HyperVHypervisorRootVirtualProcessor> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_HvStats_HyperVHypervisorRootVirtualProcessor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HvStats_HyperVHypervisorRootVirtualProcessor
                {
                     AddressDomainFlushesPersec = (ulong) (managementObject.Properties["AddressDomainFlushesPersec"]?.Value ?? default(ulong)),
		 AddressSpaceEvictionsPersec = (ulong) (managementObject.Properties["AddressSpaceEvictionsPersec"]?.Value ?? default(ulong)),
		 AddressSpaceFlushesPersec = (ulong) (managementObject.Properties["AddressSpaceFlushesPersec"]?.Value ?? default(ulong)),
		 AddressSpaceSwitchesPersec = (ulong) (managementObject.Properties["AddressSpaceSwitchesPersec"]?.Value ?? default(ulong)),
		 APICEOIAccessesPersec = (ulong) (managementObject.Properties["APICEOIAccessesPersec"]?.Value ?? default(ulong)),
		 APICIPIsSentPersec = (ulong) (managementObject.Properties["APICIPIsSentPersec"]?.Value ?? default(ulong)),
		 APICMMIOAccessesPersec = (ulong) (managementObject.Properties["APICMMIOAccessesPersec"]?.Value ?? default(ulong)),
		 APICSelfIPIsSentPersec = (ulong) (managementObject.Properties["APICSelfIPIsSentPersec"]?.Value ?? default(ulong)),
		 APICTPRAccessesPersec = (ulong) (managementObject.Properties["APICTPRAccessesPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ControlRegisterAccessesCost = (ulong) (managementObject.Properties["ControlRegisterAccessesCost"]?.Value ?? default(ulong)),
		 ControlRegisterAccessesForwardedPersec = (ulong) (managementObject.Properties["ControlRegisterAccessesForwardedPersec"]?.Value ?? default(ulong)),
		 ControlRegisterAccessesForwardingCost = (ulong) (managementObject.Properties["ControlRegisterAccessesForwardingCost"]?.Value ?? default(ulong)),
		 ControlRegisterAccessesPersec = (ulong) (managementObject.Properties["ControlRegisterAccessesPersec"]?.Value ?? default(ulong)),
		 CPUIDInstructionsCost = (ulong) (managementObject.Properties["CPUIDInstructionsCost"]?.Value ?? default(ulong)),
		 CPUIDInstructionsForwardedPersec = (ulong) (managementObject.Properties["CPUIDInstructionsForwardedPersec"]?.Value ?? default(ulong)),
		 CPUIDInstructionsForwardingCost = (ulong) (managementObject.Properties["CPUIDInstructionsForwardingCost"]?.Value ?? default(ulong)),
		 CPUIDInstructionsPersec = (ulong) (managementObject.Properties["CPUIDInstructionsPersec"]?.Value ?? default(ulong)),
		 CPUWaitTimePerDispatch = (ulong) (managementObject.Properties["CPUWaitTimePerDispatch"]?.Value ?? default(ulong)),
		 DebugRegisterAccessesCost = (ulong) (managementObject.Properties["DebugRegisterAccessesCost"]?.Value ?? default(ulong)),
		 DebugRegisterAccessesForwardedPersec = (ulong) (managementObject.Properties["DebugRegisterAccessesForwardedPersec"]?.Value ?? default(ulong)),
		 DebugRegisterAccessesForwardingCost = (ulong) (managementObject.Properties["DebugRegisterAccessesForwardingCost"]?.Value ?? default(ulong)),
		 DebugRegisterAccessesPersec = (ulong) (managementObject.Properties["DebugRegisterAccessesPersec"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 EmulatedInstructionsCost = (ulong) (managementObject.Properties["EmulatedInstructionsCost"]?.Value ?? default(ulong)),
		 EmulatedInstructionsForwardedPersec = (ulong) (managementObject.Properties["EmulatedInstructionsForwardedPersec"]?.Value ?? default(ulong)),
		 EmulatedInstructionsForwardingCost = (ulong) (managementObject.Properties["EmulatedInstructionsForwardingCost"]?.Value ?? default(ulong)),
		 EmulatedInstructionsPersec = (ulong) (managementObject.Properties["EmulatedInstructionsPersec"]?.Value ?? default(ulong)),
		 ExtendedHypercallInterceptMessagesPersec = (ulong) (managementObject.Properties["ExtendedHypercallInterceptMessagesPersec"]?.Value ?? default(ulong)),
		 ExtendedHypercallsPersec = (ulong) (managementObject.Properties["ExtendedHypercallsPersec"]?.Value ?? default(ulong)),
		 ExternalInterruptsCost = (ulong) (managementObject.Properties["ExternalInterruptsCost"]?.Value ?? default(ulong)),
		 ExternalInterruptsForwardedPersec = (ulong) (managementObject.Properties["ExternalInterruptsForwardedPersec"]?.Value ?? default(ulong)),
		 ExternalInterruptsPersec = (ulong) (managementObject.Properties["ExternalInterruptsPersec"]?.Value ?? default(ulong)),
		 FlushPhysicalAddressListHypercallsPersec = (ulong) (managementObject.Properties["FlushPhysicalAddressListHypercallsPersec"]?.Value ?? default(ulong)),
		 FlushPhysicalAddressSpaceHypercallsPersec = (ulong) (managementObject.Properties["FlushPhysicalAddressSpaceHypercallsPersec"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 GlobalGVARangeFlushesPersec = (ulong) (managementObject.Properties["GlobalGVARangeFlushesPersec"]?.Value ?? default(ulong)),
		 GlobalIOTLBFlushCost = (ulong) (managementObject.Properties["GlobalIOTLBFlushCost"]?.Value ?? default(ulong)),
		 GlobalIOTLBFlushesPersec = (ulong) (managementObject.Properties["GlobalIOTLBFlushesPersec"]?.Value ?? default(ulong)),
		 GPASpaceHypercallsPersec = (ulong) (managementObject.Properties["GPASpaceHypercallsPersec"]?.Value ?? default(ulong)),
		 GuestPageTableMapsPersec = (ulong) (managementObject.Properties["GuestPageTableMapsPersec"]?.Value ?? default(ulong)),
		 HardwareInterruptsPersec = (ulong) (managementObject.Properties["HardwareInterruptsPersec"]?.Value ?? default(ulong)),
		 HLTInstructionsCost = (ulong) (managementObject.Properties["HLTInstructionsCost"]?.Value ?? default(ulong)),
		 HLTInstructionsForwardedPersec = (ulong) (managementObject.Properties["HLTInstructionsForwardedPersec"]?.Value ?? default(ulong)),
		 HLTInstructionsForwardingCost = (ulong) (managementObject.Properties["HLTInstructionsForwardingCost"]?.Value ?? default(ulong)),
		 HLTInstructionsPersec = (ulong) (managementObject.Properties["HLTInstructionsPersec"]?.Value ?? default(ulong)),
		 HypercallsCost = (ulong) (managementObject.Properties["HypercallsCost"]?.Value ?? default(ulong)),
		 HypercallsForwardedPersec = (ulong) (managementObject.Properties["HypercallsForwardedPersec"]?.Value ?? default(ulong)),
		 HypercallsForwardingCost = (ulong) (managementObject.Properties["HypercallsForwardingCost"]?.Value ?? default(ulong)),
		 HypercallsPersec = (ulong) (managementObject.Properties["HypercallsPersec"]?.Value ?? default(ulong)),
		 InvEptAllContextEmulationInterceptsPersec = (ulong) (managementObject.Properties["InvEptAllContextEmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 InvEptAllContextInstructionEmulationCost = (ulong) (managementObject.Properties["InvEptAllContextInstructionEmulationCost"]?.Value ?? default(ulong)),
		 InvEptSingleContextEmulationInterceptsPersec = (ulong) (managementObject.Properties["InvEptSingleContextEmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 InvEptSingleContextInstructionEmulationCost = (ulong) (managementObject.Properties["InvEptSingleContextInstructionEmulationCost"]?.Value ?? default(ulong)),
		 InvVpidAllContextEmulationInterceptsPersec = (ulong) (managementObject.Properties["InvVpidAllContextEmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 InvVpidAllContextInstructionEmulationCost = (ulong) (managementObject.Properties["InvVpidAllContextInstructionEmulationCost"]?.Value ?? default(ulong)),
		 InvVpidSingleAddressEmulationInterceptsPersec = (ulong) (managementObject.Properties["InvVpidSingleAddressEmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 InvVpidSingleAddressInstructionEmulationCost = (ulong) (managementObject.Properties["InvVpidSingleAddressInstructionEmulationCost"]?.Value ?? default(ulong)),
		 InvVpidSingleContextEmulationInterceptsPersec = (ulong) (managementObject.Properties["InvVpidSingleContextEmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 InvVpidSingleContextInstructionEmulationCost = (ulong) (managementObject.Properties["InvVpidSingleContextInstructionEmulationCost"]?.Value ?? default(ulong)),
		 IOInstructionsCost = (ulong) (managementObject.Properties["IOInstructionsCost"]?.Value ?? default(ulong)),
		 IOInstructionsForwardedPersec = (ulong) (managementObject.Properties["IOInstructionsForwardedPersec"]?.Value ?? default(ulong)),
		 IOInstructionsForwardingCost = (ulong) (managementObject.Properties["IOInstructionsForwardingCost"]?.Value ?? default(ulong)),
		 IOInstructionsPersec = (ulong) (managementObject.Properties["IOInstructionsPersec"]?.Value ?? default(ulong)),
		 IOInterceptMessagesPersec = (ulong) (managementObject.Properties["IOInterceptMessagesPersec"]?.Value ?? default(ulong)),
		 LargePageTLBFillsPersec = (ulong) (managementObject.Properties["LargePageTLBFillsPersec"]?.Value ?? default(ulong)),
		 LocalFlushedGVARangesPersec = (ulong) (managementObject.Properties["LocalFlushedGVARangesPersec"]?.Value ?? default(ulong)),
		 LocalIOTLBFlushCost = (ulong) (managementObject.Properties["LocalIOTLBFlushCost"]?.Value ?? default(ulong)),
		 LocalIOTLBFlushesPersec = (ulong) (managementObject.Properties["LocalIOTLBFlushesPersec"]?.Value ?? default(ulong)),
		 LogicalProcessorDispatchesPersec = (ulong) (managementObject.Properties["LogicalProcessorDispatchesPersec"]?.Value ?? default(ulong)),
		 LogicalProcessorHypercallsPersec = (ulong) (managementObject.Properties["LogicalProcessorHypercallsPersec"]?.Value ?? default(ulong)),
		 LogicalProcessorMigrationsPersec = (ulong) (managementObject.Properties["LogicalProcessorMigrationsPersec"]?.Value ?? default(ulong)),
		 LongSpinWaitHypercallsPersec = (ulong) (managementObject.Properties["LongSpinWaitHypercallsPersec"]?.Value ?? default(ulong)),
		 MBECNestedPageTableSwitchesPersec = (ulong) (managementObject.Properties["MBECNestedPageTableSwitchesPersec"]?.Value ?? default(ulong)),
		 MemoryInterceptMessagesPersec = (ulong) (managementObject.Properties["MemoryInterceptMessagesPersec"]?.Value ?? default(ulong)),
		 MSRAccessesCost = (ulong) (managementObject.Properties["MSRAccessesCost"]?.Value ?? default(ulong)),
		 MSRAccessesForwardedPersec = (ulong) (managementObject.Properties["MSRAccessesForwardedPersec"]?.Value ?? default(ulong)),
		 MSRAccessesForwardingCost = (ulong) (managementObject.Properties["MSRAccessesForwardingCost"]?.Value ?? default(ulong)),
		 MSRAccessesPersec = (ulong) (managementObject.Properties["MSRAccessesPersec"]?.Value ?? default(ulong)),
		 MWAITInstructionsCost = (ulong) (managementObject.Properties["MWAITInstructionsCost"]?.Value ?? default(ulong)),
		 MWAITInstructionsForwardedPersec = (ulong) (managementObject.Properties["MWAITInstructionsForwardedPersec"]?.Value ?? default(ulong)),
		 MWAITInstructionsForwardingCost = (ulong) (managementObject.Properties["MWAITInstructionsForwardingCost"]?.Value ?? default(ulong)),
		 MWAITInstructionsPersec = (ulong) (managementObject.Properties["MWAITInstructionsPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NestedPageFaultInterceptsCost = (ulong) (managementObject.Properties["NestedPageFaultInterceptsCost"]?.Value ?? default(ulong)),
		 NestedPageFaultInterceptsPersec = (ulong) (managementObject.Properties["NestedPageFaultInterceptsPersec"]?.Value ?? default(ulong)),
		 NestedSLATHardPageFaultsCost = (ulong) (managementObject.Properties["NestedSLATHardPageFaultsCost"]?.Value ?? default(ulong)),
		 NestedSLATHardPageFaultsPersec = (ulong) (managementObject.Properties["NestedSLATHardPageFaultsPersec"]?.Value ?? default(ulong)),
		 NestedSLATSoftPageFaultsCost = (ulong) (managementObject.Properties["NestedSLATSoftPageFaultsCost"]?.Value ?? default(ulong)),
		 NestedSLATSoftPageFaultsPersec = (ulong) (managementObject.Properties["NestedSLATSoftPageFaultsPersec"]?.Value ?? default(ulong)),
		 NestedTLBPageTableEvictionsPersec = (ulong) (managementObject.Properties["NestedTLBPageTableEvictionsPersec"]?.Value ?? default(ulong)),
		 NestedTLBPageTableReclamationsPersec = (ulong) (managementObject.Properties["NestedTLBPageTableReclamationsPersec"]?.Value ?? default(ulong)),
		 NestedVMEntriesCost = (ulong) (managementObject.Properties["NestedVMEntriesCost"]?.Value ?? default(ulong)),
		 NestedVMEntriesPersec = (ulong) (managementObject.Properties["NestedVMEntriesPersec"]?.Value ?? default(ulong)),
		 OtherHypercallsPersec = (ulong) (managementObject.Properties["OtherHypercallsPersec"]?.Value ?? default(ulong)),
		 OtherInterceptsCost = (ulong) (managementObject.Properties["OtherInterceptsCost"]?.Value ?? default(ulong)),
		 OtherInterceptsForwardedPersec = (ulong) (managementObject.Properties["OtherInterceptsForwardedPersec"]?.Value ?? default(ulong)),
		 OtherInterceptsForwardingCost = (ulong) (managementObject.Properties["OtherInterceptsForwardingCost"]?.Value ?? default(ulong)),
		 OtherInterceptsPersec = (ulong) (managementObject.Properties["OtherInterceptsPersec"]?.Value ?? default(ulong)),
		 OtherMessagesPersec = (ulong) (managementObject.Properties["OtherMessagesPersec"]?.Value ?? default(ulong)),
		 OtherReflectedGuestExceptionsPersec = (ulong) (managementObject.Properties["OtherReflectedGuestExceptionsPersec"]?.Value ?? default(ulong)),
		 PageFaultInterceptsCost = (ulong) (managementObject.Properties["PageFaultInterceptsCost"]?.Value ?? default(ulong)),
		 PageFaultInterceptsForwardedPersec = (ulong) (managementObject.Properties["PageFaultInterceptsForwardedPersec"]?.Value ?? default(ulong)),
		 PageFaultInterceptsForwardingCost = (ulong) (managementObject.Properties["PageFaultInterceptsForwardingCost"]?.Value ?? default(ulong)),
		 PageFaultInterceptsPersec = (ulong) (managementObject.Properties["PageFaultInterceptsPersec"]?.Value ?? default(ulong)),
		 PageInvalidationsCost = (ulong) (managementObject.Properties["PageInvalidationsCost"]?.Value ?? default(ulong)),
		 PageInvalidationsForwardedPersec = (ulong) (managementObject.Properties["PageInvalidationsForwardedPersec"]?.Value ?? default(ulong)),
		 PageInvalidationsForwardingCost = (ulong) (managementObject.Properties["PageInvalidationsForwardingCost"]?.Value ?? default(ulong)),
		 PageInvalidationsPersec = (ulong) (managementObject.Properties["PageInvalidationsPersec"]?.Value ?? default(ulong)),
		 PageTableAllocationsPersec = (ulong) (managementObject.Properties["PageTableAllocationsPersec"]?.Value ?? default(ulong)),
		 PageTableEvictionsPersec = (ulong) (managementObject.Properties["PageTableEvictionsPersec"]?.Value ?? default(ulong)),
		 PageTableReclamationsPersec = (ulong) (managementObject.Properties["PageTableReclamationsPersec"]?.Value ?? default(ulong)),
		 PageTableResetsPersec = (ulong) (managementObject.Properties["PageTableResetsPersec"]?.Value ?? default(ulong)),
		 PageTableValidationsPersec = (ulong) (managementObject.Properties["PageTableValidationsPersec"]?.Value ?? default(ulong)),
		 PageTableWriteInterceptsPersec = (ulong) (managementObject.Properties["PageTableWriteInterceptsPersec"]?.Value ?? default(ulong)),
		 PendingInterruptsCost = (ulong) (managementObject.Properties["PendingInterruptsCost"]?.Value ?? default(ulong)),
		 PendingInterruptsForwardedPersec = (ulong) (managementObject.Properties["PendingInterruptsForwardedPersec"]?.Value ?? default(ulong)),
		 PendingInterruptsForwardingCost = (ulong) (managementObject.Properties["PendingInterruptsForwardingCost"]?.Value ?? default(ulong)),
		 PendingInterruptsPersec = (ulong) (managementObject.Properties["PendingInterruptsPersec"]?.Value ?? default(ulong)),
		 PercentGuestRunTime = (ulong) (managementObject.Properties["PercentGuestRunTime"]?.Value ?? default(ulong)),
		 PercentHypervisorRunTime = (ulong) (managementObject.Properties["PercentHypervisorRunTime"]?.Value ?? default(ulong)),
		 PercentRemoteRunTime = (ulong) (managementObject.Properties["PercentRemoteRunTime"]?.Value ?? default(ulong)),
		 PercentTotalRunTime = (ulong) (managementObject.Properties["PercentTotalRunTime"]?.Value ?? default(ulong)),
		 ReflectedGuestPageFaultsPersec = (ulong) (managementObject.Properties["ReflectedGuestPageFaultsPersec"]?.Value ?? default(ulong)),
		 SmallPageTLBFillsPersec = (ulong) (managementObject.Properties["SmallPageTLBFillsPersec"]?.Value ?? default(ulong)),
		 SyntheticInterruptHypercallsPersec = (ulong) (managementObject.Properties["SyntheticInterruptHypercallsPersec"]?.Value ?? default(ulong)),
		 SyntheticInterruptsPersec = (ulong) (managementObject.Properties["SyntheticInterruptsPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalInterceptsCost = (ulong) (managementObject.Properties["TotalInterceptsCost"]?.Value ?? default(ulong)),
		 TotalInterceptsPersec = (ulong) (managementObject.Properties["TotalInterceptsPersec"]?.Value ?? default(ulong)),
		 TotalMessagesPersec = (ulong) (managementObject.Properties["TotalMessagesPersec"]?.Value ?? default(ulong)),
		 TotalVirtualizationInstructionsEmulatedPersec = (ulong) (managementObject.Properties["TotalVirtualizationInstructionsEmulatedPersec"]?.Value ?? default(ulong)),
		 TotalVirtualizationInstructionsEmulationCost = (ulong) (managementObject.Properties["TotalVirtualizationInstructionsEmulationCost"]?.Value ?? default(ulong)),
		 VirtualInterruptHypercallsPersec = (ulong) (managementObject.Properties["VirtualInterruptHypercallsPersec"]?.Value ?? default(ulong)),
		 VirtualInterruptsPersec = (ulong) (managementObject.Properties["VirtualInterruptsPersec"]?.Value ?? default(ulong)),
		 VirtualMMUHypercallsPersec = (ulong) (managementObject.Properties["VirtualMMUHypercallsPersec"]?.Value ?? default(ulong)),
		 VirtualProcessorHypercallsPersec = (ulong) (managementObject.Properties["VirtualProcessorHypercallsPersec"]?.Value ?? default(ulong)),
		 VMCLEAREmulationInterceptsPersec = (ulong) (managementObject.Properties["VMCLEAREmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 VMCLEARInstructionEmulationCost = (ulong) (managementObject.Properties["VMCLEARInstructionEmulationCost"]?.Value ?? default(ulong)),
		 VMPTRLDEmulationInterceptsPersec = (ulong) (managementObject.Properties["VMPTRLDEmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 VMPTRLDInstructionEmulationCost = (ulong) (managementObject.Properties["VMPTRLDInstructionEmulationCost"]?.Value ?? default(ulong)),
		 VMPTRSTEmulationInterceptsPersec = (ulong) (managementObject.Properties["VMPTRSTEmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 VMPTRSTInstructionEmulationCost = (ulong) (managementObject.Properties["VMPTRSTInstructionEmulationCost"]?.Value ?? default(ulong)),
		 VMREADEmulationInterceptsPersec = (ulong) (managementObject.Properties["VMREADEmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 VMREADInstructionEmulationCost = (ulong) (managementObject.Properties["VMREADInstructionEmulationCost"]?.Value ?? default(ulong)),
		 VMWRITEEmulationInterceptsPersec = (ulong) (managementObject.Properties["VMWRITEEmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 VMWRITEInstructionEmulationCost = (ulong) (managementObject.Properties["VMWRITEInstructionEmulationCost"]?.Value ?? default(ulong)),
		 VMXOFFEmulationInterceptsPersec = (ulong) (managementObject.Properties["VMXOFFEmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 VMXOFFInstructionEmulationCost = (ulong) (managementObject.Properties["VMXOFFInstructionEmulationCost"]?.Value ?? default(ulong)),
		 VMXONEmulationInterceptsPersec = (ulong) (managementObject.Properties["VMXONEmulationInterceptsPersec"]?.Value ?? default(ulong)),
		 VMXONInstructionEmulationCost = (ulong) (managementObject.Properties["VMXONInstructionEmulationCost"]?.Value ?? default(ulong))
                };
        }
    }
}