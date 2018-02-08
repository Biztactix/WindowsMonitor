using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_PerfProc_Process
    {
        public string Caption { get; private set; }
        public uint CreatingProcessID { get; private set; }
        public string Description { get; private set; }
        public ulong ElapsedTime { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint HandleCount { get; private set; }
        public uint IDProcess { get; private set; }
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
        public ulong WorkingSetPrivate { get; private set; }

        public static PerfFormattedData_PerfProc_Process[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_PerfProc_Process[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_PerfProc_Process[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfProc_Process");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_PerfProc_Process>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_PerfProc_Process
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CreatingProcessID = (uint) managementObject.Properties["CreatingProcessID"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ElapsedTime = (ulong) managementObject.Properties["ElapsedTime"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    HandleCount = (uint) managementObject.Properties["HandleCount"].Value,
                    IDProcess = (uint) managementObject.Properties["IDProcess"].Value,
                    IODataBytesPersec = (ulong) managementObject.Properties["IODataBytesPersec"].Value,
                    IODataOperationsPersec = (ulong) managementObject.Properties["IODataOperationsPersec"].Value,
                    IOOtherBytesPersec = (ulong) managementObject.Properties["IOOtherBytesPersec"].Value,
                    IOOtherOperationsPersec = (ulong) managementObject.Properties["IOOtherOperationsPersec"].Value,
                    IOReadBytesPersec = (ulong) managementObject.Properties["IOReadBytesPersec"].Value,
                    IOReadOperationsPersec = (ulong) managementObject.Properties["IOReadOperationsPersec"].Value,
                    IOWriteBytesPersec = (ulong) managementObject.Properties["IOWriteBytesPersec"].Value,
                    IOWriteOperationsPersec = (ulong) managementObject.Properties["IOWriteOperationsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PageFaultsPersec = (uint) managementObject.Properties["PageFaultsPersec"].Value,
                    PageFileBytes = (ulong) managementObject.Properties["PageFileBytes"].Value,
                    PageFileBytesPeak = (ulong) managementObject.Properties["PageFileBytesPeak"].Value,
                    PercentPrivilegedTime = (ulong) managementObject.Properties["PercentPrivilegedTime"].Value,
                    PercentProcessorTime = (ulong) managementObject.Properties["PercentProcessorTime"].Value,
                    PercentUserTime = (ulong) managementObject.Properties["PercentUserTime"].Value,
                    PoolNonpagedBytes = (uint) managementObject.Properties["PoolNonpagedBytes"].Value,
                    PoolPagedBytes = (uint) managementObject.Properties["PoolPagedBytes"].Value,
                    PriorityBase = (uint) managementObject.Properties["PriorityBase"].Value,
                    PrivateBytes = (ulong) managementObject.Properties["PrivateBytes"].Value,
                    ThreadCount = (uint) managementObject.Properties["ThreadCount"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    VirtualBytes = (ulong) managementObject.Properties["VirtualBytes"].Value,
                    VirtualBytesPeak = (ulong) managementObject.Properties["VirtualBytesPeak"].Value,
                    WorkingSet = (ulong) managementObject.Properties["WorkingSet"].Value,
                    WorkingSetPeak = (ulong) managementObject.Properties["WorkingSetPeak"].Value,
                    WorkingSetPrivate = (ulong) managementObject.Properties["WorkingSetPrivate"].Value
                });

            return list.ToArray();
        }
    }
}