using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_PerProcessorNetworkInterfaceCardActivity
    {
        public ulong BuildScatterGatherListCallsPersec { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong DPCsDeferredPersec { get; private set; }
        public ulong DPCsQueuedonOtherCPUsPersec { get; private set; }
        public ulong DPCsQueuedPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong InterruptsPersec { get; private set; }
        public ulong LowResourceReceivedPacketsPersec { get; private set; }
        public ulong LowResourceReceiveIndicationsPersec { get; private set; }
        public string Name { get; private set; }
        public ulong PacketsCoalescedPersec { get; private set; }
        public ulong ReceivedPacketsPersec { get; private set; }
        public ulong ReceiveIndicationsPersec { get; private set; }
        public ulong ReturnedPacketsPersec { get; private set; }
        public ulong ReturnPacketCallsPersec { get; private set; }
        public ulong RSSIndirectionTableChangeCallsPersec { get; private set; }
        public ulong SendCompleteCallsPersec { get; private set; }
        public ulong SendRequestCallsPersec { get; private set; }
        public ulong SentCompletePacketsPersec { get; private set; }
        public ulong SentPacketsPersec { get; private set; }
        public ulong TcpOffloadReceivebytesPersec { get; private set; }
        public ulong TcpOffloadReceiveIndicationsPersec { get; private set; }
        public ulong TcpOffloadSendbytesPersec { get; private set; }
        public ulong TcpOffloadSendRequestCallsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_Counters_PerProcessorNetworkInterfaceCardActivity[] Retrieve(string remote,
            string username, string password)
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

        public static PerfFormattedData_Counters_PerProcessorNetworkInterfaceCardActivity[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_PerProcessorNetworkInterfaceCardActivity[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfFormattedData_Counters_PerProcessorNetworkInterfaceCardActivity");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_PerProcessorNetworkInterfaceCardActivity>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_PerProcessorNetworkInterfaceCardActivity
                {
                    BuildScatterGatherListCallsPersec =
                        (ulong) managementObject.Properties["BuildScatterGatherListCallsPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DPCsDeferredPersec = (ulong) managementObject.Properties["DPCsDeferredPersec"].Value,
                    DPCsQueuedonOtherCPUsPersec = (ulong) managementObject.Properties["DPCsQueuedonOtherCPUsPersec"]
                        .Value,
                    DPCsQueuedPersec = (ulong) managementObject.Properties["DPCsQueuedPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InterruptsPersec = (ulong) managementObject.Properties["InterruptsPersec"].Value,
                    LowResourceReceivedPacketsPersec =
                        (ulong) managementObject.Properties["LowResourceReceivedPacketsPersec"].Value,
                    LowResourceReceiveIndicationsPersec =
                        (ulong) managementObject.Properties["LowResourceReceiveIndicationsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PacketsCoalescedPersec = (ulong) managementObject.Properties["PacketsCoalescedPersec"].Value,
                    ReceivedPacketsPersec = (ulong) managementObject.Properties["ReceivedPacketsPersec"].Value,
                    ReceiveIndicationsPersec = (ulong) managementObject.Properties["ReceiveIndicationsPersec"].Value,
                    ReturnedPacketsPersec = (ulong) managementObject.Properties["ReturnedPacketsPersec"].Value,
                    ReturnPacketCallsPersec = (ulong) managementObject.Properties["ReturnPacketCallsPersec"].Value,
                    RSSIndirectionTableChangeCallsPersec = (ulong) managementObject
                        .Properties["RSSIndirectionTableChangeCallsPersec"].Value,
                    SendCompleteCallsPersec = (ulong) managementObject.Properties["SendCompleteCallsPersec"].Value,
                    SendRequestCallsPersec = (ulong) managementObject.Properties["SendRequestCallsPersec"].Value,
                    SentCompletePacketsPersec = (ulong) managementObject.Properties["SentCompletePacketsPersec"].Value,
                    SentPacketsPersec = (ulong) managementObject.Properties["SentPacketsPersec"].Value,
                    TcpOffloadReceivebytesPersec = (ulong) managementObject.Properties["TcpOffloadReceivebytesPersec"]
                        .Value,
                    TcpOffloadReceiveIndicationsPersec =
                        (ulong) managementObject.Properties["TcpOffloadReceiveIndicationsPersec"].Value,
                    TcpOffloadSendbytesPersec = (ulong) managementObject.Properties["TcpOffloadSendbytesPersec"].Value,
                    TcpOffloadSendRequestCallsPersec =
                        (ulong) managementObject.Properties["TcpOffloadSendRequestCallsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}