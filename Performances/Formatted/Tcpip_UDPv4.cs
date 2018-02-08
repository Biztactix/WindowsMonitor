using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Tcpip_UDPv4
    {
        public string Caption { get; private set; }
        public uint DatagramsNoPortPersec { get; private set; }
        public uint DatagramsPersec { get; private set; }
        public uint DatagramsReceivedErrors { get; private set; }
        public uint DatagramsReceivedPersec { get; private set; }
        public uint DatagramsSentPersec { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_Tcpip_UDPv4[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_Tcpip_UDPv4[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Tcpip_UDPv4[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Tcpip_UDPv4");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Tcpip_UDPv4>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Tcpip_UDPv4
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    DatagramsNoPortPersec = (uint) managementObject.Properties["DatagramsNoPortPersec"].Value,
                    DatagramsPersec = (uint) managementObject.Properties["DatagramsPersec"].Value,
                    DatagramsReceivedErrors = (uint) managementObject.Properties["DatagramsReceivedErrors"].Value,
                    DatagramsReceivedPersec = (uint) managementObject.Properties["DatagramsReceivedPersec"].Value,
                    DatagramsSentPersec = (uint) managementObject.Properties["DatagramsSentPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}