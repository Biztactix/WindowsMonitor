using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_PerfNet_Redirector
    {
        public ulong BytesReceivedPersec { get; private set; }
        public ulong BytesTotalPersec { get; private set; }
        public ulong BytesTransmittedPersec { get; private set; }
        public string Caption { get; private set; }
        public uint ConnectsCore { get; private set; }
        public uint ConnectsLanManager20 { get; private set; }
        public uint ConnectsLanManager21 { get; private set; }
        public uint ConnectsWindowsNT { get; private set; }
        public uint CurrentCommands { get; private set; }
        public string Description { get; private set; }
        public uint FileDataOperationsPersec { get; private set; }
        public uint FileReadOperationsPersec { get; private set; }
        public uint FileWriteOperationsPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint NetworkErrorsPersec { get; private set; }
        public ulong PacketsPersec { get; private set; }
        public ulong PacketsReceivedPersec { get; private set; }
        public ulong PacketsTransmittedPersec { get; private set; }
        public ulong ReadBytesCachePersec { get; private set; }
        public ulong ReadBytesNetworkPersec { get; private set; }
        public ulong ReadBytesNonPagingPersec { get; private set; }
        public ulong ReadBytesPagingPersec { get; private set; }
        public uint ReadOperationsRandomPersec { get; private set; }
        public uint ReadPacketsPersec { get; private set; }
        public uint ReadPacketsSmallPersec { get; private set; }
        public uint ReadsDeniedPersec { get; private set; }
        public uint ReadsLargePersec { get; private set; }
        public uint ServerDisconnects { get; private set; }
        public uint ServerReconnects { get; private set; }
        public uint ServerSessions { get; private set; }
        public uint ServerSessionsHung { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong WriteBytesCachePersec { get; private set; }
        public ulong WriteBytesNetworkPersec { get; private set; }
        public ulong WriteBytesNonPagingPersec { get; private set; }
        public ulong WriteBytesPagingPersec { get; private set; }
        public uint WriteOperationsRandomPersec { get; private set; }
        public uint WritePacketsPersec { get; private set; }
        public uint WritePacketsSmallPersec { get; private set; }
        public uint WritesDeniedPersec { get; private set; }
        public uint WritesLargePersec { get; private set; }

        public static PerfFormattedData_PerfNet_Redirector[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_PerfNet_Redirector[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_PerfNet_Redirector[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfNet_Redirector");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_PerfNet_Redirector>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_PerfNet_Redirector
                {
                    BytesReceivedPersec = (ulong) managementObject.Properties["BytesReceivedPersec"].Value,
                    BytesTotalPersec = (ulong) managementObject.Properties["BytesTotalPersec"].Value,
                    BytesTransmittedPersec = (ulong) managementObject.Properties["BytesTransmittedPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConnectsCore = (uint) managementObject.Properties["ConnectsCore"].Value,
                    ConnectsLanManager20 = (uint) managementObject.Properties["ConnectsLanManager20"].Value,
                    ConnectsLanManager21 = (uint) managementObject.Properties["ConnectsLanManager21"].Value,
                    ConnectsWindowsNT = (uint) managementObject.Properties["ConnectsWindowsNT"].Value,
                    CurrentCommands = (uint) managementObject.Properties["CurrentCommands"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FileDataOperationsPersec = (uint) managementObject.Properties["FileDataOperationsPersec"].Value,
                    FileReadOperationsPersec = (uint) managementObject.Properties["FileReadOperationsPersec"].Value,
                    FileWriteOperationsPersec = (uint) managementObject.Properties["FileWriteOperationsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NetworkErrorsPersec = (uint) managementObject.Properties["NetworkErrorsPersec"].Value,
                    PacketsPersec = (ulong) managementObject.Properties["PacketsPersec"].Value,
                    PacketsReceivedPersec = (ulong) managementObject.Properties["PacketsReceivedPersec"].Value,
                    PacketsTransmittedPersec = (ulong) managementObject.Properties["PacketsTransmittedPersec"].Value,
                    ReadBytesCachePersec = (ulong) managementObject.Properties["ReadBytesCachePersec"].Value,
                    ReadBytesNetworkPersec = (ulong) managementObject.Properties["ReadBytesNetworkPersec"].Value,
                    ReadBytesNonPagingPersec = (ulong) managementObject.Properties["ReadBytesNonPagingPersec"].Value,
                    ReadBytesPagingPersec = (ulong) managementObject.Properties["ReadBytesPagingPersec"].Value,
                    ReadOperationsRandomPersec = (uint) managementObject.Properties["ReadOperationsRandomPersec"].Value,
                    ReadPacketsPersec = (uint) managementObject.Properties["ReadPacketsPersec"].Value,
                    ReadPacketsSmallPersec = (uint) managementObject.Properties["ReadPacketsSmallPersec"].Value,
                    ReadsDeniedPersec = (uint) managementObject.Properties["ReadsDeniedPersec"].Value,
                    ReadsLargePersec = (uint) managementObject.Properties["ReadsLargePersec"].Value,
                    ServerDisconnects = (uint) managementObject.Properties["ServerDisconnects"].Value,
                    ServerReconnects = (uint) managementObject.Properties["ServerReconnects"].Value,
                    ServerSessions = (uint) managementObject.Properties["ServerSessions"].Value,
                    ServerSessionsHung = (uint) managementObject.Properties["ServerSessionsHung"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    WriteBytesCachePersec = (ulong) managementObject.Properties["WriteBytesCachePersec"].Value,
                    WriteBytesNetworkPersec = (ulong) managementObject.Properties["WriteBytesNetworkPersec"].Value,
                    WriteBytesNonPagingPersec = (ulong) managementObject.Properties["WriteBytesNonPagingPersec"].Value,
                    WriteBytesPagingPersec = (ulong) managementObject.Properties["WriteBytesPagingPersec"].Value,
                    WriteOperationsRandomPersec = (uint) managementObject.Properties["WriteOperationsRandomPersec"]
                        .Value,
                    WritePacketsPersec = (uint) managementObject.Properties["WritePacketsPersec"].Value,
                    WritePacketsSmallPersec = (uint) managementObject.Properties["WritePacketsSmallPersec"].Value,
                    WritesDeniedPersec = (uint) managementObject.Properties["WritesDeniedPersec"].Value,
                    WritesLargePersec = (uint) managementObject.Properties["WritesLargePersec"].Value
                });

            return list.ToArray();
        }
    }
}