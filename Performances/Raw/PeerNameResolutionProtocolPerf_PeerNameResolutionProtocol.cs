using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol
    {
        public uint Ackreceivedpersecond { get; private set; }
        public uint Acksentpersecond { get; private set; }
        public uint Advertisereceivedpersecond { get; private set; }
        public uint Advertisesentpersecond { get; private set; }
        public uint Authorityreceivedpersecond { get; private set; }
        public uint Authoritysentpersecond { get; private set; }
        public uint Averagebytesreceived { get; private set; }
        public uint Averagebytessent { get; private set; }
        public uint CacheEntry { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint Estimatedcloudsize { get; private set; }
        public uint Floodreceivedpersecond { get; private set; }
        public uint Floodsentpersecond { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint Inquirereceivedpersecond { get; private set; }
        public uint Inquiresentpersecond { get; private set; }
        public uint Lookupreceivedpersecond { get; private set; }
        public uint Lookupsentpersecond { get; private set; }
        public string Name { get; private set; }
        public uint Receivefailures { get; private set; }
        public uint Registration { get; private set; }
        public uint Requestreceivedpersecond { get; private set; }
        public uint Requestsentpersecond { get; private set; }
        public uint Resolve { get; private set; }
        public uint Sendfailures { get; private set; }
        public uint Solicitreceivedpersecond { get; private set; }
        public uint Solicitsentpersecond { get; private set; }
        public uint Stalecacheentry { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint Unknownmessagetypereceived { get; private set; }

        public static PerfRawData_PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol[] Retrieve(string remote,
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

        public static PerfRawData_PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfRawData_PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol
                {
                    Ackreceivedpersecond = (uint) managementObject.Properties["Ackreceivedpersecond"].Value,
                    Acksentpersecond = (uint) managementObject.Properties["Acksentpersecond"].Value,
                    Advertisereceivedpersecond = (uint) managementObject.Properties["Advertisereceivedpersecond"].Value,
                    Advertisesentpersecond = (uint) managementObject.Properties["Advertisesentpersecond"].Value,
                    Authorityreceivedpersecond = (uint) managementObject.Properties["Authorityreceivedpersecond"].Value,
                    Authoritysentpersecond = (uint) managementObject.Properties["Authoritysentpersecond"].Value,
                    Averagebytesreceived = (uint) managementObject.Properties["Averagebytesreceived"].Value,
                    Averagebytessent = (uint) managementObject.Properties["Averagebytessent"].Value,
                    CacheEntry = (uint) managementObject.Properties["CacheEntry"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Estimatedcloudsize = (uint) managementObject.Properties["Estimatedcloudsize"].Value,
                    Floodreceivedpersecond = (uint) managementObject.Properties["Floodreceivedpersecond"].Value,
                    Floodsentpersecond = (uint) managementObject.Properties["Floodsentpersecond"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Inquirereceivedpersecond = (uint) managementObject.Properties["Inquirereceivedpersecond"].Value,
                    Inquiresentpersecond = (uint) managementObject.Properties["Inquiresentpersecond"].Value,
                    Lookupreceivedpersecond = (uint) managementObject.Properties["Lookupreceivedpersecond"].Value,
                    Lookupsentpersecond = (uint) managementObject.Properties["Lookupsentpersecond"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Receivefailures = (uint) managementObject.Properties["Receivefailures"].Value,
                    Registration = (uint) managementObject.Properties["Registration"].Value,
                    Requestreceivedpersecond = (uint) managementObject.Properties["Requestreceivedpersecond"].Value,
                    Requestsentpersecond = (uint) managementObject.Properties["Requestsentpersecond"].Value,
                    Resolve = (uint) managementObject.Properties["Resolve"].Value,
                    Sendfailures = (uint) managementObject.Properties["Sendfailures"].Value,
                    Solicitreceivedpersecond = (uint) managementObject.Properties["Solicitreceivedpersecond"].Value,
                    Solicitsentpersecond = (uint) managementObject.Properties["Solicitsentpersecond"].Value,
                    Stalecacheentry = (uint) managementObject.Properties["Stalecacheentry"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    Unknownmessagetypereceived = (uint) managementObject.Properties["Unknownmessagetypereceived"].Value
                });

            return list.ToArray();
        }
    }
}