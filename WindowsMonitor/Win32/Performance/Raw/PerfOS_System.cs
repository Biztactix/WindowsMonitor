using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class PerfOS_System
    {
		public uint AlignmentFixupsPersec { get; private set; }
		public string Caption { get; private set; }
		public uint ContextSwitchesPersec { get; private set; }
		public string Description { get; private set; }
		public uint ExceptionDispatchesPersec { get; private set; }
		public ulong FileControlBytesPersec { get; private set; }
		public uint FileControlOperationsPersec { get; private set; }
		public uint FileDataOperationsPersec { get; private set; }
		public ulong FileReadBytesPersec { get; private set; }
		public uint FileReadOperationsPersec { get; private set; }
		public ulong FileWriteBytesPersec { get; private set; }
		public uint FileWriteOperationsPersec { get; private set; }
		public uint FloatingEmulationsPersec { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint PercentRegistryQuotaInUse { get; private set; }
		public uint PercentRegistryQuotaInUse_Base { get; private set; }
		public uint Processes { get; private set; }
		public uint ProcessorQueueLength { get; private set; }
		public uint SystemCallsPersec { get; private set; }
		public ulong SystemUpTime { get; private set; }
		public uint Threads { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<PerfOS_System> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PerfOS_System> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PerfOS_System> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PerfOS_System");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PerfOS_System
                {
                     AlignmentFixupsPersec = (uint) (managementObject.Properties["AlignmentFixupsPersec"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 ContextSwitchesPersec = (uint) (managementObject.Properties["ContextSwitchesPersec"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 ExceptionDispatchesPersec = (uint) (managementObject.Properties["ExceptionDispatchesPersec"]?.Value ?? default(uint)),
		 FileControlBytesPersec = (ulong) (managementObject.Properties["FileControlBytesPersec"]?.Value ?? default(ulong)),
		 FileControlOperationsPersec = (uint) (managementObject.Properties["FileControlOperationsPersec"]?.Value ?? default(uint)),
		 FileDataOperationsPersec = (uint) (managementObject.Properties["FileDataOperationsPersec"]?.Value ?? default(uint)),
		 FileReadBytesPersec = (ulong) (managementObject.Properties["FileReadBytesPersec"]?.Value ?? default(ulong)),
		 FileReadOperationsPersec = (uint) (managementObject.Properties["FileReadOperationsPersec"]?.Value ?? default(uint)),
		 FileWriteBytesPersec = (ulong) (managementObject.Properties["FileWriteBytesPersec"]?.Value ?? default(ulong)),
		 FileWriteOperationsPersec = (uint) (managementObject.Properties["FileWriteOperationsPersec"]?.Value ?? default(uint)),
		 FloatingEmulationsPersec = (uint) (managementObject.Properties["FloatingEmulationsPersec"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 PercentRegistryQuotaInUse = (uint) (managementObject.Properties["PercentRegistryQuotaInUse"]?.Value ?? default(uint)),
		 PercentRegistryQuotaInUse_Base = (uint) (managementObject.Properties["PercentRegistryQuotaInUse_Base"]?.Value ?? default(uint)),
		 Processes = (uint) (managementObject.Properties["Processes"]?.Value ?? default(uint)),
		 ProcessorQueueLength = (uint) (managementObject.Properties["ProcessorQueueLength"]?.Value ?? default(uint)),
		 SystemCallsPersec = (uint) (managementObject.Properties["SystemCallsPersec"]?.Value ?? default(uint)),
		 SystemUpTime = (ulong) (managementObject.Properties["SystemUpTime"]?.Value ?? default(ulong)),
		 Threads = (uint) (managementObject.Properties["Threads"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}