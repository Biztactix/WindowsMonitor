using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_PacketDirectECUtilization
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
        public uint PercentBusyWaitIterations { get; private set; }
        public ulong PercentIdleTime { get; private set; }
        public ulong PercentProcessingTime { get; private set; }
        public uint ProcessorNumber { get; private set; }
        public uint RXQueueCount { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalBusyWaitIterations { get; private set; }
        public ulong TotalIterations { get; private set; }
        public uint TXQueueCount { get; private set; }

        public static PerfFormattedData_Counters_PacketDirectECUtilization[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_Counters_PacketDirectECUtilization[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_PacketDirectECUtilization[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_PacketDirectECUtilization");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_PacketDirectECUtilization>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_PacketDirectECUtilization
                {
                    BusyWaitIterationsPersec = (uint) managementObject.Properties["BusyWaitIterationsPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IterationsPersec = (uint) managementObject.Properties["IterationsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PercentBusyWaitingTime = (ulong) managementObject.Properties["PercentBusyWaitingTime"].Value,
                    PercentBusyWaitIterations = (uint) managementObject.Properties["PercentBusyWaitIterations"].Value,
                    PercentIdleTime = (ulong) managementObject.Properties["PercentIdleTime"].Value,
                    PercentProcessingTime = (ulong) managementObject.Properties["PercentProcessingTime"].Value,
                    ProcessorNumber = (uint) managementObject.Properties["ProcessorNumber"].Value,
                    RXQueueCount = (uint) managementObject.Properties["RXQueueCount"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalBusyWaitIterations = (ulong) managementObject.Properties["TotalBusyWaitIterations"].Value,
                    TotalIterations = (ulong) managementObject.Properties["TotalIterations"].Value,
                    TXQueueCount = (uint) managementObject.Properties["TXQueueCount"].Value
                });

            return list.ToArray();
        }
    }
}