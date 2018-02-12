using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol
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

        public static IEnumerable<PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PeerNameResolutionProtocolPerf_PeerNameResolutionProtocol
                {
                     Ackreceivedpersecond = (uint) (managementObject.Properties["Ackreceivedpersecond"]?.Value ?? default(uint)),
		 Acksentpersecond = (uint) (managementObject.Properties["Acksentpersecond"]?.Value ?? default(uint)),
		 Advertisereceivedpersecond = (uint) (managementObject.Properties["Advertisereceivedpersecond"]?.Value ?? default(uint)),
		 Advertisesentpersecond = (uint) (managementObject.Properties["Advertisesentpersecond"]?.Value ?? default(uint)),
		 Authorityreceivedpersecond = (uint) (managementObject.Properties["Authorityreceivedpersecond"]?.Value ?? default(uint)),
		 Authoritysentpersecond = (uint) (managementObject.Properties["Authoritysentpersecond"]?.Value ?? default(uint)),
		 Averagebytesreceived = (uint) (managementObject.Properties["Averagebytesreceived"]?.Value ?? default(uint)),
		 Averagebytessent = (uint) (managementObject.Properties["Averagebytessent"]?.Value ?? default(uint)),
		 CacheEntry = (uint) (managementObject.Properties["CacheEntry"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Estimatedcloudsize = (uint) (managementObject.Properties["Estimatedcloudsize"]?.Value ?? default(uint)),
		 Floodreceivedpersecond = (uint) (managementObject.Properties["Floodreceivedpersecond"]?.Value ?? default(uint)),
		 Floodsentpersecond = (uint) (managementObject.Properties["Floodsentpersecond"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Inquirereceivedpersecond = (uint) (managementObject.Properties["Inquirereceivedpersecond"]?.Value ?? default(uint)),
		 Inquiresentpersecond = (uint) (managementObject.Properties["Inquiresentpersecond"]?.Value ?? default(uint)),
		 Lookupreceivedpersecond = (uint) (managementObject.Properties["Lookupreceivedpersecond"]?.Value ?? default(uint)),
		 Lookupsentpersecond = (uint) (managementObject.Properties["Lookupsentpersecond"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Receivefailures = (uint) (managementObject.Properties["Receivefailures"]?.Value ?? default(uint)),
		 Registration = (uint) (managementObject.Properties["Registration"]?.Value ?? default(uint)),
		 Requestreceivedpersecond = (uint) (managementObject.Properties["Requestreceivedpersecond"]?.Value ?? default(uint)),
		 Requestsentpersecond = (uint) (managementObject.Properties["Requestsentpersecond"]?.Value ?? default(uint)),
		 Resolve = (uint) (managementObject.Properties["Resolve"]?.Value ?? default(uint)),
		 Sendfailures = (uint) (managementObject.Properties["Sendfailures"]?.Value ?? default(uint)),
		 Solicitreceivedpersecond = (uint) (managementObject.Properties["Solicitreceivedpersecond"]?.Value ?? default(uint)),
		 Solicitsentpersecond = (uint) (managementObject.Properties["Solicitsentpersecond"]?.Value ?? default(uint)),
		 Stalecacheentry = (uint) (managementObject.Properties["Stalecacheentry"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 Unknownmessagetypereceived = (uint) (managementObject.Properties["Unknownmessagetypereceived"]?.Value ?? default(uint))
                };
        }
    }
}