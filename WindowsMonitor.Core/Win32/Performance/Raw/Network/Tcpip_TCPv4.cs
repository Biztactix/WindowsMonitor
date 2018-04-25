using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Tcpip_TCPv4
    {
		public string Caption { get; private set; }
		public uint ConnectionFailures { get; private set; }
		public uint ConnectionsActive { get; private set; }
		public uint ConnectionsEstablished { get; private set; }
		public uint ConnectionsPassive { get; private set; }
		public uint ConnectionsReset { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint SegmentsPersec { get; private set; }
		public uint SegmentsReceivedPersec { get; private set; }
		public uint SegmentsRetransmittedPersec { get; private set; }
		public uint SegmentsSentPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Tcpip_TCPv4> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Tcpip_TCPv4> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Tcpip_TCPv4> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Tcpip_TCPv4");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Tcpip_TCPv4
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ConnectionFailures = (uint) (managementObject.Properties["ConnectionFailures"]?.Value ?? default(uint)),
		 ConnectionsActive = (uint) (managementObject.Properties["ConnectionsActive"]?.Value ?? default(uint)),
		 ConnectionsEstablished = (uint) (managementObject.Properties["ConnectionsEstablished"]?.Value ?? default(uint)),
		 ConnectionsPassive = (uint) (managementObject.Properties["ConnectionsPassive"]?.Value ?? default(uint)),
		 ConnectionsReset = (uint) (managementObject.Properties["ConnectionsReset"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 SegmentsPersec = (uint) (managementObject.Properties["SegmentsPersec"]?.Value ?? default(uint)),
		 SegmentsReceivedPersec = (uint) (managementObject.Properties["SegmentsReceivedPersec"]?.Value ?? default(uint)),
		 SegmentsRetransmittedPersec = (uint) (managementObject.Properties["SegmentsRetransmittedPersec"]?.Value ?? default(uint)),
		 SegmentsSentPersec = (uint) (managementObject.Properties["SegmentsSentPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}