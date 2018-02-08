using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_TeredoServer
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint InTeredoServerErrorPacketsAuthenticationError { get; private set; }
        public uint InTeredoServerErrorPacketsDestinationError { get; private set; }
        public uint InTeredoServerErrorPacketsHeaderError { get; private set; }
        public uint InTeredoServerErrorPacketsSourceError { get; private set; }
        public uint InTeredoServerErrorPacketsTotal { get; private set; }
        public uint InTeredoServerSuccessPacketsBubbles { get; private set; }
        public uint InTeredoServerSuccessPacketsEcho { get; private set; }
        public uint InTeredoServerSuccessPacketsRSPrimary { get; private set; }
        public uint InTeredoServerSuccessPacketsRSSecondary { get; private set; }
        public uint InTeredoServerSuccessPacketsTotal { get; private set; }
        public uint InTeredoServerTotalPacketsSuccessError { get; private set; }
        public uint InTeredoServerTotalPacketsSuccessErrorPersec { get; private set; }
        public string Name { get; private set; }
        public uint OutTeredoServerRAPrimary { get; private set; }
        public uint OutTeredoServerRASecondary { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_TeredoServer[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_TeredoServer[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_TeredoServer[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_TeredoServer");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_TeredoServer>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_TeredoServer
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InTeredoServerErrorPacketsAuthenticationError = (uint) managementObject
                        .Properties["InTeredoServerErrorPacketsAuthenticationError"].Value,
                    InTeredoServerErrorPacketsDestinationError = (uint) managementObject
                        .Properties["InTeredoServerErrorPacketsDestinationError"].Value,
                    InTeredoServerErrorPacketsHeaderError = (uint) managementObject
                        .Properties["InTeredoServerErrorPacketsHeaderError"].Value,
                    InTeredoServerErrorPacketsSourceError = (uint) managementObject
                        .Properties["InTeredoServerErrorPacketsSourceError"].Value,
                    InTeredoServerErrorPacketsTotal =
                        (uint) managementObject.Properties["InTeredoServerErrorPacketsTotal"].Value,
                    InTeredoServerSuccessPacketsBubbles =
                        (uint) managementObject.Properties["InTeredoServerSuccessPacketsBubbles"].Value,
                    InTeredoServerSuccessPacketsEcho =
                        (uint) managementObject.Properties["InTeredoServerSuccessPacketsEcho"].Value,
                    InTeredoServerSuccessPacketsRSPrimary = (uint) managementObject
                        .Properties["InTeredoServerSuccessPacketsRSPrimary"].Value,
                    InTeredoServerSuccessPacketsRSSecondary = (uint) managementObject
                        .Properties["InTeredoServerSuccessPacketsRSSecondary"].Value,
                    InTeredoServerSuccessPacketsTotal =
                        (uint) managementObject.Properties["InTeredoServerSuccessPacketsTotal"].Value,
                    InTeredoServerTotalPacketsSuccessError = (uint) managementObject
                        .Properties["InTeredoServerTotalPacketsSuccessError"].Value,
                    InTeredoServerTotalPacketsSuccessErrorPersec = (uint) managementObject
                        .Properties["InTeredoServerTotalPacketsSuccessErrorPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OutTeredoServerRAPrimary = (uint) managementObject.Properties["OutTeredoServerRAPrimary"].Value,
                    OutTeredoServerRASecondary = (uint) managementObject.Properties["OutTeredoServerRASecondary"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}