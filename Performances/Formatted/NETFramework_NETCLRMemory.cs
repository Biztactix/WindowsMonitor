using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_NETFramework_NETCLRMemory
    {
        public uint AllocatedBytesPersec { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint FinalizationSurvivors { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint Gen0heapsize { get; private set; }
        public uint Gen0PromotedBytesPerSec { get; private set; }
        public uint Gen1heapsize { get; private set; }
        public uint Gen1PromotedBytesPerSec { get; private set; }
        public uint Gen2heapsize { get; private set; }
        public uint LargeObjectHeapsize { get; private set; }
        public string Name { get; private set; }
        public uint NumberBytesinallHeaps { get; private set; }
        public uint NumberGCHandles { get; private set; }
        public uint NumberGen0Collections { get; private set; }
        public uint NumberGen1Collections { get; private set; }
        public uint NumberGen2Collections { get; private set; }
        public uint NumberInducedGC { get; private set; }
        public uint NumberofPinnedObjects { get; private set; }
        public uint NumberofSinkBlocksinuse { get; private set; }
        public uint NumberTotalcommittedBytes { get; private set; }
        public uint NumberTotalreservedBytes { get; private set; }
        public uint PercentTimeinGC { get; private set; }
        public uint ProcessID { get; private set; }
        public uint PromotedFinalizationMemoryfromGen0 { get; private set; }
        public uint PromotedMemoryfromGen0 { get; private set; }
        public uint PromotedMemoryfromGen1 { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_NETFramework_NETCLRMemory[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_NETFramework_NETCLRMemory[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_NETFramework_NETCLRMemory[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_NETFramework_NETCLRMemory");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_NETFramework_NETCLRMemory>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_NETFramework_NETCLRMemory
                {
                    AllocatedBytesPersec = (uint) managementObject.Properties["AllocatedBytesPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FinalizationSurvivors = (uint) managementObject.Properties["FinalizationSurvivors"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Gen0heapsize = (uint) managementObject.Properties["Gen0heapsize"].Value,
                    Gen0PromotedBytesPerSec = (uint) managementObject.Properties["Gen0PromotedBytesPerSec"].Value,
                    Gen1heapsize = (uint) managementObject.Properties["Gen1heapsize"].Value,
                    Gen1PromotedBytesPerSec = (uint) managementObject.Properties["Gen1PromotedBytesPerSec"].Value,
                    Gen2heapsize = (uint) managementObject.Properties["Gen2heapsize"].Value,
                    LargeObjectHeapsize = (uint) managementObject.Properties["LargeObjectHeapsize"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberBytesinallHeaps = (uint) managementObject.Properties["NumberBytesinallHeaps"].Value,
                    NumberGCHandles = (uint) managementObject.Properties["NumberGCHandles"].Value,
                    NumberGen0Collections = (uint) managementObject.Properties["NumberGen0Collections"].Value,
                    NumberGen1Collections = (uint) managementObject.Properties["NumberGen1Collections"].Value,
                    NumberGen2Collections = (uint) managementObject.Properties["NumberGen2Collections"].Value,
                    NumberInducedGC = (uint) managementObject.Properties["NumberInducedGC"].Value,
                    NumberofPinnedObjects = (uint) managementObject.Properties["NumberofPinnedObjects"].Value,
                    NumberofSinkBlocksinuse = (uint) managementObject.Properties["NumberofSinkBlocksinuse"].Value,
                    NumberTotalcommittedBytes = (uint) managementObject.Properties["NumberTotalcommittedBytes"].Value,
                    NumberTotalreservedBytes = (uint) managementObject.Properties["NumberTotalreservedBytes"].Value,
                    PercentTimeinGC = (uint) managementObject.Properties["PercentTimeinGC"].Value,
                    ProcessID = (uint) managementObject.Properties["ProcessID"].Value,
                    PromotedFinalizationMemoryfromGen0 =
                        (uint) managementObject.Properties["PromotedFinalizationMemoryfromGen0"].Value,
                    PromotedMemoryfromGen0 = (uint) managementObject.Properties["PromotedMemoryfromGen0"].Value,
                    PromotedMemoryfromGen1 = (uint) managementObject.Properties["PromotedMemoryfromGen1"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}