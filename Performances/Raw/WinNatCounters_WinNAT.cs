using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_WinNatCounters_WinNAT
    {
        public string Caption { get; private set; }
        public uint CurrentSessionCount { get; private set; }
        public string Description { get; private set; }
        public uint DroppedICMPerrorpackets { get; private set; }
        public uint DroppedICMPerrorpacketsPersec { get; private set; }
        public uint DroppedPackets { get; private set; }
        public uint DroppedPacketsPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint InterRoutingDomainHairpinnedPackets { get; private set; }
        public uint InterRoutingDomainHairpinnedPacketsPersec { get; private set; }
        public uint IntraRoutingDomainHairpinnedPackets { get; private set; }
        public uint IntraRoutingDomainHairpinnedPacketsPersec { get; private set; }
        public string Name { get; private set; }
        public uint PacketsExternaltoInternal { get; private set; }
        public uint PacketsInternaltoExternal { get; private set; }
        public uint PacketsPersecExternaltoInternal { get; private set; }
        public uint PacketsPersecInternaltoExternal { get; private set; }
        public uint SessionsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_WinNatCounters_WinNAT[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_WinNatCounters_WinNAT[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_WinNatCounters_WinNAT[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_WinNatCounters_WinNAT");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_WinNatCounters_WinNAT>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_WinNatCounters_WinNAT
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentSessionCount = (uint) managementObject.Properties["CurrentSessionCount"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DroppedICMPerrorpackets = (uint) managementObject.Properties["DroppedICMPerrorpackets"].Value,
                    DroppedICMPerrorpacketsPersec = (uint) managementObject.Properties["DroppedICMPerrorpacketsPersec"]
                        .Value,
                    DroppedPackets = (uint) managementObject.Properties["DroppedPackets"].Value,
                    DroppedPacketsPersec = (uint) managementObject.Properties["DroppedPacketsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InterRoutingDomainHairpinnedPackets =
                        (uint) managementObject.Properties["InterRoutingDomainHairpinnedPackets"].Value,
                    InterRoutingDomainHairpinnedPacketsPersec = (uint) managementObject
                        .Properties["InterRoutingDomainHairpinnedPacketsPersec"].Value,
                    IntraRoutingDomainHairpinnedPackets =
                        (uint) managementObject.Properties["IntraRoutingDomainHairpinnedPackets"].Value,
                    IntraRoutingDomainHairpinnedPacketsPersec = (uint) managementObject
                        .Properties["IntraRoutingDomainHairpinnedPacketsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PacketsExternaltoInternal = (uint) managementObject.Properties["PacketsExternaltoInternal"].Value,
                    PacketsInternaltoExternal = (uint) managementObject.Properties["PacketsInternaltoExternal"].Value,
                    PacketsPersecExternaltoInternal =
                        (uint) managementObject.Properties["PacketsPersecExternaltoInternal"].Value,
                    PacketsPersecInternaltoExternal =
                        (uint) managementObject.Properties["PacketsPersecInternaltoExternal"].Value,
                    SessionsPersec = (uint) managementObject.Properties["SessionsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}