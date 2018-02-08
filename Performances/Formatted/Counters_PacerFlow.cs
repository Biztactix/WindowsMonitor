using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_PacerFlow
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

        public static PerfFormattedData_Counters_PacerFlow[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_Counters_PacerFlow[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_PacerFlow[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_PacerFlow");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_PacerFlow>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_PacerFlow
                {
                    Averagepacketsinnetcard = (uint) managementObject.Properties["Averagepacketsinnetcard"].Value,
                    Averagepacketsinsequencer = (uint) managementObject.Properties["Averagepacketsinsequencer"].Value,
                    Averagepacketsinshaper = (uint) managementObject.Properties["Averagepacketsinshaper"].Value,
                    Bytesscheduled = (ulong) managementObject.Properties["Bytesscheduled"].Value,
                    BytesscheduledPersec = (ulong) managementObject.Properties["BytesscheduledPersec"].Value,
                    Bytestransmitted = (ulong) managementObject.Properties["Bytestransmitted"].Value,
                    BytestransmittedPersec = (ulong) managementObject.Properties["BytestransmittedPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Maximumpacketsinnetcard = (uint) managementObject.Properties["Maximumpacketsinnetcard"].Value,
                    Maxpacketsinsequencer = (uint) managementObject.Properties["Maxpacketsinsequencer"].Value,
                    Maxpacketsinshaper = (uint) managementObject.Properties["Maxpacketsinshaper"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Nonconformingpacketsscheduled = (uint) managementObject.Properties["Nonconformingpacketsscheduled"]
                        .Value,
                    NonconformingpacketsscheduledPersec =
                        (uint) managementObject.Properties["NonconformingpacketsscheduledPersec"].Value,
                    Nonconformingpacketstransmitted =
                        (uint) managementObject.Properties["Nonconformingpacketstransmitted"].Value,
                    NonconformingpacketstransmittedPersec = (uint) managementObject
                        .Properties["NonconformingpacketstransmittedPersec"].Value,
                    Packetsdropped = (uint) managementObject.Properties["Packetsdropped"].Value,
                    PacketsdroppedPersec = (uint) managementObject.Properties["PacketsdroppedPersec"].Value,
                    Packetsscheduled = (uint) managementObject.Properties["Packetsscheduled"].Value,
                    PacketsscheduledPersec = (uint) managementObject.Properties["PacketsscheduledPersec"].Value,
                    Packetstransmitted = (uint) managementObject.Properties["Packetstransmitted"].Value,
                    PacketstransmittedPersec = (uint) managementObject.Properties["PacketstransmittedPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}