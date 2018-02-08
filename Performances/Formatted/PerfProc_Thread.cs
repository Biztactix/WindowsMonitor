using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_PerfProc_Thread
    {
        public string Caption { get; private set; }
        public uint ContextSwitchesPersec { get; private set; }
        public string Description { get; private set; }
        public ulong ElapsedTime { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint IDProcess { get; private set; }
        public uint IDThread { get; private set; }
        public string Name { get; private set; }
        public ulong PercentPrivilegedTime { get; private set; }
        public ulong PercentProcessorTime { get; private set; }
        public ulong PercentUserTime { get; private set; }
        public uint PriorityBase { get; private set; }
        public uint PriorityCurrent { get; private set; }
        public uint StartAddress { get; private set; }
        public uint ThreadState { get; private set; }
        public uint ThreadWaitReason { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_PerfProc_Thread[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_PerfProc_Thread[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_PerfProc_Thread[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfProc_Thread");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_PerfProc_Thread>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_PerfProc_Thread
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ContextSwitchesPersec = (uint) managementObject.Properties["ContextSwitchesPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ElapsedTime = (ulong) managementObject.Properties["ElapsedTime"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IDProcess = (uint) managementObject.Properties["IDProcess"].Value,
                    IDThread = (uint) managementObject.Properties["IDThread"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PercentPrivilegedTime = (ulong) managementObject.Properties["PercentPrivilegedTime"].Value,
                    PercentProcessorTime = (ulong) managementObject.Properties["PercentProcessorTime"].Value,
                    PercentUserTime = (ulong) managementObject.Properties["PercentUserTime"].Value,
                    PriorityBase = (uint) managementObject.Properties["PriorityBase"].Value,
                    PriorityCurrent = (uint) managementObject.Properties["PriorityCurrent"].Value,
                    StartAddress = (uint) managementObject.Properties["StartAddress"].Value,
                    ThreadState = (uint) managementObject.Properties["ThreadState"].Value,
                    ThreadWaitReason = (uint) managementObject.Properties["ThreadWaitReason"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}