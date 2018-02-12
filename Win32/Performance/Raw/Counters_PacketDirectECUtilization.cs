using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_PacketDirectECUtilization
    {
		public uint BusyWaitIterationsPersec { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint IterationsPersec { get; private set; }
		public string Name { get; private set; }
		public ulong PercentBusyWaitingTime { get; private set; }
		public ulong PercentBusyWaitingTime_Base { get; private set; }
		public uint PercentBusyWaitIterations { get; private set; }
		public uint PercentBusyWaitIterations_Base { get; private set; }
		public ulong PercentIdleTime { get; private set; }
		public ulong PercentIdleTime_Base { get; private set; }
		public ulong PercentProcessingTime { get; private set; }
		public ulong PercentProcessingTime_Base { get; private set; }
		public uint ProcessorNumber { get; private set; }
		public uint RXQueueCount { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong TotalBusyWaitIterations { get; private set; }
		public ulong TotalIterations { get; private set; }
		public uint TXQueueCount { get; private set; }

        public static IEnumerable<Counters_PacketDirectECUtilization> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_PacketDirectECUtilization> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_PacketDirectECUtilization> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_PacketDirectECUtilization");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_PacketDirectECUtilization
                {
                     BusyWaitIterationsPersec = (uint) (managementObject.Properties["BusyWaitIterationsPersec"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IterationsPersec = (uint) (managementObject.Properties["IterationsPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PercentBusyWaitingTime = (ulong) (managementObject.Properties["PercentBusyWaitingTime"]?.Value ?? default(ulong)),
		 PercentBusyWaitingTime_Base = (ulong) (managementObject.Properties["PercentBusyWaitingTime_Base"]?.Value ?? default(ulong)),
		 PercentBusyWaitIterations = (uint) (managementObject.Properties["PercentBusyWaitIterations"]?.Value ?? default(uint)),
		 PercentBusyWaitIterations_Base = (uint) (managementObject.Properties["PercentBusyWaitIterations_Base"]?.Value ?? default(uint)),
		 PercentIdleTime = (ulong) (managementObject.Properties["PercentIdleTime"]?.Value ?? default(ulong)),
		 PercentIdleTime_Base = (ulong) (managementObject.Properties["PercentIdleTime_Base"]?.Value ?? default(ulong)),
		 PercentProcessingTime = (ulong) (managementObject.Properties["PercentProcessingTime"]?.Value ?? default(ulong)),
		 PercentProcessingTime_Base = (ulong) (managementObject.Properties["PercentProcessingTime_Base"]?.Value ?? default(ulong)),
		 ProcessorNumber = (uint) (managementObject.Properties["ProcessorNumber"]?.Value ?? default(uint)),
		 RXQueueCount = (uint) (managementObject.Properties["RXQueueCount"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalBusyWaitIterations = (ulong) (managementObject.Properties["TotalBusyWaitIterations"]?.Value ?? default(ulong)),
		 TotalIterations = (ulong) (managementObject.Properties["TotalIterations"]?.Value ?? default(ulong)),
		 TXQueueCount = (uint) (managementObject.Properties["TXQueueCount"]?.Value ?? default(uint))
                };
        }
    }
}