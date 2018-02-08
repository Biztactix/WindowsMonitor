using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Tcpip_ICMP
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
        public uint ReceivedAddressMask { get; private set; }
        public uint ReceivedAddressMaskReply { get; private set; }
        public uint ReceivedDestUnreachable { get; private set; }
        public uint ReceivedEchoPersec { get; private set; }
        public uint ReceivedEchoReplyPersec { get; private set; }
        public uint ReceivedParameterProblem { get; private set; }
        public uint ReceivedRedirectPersec { get; private set; }
        public uint ReceivedSourceQuench { get; private set; }
        public uint ReceivedTimeExceeded { get; private set; }
        public uint ReceivedTimestampPersec { get; private set; }
        public uint ReceivedTimestampReplyPersec { get; private set; }
        public uint SentAddressMask { get; private set; }
        public uint SentAddressMaskReply { get; private set; }
        public uint SentDestinationUnreachable { get; private set; }
        public uint SentEchoPersec { get; private set; }
        public uint SentEchoReplyPersec { get; private set; }
        public uint SentParameterProblem { get; private set; }
        public uint SentRedirectPersec { get; private set; }
        public uint SentSourceQuench { get; private set; }
        public uint SentTimeExceeded { get; private set; }
        public uint SentTimestampPersec { get; private set; }
        public uint SentTimestampReplyPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_Tcpip_ICMP[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_Tcpip_ICMP[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Tcpip_ICMP[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Tcpip_ICMP");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Tcpip_ICMP>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Tcpip_ICMP
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
                    ReceivedAddressMask = (uint) managementObject.Properties["ReceivedAddressMask"].Value,
                    ReceivedAddressMaskReply = (uint) managementObject.Properties["ReceivedAddressMaskReply"].Value,
                    ReceivedDestUnreachable = (uint) managementObject.Properties["ReceivedDestUnreachable"].Value,
                    ReceivedEchoPersec = (uint) managementObject.Properties["ReceivedEchoPersec"].Value,
                    ReceivedEchoReplyPersec = (uint) managementObject.Properties["ReceivedEchoReplyPersec"].Value,
                    ReceivedParameterProblem = (uint) managementObject.Properties["ReceivedParameterProblem"].Value,
                    ReceivedRedirectPersec = (uint) managementObject.Properties["ReceivedRedirectPersec"].Value,
                    ReceivedSourceQuench = (uint) managementObject.Properties["ReceivedSourceQuench"].Value,
                    ReceivedTimeExceeded = (uint) managementObject.Properties["ReceivedTimeExceeded"].Value,
                    ReceivedTimestampPersec = (uint) managementObject.Properties["ReceivedTimestampPersec"].Value,
                    ReceivedTimestampReplyPersec = (uint) managementObject.Properties["ReceivedTimestampReplyPersec"]
                        .Value,
                    SentAddressMask = (uint) managementObject.Properties["SentAddressMask"].Value,
                    SentAddressMaskReply = (uint) managementObject.Properties["SentAddressMaskReply"].Value,
                    SentDestinationUnreachable = (uint) managementObject.Properties["SentDestinationUnreachable"].Value,
                    SentEchoPersec = (uint) managementObject.Properties["SentEchoPersec"].Value,
                    SentEchoReplyPersec = (uint) managementObject.Properties["SentEchoReplyPersec"].Value,
                    SentParameterProblem = (uint) managementObject.Properties["SentParameterProblem"].Value,
                    SentRedirectPersec = (uint) managementObject.Properties["SentRedirectPersec"].Value,
                    SentSourceQuench = (uint) managementObject.Properties["SentSourceQuench"].Value,
                    SentTimeExceeded = (uint) managementObject.Properties["SentTimeExceeded"].Value,
                    SentTimestampPersec = (uint) managementObject.Properties["SentTimestampPersec"].Value,
                    SentTimestampReplyPersec = (uint) managementObject.Properties["SentTimestampReplyPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}