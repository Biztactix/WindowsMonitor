using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Tcpip_IPv6
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

        public static IEnumerable<Tcpip_IPv6> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Tcpip_IPv6> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Tcpip_IPv6> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Tcpip_IPv6");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Tcpip_IPv6
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 DatagramsForwardedPersec = (uint) (managementObject.Properties["DatagramsForwardedPersec"]?.Value ?? default(uint)),
		 DatagramsOutboundDiscarded = (uint) (managementObject.Properties["DatagramsOutboundDiscarded"]?.Value ?? default(uint)),
		 DatagramsOutboundNoRoute = (uint) (managementObject.Properties["DatagramsOutboundNoRoute"]?.Value ?? default(uint)),
		 DatagramsPersec = (uint) (managementObject.Properties["DatagramsPersec"]?.Value ?? default(uint)),
		 DatagramsReceivedAddressErrors = (uint) (managementObject.Properties["DatagramsReceivedAddressErrors"]?.Value ?? default(uint)),
		 DatagramsReceivedDeliveredPersec = (uint) (managementObject.Properties["DatagramsReceivedDeliveredPersec"]?.Value ?? default(uint)),
		 DatagramsReceivedDiscarded = (uint) (managementObject.Properties["DatagramsReceivedDiscarded"]?.Value ?? default(uint)),
		 DatagramsReceivedHeaderErrors = (uint) (managementObject.Properties["DatagramsReceivedHeaderErrors"]?.Value ?? default(uint)),
		 DatagramsReceivedPersec = (uint) (managementObject.Properties["DatagramsReceivedPersec"]?.Value ?? default(uint)),
		 DatagramsReceivedUnknownProtocol = (uint) (managementObject.Properties["DatagramsReceivedUnknownProtocol"]?.Value ?? default(uint)),
		 DatagramsSentPersec = (uint) (managementObject.Properties["DatagramsSentPersec"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 FragmentationFailures = (uint) (managementObject.Properties["FragmentationFailures"]?.Value ?? default(uint)),
		 FragmentedDatagramsPersec = (uint) (managementObject.Properties["FragmentedDatagramsPersec"]?.Value ?? default(uint)),
		 FragmentReassemblyFailures = (uint) (managementObject.Properties["FragmentReassemblyFailures"]?.Value ?? default(uint)),
		 FragmentsCreatedPersec = (uint) (managementObject.Properties["FragmentsCreatedPersec"]?.Value ?? default(uint)),
		 FragmentsReassembledPersec = (uint) (managementObject.Properties["FragmentsReassembledPersec"]?.Value ?? default(uint)),
		 FragmentsReceivedPersec = (uint) (managementObject.Properties["FragmentsReceivedPersec"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}