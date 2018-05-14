using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_RemoteFXNetwork
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
		public uint FECRate_Base { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint LossRate { get; private set; }
		public uint LossRate_Base { get; private set; }
		public string Name { get; private set; }
		public uint RetransmissionRate { get; private set; }
		public uint RetransmissionRate_Base { get; private set; }
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

        public static IEnumerable<Counters_RemoteFXNetwork> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_RemoteFXNetwork> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_RemoteFXNetwork> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_RemoteFXNetwork");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_RemoteFXNetwork
                {
                     BaseTCPRTT = (uint) (managementObject.Properties["BaseTCPRTT"]?.Value ?? default(uint)),
		 BaseUDPRTT = (uint) (managementObject.Properties["BaseUDPRTT"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CurrentTCPBandwidth = (uint) (managementObject.Properties["CurrentTCPBandwidth"]?.Value ?? default(uint)),
		 CurrentTCPRTT = (uint) (managementObject.Properties["CurrentTCPRTT"]?.Value ?? default(uint)),
		 CurrentUDPBandwidth = (uint) (managementObject.Properties["CurrentUDPBandwidth"]?.Value ?? default(uint)),
		 CurrentUDPRTT = (uint) (managementObject.Properties["CurrentUDPRTT"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 FECRate = (uint) (managementObject.Properties["FECRate"]?.Value ?? default(uint)),
		 FECRate_Base = (uint) (managementObject.Properties["FECRate_Base"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 LossRate = (uint) (managementObject.Properties["LossRate"]?.Value ?? default(uint)),
		 LossRate_Base = (uint) (managementObject.Properties["LossRate_Base"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 RetransmissionRate = (uint) (managementObject.Properties["RetransmissionRate"]?.Value ?? default(uint)),
		 RetransmissionRate_Base = (uint) (managementObject.Properties["RetransmissionRate_Base"]?.Value ?? default(uint)),
		 SentRateP0 = (uint) (managementObject.Properties["SentRateP0"]?.Value ?? default(uint)),
		 SentRateP1 = (uint) (managementObject.Properties["SentRateP1"]?.Value ?? default(uint)),
		 SentRateP2 = (uint) (managementObject.Properties["SentRateP2"]?.Value ?? default(uint)),
		 SentRateP3 = (uint) (managementObject.Properties["SentRateP3"]?.Value ?? default(uint)),
		 TCPReceivedRate = (uint) (managementObject.Properties["TCPReceivedRate"]?.Value ?? default(uint)),
		 TCPSentRate = (uint) (managementObject.Properties["TCPSentRate"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalReceivedBytes = (uint) (managementObject.Properties["TotalReceivedBytes"]?.Value ?? default(uint)),
		 TotalReceivedRate = (uint) (managementObject.Properties["TotalReceivedRate"]?.Value ?? default(uint)),
		 TotalSentBytes = (uint) (managementObject.Properties["TotalSentBytes"]?.Value ?? default(uint)),
		 TotalSentRate = (uint) (managementObject.Properties["TotalSentRate"]?.Value ?? default(uint)),
		 UDPPacketsReceivedPersec = (uint) (managementObject.Properties["UDPPacketsReceivedPersec"]?.Value ?? default(uint)),
		 UDPPacketsSentPersec = (uint) (managementObject.Properties["UDPPacketsSentPersec"]?.Value ?? default(uint)),
		 UDPReceivedRate = (uint) (managementObject.Properties["UDPReceivedRate"]?.Value ?? default(uint)),
		 UDPSentRate = (uint) (managementObject.Properties["UDPSentRate"]?.Value ?? default(uint))
                };
        }
    }
}