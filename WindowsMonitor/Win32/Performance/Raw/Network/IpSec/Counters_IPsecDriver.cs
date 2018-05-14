using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_IPsecDriver
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

        public static IEnumerable<Counters_IPsecDriver> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_IPsecDriver> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_IPsecDriver> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_IPsecDriver");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_IPsecDriver
                {
                     ActiveSecurityAssociations = (uint) (managementObject.Properties["ActiveSecurityAssociations"]?.Value ?? default(uint)),
		 BytesReceivedinTransportModePersec = (uint) (managementObject.Properties["BytesReceivedinTransportModePersec"]?.Value ?? default(uint)),
		 BytesReceivedinTunnelModePersec = (uint) (managementObject.Properties["BytesReceivedinTunnelModePersec"]?.Value ?? default(uint)),
		 BytesSentinTransportModePersec = (uint) (managementObject.Properties["BytesSentinTransportModePersec"]?.Value ?? default(uint)),
		 BytesSentinTunnelModePersec = (uint) (managementObject.Properties["BytesSentinTunnelModePersec"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 InboundPacketsDroppedPersec = (uint) (managementObject.Properties["InboundPacketsDroppedPersec"]?.Value ?? default(uint)),
		 InboundPacketsReceivedPersec = (uint) (managementObject.Properties["InboundPacketsReceivedPersec"]?.Value ?? default(uint)),
		 IncorrectSPIPackets = (uint) (managementObject.Properties["IncorrectSPIPackets"]?.Value ?? default(uint)),
		 IncorrectSPIPacketsPersec = (uint) (managementObject.Properties["IncorrectSPIPacketsPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 OffloadedBytesReceivedPersec = (uint) (managementObject.Properties["OffloadedBytesReceivedPersec"]?.Value ?? default(uint)),
		 OffloadedBytesSentPersec = (uint) (managementObject.Properties["OffloadedBytesSentPersec"]?.Value ?? default(uint)),
		 OffloadedSecurityAssociations = (uint) (managementObject.Properties["OffloadedSecurityAssociations"]?.Value ?? default(uint)),
		 PacketsNotAuthenticated = (uint) (managementObject.Properties["PacketsNotAuthenticated"]?.Value ?? default(uint)),
		 PacketsNotAuthenticatedPersec = (uint) (managementObject.Properties["PacketsNotAuthenticatedPersec"]?.Value ?? default(uint)),
		 PacketsNotDecrypted = (uint) (managementObject.Properties["PacketsNotDecrypted"]?.Value ?? default(uint)),
		 PacketsNotDecryptedPersec = (uint) (managementObject.Properties["PacketsNotDecryptedPersec"]?.Value ?? default(uint)),
		 PacketsReceivedOverWrongSA = (uint) (managementObject.Properties["PacketsReceivedOverWrongSA"]?.Value ?? default(uint)),
		 PacketsReceivedOverWrongSAPersec = (uint) (managementObject.Properties["PacketsReceivedOverWrongSAPersec"]?.Value ?? default(uint)),
		 PacketsThatFailedESPValidation = (uint) (managementObject.Properties["PacketsThatFailedESPValidation"]?.Value ?? default(uint)),
		 PacketsThatFailedESPValidationPersec = (uint) (managementObject.Properties["PacketsThatFailedESPValidationPersec"]?.Value ?? default(uint)),
		 PacketsThatFailedReplayDetection = (uint) (managementObject.Properties["PacketsThatFailedReplayDetection"]?.Value ?? default(uint)),
		 PacketsThatFailedReplayDetectionPersec = (uint) (managementObject.Properties["PacketsThatFailedReplayDetectionPersec"]?.Value ?? default(uint)),
		 PacketsThatFailedUDPESPValidation = (uint) (managementObject.Properties["PacketsThatFailedUDPESPValidation"]?.Value ?? default(uint)),
		 PacketsThatFailedUDPESPValidationPersec = (uint) (managementObject.Properties["PacketsThatFailedUDPESPValidationPersec"]?.Value ?? default(uint)),
		 PendingSecurityAssociations = (uint) (managementObject.Properties["PendingSecurityAssociations"]?.Value ?? default(uint)),
		 PlaintextPacketsReceived = (uint) (managementObject.Properties["PlaintextPacketsReceived"]?.Value ?? default(uint)),
		 PlaintextPacketsReceivedPersec = (uint) (managementObject.Properties["PlaintextPacketsReceivedPersec"]?.Value ?? default(uint)),
		 SARekeys = (uint) (managementObject.Properties["SARekeys"]?.Value ?? default(uint)),
		 SecurityAssociationsAdded = (uint) (managementObject.Properties["SecurityAssociationsAdded"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalInboundPacketsDropped = (uint) (managementObject.Properties["TotalInboundPacketsDropped"]?.Value ?? default(uint)),
		 TotalInboundPacketsReceived = (uint) (managementObject.Properties["TotalInboundPacketsReceived"]?.Value ?? default(uint))
                };
        }
    }
}