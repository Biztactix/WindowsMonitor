using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_DistributedRoutingTablePerf_DistributedRoutingTable
    {
        public uint AckMessagesReceivedPersecond { get; private set; }
        public uint AckMessagesSentPersecond { get; private set; }
        public uint AdvertiseMessagesReceivedPersecond { get; private set; }
        public uint AdvertiseMessagesSentPersecond { get; private set; }
        public uint AuthorityMessagesReceivedPersecond { get; private set; }
        public uint AuthoritySentPersecond { get; private set; }
        public uint AverageBytesPersecondReceived { get; private set; }
        public uint AverageBytesPersecondSent { get; private set; }
        public uint CacheEntries { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint Estimatedcloudsize { get; private set; }
        public uint FloodMessagesReceivedPersecond { get; private set; }
        public uint FloodMessagesSentPersecond { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint InquireMessagesReceivedPersecond { get; private set; }
        public uint InquireMessagesSentPersecond { get; private set; }
        public uint LookupMessagesReceivedPersecond { get; private set; }
        public uint LookupMessagesSentPersecond { get; private set; }
        public string Name { get; private set; }
        public uint ReceiveFailures { get; private set; }
        public uint Registrations { get; private set; }
        public uint RequestMessagesReceivedPersecond { get; private set; }
        public uint RequestMessagesSentPersecond { get; private set; }
        public uint Searches { get; private set; }
        public uint SendFailures { get; private set; }
        public uint SolicitMessagesReceivedPersecond { get; private set; }
        public uint SolicitMessagesSentPersecond { get; private set; }
        public uint StaleCacheEntries { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint UnrecognizedMessagesReceived { get; private set; }

        public static PerfRawData_DistributedRoutingTablePerf_DistributedRoutingTable[] Retrieve(string remote,
            string username, string password)
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

        public static PerfRawData_DistributedRoutingTablePerf_DistributedRoutingTable[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_DistributedRoutingTablePerf_DistributedRoutingTable[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_DistributedRoutingTablePerf_DistributedRoutingTable");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_DistributedRoutingTablePerf_DistributedRoutingTable>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_DistributedRoutingTablePerf_DistributedRoutingTable
                {
                    AckMessagesReceivedPersecond = (uint) managementObject.Properties["AckMessagesReceivedPersecond"]
                        .Value,
                    AckMessagesSentPersecond = (uint) managementObject.Properties["AckMessagesSentPersecond"].Value,
                    AdvertiseMessagesReceivedPersecond =
                        (uint) managementObject.Properties["AdvertiseMessagesReceivedPersecond"].Value,
                    AdvertiseMessagesSentPersecond =
                        (uint) managementObject.Properties["AdvertiseMessagesSentPersecond"].Value,
                    AuthorityMessagesReceivedPersecond =
                        (uint) managementObject.Properties["AuthorityMessagesReceivedPersecond"].Value,
                    AuthoritySentPersecond = (uint) managementObject.Properties["AuthoritySentPersecond"].Value,
                    AverageBytesPersecondReceived = (uint) managementObject.Properties["AverageBytesPersecondReceived"]
                        .Value,
                    AverageBytesPersecondSent = (uint) managementObject.Properties["AverageBytesPersecondSent"].Value,
                    CacheEntries = (uint) managementObject.Properties["CacheEntries"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Estimatedcloudsize = (uint) managementObject.Properties["Estimatedcloudsize"].Value,
                    FloodMessagesReceivedPersecond =
                        (uint) managementObject.Properties["FloodMessagesReceivedPersecond"].Value,
                    FloodMessagesSentPersecond = (uint) managementObject.Properties["FloodMessagesSentPersecond"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InquireMessagesReceivedPersecond =
                        (uint) managementObject.Properties["InquireMessagesReceivedPersecond"].Value,
                    InquireMessagesSentPersecond = (uint) managementObject.Properties["InquireMessagesSentPersecond"]
                        .Value,
                    LookupMessagesReceivedPersecond =
                        (uint) managementObject.Properties["LookupMessagesReceivedPersecond"].Value,
                    LookupMessagesSentPersecond = (uint) managementObject.Properties["LookupMessagesSentPersecond"]
                        .Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ReceiveFailures = (uint) managementObject.Properties["ReceiveFailures"].Value,
                    Registrations = (uint) managementObject.Properties["Registrations"].Value,
                    RequestMessagesReceivedPersecond =
                        (uint) managementObject.Properties["RequestMessagesReceivedPersecond"].Value,
                    RequestMessagesSentPersecond = (uint) managementObject.Properties["RequestMessagesSentPersecond"]
                        .Value,
                    Searches = (uint) managementObject.Properties["Searches"].Value,
                    SendFailures = (uint) managementObject.Properties["SendFailures"].Value,
                    SolicitMessagesReceivedPersecond =
                        (uint) managementObject.Properties["SolicitMessagesReceivedPersecond"].Value,
                    SolicitMessagesSentPersecond = (uint) managementObject.Properties["SolicitMessagesSentPersecond"]
                        .Value,
                    StaleCacheEntries = (uint) managementObject.Properties["StaleCacheEntries"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    UnrecognizedMessagesReceived = (uint) managementObject.Properties["UnrecognizedMessagesReceived"]
                        .Value
                });

            return list.ToArray();
        }
    }
}