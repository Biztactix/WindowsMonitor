using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class NETFramework_NETCLRMemory
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

        public static IEnumerable<NETFramework_NETCLRMemory> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NETFramework_NETCLRMemory> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NETFramework_NETCLRMemory> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_NETFramework_NETCLRMemory");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NETFramework_NETCLRMemory
                {
                     AllocatedBytesPersec = (uint) (managementObject.Properties["AllocatedBytesPersec"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FinalizationSurvivors = (uint) (managementObject.Properties["FinalizationSurvivors"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Gen0heapsize = (uint) (managementObject.Properties["Gen0heapsize"]?.Value ?? default(uint)),
		 Gen0PromotedBytesPerSec = (uint) (managementObject.Properties["Gen0PromotedBytesPerSec"]?.Value ?? default(uint)),
		 Gen1heapsize = (uint) (managementObject.Properties["Gen1heapsize"]?.Value ?? default(uint)),
		 Gen1PromotedBytesPerSec = (uint) (managementObject.Properties["Gen1PromotedBytesPerSec"]?.Value ?? default(uint)),
		 Gen2heapsize = (uint) (managementObject.Properties["Gen2heapsize"]?.Value ?? default(uint)),
		 LargeObjectHeapsize = (uint) (managementObject.Properties["LargeObjectHeapsize"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberBytesinallHeaps = (uint) (managementObject.Properties["NumberBytesinallHeaps"]?.Value ?? default(uint)),
		 NumberGCHandles = (uint) (managementObject.Properties["NumberGCHandles"]?.Value ?? default(uint)),
		 NumberGen0Collections = (uint) (managementObject.Properties["NumberGen0Collections"]?.Value ?? default(uint)),
		 NumberGen1Collections = (uint) (managementObject.Properties["NumberGen1Collections"]?.Value ?? default(uint)),
		 NumberGen2Collections = (uint) (managementObject.Properties["NumberGen2Collections"]?.Value ?? default(uint)),
		 NumberInducedGC = (uint) (managementObject.Properties["NumberInducedGC"]?.Value ?? default(uint)),
		 NumberofPinnedObjects = (uint) (managementObject.Properties["NumberofPinnedObjects"]?.Value ?? default(uint)),
		 NumberofSinkBlocksinuse = (uint) (managementObject.Properties["NumberofSinkBlocksinuse"]?.Value ?? default(uint)),
		 NumberTotalcommittedBytes = (uint) (managementObject.Properties["NumberTotalcommittedBytes"]?.Value ?? default(uint)),
		 NumberTotalreservedBytes = (uint) (managementObject.Properties["NumberTotalreservedBytes"]?.Value ?? default(uint)),
		 PercentTimeinGC = (uint) (managementObject.Properties["PercentTimeinGC"]?.Value ?? default(uint)),
		 ProcessID = (uint) (managementObject.Properties["ProcessID"]?.Value ?? default(uint)),
		 PromotedFinalizationMemoryfromGen0 = (uint) (managementObject.Properties["PromotedFinalizationMemoryfromGen0"]?.Value ?? default(uint)),
		 PromotedMemoryfromGen0 = (uint) (managementObject.Properties["PromotedMemoryfromGen0"]?.Value ?? default(uint)),
		 PromotedMemoryfromGen1 = (uint) (managementObject.Properties["PromotedMemoryfromGen1"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}