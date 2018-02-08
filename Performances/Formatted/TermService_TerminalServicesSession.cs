using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_TermService_TerminalServicesSession
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint HandleCount { get; private set; }
        public string Name { get; private set; }
        public uint PageFaultsPersec { get; private set; }
        public ulong PageFileBytes { get; private set; }
        public ulong PageFileBytesPeak { get; private set; }
        public ulong PercentPrivilegedTime { get; private set; }
        public ulong PercentProcessorTime { get; private set; }
        public ulong PercentUserTime { get; private set; }
        public uint PoolNonpagedBytes { get; private set; }
        public uint PoolPagedBytes { get; private set; }
        public ulong PrivateBytes { get; private set; }
        public uint ThreadCount { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong VirtualBytes { get; private set; }
        public ulong VirtualBytesPeak { get; private set; }
        public ulong WorkingSet { get; private set; }
        public ulong WorkingSetPeak { get; private set; }

        public static PerfFormattedData_TermService_TerminalServicesSession[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_TermService_TerminalServicesSession[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_TermService_TerminalServicesSession[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_TermService_TerminalServicesSession");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_TermService_TerminalServicesSession>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_TermService_TerminalServicesSession
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    HandleCount = (uint) managementObject.Properties["HandleCount"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PageFaultsPersec = (uint) managementObject.Properties["PageFaultsPersec"].Value,
                    PageFileBytes = (ulong) managementObject.Properties["PageFileBytes"].Value,
                    PageFileBytesPeak = (ulong) managementObject.Properties["PageFileBytesPeak"].Value,
                    PercentPrivilegedTime = (ulong) managementObject.Properties["PercentPrivilegedTime"].Value,
                    PercentProcessorTime = (ulong) managementObject.Properties["PercentProcessorTime"].Value,
                    PercentUserTime = (ulong) managementObject.Properties["PercentUserTime"].Value,
                    PoolNonpagedBytes = (uint) managementObject.Properties["PoolNonpagedBytes"].Value,
                    PoolPagedBytes = (uint) managementObject.Properties["PoolPagedBytes"].Value,
                    PrivateBytes = (ulong) managementObject.Properties["PrivateBytes"].Value,
                    ThreadCount = (uint) managementObject.Properties["ThreadCount"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    VirtualBytes = (ulong) managementObject.Properties["VirtualBytes"].Value,
                    VirtualBytesPeak = (ulong) managementObject.Properties["VirtualBytesPeak"].Value,
                    WorkingSet = (ulong) managementObject.Properties["WorkingSet"].Value,
                    WorkingSetPeak = (ulong) managementObject.Properties["WorkingSetPeak"].Value
                });

            return list.ToArray();
        }
    }
}