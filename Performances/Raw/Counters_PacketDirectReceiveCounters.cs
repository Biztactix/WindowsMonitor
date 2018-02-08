using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_PacketDirectReceiveCounters
    {
        public ulong BytesReceived { get; private set; }
        public ulong BytesReceivedPersec { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong PacketsDropped { get; private set; }
        public ulong PacketsDroppedPersec { get; private set; }
        public ulong PacketsReceived { get; private set; }
        public ulong PacketsReceivedPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_PacketDirectReceiveCounters[] Retrieve(string remote, string username,
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

        public static PerfRawData_Counters_PacketDirectReceiveCounters[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_PacketDirectReceiveCounters[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_PacketDirectReceiveCounters");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_PacketDirectReceiveCounters>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_PacketDirectReceiveCounters
                {
                    BytesReceived = (ulong) managementObject.Properties["BytesReceived"].Value,
                    BytesReceivedPersec = (ulong) managementObject.Properties["BytesReceivedPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PacketsDropped = (ulong) managementObject.Properties["PacketsDropped"].Value,
                    PacketsDroppedPersec = (ulong) managementObject.Properties["PacketsDroppedPersec"].Value,
                    PacketsReceived = (ulong) managementObject.Properties["PacketsReceived"].Value,
                    PacketsReceivedPersec = (ulong) managementObject.Properties["PacketsReceivedPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}