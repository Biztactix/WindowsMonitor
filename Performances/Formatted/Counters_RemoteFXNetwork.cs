using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_RemoteFXNetwork
    {
        public uint BaseTCPRTT { get; private set; }
        public uint BaseUDPRTT { get; private set; }
        public string Caption { get; private set; }
        public uint CurrentTCPBandwidth { get; private set; }
        public uint CurrentTCPRTT { get; private set; }
        public uint CurrentUDPBandwidth { get; private set; }
        public uint CurrentUDPRTT { get; private set; }
        public string Description { get; private set; }
        public uint FECRate { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint LossRate { get; private set; }
        public string Name { get; private set; }
        public uint RetransmissionRate { get; private set; }
        public uint SentRateP0 { get; private set; }
        public uint SentRateP1 { get; private set; }
        public uint SentRateP2 { get; private set; }
        public uint SentRateP3 { get; private set; }
        public uint TCPReceivedRate { get; private set; }
        public uint TCPSentRate { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalReceivedBytes { get; private set; }
        public uint TotalReceivedRate { get; private set; }
        public uint TotalSentBytes { get; private set; }
        public uint TotalSentRate { get; private set; }
        public uint UDPPacketsReceivedPersec { get; private set; }
        public uint UDPPacketsSentPersec { get; private set; }
        public uint UDPReceivedRate { get; private set; }
        public uint UDPSentRate { get; private set; }

        public static PerfFormattedData_Counters_RemoteFXNetwork[] Retrieve(string remote, string username,
            string password)
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

        public static PerfFormattedData_Counters_RemoteFXNetwork[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_RemoteFXNetwork[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_RemoteFXNetwork");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_RemoteFXNetwork>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_RemoteFXNetwork
                {
                    BaseTCPRTT = (uint) managementObject.Properties["BaseTCPRTT"].Value,
                    BaseUDPRTT = (uint) managementObject.Properties["BaseUDPRTT"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentTCPBandwidth = (uint) managementObject.Properties["CurrentTCPBandwidth"].Value,
                    CurrentTCPRTT = (uint) managementObject.Properties["CurrentTCPRTT"].Value,
                    CurrentUDPBandwidth = (uint) managementObject.Properties["CurrentUDPBandwidth"].Value,
                    CurrentUDPRTT = (uint) managementObject.Properties["CurrentUDPRTT"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FECRate = (uint) managementObject.Properties["FECRate"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    LossRate = (uint) managementObject.Properties["LossRate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    RetransmissionRate = (uint) managementObject.Properties["RetransmissionRate"].Value,
                    SentRateP0 = (uint) managementObject.Properties["SentRateP0"].Value,
                    SentRateP1 = (uint) managementObject.Properties["SentRateP1"].Value,
                    SentRateP2 = (uint) managementObject.Properties["SentRateP2"].Value,
                    SentRateP3 = (uint) managementObject.Properties["SentRateP3"].Value,
                    TCPReceivedRate = (uint) managementObject.Properties["TCPReceivedRate"].Value,
                    TCPSentRate = (uint) managementObject.Properties["TCPSentRate"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalReceivedBytes = (uint) managementObject.Properties["TotalReceivedBytes"].Value,
                    TotalReceivedRate = (uint) managementObject.Properties["TotalReceivedRate"].Value,
                    TotalSentBytes = (uint) managementObject.Properties["TotalSentBytes"].Value,
                    TotalSentRate = (uint) managementObject.Properties["TotalSentRate"].Value,
                    UDPPacketsReceivedPersec = (uint) managementObject.Properties["UDPPacketsReceivedPersec"].Value,
                    UDPPacketsSentPersec = (uint) managementObject.Properties["UDPPacketsSentPersec"].Value,
                    UDPReceivedRate = (uint) managementObject.Properties["UDPReceivedRate"].Value,
                    UDPSentRate = (uint) managementObject.Properties["UDPSentRate"].Value
                });

            return list.ToArray();
        }
    }
}