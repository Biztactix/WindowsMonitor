using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Tcpip_NetworkAdapter
    {
        public ulong BytesReceivedPersec { get; private set; }
        public ulong BytesSentPersec { get; private set; }
        public ulong BytesTotalPersec { get; private set; }
        public string Caption { get; private set; }
        public ulong CurrentBandwidth { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong OffloadedConnections { get; private set; }
        public ulong OutputQueueLength { get; private set; }
        public ulong PacketsOutboundDiscarded { get; private set; }
        public ulong PacketsOutboundErrors { get; private set; }
        public ulong PacketsPersec { get; private set; }
        public ulong PacketsReceivedDiscarded { get; private set; }
        public ulong PacketsReceivedErrors { get; private set; }
        public ulong PacketsReceivedNonUnicastPersec { get; private set; }
        public ulong PacketsReceivedPersec { get; private set; }
        public ulong PacketsReceivedUnicastPersec { get; private set; }
        public ulong PacketsReceivedUnknown { get; private set; }
        public ulong PacketsSentNonUnicastPersec { get; private set; }
        public ulong PacketsSentPersec { get; private set; }
        public ulong PacketsSentUnicastPersec { get; private set; }
        public ulong TCPActiveRSCConnections { get; private set; }
        public ulong TCPRSCAveragePacketSize { get; private set; }
        public ulong TCPRSCCoalescedPacketsPersec { get; private set; }
        public ulong TCPRSCExceptionsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Tcpip_NetworkAdapter[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Tcpip_NetworkAdapter[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Tcpip_NetworkAdapter[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Tcpip_NetworkAdapter");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Tcpip_NetworkAdapter>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Tcpip_NetworkAdapter
                {
                    BytesReceivedPersec = (ulong) managementObject.Properties["BytesReceivedPersec"].Value,
                    BytesSentPersec = (ulong) managementObject.Properties["BytesSentPersec"].Value,
                    BytesTotalPersec = (ulong) managementObject.Properties["BytesTotalPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentBandwidth = (ulong) managementObject.Properties["CurrentBandwidth"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OffloadedConnections = (ulong) managementObject.Properties["OffloadedConnections"].Value,
                    OutputQueueLength = (ulong) managementObject.Properties["OutputQueueLength"].Value,
                    PacketsOutboundDiscarded = (ulong) managementObject.Properties["PacketsOutboundDiscarded"].Value,
                    PacketsOutboundErrors = (ulong) managementObject.Properties["PacketsOutboundErrors"].Value,
                    PacketsPersec = (ulong) managementObject.Properties["PacketsPersec"].Value,
                    PacketsReceivedDiscarded = (ulong) managementObject.Properties["PacketsReceivedDiscarded"].Value,
                    PacketsReceivedErrors = (ulong) managementObject.Properties["PacketsReceivedErrors"].Value,
                    PacketsReceivedNonUnicastPersec =
                        (ulong) managementObject.Properties["PacketsReceivedNonUnicastPersec"].Value,
                    PacketsReceivedPersec = (ulong) managementObject.Properties["PacketsReceivedPersec"].Value,
                    PacketsReceivedUnicastPersec = (ulong) managementObject.Properties["PacketsReceivedUnicastPersec"]
                        .Value,
                    PacketsReceivedUnknown = (ulong) managementObject.Properties["PacketsReceivedUnknown"].Value,
                    PacketsSentNonUnicastPersec = (ulong) managementObject.Properties["PacketsSentNonUnicastPersec"]
                        .Value,
                    PacketsSentPersec = (ulong) managementObject.Properties["PacketsSentPersec"].Value,
                    PacketsSentUnicastPersec = (ulong) managementObject.Properties["PacketsSentUnicastPersec"].Value,
                    TCPActiveRSCConnections = (ulong) managementObject.Properties["TCPActiveRSCConnections"].Value,
                    TCPRSCAveragePacketSize = (ulong) managementObject.Properties["TCPRSCAveragePacketSize"].Value,
                    TCPRSCCoalescedPacketsPersec = (ulong) managementObject.Properties["TCPRSCCoalescedPacketsPersec"]
                        .Value,
                    TCPRSCExceptionsPersec = (ulong) managementObject.Properties["TCPRSCExceptionsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}