using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_NETCLRNetworking4000_NETCLRNetworking4000
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

        public static PerfRawData_NETCLRNetworking4000_NETCLRNetworking4000[] Retrieve(string remote, string username,
            string password)
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

        public static PerfRawData_NETCLRNetworking4000_NETCLRNetworking4000[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_NETCLRNetworking4000_NETCLRNetworking4000[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_NETCLRNetworking4000_NETCLRNetworking4000");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_NETCLRNetworking4000_NETCLRNetworking4000>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_NETCLRNetworking4000_NETCLRNetworking4000
                {
                    BytesReceived = (ulong) managementObject.Properties["BytesReceived"].Value,
                    BytesSent = (ulong) managementObject.Properties["BytesSent"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConnectionsEstablished = (uint) managementObject.Properties["ConnectionsEstablished"].Value,
                    DatagramsReceived = (uint) managementObject.Properties["DatagramsReceived"].Value,
                    DatagramsSent = (uint) managementObject.Properties["DatagramsSent"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    HttpWebRequestsAbortedPerSec = (uint) managementObject.Properties["HttpWebRequestsAbortedPerSec"]
                        .Value,
                    HttpWebRequestsAverageLifetime =
                        (ulong) managementObject.Properties["HttpWebRequestsAverageLifetime"].Value,
                    HttpWebRequestsAverageLifetime_Base =
                        (uint) managementObject.Properties["HttpWebRequestsAverageLifetime_Base"].Value,
                    HttpWebRequestsAverageQueueTime =
                        (ulong) managementObject.Properties["HttpWebRequestsAverageQueueTime"].Value,
                    HttpWebRequestsAverageQueueTime_Base = (uint) managementObject
                        .Properties["HttpWebRequestsAverageQueueTime_Base"].Value,
                    HttpWebRequestsCreatedPerSec = (uint) managementObject.Properties["HttpWebRequestsCreatedPerSec"]
                        .Value,
                    HttpWebRequestsFailedPerSec = (uint) managementObject.Properties["HttpWebRequestsFailedPerSec"]
                        .Value,
                    HttpWebRequestsQueuedPerSec = (uint) managementObject.Properties["HttpWebRequestsQueuedPerSec"]
                        .Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}