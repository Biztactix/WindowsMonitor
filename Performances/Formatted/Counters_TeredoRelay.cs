using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_TeredoRelay
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint InTeredoRelayErrorPacketsDestinationError { get; private set; }
        public uint InTeredoRelayErrorPacketsHeaderError { get; private set; }
        public uint InTeredoRelayErrorPacketsSourceError { get; private set; }
        public uint InTeredoRelayErrorPacketsTotal { get; private set; }
        public uint InTeredoRelaySuccessPacketsBubbles { get; private set; }
        public ulong InTeredoRelaySuccessPacketsDataPackets { get; private set; }
        public ulong InTeredoRelaySuccessPacketsDataPacketsKernelMode { get; private set; }
        public ulong InTeredoRelaySuccessPacketsDataPacketsUserMode { get; private set; }
        public ulong InTeredoRelaySuccessPacketsTotal { get; private set; }
        public uint InTeredoRelayTotalPacketsSuccessError { get; private set; }
        public uint InTeredoRelayTotalPacketsSuccessErrorPersec { get; private set; }
        public string Name { get; private set; }
        public uint OutTeredoRelayErrorPackets { get; private set; }
        public uint OutTeredoRelayErrorPacketsDestinationError { get; private set; }
        public uint OutTeredoRelayErrorPacketsHeaderError { get; private set; }
        public uint OutTeredoRelayErrorPacketsSourceError { get; private set; }
        public ulong OutTeredoRelaySuccessPackets { get; private set; }
        public uint OutTeredoRelaySuccessPacketsBubbles { get; private set; }
        public ulong OutTeredoRelaySuccessPacketsDataPackets { get; private set; }
        public ulong OutTeredoRelaySuccessPacketsDataPacketsKernelMode { get; private set; }
        public ulong OutTeredoRelaySuccessPacketsDataPacketsUserMode { get; private set; }
        public uint OutTeredoRelayTotalPacketsSuccessError { get; private set; }
        public uint OutTeredoRelayTotalPacketsSuccessErrorPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_Counters_TeredoRelay[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_Counters_TeredoRelay[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_TeredoRelay[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_TeredoRelay");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_TeredoRelay>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_TeredoRelay
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InTeredoRelayErrorPacketsDestinationError = (uint) managementObject
                        .Properties["InTeredoRelayErrorPacketsDestinationError"].Value,
                    InTeredoRelayErrorPacketsHeaderError = (uint) managementObject
                        .Properties["InTeredoRelayErrorPacketsHeaderError"].Value,
                    InTeredoRelayErrorPacketsSourceError = (uint) managementObject
                        .Properties["InTeredoRelayErrorPacketsSourceError"].Value,
                    InTeredoRelayErrorPacketsTotal =
                        (uint) managementObject.Properties["InTeredoRelayErrorPacketsTotal"].Value,
                    InTeredoRelaySuccessPacketsBubbles =
                        (uint) managementObject.Properties["InTeredoRelaySuccessPacketsBubbles"].Value,
                    InTeredoRelaySuccessPacketsDataPackets = (ulong) managementObject
                        .Properties["InTeredoRelaySuccessPacketsDataPackets"].Value,
                    InTeredoRelaySuccessPacketsDataPacketsKernelMode = (ulong) managementObject
                        .Properties["InTeredoRelaySuccessPacketsDataPacketsKernelMode"].Value,
                    InTeredoRelaySuccessPacketsDataPacketsUserMode = (ulong) managementObject
                        .Properties["InTeredoRelaySuccessPacketsDataPacketsUserMode"].Value,
                    InTeredoRelaySuccessPacketsTotal =
                        (ulong) managementObject.Properties["InTeredoRelaySuccessPacketsTotal"].Value,
                    InTeredoRelayTotalPacketsSuccessError = (uint) managementObject
                        .Properties["InTeredoRelayTotalPacketsSuccessError"].Value,
                    InTeredoRelayTotalPacketsSuccessErrorPersec = (uint) managementObject
                        .Properties["InTeredoRelayTotalPacketsSuccessErrorPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OutTeredoRelayErrorPackets = (uint) managementObject.Properties["OutTeredoRelayErrorPackets"].Value,
                    OutTeredoRelayErrorPacketsDestinationError = (uint) managementObject
                        .Properties["OutTeredoRelayErrorPacketsDestinationError"].Value,
                    OutTeredoRelayErrorPacketsHeaderError = (uint) managementObject
                        .Properties["OutTeredoRelayErrorPacketsHeaderError"].Value,
                    OutTeredoRelayErrorPacketsSourceError = (uint) managementObject
                        .Properties["OutTeredoRelayErrorPacketsSourceError"].Value,
                    OutTeredoRelaySuccessPackets = (ulong) managementObject.Properties["OutTeredoRelaySuccessPackets"]
                        .Value,
                    OutTeredoRelaySuccessPacketsBubbles =
                        (uint) managementObject.Properties["OutTeredoRelaySuccessPacketsBubbles"].Value,
                    OutTeredoRelaySuccessPacketsDataPackets = (ulong) managementObject
                        .Properties["OutTeredoRelaySuccessPacketsDataPackets"].Value,
                    OutTeredoRelaySuccessPacketsDataPacketsKernelMode = (ulong) managementObject
                        .Properties["OutTeredoRelaySuccessPacketsDataPacketsKernelMode"].Value,
                    OutTeredoRelaySuccessPacketsDataPacketsUserMode = (ulong) managementObject
                        .Properties["OutTeredoRelaySuccessPacketsDataPacketsUserMode"].Value,
                    OutTeredoRelayTotalPacketsSuccessError = (uint) managementObject
                        .Properties["OutTeredoRelayTotalPacketsSuccessError"].Value,
                    OutTeredoRelayTotalPacketsSuccessErrorPersec = (uint) managementObject
                        .Properties["OutTeredoRelayTotalPacketsSuccessErrorPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}