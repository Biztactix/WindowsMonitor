using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Lsa_SecuritySystemWideStatistics
    {
		public uint ActiveSchannelSessionCacheEntries { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public uint DigestAuthentications { get; private set; }
		public uint ForwardedKerberosRequests { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint KDCarmoredASRequests { get; private set; }
		public uint KDCarmoredTGSRequests { get; private set; }
		public uint KDCASRequests { get; private set; }
		public uint KDCclaimsawareASRequests { get; private set; }
		public uint KDCclaimsawareserviceassertedidentityTGSrequests { get; private set; }
		public uint KDCclaimsawareTGSRequests { get; private set; }
		public uint KDCclassictypeconstraineddelegationTGSRequests { get; private set; }
		public uint KDCkeytrustASRequests { get; private set; }
		public uint KDCresourcetypeconstraineddelegationTGSRequests { get; private set; }
		public uint KDCTGSRequests { get; private set; }
		public uint KerberosAuthentications { get; private set; }
		public string Name { get; private set; }
		public uint NTLMAuthentications { get; private set; }
		public uint SchannelSessionCacheEntries { get; private set; }
		public uint SSLClientSideFullHandshakes { get; private set; }
		public uint SSLClientSideReconnectHandshakes { get; private set; }
		public uint SSLServerSideFullHandshakes { get; private set; }
		public uint SSLServerSideReconnectHandshakes { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Lsa_SecuritySystemWideStatistics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Lsa_SecuritySystemWideStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Lsa_SecuritySystemWideStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Lsa_SecuritySystemWideStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Lsa_SecuritySystemWideStatistics
                {
                     ActiveSchannelSessionCacheEntries = (uint) (managementObject.Properties["ActiveSchannelSessionCacheEntries"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 DigestAuthentications = (uint) (managementObject.Properties["DigestAuthentications"]?.Value ?? default(uint)),
		 ForwardedKerberosRequests = (uint) (managementObject.Properties["ForwardedKerberosRequests"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 KDCarmoredASRequests = (uint) (managementObject.Properties["KDCarmoredASRequests"]?.Value ?? default(uint)),
		 KDCarmoredTGSRequests = (uint) (managementObject.Properties["KDCarmoredTGSRequests"]?.Value ?? default(uint)),
		 KDCASRequests = (uint) (managementObject.Properties["KDCASRequests"]?.Value ?? default(uint)),
		 KDCclaimsawareASRequests = (uint) (managementObject.Properties["KDCclaimsawareASRequests"]?.Value ?? default(uint)),
		 KDCclaimsawareserviceassertedidentityTGSrequests = (uint) (managementObject.Properties["KDCclaimsawareserviceassertedidentityTGSrequests"]?.Value ?? default(uint)),
		 KDCclaimsawareTGSRequests = (uint) (managementObject.Properties["KDCclaimsawareTGSRequests"]?.Value ?? default(uint)),
		 KDCclassictypeconstraineddelegationTGSRequests = (uint) (managementObject.Properties["KDCclassictypeconstraineddelegationTGSRequests"]?.Value ?? default(uint)),
		 KDCkeytrustASRequests = (uint) (managementObject.Properties["KDCkeytrustASRequests"]?.Value ?? default(uint)),
		 KDCresourcetypeconstraineddelegationTGSRequests = (uint) (managementObject.Properties["KDCresourcetypeconstraineddelegationTGSRequests"]?.Value ?? default(uint)),
		 KDCTGSRequests = (uint) (managementObject.Properties["KDCTGSRequests"]?.Value ?? default(uint)),
		 KerberosAuthentications = (uint) (managementObject.Properties["KerberosAuthentications"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 NTLMAuthentications = (uint) (managementObject.Properties["NTLMAuthentications"]?.Value ?? default(uint)),
		 SchannelSessionCacheEntries = (uint) (managementObject.Properties["SchannelSessionCacheEntries"]?.Value ?? default(uint)),
		 SSLClientSideFullHandshakes = (uint) (managementObject.Properties["SSLClientSideFullHandshakes"]?.Value ?? default(uint)),
		 SSLClientSideReconnectHandshakes = (uint) (managementObject.Properties["SSLClientSideReconnectHandshakes"]?.Value ?? default(uint)),
		 SSLServerSideFullHandshakes = (uint) (managementObject.Properties["SSLServerSideFullHandshakes"]?.Value ?? default(uint)),
		 SSLServerSideReconnectHandshakes = (uint) (managementObject.Properties["SSLServerSideReconnectHandshakes"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}