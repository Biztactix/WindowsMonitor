using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_PacerPipe
    {
        public uint Averagepacketsinnetcard { get; private set; }
        public uint Averagepacketsinsequencer { get; private set; }
        public uint Averagepacketsinshaper { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint Flowmodsrejected { get; private set; }
        public uint Flowsclosed { get; private set; }
        public uint Flowsmodified { get; private set; }
        public uint Flowsopened { get; private set; }
        public uint Flowsrejected { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint Maxpacketsinnetcard { get; private set; }
        public uint Maxpacketsinsequencer { get; private set; }
        public uint Maxpacketsinshaper { get; private set; }
        public uint Maxsimultaneousflows { get; private set; }
        public string Name { get; private set; }
        public uint Nonconformingpacketsscheduled { get; private set; }
        public uint NonconformingpacketsscheduledPersec { get; private set; }
        public uint Nonconformingpacketstransmitted { get; private set; }
        public uint NonconformingpacketstransmittedPersec { get; private set; }
        public uint Outofpackets { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_PacerPipe[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_PacerPipe[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_PacerPipe[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_PacerPipe");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_PacerPipe>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_PacerPipe
                {
                    Averagepacketsinnetcard = (uint) managementObject.Properties["Averagepacketsinnetcard"].Value,
                    Averagepacketsinsequencer = (uint) managementObject.Properties["Averagepacketsinsequencer"].Value,
                    Averagepacketsinshaper = (uint) managementObject.Properties["Averagepacketsinshaper"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Flowmodsrejected = (uint) managementObject.Properties["Flowmodsrejected"].Value,
                    Flowsclosed = (uint) managementObject.Properties["Flowsclosed"].Value,
                    Flowsmodified = (uint) managementObject.Properties["Flowsmodified"].Value,
                    Flowsopened = (uint) managementObject.Properties["Flowsopened"].Value,
                    Flowsrejected = (uint) managementObject.Properties["Flowsrejected"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Maxpacketsinnetcard = (uint) managementObject.Properties["Maxpacketsinnetcard"].Value,
                    Maxpacketsinsequencer = (uint) managementObject.Properties["Maxpacketsinsequencer"].Value,
                    Maxpacketsinshaper = (uint) managementObject.Properties["Maxpacketsinshaper"].Value,
                    Maxsimultaneousflows = (uint) managementObject.Properties["Maxsimultaneousflows"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Nonconformingpacketsscheduled = (uint) managementObject.Properties["Nonconformingpacketsscheduled"]
                        .Value,
                    NonconformingpacketsscheduledPersec =
                        (uint) managementObject.Properties["NonconformingpacketsscheduledPersec"].Value,
                    Nonconformingpacketstransmitted =
                        (uint) managementObject.Properties["Nonconformingpacketstransmitted"].Value,
                    NonconformingpacketstransmittedPersec = (uint) managementObject
                        .Properties["NonconformingpacketstransmittedPersec"].Value,
                    Outofpackets = (uint) managementObject.Properties["Outofpackets"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}