using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_HvStats_HyperVHypervisorRootVirtualProcessor
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
        public ulong ControlRegisterAccessesCost_Base { get; private set; }
        public ulong ControlRegisterAccessesForwardedPersec { get; private set; }
        public ulong ControlRegisterAccessesForwardingCost { get; private set; }
        public ulong ControlRegisterAccessesForwardingCost_Base { get; private set; }
        public ulong ControlRegisterAccessesPersec { get; private set; }
        public ulong CPUIDInstructionsCost { get; private set; }
        public ulong CPUIDInstructionsCost_Base { get; private set; }
        public ulong CPUIDInstructionsForwardedPersec { get; private set; }
        public ulong CPUIDInstructionsForwardingCost { get; private set; }
        public ulong CPUIDInstructionsForwardingCost_Base { get; private set; }
        public ulong CPUIDInstructionsPersec { get; private set; }
        public ulong CPUWaitTimePerDispatch { get; private set; }
        public ulong CPUWaitTimePerDispatch_Base { get; private set; }
        public ulong DebugRegisterAccessesCost { get; private set; }
        public ulong DebugRegisterAccessesCost_Base { get; private set; }
        public ulong DebugRegisterAccessesForwardedPersec { get; private set; }
        public ulong DebugRegisterAccessesForwardingCost { get; private set; }
        public ulong DebugRegisterAccessesForwardingCost_Base { get; private set; }
        public ulong DebugRegisterAccessesPersec { get; private set; }
        public string Description { get; private set; }
        public ulong EmulatedInstructionsCost { get; private set; }
        public ulong EmulatedInstructionsCost_Base { get; private set; }
        public ulong EmulatedInstructionsForwardedPersec { get; private set; }
        public ulong EmulatedInstructionsForwardingCost { get; private set; }
        public ulong EmulatedInstructionsForwardingCost_Base { get; private set; }
        public ulong EmulatedInstructionsPersec { get; private set; }
        public ulong ExtendedHypercallInterceptMessagesPersec { get; private set; }
        public ulong ExtendedHypercallsPersec { get; private set; }
        public ulong ExternalInterruptsCost { get; private set; }
        public ulong ExternalInterruptsCost_Base { get; private set; }
        public ulong ExternalInterruptsForwardedPersec { get; private set; }
        public ulong ExternalInterruptsPersec { get; private set; }
        public ulong FlushPhysicalAddressListHypercallsPersec { get; private set; }
        public ulong FlushPhysicalAddressSpaceHypercallsPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong GlobalGVARangeFlushesPersec { get; private set; }
        public ulong GlobalIOTLBFlushCost { get; private set; }
        public ulong GlobalIOTLBFlushCost_Base { get; private set; }
        public ulong GlobalIOTLBFlushesPersec { get; private set; }
        public ulong GPASpaceHypercallsPersec { get; private set; }
        public ulong GuestPageTableMapsPersec { get; private set; }
        public ulong HardwareInterruptsPersec { get; private set; }
        public ulong HLTInstructionsCost { get; private set; }
        public ulong HLTInstructionsCost_Base { get; private set; }
        public ulong HLTInstructionsForwardedPersec { get; private set; }
        public ulong HLTInstructionsForwardingCost { get; private set; }
        public ulong HLTInstructionsForwardingCost_Base { get; private set; }
        public ulong HLTInstructionsPersec { get; private set; }
        public ulong HypercallsCost { get; private set; }
        public ulong HypercallsCost_Base { get; private set; }
        public ulong HypercallsForwardedPersec { get; private set; }
        public ulong HypercallsForwardingCost { get; private set; }
        public ulong HypercallsForwardingCost_Base { get; private set; }
        public ulong HypercallsPersec { get; private set; }
        public ulong InvEptAllContextEmulationInterceptsPersec { get; private set; }
        public ulong InvEptAllContextInstructionEmulationCost { get; private set; }
        public ulong InvEptAllContextInstructionEmulationCost_Base { get; private set; }
        public ulong InvEptSingleContextEmulationInterceptsPersec { get; private set; }
        public ulong InvEptSingleContextInstructionEmulationCost { get; private set; }
        public ulong InvEptSingleContextInstructionEmulationCost_Base { get; private set; }
        public ulong InvVpidAllContextEmulationInterceptsPersec { get; private set; }
        public ulong InvVpidAllContextInstructionEmulationCost { get; private set; }
        public ulong InvVpidAllContextInstructionEmulationCost_Base { get; private set; }
        public ulong InvVpidSingleAddressEmulationInterceptsPersec { get; private set; }
        public ulong InvVpidSingleAddressInstructionEmulationCost { get; private set; }
        public ulong InvVpidSingleAddressInstructionEmulationCost_Base { get; private set; }
        public ulong InvVpidSingleContextEmulationInterceptsPersec { get; private set; }
        public ulong InvVpidSingleContextInstructionEmulationCost { get; private set; }
        public ulong InvVpidSingleContextInstructionEmulationCost_Base { get; private set; }
        public ulong IOInstructionsCost { get; private set; }
        public ulong IOInstructionsCost_Base { get; private set; }
        public ulong IOInstructionsForwardedPersec { get; private set; }
        public ulong IOInstructionsForwardingCost { get; private set; }
        public ulong IOInstructionsForwardingCost_Base { get; private set; }
        public ulong IOInstructionsPersec { get; private set; }
        public ulong IOInterceptMessagesPersec { get; private set; }
        public ulong LargePageTLBFillsPersec { get; private set; }
        public ulong LocalFlushedGVARangesPersec { get; private set; }
        public ulong LocalIOTLBFlushCost { get; private set; }
        public ulong LocalIOTLBFlushCost_Base { get; private set; }
        public ulong LocalIOTLBFlushesPersec { get; private set; }
        public ulong LogicalProcessorDispatchesPersec { get; private set; }
        public ulong LogicalProcessorHypercallsPersec { get; private set; }
        public ulong LogicalProcessorMigrationsPersec { get; private set; }
        public ulong LongSpinWaitHypercallsPersec { get; private set; }
        public ulong MBECNestedPageTableSwitchesPersec { get; private set; }
        public ulong MemoryInterceptMessagesPersec { get; private set; }
        public ulong MSRAccessesCost { get; private set; }
        public ulong MSRAccessesCost_Base { get; private set; }
        public ulong MSRAccessesForwardedPersec { get; private set; }
        public ulong MSRAccessesForwardingCost { get; private set; }
        public ulong MSRAccessesForwardingCost_Base { get; private set; }
        public ulong MSRAccessesPersec { get; private set; }
        public ulong MWAITInstructionsCost { get; private set; }
        public ulong MWAITInstructionsCost_Base { get; private set; }
        public ulong MWAITInstructionsForwardedPersec { get; private set; }
        public ulong MWAITInstructionsForwardingCost { get; private set; }
        public ulong MWAITInstructionsForwardingCost_Base { get; private set; }
        public ulong MWAITInstructionsPersec { get; private set; }
        public string Name { get; private set; }
        public ulong NestedPageFaultInterceptsCost { get; private set; }
        public ulong NestedPageFaultInterceptsCost_Base { get; private set; }
        public ulong NestedPageFaultInterceptsPersec { get; private set; }
        public ulong NestedSLATHardPageFaultsCost { get; private set; }
        public ulong NestedSLATHardPageFaultsCost_Base { get; private set; }
        public ulong NestedSLATHardPageFaultsPersec { get; private set; }
        public ulong NestedSLATSoftPageFaultsCost { get; private set; }
        public ulong NestedSLATSoftPageFaultsCost_Base { get; private set; }
        public ulong NestedSLATSoftPageFaultsPersec { get; private set; }
        public ulong NestedTLBPageTableEvictionsPersec { get; private set; }
        public ulong NestedTLBPageTableReclamationsPersec { get; private set; }
        public ulong NestedVMEntriesCost { get; private set; }
        public ulong NestedVMEntriesCost_Base { get; private set; }
        public ulong NestedVMEntriesPersec { get; private set; }
        public ulong OtherHypercallsPersec { get; private set; }
        public ulong OtherInterceptsCost { get; private set; }
        public ulong OtherInterceptsCost_Base { get; private set; }
        public ulong OtherInterceptsForwardedPersec { get; private set; }
        public ulong OtherInterceptsForwardingCost { get; private set; }
        public ulong OtherInterceptsForwardingCost_Base { get; private set; }
        public ulong OtherInterceptsPersec { get; private set; }
        public ulong OtherMessagesPersec { get; private set; }
        public ulong OtherReflectedGuestExceptionsPersec { get; private set; }
        public ulong PageFaultInterceptsCost { get; private set; }
        public ulong PageFaultInterceptsCost_Base { get; private set; }
        public ulong PageFaultInterceptsForwardedPersec { get; private set; }
        public ulong PageFaultInterceptsForwardingCost { get; private set; }
        public ulong PageFaultInterceptsForwardingCost_Base { get; private set; }
        public ulong PageFaultInterceptsPersec { get; private set; }
        public ulong PageInvalidationsCost { get; private set; }
        public ulong PageInvalidationsCost_Base { get; private set; }
        public ulong PageInvalidationsForwardedPersec { get; private set; }
        public ulong PageInvalidationsForwardingCost { get; private set; }
        public ulong PageInvalidationsForwardingCost_Base { get; private set; }
        public ulong PageInvalidationsPersec { get; private set; }
        public ulong PageTableAllocationsPersec { get; private set; }
        public ulong PageTableEvictionsPersec { get; private set; }
        public ulong PageTableReclamationsPersec { get; private set; }
        public ulong PageTableResetsPersec { get; private set; }
        public ulong PageTableValidationsPersec { get; private set; }
        public ulong PageTableWriteInterceptsPersec { get; private set; }
        public ulong PendingInterruptsCost { get; private set; }
        public ulong PendingInterruptsCost_Base { get; private set; }
        public ulong PendingInterruptsForwardedPersec { get; private set; }
        public ulong PendingInterruptsForwardingCost { get; private set; }
        public ulong PendingInterruptsForwardingCost_Base { get; private set; }
        public ulong PendingInterruptsPersec { get; private set; }
        public ulong PercentGuestRunTime { get; private set; }
        public ulong PercentGuestRunTime_Base { get; private set; }
        public ulong PercentHypervisorRunTime { get; private set; }
        public ulong PercentHypervisorRunTime_Base { get; private set; }
        public ulong PercentRemoteRunTime { get; private set; }
        public ulong PercentRemoteRunTime_Base { get; private set; }
        public ulong PercentTotalRunTime { get; private set; }
        public ulong PercentTotalRunTime_Base { get; private set; }
        public ulong ReflectedGuestPageFaultsPersec { get; private set; }
        public ulong SmallPageTLBFillsPersec { get; private set; }
        public ulong SyntheticInterruptHypercallsPersec { get; private set; }
        public ulong SyntheticInterruptsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalInterceptsCost { get; private set; }
        public ulong TotalInterceptsCost_Base { get; private set; }
        public ulong TotalInterceptsPersec { get; private set; }
        public ulong TotalMessagesPersec { get; private set; }
        public ulong TotalVirtualizationInstructionsEmulatedPersec { get; private set; }
        public ulong TotalVirtualizationInstructionsEmulationCost { get; private set; }
        public ulong TotalVirtualizationInstructionsEmulationCost_Base { get; private set; }
        public ulong VirtualInterruptHypercallsPersec { get; private set; }
        public ulong VirtualInterruptsPersec { get; private set; }
        public ulong VirtualMMUHypercallsPersec { get; private set; }
        public ulong VirtualProcessorHypercallsPersec { get; private set; }
        public ulong VMCLEAREmulationInterceptsPersec { get; private set; }
        public ulong VMCLEARInstructionEmulationCost { get; private set; }
        public ulong VMCLEARInstructionEmulationCost_Base { get; private set; }
        public ulong VMPTRLDEmulationInterceptsPersec { get; private set; }
        public ulong VMPTRLDInstructionEmulationCost { get; private set; }
        public ulong VMPTRLDInstructionEmulationCost_Base { get; private set; }
        public ulong VMPTRSTEmulationInterceptsPersec { get; private set; }
        public ulong VMPTRSTInstructionEmulationCost { get; private set; }
        public ulong VMPTRSTInstructionEmulationCost_Base { get; private set; }
        public ulong VMREADEmulationInterceptsPersec { get; private set; }
        public ulong VMREADInstructionEmulationCost { get; private set; }
        public ulong VMREADInstructionEmulationCost_Base { get; private set; }
        public ulong VMWRITEEmulationInterceptsPersec { get; private set; }
        public ulong VMWRITEInstructionEmulationCost { get; private set; }
        public ulong VMWRITEInstructionEmulationCost_Base { get; private set; }
        public ulong VMXOFFEmulationInterceptsPersec { get; private set; }
        public ulong VMXOFFInstructionEmulationCost { get; private set; }
        public ulong VMXOFFInstructionEmulationCost_Base { get; private set; }
        public ulong VMXONEmulationInterceptsPersec { get; private set; }
        public ulong VMXONInstructionEmulationCost { get; private set; }
        public ulong VMXONInstructionEmulationCost_Base { get; private set; }

        public static PerfRawData_HvStats_HyperVHypervisorRootVirtualProcessor[] Retrieve(string remote,
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

        public static PerfRawData_HvStats_HyperVHypervisorRootVirtualProcessor[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_HvStats_HyperVHypervisorRootVirtualProcessor[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_HvStats_HyperVHypervisorRootVirtualProcessor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_HvStats_HyperVHypervisorRootVirtualProcessor>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_HvStats_HyperVHypervisorRootVirtualProcessor
                {
                    AddressDomainFlushesPersec =
                        (ulong) managementObject.Properties["AddressDomainFlushesPersec"].Value,
                    AddressSpaceEvictionsPersec = (ulong) managementObject.Properties["AddressSpaceEvictionsPersec"]
                        .Value,
                    AddressSpaceFlushesPersec = (ulong) managementObject.Properties["AddressSpaceFlushesPersec"].Value,
                    AddressSpaceSwitchesPersec =
                        (ulong) managementObject.Properties["AddressSpaceSwitchesPersec"].Value,
                    APICEOIAccessesPersec = (ulong) managementObject.Properties["APICEOIAccessesPersec"].Value,
                    APICIPIsSentPersec = (ulong) managementObject.Properties["APICIPIsSentPersec"].Value,
                    APICMMIOAccessesPersec = (ulong) managementObject.Properties["APICMMIOAccessesPersec"].Value,
                    APICSelfIPIsSentPersec = (ulong) managementObject.Properties["APICSelfIPIsSentPersec"].Value,
                    APICTPRAccessesPersec = (ulong) managementObject.Properties["APICTPRAccessesPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ControlRegisterAccessesCost = (ulong) managementObject.Properties["ControlRegisterAccessesCost"]
                        .Value,
                    ControlRegisterAccessesCost_Base =
                        (ulong) managementObject.Properties["ControlRegisterAccessesCost_Base"].Value,
                    ControlRegisterAccessesForwardedPersec = (ulong) managementObject
                        .Properties["ControlRegisterAccessesForwardedPersec"].Value,
                    ControlRegisterAccessesForwardingCost = (ulong) managementObject
                        .Properties["ControlRegisterAccessesForwardingCost"].Value,
                    ControlRegisterAccessesForwardingCost_Base = (ulong) managementObject
                        .Properties["ControlRegisterAccessesForwardingCost_Base"].Value,
                    ControlRegisterAccessesPersec =
                        (ulong) managementObject.Properties["ControlRegisterAccessesPersec"].Value,
                    CPUIDInstructionsCost = (ulong) managementObject.Properties["CPUIDInstructionsCost"].Value,
                    CPUIDInstructionsCost_Base =
                        (ulong) managementObject.Properties["CPUIDInstructionsCost_Base"].Value,
                    CPUIDInstructionsForwardedPersec =
                        (ulong) managementObject.Properties["CPUIDInstructionsForwardedPersec"].Value,
                    CPUIDInstructionsForwardingCost =
                        (ulong) managementObject.Properties["CPUIDInstructionsForwardingCost"].Value,
                    CPUIDInstructionsForwardingCost_Base = (ulong) managementObject
                        .Properties["CPUIDInstructionsForwardingCost_Base"].Value,
                    CPUIDInstructionsPersec = (ulong) managementObject.Properties["CPUIDInstructionsPersec"].Value,
                    CPUWaitTimePerDispatch = (ulong) managementObject.Properties["CPUWaitTimePerDispatch"].Value,
                    CPUWaitTimePerDispatch_Base = (ulong) managementObject.Properties["CPUWaitTimePerDispatch_Base"]
                        .Value,
                    DebugRegisterAccessesCost = (ulong) managementObject.Properties["DebugRegisterAccessesCost"].Value,
                    DebugRegisterAccessesCost_Base =
                        (ulong) managementObject.Properties["DebugRegisterAccessesCost_Base"].Value,
                    DebugRegisterAccessesForwardedPersec = (ulong) managementObject
                        .Properties["DebugRegisterAccessesForwardedPersec"].Value,
                    DebugRegisterAccessesForwardingCost =
                        (ulong) managementObject.Properties["DebugRegisterAccessesForwardingCost"].Value,
                    DebugRegisterAccessesForwardingCost_Base = (ulong) managementObject
                        .Properties["DebugRegisterAccessesForwardingCost_Base"].Value,
                    DebugRegisterAccessesPersec = (ulong) managementObject.Properties["DebugRegisterAccessesPersec"]
                        .Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    EmulatedInstructionsCost = (ulong) managementObject.Properties["EmulatedInstructionsCost"].Value,
                    EmulatedInstructionsCost_Base =
                        (ulong) managementObject.Properties["EmulatedInstructionsCost_Base"].Value,
                    EmulatedInstructionsForwardedPersec =
                        (ulong) managementObject.Properties["EmulatedInstructionsForwardedPersec"].Value,
                    EmulatedInstructionsForwardingCost =
                        (ulong) managementObject.Properties["EmulatedInstructionsForwardingCost"].Value,
                    EmulatedInstructionsForwardingCost_Base = (ulong) managementObject
                        .Properties["EmulatedInstructionsForwardingCost_Base"].Value,
                    EmulatedInstructionsPersec =
                        (ulong) managementObject.Properties["EmulatedInstructionsPersec"].Value,
                    ExtendedHypercallInterceptMessagesPersec = (ulong) managementObject
                        .Properties["ExtendedHypercallInterceptMessagesPersec"].Value,
                    ExtendedHypercallsPersec = (ulong) managementObject.Properties["ExtendedHypercallsPersec"].Value,
                    ExternalInterruptsCost = (ulong) managementObject.Properties["ExternalInterruptsCost"].Value,
                    ExternalInterruptsCost_Base = (ulong) managementObject.Properties["ExternalInterruptsCost_Base"]
                        .Value,
                    ExternalInterruptsForwardedPersec =
                        (ulong) managementObject.Properties["ExternalInterruptsForwardedPersec"].Value,
                    ExternalInterruptsPersec = (ulong) managementObject.Properties["ExternalInterruptsPersec"].Value,
                    FlushPhysicalAddressListHypercallsPersec = (ulong) managementObject
                        .Properties["FlushPhysicalAddressListHypercallsPersec"].Value,
                    FlushPhysicalAddressSpaceHypercallsPersec = (ulong) managementObject
                        .Properties["FlushPhysicalAddressSpaceHypercallsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    GlobalGVARangeFlushesPersec = (ulong) managementObject.Properties["GlobalGVARangeFlushesPersec"]
                        .Value,
                    GlobalIOTLBFlushCost = (ulong) managementObject.Properties["GlobalIOTLBFlushCost"].Value,
                    GlobalIOTLBFlushCost_Base = (ulong) managementObject.Properties["GlobalIOTLBFlushCost_Base"].Value,
                    GlobalIOTLBFlushesPersec = (ulong) managementObject.Properties["GlobalIOTLBFlushesPersec"].Value,
                    GPASpaceHypercallsPersec = (ulong) managementObject.Properties["GPASpaceHypercallsPersec"].Value,
                    GuestPageTableMapsPersec = (ulong) managementObject.Properties["GuestPageTableMapsPersec"].Value,
                    HardwareInterruptsPersec = (ulong) managementObject.Properties["HardwareInterruptsPersec"].Value,
                    HLTInstructionsCost = (ulong) managementObject.Properties["HLTInstructionsCost"].Value,
                    HLTInstructionsCost_Base = (ulong) managementObject.Properties["HLTInstructionsCost_Base"].Value,
                    HLTInstructionsForwardedPersec =
                        (ulong) managementObject.Properties["HLTInstructionsForwardedPersec"].Value,
                    HLTInstructionsForwardingCost =
                        (ulong) managementObject.Properties["HLTInstructionsForwardingCost"].Value,
                    HLTInstructionsForwardingCost_Base =
                        (ulong) managementObject.Properties["HLTInstructionsForwardingCost_Base"].Value,
                    HLTInstructionsPersec = (ulong) managementObject.Properties["HLTInstructionsPersec"].Value,
                    HypercallsCost = (ulong) managementObject.Properties["HypercallsCost"].Value,
                    HypercallsCost_Base = (ulong) managementObject.Properties["HypercallsCost_Base"].Value,
                    HypercallsForwardedPersec = (ulong) managementObject.Properties["HypercallsForwardedPersec"].Value,
                    HypercallsForwardingCost = (ulong) managementObject.Properties["HypercallsForwardingCost"].Value,
                    HypercallsForwardingCost_Base =
                        (ulong) managementObject.Properties["HypercallsForwardingCost_Base"].Value,
                    HypercallsPersec = (ulong) managementObject.Properties["HypercallsPersec"].Value,
                    InvEptAllContextEmulationInterceptsPersec = (ulong) managementObject
                        .Properties["InvEptAllContextEmulationInterceptsPersec"].Value,
                    InvEptAllContextInstructionEmulationCost = (ulong) managementObject
                        .Properties["InvEptAllContextInstructionEmulationCost"].Value,
                    InvEptAllContextInstructionEmulationCost_Base = (ulong) managementObject
                        .Properties["InvEptAllContextInstructionEmulationCost_Base"].Value,
                    InvEptSingleContextEmulationInterceptsPersec = (ulong) managementObject
                        .Properties["InvEptSingleContextEmulationInterceptsPersec"].Value,
                    InvEptSingleContextInstructionEmulationCost = (ulong) managementObject
                        .Properties["InvEptSingleContextInstructionEmulationCost"].Value,
                    InvEptSingleContextInstructionEmulationCost_Base = (ulong) managementObject
                        .Properties["InvEptSingleContextInstructionEmulationCost_Base"].Value,
                    InvVpidAllContextEmulationInterceptsPersec = (ulong) managementObject
                        .Properties["InvVpidAllContextEmulationInterceptsPersec"].Value,
                    InvVpidAllContextInstructionEmulationCost = (ulong) managementObject
                        .Properties["InvVpidAllContextInstructionEmulationCost"].Value,
                    InvVpidAllContextInstructionEmulationCost_Base = (ulong) managementObject
                        .Properties["InvVpidAllContextInstructionEmulationCost_Base"].Value,
                    InvVpidSingleAddressEmulationInterceptsPersec = (ulong) managementObject
                        .Properties["InvVpidSingleAddressEmulationInterceptsPersec"].Value,
                    InvVpidSingleAddressInstructionEmulationCost = (ulong) managementObject
                        .Properties["InvVpidSingleAddressInstructionEmulationCost"].Value,
                    InvVpidSingleAddressInstructionEmulationCost_Base = (ulong) managementObject
                        .Properties["InvVpidSingleAddressInstructionEmulationCost_Base"].Value,
                    InvVpidSingleContextEmulationInterceptsPersec = (ulong) managementObject
                        .Properties["InvVpidSingleContextEmulationInterceptsPersec"].Value,
                    InvVpidSingleContextInstructionEmulationCost = (ulong) managementObject
                        .Properties["InvVpidSingleContextInstructionEmulationCost"].Value,
                    InvVpidSingleContextInstructionEmulationCost_Base = (ulong) managementObject
                        .Properties["InvVpidSingleContextInstructionEmulationCost_Base"].Value,
                    IOInstructionsCost = (ulong) managementObject.Properties["IOInstructionsCost"].Value,
                    IOInstructionsCost_Base = (ulong) managementObject.Properties["IOInstructionsCost_Base"].Value,
                    IOInstructionsForwardedPersec =
                        (ulong) managementObject.Properties["IOInstructionsForwardedPersec"].Value,
                    IOInstructionsForwardingCost = (ulong) managementObject.Properties["IOInstructionsForwardingCost"]
                        .Value,
                    IOInstructionsForwardingCost_Base =
                        (ulong) managementObject.Properties["IOInstructionsForwardingCost_Base"].Value,
                    IOInstructionsPersec = (ulong) managementObject.Properties["IOInstructionsPersec"].Value,
                    IOInterceptMessagesPersec = (ulong) managementObject.Properties["IOInterceptMessagesPersec"].Value,
                    LargePageTLBFillsPersec = (ulong) managementObject.Properties["LargePageTLBFillsPersec"].Value,
                    LocalFlushedGVARangesPersec = (ulong) managementObject.Properties["LocalFlushedGVARangesPersec"]
                        .Value,
                    LocalIOTLBFlushCost = (ulong) managementObject.Properties["LocalIOTLBFlushCost"].Value,
                    LocalIOTLBFlushCost_Base = (ulong) managementObject.Properties["LocalIOTLBFlushCost_Base"].Value,
                    LocalIOTLBFlushesPersec = (ulong) managementObject.Properties["LocalIOTLBFlushesPersec"].Value,
                    LogicalProcessorDispatchesPersec =
                        (ulong) managementObject.Properties["LogicalProcessorDispatchesPersec"].Value,
                    LogicalProcessorHypercallsPersec =
                        (ulong) managementObject.Properties["LogicalProcessorHypercallsPersec"].Value,
                    LogicalProcessorMigrationsPersec =
                        (ulong) managementObject.Properties["LogicalProcessorMigrationsPersec"].Value,
                    LongSpinWaitHypercallsPersec = (ulong) managementObject.Properties["LongSpinWaitHypercallsPersec"]
                        .Value,
                    MBECNestedPageTableSwitchesPersec =
                        (ulong) managementObject.Properties["MBECNestedPageTableSwitchesPersec"].Value,
                    MemoryInterceptMessagesPersec =
                        (ulong) managementObject.Properties["MemoryInterceptMessagesPersec"].Value,
                    MSRAccessesCost = (ulong) managementObject.Properties["MSRAccessesCost"].Value,
                    MSRAccessesCost_Base = (ulong) managementObject.Properties["MSRAccessesCost_Base"].Value,
                    MSRAccessesForwardedPersec =
                        (ulong) managementObject.Properties["MSRAccessesForwardedPersec"].Value,
                    MSRAccessesForwardingCost = (ulong) managementObject.Properties["MSRAccessesForwardingCost"].Value,
                    MSRAccessesForwardingCost_Base =
                        (ulong) managementObject.Properties["MSRAccessesForwardingCost_Base"].Value,
                    MSRAccessesPersec = (ulong) managementObject.Properties["MSRAccessesPersec"].Value,
                    MWAITInstructionsCost = (ulong) managementObject.Properties["MWAITInstructionsCost"].Value,
                    MWAITInstructionsCost_Base =
                        (ulong) managementObject.Properties["MWAITInstructionsCost_Base"].Value,
                    MWAITInstructionsForwardedPersec =
                        (ulong) managementObject.Properties["MWAITInstructionsForwardedPersec"].Value,
                    MWAITInstructionsForwardingCost =
                        (ulong) managementObject.Properties["MWAITInstructionsForwardingCost"].Value,
                    MWAITInstructionsForwardingCost_Base = (ulong) managementObject
                        .Properties["MWAITInstructionsForwardingCost_Base"].Value,
                    MWAITInstructionsPersec = (ulong) managementObject.Properties["MWAITInstructionsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NestedPageFaultInterceptsCost =
                        (ulong) managementObject.Properties["NestedPageFaultInterceptsCost"].Value,
                    NestedPageFaultInterceptsCost_Base =
                        (ulong) managementObject.Properties["NestedPageFaultInterceptsCost_Base"].Value,
                    NestedPageFaultInterceptsPersec =
                        (ulong) managementObject.Properties["NestedPageFaultInterceptsPersec"].Value,
                    NestedSLATHardPageFaultsCost = (ulong) managementObject.Properties["NestedSLATHardPageFaultsCost"]
                        .Value,
                    NestedSLATHardPageFaultsCost_Base =
                        (ulong) managementObject.Properties["NestedSLATHardPageFaultsCost_Base"].Value,
                    NestedSLATHardPageFaultsPersec =
                        (ulong) managementObject.Properties["NestedSLATHardPageFaultsPersec"].Value,
                    NestedSLATSoftPageFaultsCost = (ulong) managementObject.Properties["NestedSLATSoftPageFaultsCost"]
                        .Value,
                    NestedSLATSoftPageFaultsCost_Base =
                        (ulong) managementObject.Properties["NestedSLATSoftPageFaultsCost_Base"].Value,
                    NestedSLATSoftPageFaultsPersec =
                        (ulong) managementObject.Properties["NestedSLATSoftPageFaultsPersec"].Value,
                    NestedTLBPageTableEvictionsPersec =
                        (ulong) managementObject.Properties["NestedTLBPageTableEvictionsPersec"].Value,
                    NestedTLBPageTableReclamationsPersec = (ulong) managementObject
                        .Properties["NestedTLBPageTableReclamationsPersec"].Value,
                    NestedVMEntriesCost = (ulong) managementObject.Properties["NestedVMEntriesCost"].Value,
                    NestedVMEntriesCost_Base = (ulong) managementObject.Properties["NestedVMEntriesCost_Base"].Value,
                    NestedVMEntriesPersec = (ulong) managementObject.Properties["NestedVMEntriesPersec"].Value,
                    OtherHypercallsPersec = (ulong) managementObject.Properties["OtherHypercallsPersec"].Value,
                    OtherInterceptsCost = (ulong) managementObject.Properties["OtherInterceptsCost"].Value,
                    OtherInterceptsCost_Base = (ulong) managementObject.Properties["OtherInterceptsCost_Base"].Value,
                    OtherInterceptsForwardedPersec =
                        (ulong) managementObject.Properties["OtherInterceptsForwardedPersec"].Value,
                    OtherInterceptsForwardingCost =
                        (ulong) managementObject.Properties["OtherInterceptsForwardingCost"].Value,
                    OtherInterceptsForwardingCost_Base =
                        (ulong) managementObject.Properties["OtherInterceptsForwardingCost_Base"].Value,
                    OtherInterceptsPersec = (ulong) managementObject.Properties["OtherInterceptsPersec"].Value,
                    OtherMessagesPersec = (ulong) managementObject.Properties["OtherMessagesPersec"].Value,
                    OtherReflectedGuestExceptionsPersec =
                        (ulong) managementObject.Properties["OtherReflectedGuestExceptionsPersec"].Value,
                    PageFaultInterceptsCost = (ulong) managementObject.Properties["PageFaultInterceptsCost"].Value,
                    PageFaultInterceptsCost_Base = (ulong) managementObject.Properties["PageFaultInterceptsCost_Base"]
                        .Value,
                    PageFaultInterceptsForwardedPersec =
                        (ulong) managementObject.Properties["PageFaultInterceptsForwardedPersec"].Value,
                    PageFaultInterceptsForwardingCost =
                        (ulong) managementObject.Properties["PageFaultInterceptsForwardingCost"].Value,
                    PageFaultInterceptsForwardingCost_Base = (ulong) managementObject
                        .Properties["PageFaultInterceptsForwardingCost_Base"].Value,
                    PageFaultInterceptsPersec = (ulong) managementObject.Properties["PageFaultInterceptsPersec"].Value,
                    PageInvalidationsCost = (ulong) managementObject.Properties["PageInvalidationsCost"].Value,
                    PageInvalidationsCost_Base =
                        (ulong) managementObject.Properties["PageInvalidationsCost_Base"].Value,
                    PageInvalidationsForwardedPersec =
                        (ulong) managementObject.Properties["PageInvalidationsForwardedPersec"].Value,
                    PageInvalidationsForwardingCost =
                        (ulong) managementObject.Properties["PageInvalidationsForwardingCost"].Value,
                    PageInvalidationsForwardingCost_Base = (ulong) managementObject
                        .Properties["PageInvalidationsForwardingCost_Base"].Value,
                    PageInvalidationsPersec = (ulong) managementObject.Properties["PageInvalidationsPersec"].Value,
                    PageTableAllocationsPersec =
                        (ulong) managementObject.Properties["PageTableAllocationsPersec"].Value,
                    PageTableEvictionsPersec = (ulong) managementObject.Properties["PageTableEvictionsPersec"].Value,
                    PageTableReclamationsPersec = (ulong) managementObject.Properties["PageTableReclamationsPersec"]
                        .Value,
                    PageTableResetsPersec = (ulong) managementObject.Properties["PageTableResetsPersec"].Value,
                    PageTableValidationsPersec =
                        (ulong) managementObject.Properties["PageTableValidationsPersec"].Value,
                    PageTableWriteInterceptsPersec =
                        (ulong) managementObject.Properties["PageTableWriteInterceptsPersec"].Value,
                    PendingInterruptsCost = (ulong) managementObject.Properties["PendingInterruptsCost"].Value,
                    PendingInterruptsCost_Base =
                        (ulong) managementObject.Properties["PendingInterruptsCost_Base"].Value,
                    PendingInterruptsForwardedPersec =
                        (ulong) managementObject.Properties["PendingInterruptsForwardedPersec"].Value,
                    PendingInterruptsForwardingCost =
                        (ulong) managementObject.Properties["PendingInterruptsForwardingCost"].Value,
                    PendingInterruptsForwardingCost_Base = (ulong) managementObject
                        .Properties["PendingInterruptsForwardingCost_Base"].Value,
                    PendingInterruptsPersec = (ulong) managementObject.Properties["PendingInterruptsPersec"].Value,
                    PercentGuestRunTime = (ulong) managementObject.Properties["PercentGuestRunTime"].Value,
                    PercentGuestRunTime_Base = (ulong) managementObject.Properties["PercentGuestRunTime_Base"].Value,
                    PercentHypervisorRunTime = (ulong) managementObject.Properties["PercentHypervisorRunTime"].Value,
                    PercentHypervisorRunTime_Base =
                        (ulong) managementObject.Properties["PercentHypervisorRunTime_Base"].Value,
                    PercentRemoteRunTime = (ulong) managementObject.Properties["PercentRemoteRunTime"].Value,
                    PercentRemoteRunTime_Base = (ulong) managementObject.Properties["PercentRemoteRunTime_Base"].Value,
                    PercentTotalRunTime = (ulong) managementObject.Properties["PercentTotalRunTime"].Value,
                    PercentTotalRunTime_Base = (ulong) managementObject.Properties["PercentTotalRunTime_Base"].Value,
                    ReflectedGuestPageFaultsPersec =
                        (ulong) managementObject.Properties["ReflectedGuestPageFaultsPersec"].Value,
                    SmallPageTLBFillsPersec = (ulong) managementObject.Properties["SmallPageTLBFillsPersec"].Value,
                    SyntheticInterruptHypercallsPersec =
                        (ulong) managementObject.Properties["SyntheticInterruptHypercallsPersec"].Value,
                    SyntheticInterruptsPersec = (ulong) managementObject.Properties["SyntheticInterruptsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalInterceptsCost = (ulong) managementObject.Properties["TotalInterceptsCost"].Value,
                    TotalInterceptsCost_Base = (ulong) managementObject.Properties["TotalInterceptsCost_Base"].Value,
                    TotalInterceptsPersec = (ulong) managementObject.Properties["TotalInterceptsPersec"].Value,
                    TotalMessagesPersec = (ulong) managementObject.Properties["TotalMessagesPersec"].Value,
                    TotalVirtualizationInstructionsEmulatedPersec = (ulong) managementObject
                        .Properties["TotalVirtualizationInstructionsEmulatedPersec"].Value,
                    TotalVirtualizationInstructionsEmulationCost = (ulong) managementObject
                        .Properties["TotalVirtualizationInstructionsEmulationCost"].Value,
                    TotalVirtualizationInstructionsEmulationCost_Base = (ulong) managementObject
                        .Properties["TotalVirtualizationInstructionsEmulationCost_Base"].Value,
                    VirtualInterruptHypercallsPersec =
                        (ulong) managementObject.Properties["VirtualInterruptHypercallsPersec"].Value,
                    VirtualInterruptsPersec = (ulong) managementObject.Properties["VirtualInterruptsPersec"].Value,
                    VirtualMMUHypercallsPersec =
                        (ulong) managementObject.Properties["VirtualMMUHypercallsPersec"].Value,
                    VirtualProcessorHypercallsPersec =
                        (ulong) managementObject.Properties["VirtualProcessorHypercallsPersec"].Value,
                    VMCLEAREmulationInterceptsPersec =
                        (ulong) managementObject.Properties["VMCLEAREmulationInterceptsPersec"].Value,
                    VMCLEARInstructionEmulationCost =
                        (ulong) managementObject.Properties["VMCLEARInstructionEmulationCost"].Value,
                    VMCLEARInstructionEmulationCost_Base = (ulong) managementObject
                        .Properties["VMCLEARInstructionEmulationCost_Base"].Value,
                    VMPTRLDEmulationInterceptsPersec =
                        (ulong) managementObject.Properties["VMPTRLDEmulationInterceptsPersec"].Value,
                    VMPTRLDInstructionEmulationCost =
                        (ulong) managementObject.Properties["VMPTRLDInstructionEmulationCost"].Value,
                    VMPTRLDInstructionEmulationCost_Base = (ulong) managementObject
                        .Properties["VMPTRLDInstructionEmulationCost_Base"].Value,
                    VMPTRSTEmulationInterceptsPersec =
                        (ulong) managementObject.Properties["VMPTRSTEmulationInterceptsPersec"].Value,
                    VMPTRSTInstructionEmulationCost =
                        (ulong) managementObject.Properties["VMPTRSTInstructionEmulationCost"].Value,
                    VMPTRSTInstructionEmulationCost_Base = (ulong) managementObject
                        .Properties["VMPTRSTInstructionEmulationCost_Base"].Value,
                    VMREADEmulationInterceptsPersec =
                        (ulong) managementObject.Properties["VMREADEmulationInterceptsPersec"].Value,
                    VMREADInstructionEmulationCost =
                        (ulong) managementObject.Properties["VMREADInstructionEmulationCost"].Value,
                    VMREADInstructionEmulationCost_Base =
                        (ulong) managementObject.Properties["VMREADInstructionEmulationCost_Base"].Value,
                    VMWRITEEmulationInterceptsPersec =
                        (ulong) managementObject.Properties["VMWRITEEmulationInterceptsPersec"].Value,
                    VMWRITEInstructionEmulationCost =
                        (ulong) managementObject.Properties["VMWRITEInstructionEmulationCost"].Value,
                    VMWRITEInstructionEmulationCost_Base = (ulong) managementObject
                        .Properties["VMWRITEInstructionEmulationCost_Base"].Value,
                    VMXOFFEmulationInterceptsPersec =
                        (ulong) managementObject.Properties["VMXOFFEmulationInterceptsPersec"].Value,
                    VMXOFFInstructionEmulationCost =
                        (ulong) managementObject.Properties["VMXOFFInstructionEmulationCost"].Value,
                    VMXOFFInstructionEmulationCost_Base =
                        (ulong) managementObject.Properties["VMXOFFInstructionEmulationCost_Base"].Value,
                    VMXONEmulationInterceptsPersec =
                        (ulong) managementObject.Properties["VMXONEmulationInterceptsPersec"].Value,
                    VMXONInstructionEmulationCost =
                        (ulong) managementObject.Properties["VMXONInstructionEmulationCost"].Value,
                    VMXONInstructionEmulationCost_Base =
                        (ulong) managementObject.Properties["VMXONInstructionEmulationCost_Base"].Value
                });

            return list.ToArray();
        }
    }
}