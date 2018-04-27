using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class PerfProc_Thread
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

        public static IEnumerable<PerfProc_Thread> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PerfProc_Thread> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PerfProc_Thread> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfProc_Thread");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PerfProc_Thread
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ContextSwitchesPersec = (uint) (managementObject.Properties["ContextSwitchesPersec"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 ElapsedTime = (ulong) (managementObject.Properties["ElapsedTime"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IDProcess = (uint) (managementObject.Properties["IDProcess"]?.Value ?? default(uint)),
		 IDThread = (uint) (managementObject.Properties["IDThread"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PercentPrivilegedTime = (ulong) (managementObject.Properties["PercentPrivilegedTime"]?.Value ?? default(ulong)),
		 PercentProcessorTime = (ulong) (managementObject.Properties["PercentProcessorTime"]?.Value ?? default(ulong)),
		 PercentUserTime = (ulong) (managementObject.Properties["PercentUserTime"]?.Value ?? default(ulong)),
		 PriorityBase = (uint) (managementObject.Properties["PriorityBase"]?.Value ?? default(uint)),
		 PriorityCurrent = (uint) (managementObject.Properties["PriorityCurrent"]?.Value ?? default(uint)),
		 StartAddress = (uint) (managementObject.Properties["StartAddress"]?.Value ?? default(uint)),
		 ThreadState = (uint) (managementObject.Properties["ThreadState"]?.Value ?? default(uint)),
		 ThreadWaitReason = (uint) (managementObject.Properties["ThreadWaitReason"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}