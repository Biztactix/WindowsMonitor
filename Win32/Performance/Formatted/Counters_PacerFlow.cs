using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_PacerFlow
    {
		public uint Averagepacketsinnetcard { get; private set; }
		public uint Averagepacketsinsequencer { get; private set; }
		public uint Averagepacketsinshaper { get; private set; }
		public ulong Bytesscheduled { get; private set; }
		public ulong BytesscheduledPersec { get; private set; }
		public ulong Bytestransmitted { get; private set; }
		public ulong BytestransmittedPersec { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint Maximumpacketsinnetcard { get; private set; }
		public uint Maxpacketsinsequencer { get; private set; }
		public uint Maxpacketsinshaper { get; private set; }
		public string Name { get; private set; }
		public uint Nonconformingpacketsscheduled { get; private set; }
		public uint NonconformingpacketsscheduledPersec { get; private set; }
		public uint Nonconformingpacketstransmitted { get; private set; }
		public uint NonconformingpacketstransmittedPersec { get; private set; }
		public uint Packetsdropped { get; private set; }
		public uint PacketsdroppedPersec { get; private set; }
		public uint Packetsscheduled { get; private set; }
		public uint PacketsscheduledPersec { get; private set; }
		public uint Packetstransmitted { get; private set; }
		public uint PacketstransmittedPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_PacerFlow> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_PacerFlow> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_PacerFlow> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_PacerFlow");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_PacerFlow
                {
                     Averagepacketsinnetcard = (uint) (managementObject.Properties["Averagepacketsinnetcard"]?.Value ?? default(uint)),
		 Averagepacketsinsequencer = (uint) (managementObject.Properties["Averagepacketsinsequencer"]?.Value ?? default(uint)),
		 Averagepacketsinshaper = (uint) (managementObject.Properties["Averagepacketsinshaper"]?.Value ?? default(uint)),
		 Bytesscheduled = (ulong) (managementObject.Properties["Bytesscheduled"]?.Value ?? default(ulong)),
		 BytesscheduledPersec = (ulong) (managementObject.Properties["BytesscheduledPersec"]?.Value ?? default(ulong)),
		 Bytestransmitted = (ulong) (managementObject.Properties["Bytestransmitted"]?.Value ?? default(ulong)),
		 BytestransmittedPersec = (ulong) (managementObject.Properties["BytestransmittedPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Maximumpacketsinnetcard = (uint) (managementObject.Properties["Maximumpacketsinnetcard"]?.Value ?? default(uint)),
		 Maxpacketsinsequencer = (uint) (managementObject.Properties["Maxpacketsinsequencer"]?.Value ?? default(uint)),
		 Maxpacketsinshaper = (uint) (managementObject.Properties["Maxpacketsinshaper"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Nonconformingpacketsscheduled = (uint) (managementObject.Properties["Nonconformingpacketsscheduled"]?.Value ?? default(uint)),
		 NonconformingpacketsscheduledPersec = (uint) (managementObject.Properties["NonconformingpacketsscheduledPersec"]?.Value ?? default(uint)),
		 Nonconformingpacketstransmitted = (uint) (managementObject.Properties["Nonconformingpacketstransmitted"]?.Value ?? default(uint)),
		 NonconformingpacketstransmittedPersec = (uint) (managementObject.Properties["NonconformingpacketstransmittedPersec"]?.Value ?? default(uint)),
		 Packetsdropped = (uint) (managementObject.Properties["Packetsdropped"]?.Value ?? default(uint)),
		 PacketsdroppedPersec = (uint) (managementObject.Properties["PacketsdroppedPersec"]?.Value ?? default(uint)),
		 Packetsscheduled = (uint) (managementObject.Properties["Packetsscheduled"]?.Value ?? default(uint)),
		 PacketsscheduledPersec = (uint) (managementObject.Properties["PacketsscheduledPersec"]?.Value ?? default(uint)),
		 Packetstransmitted = (uint) (managementObject.Properties["Packetstransmitted"]?.Value ?? default(uint)),
		 PacketstransmittedPersec = (uint) (managementObject.Properties["PacketstransmittedPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}