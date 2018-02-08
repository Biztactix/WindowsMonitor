using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Tcpip_IPv4
    {
        public string Caption { get; private set; }
        public uint DatagramsForwardedPersec { get; private set; }
        public uint DatagramsOutboundDiscarded { get; private set; }
        public uint DatagramsOutboundNoRoute { get; private set; }
        public uint DatagramsPersec { get; private set; }
        public uint DatagramsReceivedAddressErrors { get; private set; }
        public uint DatagramsReceivedDeliveredPersec { get; private set; }
        public uint DatagramsReceivedDiscarded { get; private set; }
        public uint DatagramsReceivedHeaderErrors { get; private set; }
        public uint DatagramsReceivedPersec { get; private set; }
        public uint DatagramsReceivedUnknownProtocol { get; private set; }
        public uint DatagramsSentPersec { get; private set; }
        public string Description { get; private set; }
        public uint FragmentationFailures { get; private set; }
        public uint FragmentedDatagramsPersec { get; private set; }
        public uint FragmentReassemblyFailures { get; private set; }
        public uint FragmentsCreatedPersec { get; private set; }
        public uint FragmentsReassembledPersec { get; private set; }
        public uint FragmentsReceivedPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_Tcpip_IPv4[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_Tcpip_IPv4[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Tcpip_IPv4[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Tcpip_IPv4");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Tcpip_IPv4>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Tcpip_IPv4
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    DatagramsForwardedPersec = (uint) managementObject.Properties["DatagramsForwardedPersec"].Value,
                    DatagramsOutboundDiscarded = (uint) managementObject.Properties["DatagramsOutboundDiscarded"].Value,
                    DatagramsOutboundNoRoute = (uint) managementObject.Properties["DatagramsOutboundNoRoute"].Value,
                    DatagramsPersec = (uint) managementObject.Properties["DatagramsPersec"].Value,
                    DatagramsReceivedAddressErrors =
                        (uint) managementObject.Properties["DatagramsReceivedAddressErrors"].Value,
                    DatagramsReceivedDeliveredPersec =
                        (uint) managementObject.Properties["DatagramsReceivedDeliveredPersec"].Value,
                    DatagramsReceivedDiscarded = (uint) managementObject.Properties["DatagramsReceivedDiscarded"].Value,
                    DatagramsReceivedHeaderErrors = (uint) managementObject.Properties["DatagramsReceivedHeaderErrors"]
                        .Value,
                    DatagramsReceivedPersec = (uint) managementObject.Properties["DatagramsReceivedPersec"].Value,
                    DatagramsReceivedUnknownProtocol =
                        (uint) managementObject.Properties["DatagramsReceivedUnknownProtocol"].Value,
                    DatagramsSentPersec = (uint) managementObject.Properties["DatagramsSentPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FragmentationFailures = (uint) managementObject.Properties["FragmentationFailures"].Value,
                    FragmentedDatagramsPersec = (uint) managementObject.Properties["FragmentedDatagramsPersec"].Value,
                    FragmentReassemblyFailures = (uint) managementObject.Properties["FragmentReassemblyFailures"].Value,
                    FragmentsCreatedPersec = (uint) managementObject.Properties["FragmentsCreatedPersec"].Value,
                    FragmentsReassembledPersec = (uint) managementObject.Properties["FragmentsReassembledPersec"].Value,
                    FragmentsReceivedPersec = (uint) managementObject.Properties["FragmentsReceivedPersec"].Value,
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