using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Tcpip_ICMPv6
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint MessagesOutboundErrors { get; private set; }
        public uint MessagesPersec { get; private set; }
        public uint MessagesReceivedErrors { get; private set; }
        public uint MessagesReceivedPersec { get; private set; }
        public uint MessagesSentPersec { get; private set; }
        public string Name { get; private set; }
        public uint ReceivedDestUnreachable { get; private set; }
        public uint ReceivedEchoPersec { get; private set; }
        public uint ReceivedEchoReplyPersec { get; private set; }
        public uint ReceivedMembershipQuery { get; private set; }
        public uint ReceivedMembershipReduction { get; private set; }
        public uint ReceivedMembershipReport { get; private set; }
        public uint ReceivedNeighborAdvert { get; private set; }
        public uint ReceivedNeighborSolicit { get; private set; }
        public uint ReceivedPacketTooBig { get; private set; }
        public uint ReceivedParameterProblem { get; private set; }
        public uint ReceivedRedirectPersec { get; private set; }
        public uint ReceivedRouterAdvert { get; private set; }
        public uint ReceivedRouterSolicit { get; private set; }
        public uint ReceivedTimeExceeded { get; private set; }
        public uint SentDestinationUnreachable { get; private set; }
        public uint SentEchoPersec { get; private set; }
        public uint SentEchoReplyPersec { get; private set; }
        public uint SentMembershipQuery { get; private set; }
        public uint SentMembershipReduction { get; private set; }
        public uint SentMembershipReport { get; private set; }
        public uint SentNeighborAdvert { get; private set; }
        public uint SentNeighborSolicit { get; private set; }
        public uint SentPacketTooBig { get; private set; }
        public uint SentParameterProblem { get; private set; }
        public uint SentRedirectPersec { get; private set; }
        public uint SentRouterAdvert { get; private set; }
        public uint SentRouterSolicit { get; private set; }
        public uint SentTimeExceeded { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Tcpip_ICMPv6[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Tcpip_ICMPv6[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Tcpip_ICMPv6[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Tcpip_ICMPv6");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Tcpip_ICMPv6>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Tcpip_ICMPv6
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MessagesOutboundErrors = (uint) managementObject.Properties["MessagesOutboundErrors"].Value,
                    MessagesPersec = (uint) managementObject.Properties["MessagesPersec"].Value,
                    MessagesReceivedErrors = (uint) managementObject.Properties["MessagesReceivedErrors"].Value,
                    MessagesReceivedPersec = (uint) managementObject.Properties["MessagesReceivedPersec"].Value,
                    MessagesSentPersec = (uint) managementObject.Properties["MessagesSentPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ReceivedDestUnreachable = (uint) managementObject.Properties["ReceivedDestUnreachable"].Value,
                    ReceivedEchoPersec = (uint) managementObject.Properties["ReceivedEchoPersec"].Value,
                    ReceivedEchoReplyPersec = (uint) managementObject.Properties["ReceivedEchoReplyPersec"].Value,
                    ReceivedMembershipQuery = (uint) managementObject.Properties["ReceivedMembershipQuery"].Value,
                    ReceivedMembershipReduction = (uint) managementObject.Properties["ReceivedMembershipReduction"]
                        .Value,
                    ReceivedMembershipReport = (uint) managementObject.Properties["ReceivedMembershipReport"].Value,
                    ReceivedNeighborAdvert = (uint) managementObject.Properties["ReceivedNeighborAdvert"].Value,
                    ReceivedNeighborSolicit = (uint) managementObject.Properties["ReceivedNeighborSolicit"].Value,
                    ReceivedPacketTooBig = (uint) managementObject.Properties["ReceivedPacketTooBig"].Value,
                    ReceivedParameterProblem = (uint) managementObject.Properties["ReceivedParameterProblem"].Value,
                    ReceivedRedirectPersec = (uint) managementObject.Properties["ReceivedRedirectPersec"].Value,
                    ReceivedRouterAdvert = (uint) managementObject.Properties["ReceivedRouterAdvert"].Value,
                    ReceivedRouterSolicit = (uint) managementObject.Properties["ReceivedRouterSolicit"].Value,
                    ReceivedTimeExceeded = (uint) managementObject.Properties["ReceivedTimeExceeded"].Value,
                    SentDestinationUnreachable = (uint) managementObject.Properties["SentDestinationUnreachable"].Value,
                    SentEchoPersec = (uint) managementObject.Properties["SentEchoPersec"].Value,
                    SentEchoReplyPersec = (uint) managementObject.Properties["SentEchoReplyPersec"].Value,
                    SentMembershipQuery = (uint) managementObject.Properties["SentMembershipQuery"].Value,
                    SentMembershipReduction = (uint) managementObject.Properties["SentMembershipReduction"].Value,
                    SentMembershipReport = (uint) managementObject.Properties["SentMembershipReport"].Value,
                    SentNeighborAdvert = (uint) managementObject.Properties["SentNeighborAdvert"].Value,
                    SentNeighborSolicit = (uint) managementObject.Properties["SentNeighborSolicit"].Value,
                    SentPacketTooBig = (uint) managementObject.Properties["SentPacketTooBig"].Value,
                    SentParameterProblem = (uint) managementObject.Properties["SentParameterProblem"].Value,
                    SentRedirectPersec = (uint) managementObject.Properties["SentRedirectPersec"].Value,
                    SentRouterAdvert = (uint) managementObject.Properties["SentRouterAdvert"].Value,
                    SentRouterSolicit = (uint) managementObject.Properties["SentRouterSolicit"].Value,
                    SentTimeExceeded = (uint) managementObject.Properties["SentTimeExceeded"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}