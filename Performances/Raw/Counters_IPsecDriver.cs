using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_IPsecDriver
    {
        public uint ActiveSecurityAssociations { get; private set; }
        public uint BytesReceivedinTransportModePersec { get; private set; }
        public uint BytesReceivedinTunnelModePersec { get; private set; }
        public uint BytesSentinTransportModePersec { get; private set; }
        public uint BytesSentinTunnelModePersec { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint InboundPacketsDroppedPersec { get; private set; }
        public uint InboundPacketsReceivedPersec { get; private set; }
        public uint IncorrectSPIPackets { get; private set; }
        public uint IncorrectSPIPacketsPersec { get; private set; }
        public string Name { get; private set; }
        public uint OffloadedBytesReceivedPersec { get; private set; }
        public uint OffloadedBytesSentPersec { get; private set; }
        public uint OffloadedSecurityAssociations { get; private set; }
        public uint PacketsNotAuthenticated { get; private set; }
        public uint PacketsNotAuthenticatedPersec { get; private set; }
        public uint PacketsNotDecrypted { get; private set; }
        public uint PacketsNotDecryptedPersec { get; private set; }
        public uint PacketsReceivedOverWrongSA { get; private set; }
        public uint PacketsReceivedOverWrongSAPersec { get; private set; }
        public uint PacketsThatFailedESPValidation { get; private set; }
        public uint PacketsThatFailedESPValidationPersec { get; private set; }
        public uint PacketsThatFailedReplayDetection { get; private set; }
        public uint PacketsThatFailedReplayDetectionPersec { get; private set; }
        public uint PacketsThatFailedUDPESPValidation { get; private set; }
        public uint PacketsThatFailedUDPESPValidationPersec { get; private set; }
        public uint PendingSecurityAssociations { get; private set; }
        public uint PlaintextPacketsReceived { get; private set; }
        public uint PlaintextPacketsReceivedPersec { get; private set; }
        public uint SARekeys { get; private set; }
        public uint SecurityAssociationsAdded { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalInboundPacketsDropped { get; private set; }
        public uint TotalInboundPacketsReceived { get; private set; }

        public static PerfRawData_Counters_IPsecDriver[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_IPsecDriver[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_IPsecDriver[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_IPsecDriver");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_IPsecDriver>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_IPsecDriver
                {
                    ActiveSecurityAssociations = (uint) managementObject.Properties["ActiveSecurityAssociations"].Value,
                    BytesReceivedinTransportModePersec =
                        (uint) managementObject.Properties["BytesReceivedinTransportModePersec"].Value,
                    BytesReceivedinTunnelModePersec =
                        (uint) managementObject.Properties["BytesReceivedinTunnelModePersec"].Value,
                    BytesSentinTransportModePersec =
                        (uint) managementObject.Properties["BytesSentinTransportModePersec"].Value,
                    BytesSentinTunnelModePersec = (uint) managementObject.Properties["BytesSentinTunnelModePersec"]
                        .Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InboundPacketsDroppedPersec = (uint) managementObject.Properties["InboundPacketsDroppedPersec"]
                        .Value,
                    InboundPacketsReceivedPersec = (uint) managementObject.Properties["InboundPacketsReceivedPersec"]
                        .Value,
                    IncorrectSPIPackets = (uint) managementObject.Properties["IncorrectSPIPackets"].Value,
                    IncorrectSPIPacketsPersec = (uint) managementObject.Properties["IncorrectSPIPacketsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OffloadedBytesReceivedPersec = (uint) managementObject.Properties["OffloadedBytesReceivedPersec"]
                        .Value,
                    OffloadedBytesSentPersec = (uint) managementObject.Properties["OffloadedBytesSentPersec"].Value,
                    OffloadedSecurityAssociations = (uint) managementObject.Properties["OffloadedSecurityAssociations"]
                        .Value,
                    PacketsNotAuthenticated = (uint) managementObject.Properties["PacketsNotAuthenticated"].Value,
                    PacketsNotAuthenticatedPersec = (uint) managementObject.Properties["PacketsNotAuthenticatedPersec"]
                        .Value,
                    PacketsNotDecrypted = (uint) managementObject.Properties["PacketsNotDecrypted"].Value,
                    PacketsNotDecryptedPersec = (uint) managementObject.Properties["PacketsNotDecryptedPersec"].Value,
                    PacketsReceivedOverWrongSA = (uint) managementObject.Properties["PacketsReceivedOverWrongSA"].Value,
                    PacketsReceivedOverWrongSAPersec =
                        (uint) managementObject.Properties["PacketsReceivedOverWrongSAPersec"].Value,
                    PacketsThatFailedESPValidation =
                        (uint) managementObject.Properties["PacketsThatFailedESPValidation"].Value,
                    PacketsThatFailedESPValidationPersec = (uint) managementObject
                        .Properties["PacketsThatFailedESPValidationPersec"].Value,
                    PacketsThatFailedReplayDetection =
                        (uint) managementObject.Properties["PacketsThatFailedReplayDetection"].Value,
                    PacketsThatFailedReplayDetectionPersec = (uint) managementObject
                        .Properties["PacketsThatFailedReplayDetectionPersec"].Value,
                    PacketsThatFailedUDPESPValidation =
                        (uint) managementObject.Properties["PacketsThatFailedUDPESPValidation"].Value,
                    PacketsThatFailedUDPESPValidationPersec = (uint) managementObject
                        .Properties["PacketsThatFailedUDPESPValidationPersec"].Value,
                    PendingSecurityAssociations = (uint) managementObject.Properties["PendingSecurityAssociations"]
                        .Value,
                    PlaintextPacketsReceived = (uint) managementObject.Properties["PlaintextPacketsReceived"].Value,
                    PlaintextPacketsReceivedPersec =
                        (uint) managementObject.Properties["PlaintextPacketsReceivedPersec"].Value,
                    SARekeys = (uint) managementObject.Properties["SARekeys"].Value,
                    SecurityAssociationsAdded = (uint) managementObject.Properties["SecurityAssociationsAdded"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalInboundPacketsDropped = (uint) managementObject.Properties["TotalInboundPacketsDropped"].Value,
                    TotalInboundPacketsReceived = (uint) managementObject.Properties["TotalInboundPacketsReceived"]
                        .Value
                });

            return list.ToArray();
        }
    }
}