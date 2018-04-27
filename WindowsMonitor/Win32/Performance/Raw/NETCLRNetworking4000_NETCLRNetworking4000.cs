using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class NETCLRNetworking4000_NETCLRNetworking4000
    {
		public ulong BytesReceived { get; private set; }
		public ulong BytesSent { get; private set; }
		public string Caption { get; private set; }
		public uint ConnectionsEstablished { get; private set; }
		public uint DatagramsReceived { get; private set; }
		public uint DatagramsSent { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint HttpWebRequestsAbortedPerSec { get; private set; }
		public ulong HttpWebRequestsAverageLifetime { get; private set; }
		public uint HttpWebRequestsAverageLifetime_Base { get; private set; }
		public ulong HttpWebRequestsAverageQueueTime { get; private set; }
		public uint HttpWebRequestsAverageQueueTime_Base { get; private set; }
		public uint HttpWebRequestsCreatedPerSec { get; private set; }
		public uint HttpWebRequestsFailedPerSec { get; private set; }
		public uint HttpWebRequestsQueuedPerSec { get; private set; }
		public string Name { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<NETCLRNetworking4000_NETCLRNetworking4000> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NETCLRNetworking4000_NETCLRNetworking4000> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NETCLRNetworking4000_NETCLRNetworking4000> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_NETCLRNetworking4000_NETCLRNetworking4000");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NETCLRNetworking4000_NETCLRNetworking4000
                {
                     BytesReceived = (ulong) (managementObject.Properties["BytesReceived"]?.Value ?? default(ulong)),
		 BytesSent = (ulong) (managementObject.Properties["BytesSent"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ConnectionsEstablished = (uint) (managementObject.Properties["ConnectionsEstablished"]?.Value ?? default(uint)),
		 DatagramsReceived = (uint) (managementObject.Properties["DatagramsReceived"]?.Value ?? default(uint)),
		 DatagramsSent = (uint) (managementObject.Properties["DatagramsSent"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 HttpWebRequestsAbortedPerSec = (uint) (managementObject.Properties["HttpWebRequestsAbortedPerSec"]?.Value ?? default(uint)),
		 HttpWebRequestsAverageLifetime = (ulong) (managementObject.Properties["HttpWebRequestsAverageLifetime"]?.Value ?? default(ulong)),
		 HttpWebRequestsAverageLifetime_Base = (uint) (managementObject.Properties["HttpWebRequestsAverageLifetime_Base"]?.Value ?? default(uint)),
		 HttpWebRequestsAverageQueueTime = (ulong) (managementObject.Properties["HttpWebRequestsAverageQueueTime"]?.Value ?? default(ulong)),
		 HttpWebRequestsAverageQueueTime_Base = (uint) (managementObject.Properties["HttpWebRequestsAverageQueueTime_Base"]?.Value ?? default(uint)),
		 HttpWebRequestsCreatedPerSec = (uint) (managementObject.Properties["HttpWebRequestsCreatedPerSec"]?.Value ?? default(uint)),
		 HttpWebRequestsFailedPerSec = (uint) (managementObject.Properties["HttpWebRequestsFailedPerSec"]?.Value ?? default(uint)),
		 HttpWebRequestsQueuedPerSec = (uint) (managementObject.Properties["HttpWebRequestsQueuedPerSec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}