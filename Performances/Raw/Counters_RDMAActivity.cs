using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_RDMAActivity
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint RDMAAcceptedConnections { get; private set; }
        public uint RDMAActiveConnections { get; private set; }
        public uint RDMACompletionQueueErrors { get; private set; }
        public uint RDMAConnectionErrors { get; private set; }
        public uint RDMAFailedConnectionAttempts { get; private set; }
        public ulong RDMAInboundBytesPersec { get; private set; }
        public ulong RDMAInboundFramesPersec { get; private set; }
        public uint RDMAInitiatedConnections { get; private set; }
        public ulong RDMAOutboundBytesPersec { get; private set; }
        public ulong RDMAOutboundFramesPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_RDMAActivity[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_RDMAActivity[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_RDMAActivity[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_RDMAActivity");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_RDMAActivity>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_RDMAActivity
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    RDMAAcceptedConnections = (uint) managementObject.Properties["RDMAAcceptedConnections"].Value,
                    RDMAActiveConnections = (uint) managementObject.Properties["RDMAActiveConnections"].Value,
                    RDMACompletionQueueErrors = (uint) managementObject.Properties["RDMACompletionQueueErrors"].Value,
                    RDMAConnectionErrors = (uint) managementObject.Properties["RDMAConnectionErrors"].Value,
                    RDMAFailedConnectionAttempts = (uint) managementObject.Properties["RDMAFailedConnectionAttempts"]
                        .Value,
                    RDMAInboundBytesPersec = (ulong) managementObject.Properties["RDMAInboundBytesPersec"].Value,
                    RDMAInboundFramesPersec = (ulong) managementObject.Properties["RDMAInboundFramesPersec"].Value,
                    RDMAInitiatedConnections = (uint) managementObject.Properties["RDMAInitiatedConnections"].Value,
                    RDMAOutboundBytesPersec = (ulong) managementObject.Properties["RDMAOutboundBytesPersec"].Value,
                    RDMAOutboundFramesPersec = (ulong) managementObject.Properties["RDMAOutboundFramesPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}