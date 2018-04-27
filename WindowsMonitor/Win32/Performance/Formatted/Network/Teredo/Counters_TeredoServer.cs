using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_TeredoServer
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

        public static IEnumerable<Counters_TeredoServer> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_TeredoServer> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_TeredoServer> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_TeredoServer");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_TeredoServer
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 InTeredoServerErrorPacketsAuthenticationError = (uint) (managementObject.Properties["InTeredoServerErrorPacketsAuthenticationError"]?.Value ?? default(uint)),
		 InTeredoServerErrorPacketsDestinationError = (uint) (managementObject.Properties["InTeredoServerErrorPacketsDestinationError"]?.Value ?? default(uint)),
		 InTeredoServerErrorPacketsHeaderError = (uint) (managementObject.Properties["InTeredoServerErrorPacketsHeaderError"]?.Value ?? default(uint)),
		 InTeredoServerErrorPacketsSourceError = (uint) (managementObject.Properties["InTeredoServerErrorPacketsSourceError"]?.Value ?? default(uint)),
		 InTeredoServerErrorPacketsTotal = (uint) (managementObject.Properties["InTeredoServerErrorPacketsTotal"]?.Value ?? default(uint)),
		 InTeredoServerSuccessPacketsBubbles = (uint) (managementObject.Properties["InTeredoServerSuccessPacketsBubbles"]?.Value ?? default(uint)),
		 InTeredoServerSuccessPacketsEcho = (uint) (managementObject.Properties["InTeredoServerSuccessPacketsEcho"]?.Value ?? default(uint)),
		 InTeredoServerSuccessPacketsRSPrimary = (uint) (managementObject.Properties["InTeredoServerSuccessPacketsRSPrimary"]?.Value ?? default(uint)),
		 InTeredoServerSuccessPacketsRSSecondary = (uint) (managementObject.Properties["InTeredoServerSuccessPacketsRSSecondary"]?.Value ?? default(uint)),
		 InTeredoServerSuccessPacketsTotal = (uint) (managementObject.Properties["InTeredoServerSuccessPacketsTotal"]?.Value ?? default(uint)),
		 InTeredoServerTotalPacketsSuccessError = (uint) (managementObject.Properties["InTeredoServerTotalPacketsSuccessError"]?.Value ?? default(uint)),
		 InTeredoServerTotalPacketsSuccessErrorPersec = (uint) (managementObject.Properties["InTeredoServerTotalPacketsSuccessErrorPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OutTeredoServerRAPrimary = (uint) (managementObject.Properties["OutTeredoServerRAPrimary"]?.Value ?? default(uint)),
		 OutTeredoServerRASecondary = (uint) (managementObject.Properties["OutTeredoServerRASecondary"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}