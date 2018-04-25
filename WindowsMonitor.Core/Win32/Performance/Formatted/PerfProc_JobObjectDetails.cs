using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class PerfProc_JobObjectDetails
    {
		public string Caption { get; private set; }
		public ulong CreatingProcessID { get; private set; }
		public string Description { get; private set; }
		public ulong ElapsedTime { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint HandleCount { get; private set; }
		public ulong IDProcess { get; private set; }
		public ulong IODataBytesPersec { get; private set; }
		public ulong IODataOperationsPersec { get; private set; }
		public ulong IOOtherBytesPersec { get; private set; }
		public ulong IOOtherOperationsPersec { get; private set; }
		public ulong IOReadBytesPersec { get; private set; }
		public ulong IOReadOperationsPersec { get; private set; }
		public ulong IOWriteBytesPersec { get; private set; }
		public ulong IOWriteOperationsPersec { get; private set; }
		public string Name { get; private set; }
		public uint PageFaultsPersec { get; private set; }
		public ulong PageFileBytes { get; private set; }
		public ulong PageFileBytesPeak { get; private set; }
		public ulong PercentPrivilegedTime { get; private set; }
		public ulong PercentProcessorTime { get; private set; }
		public ulong PercentUserTime { get; private set; }
		public uint PoolNonpagedBytes { get; private set; }
		public uint PoolPagedBytes { get; private set; }
		public uint PriorityBase { get; private set; }
		public ulong PrivateBytes { get; private set; }
		public uint ThreadCount { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong VirtualBytes { get; private set; }
		public ulong VirtualBytesPeak { get; private set; }
		public ulong WorkingSet { get; private set; }
		public ulong WorkingSetPeak { get; private set; }

        public static IEnumerable<PerfProc_JobObjectDetails> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PerfProc_JobObjectDetails> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PerfProc_JobObjectDetails> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfProc_JobObjectDetails");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PerfProc_JobObjectDetails
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CreatingProcessID = (ulong) (managementObject.Properties["CreatingProcessID"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 ElapsedTime = (ulong) (managementObject.Properties["ElapsedTime"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 HandleCount = (uint) (managementObject.Properties["HandleCount"]?.Value ?? default(uint)),
		 IDProcess = (ulong) (managementObject.Properties["IDProcess"]?.Value ?? default(ulong)),
		 IODataBytesPersec = (ulong) (managementObject.Properties["IODataBytesPersec"]?.Value ?? default(ulong)),
		 IODataOperationsPersec = (ulong) (managementObject.Properties["IODataOperationsPersec"]?.Value ?? default(ulong)),
		 IOOtherBytesPersec = (ulong) (managementObject.Properties["IOOtherBytesPersec"]?.Value ?? default(ulong)),
		 IOOtherOperationsPersec = (ulong) (managementObject.Properties["IOOtherOperationsPersec"]?.Value ?? default(ulong)),
		 IOReadBytesPersec = (ulong) (managementObject.Properties["IOReadBytesPersec"]?.Value ?? default(ulong)),
		 IOReadOperationsPersec = (ulong) (managementObject.Properties["IOReadOperationsPersec"]?.Value ?? default(ulong)),
		 IOWriteBytesPersec = (ulong) (managementObject.Properties["IOWriteBytesPersec"]?.Value ?? default(ulong)),
		 IOWriteOperationsPersec = (ulong) (managementObject.Properties["IOWriteOperationsPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PageFaultsPersec = (uint) (managementObject.Properties["PageFaultsPersec"]?.Value ?? default(uint)),
		 PageFileBytes = (ulong) (managementObject.Properties["PageFileBytes"]?.Value ?? default(ulong)),
		 PageFileBytesPeak = (ulong) (managementObject.Properties["PageFileBytesPeak"]?.Value ?? default(ulong)),
		 PercentPrivilegedTime = (ulong) (managementObject.Properties["PercentPrivilegedTime"]?.Value ?? default(ulong)),
		 PercentProcessorTime = (ulong) (managementObject.Properties["PercentProcessorTime"]?.Value ?? default(ulong)),
		 PercentUserTime = (ulong) (managementObject.Properties["PercentUserTime"]?.Value ?? default(ulong)),
		 PoolNonpagedBytes = (uint) (managementObject.Properties["PoolNonpagedBytes"]?.Value ?? default(uint)),
		 PoolPagedBytes = (uint) (managementObject.Properties["PoolPagedBytes"]?.Value ?? default(uint)),
		 PriorityBase = (uint) (managementObject.Properties["PriorityBase"]?.Value ?? default(uint)),
		 PrivateBytes = (ulong) (managementObject.Properties["PrivateBytes"]?.Value ?? default(ulong)),
		 ThreadCount = (uint) (managementObject.Properties["ThreadCount"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 VirtualBytes = (ulong) (managementObject.Properties["VirtualBytes"]?.Value ?? default(ulong)),
		 VirtualBytesPeak = (ulong) (managementObject.Properties["VirtualBytesPeak"]?.Value ?? default(ulong)),
		 WorkingSet = (ulong) (managementObject.Properties["WorkingSet"]?.Value ?? default(ulong)),
		 WorkingSetPeak = (ulong) (managementObject.Properties["WorkingSetPeak"]?.Value ?? default(ulong))
                };
        }
    }
}