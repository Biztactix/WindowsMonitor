using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Tcpip_TCPv4
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

        public static PerfFormattedData_Tcpip_TCPv4[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_Tcpip_TCPv4[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Tcpip_TCPv4[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Tcpip_TCPv4");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Tcpip_TCPv4>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Tcpip_TCPv4
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConnectionFailures = (uint) managementObject.Properties["ConnectionFailures"].Value,
                    ConnectionsActive = (uint) managementObject.Properties["ConnectionsActive"].Value,
                    ConnectionsEstablished = (uint) managementObject.Properties["ConnectionsEstablished"].Value,
                    ConnectionsPassive = (uint) managementObject.Properties["ConnectionsPassive"].Value,
                    ConnectionsReset = (uint) managementObject.Properties["ConnectionsReset"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SegmentsPersec = (uint) managementObject.Properties["SegmentsPersec"].Value,
                    SegmentsReceivedPersec = (uint) managementObject.Properties["SegmentsReceivedPersec"].Value,
                    SegmentsRetransmittedPersec = (uint) managementObject.Properties["SegmentsRetransmittedPersec"]
                        .Value,
                    SegmentsSentPersec = (uint) managementObject.Properties["SegmentsSentPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}