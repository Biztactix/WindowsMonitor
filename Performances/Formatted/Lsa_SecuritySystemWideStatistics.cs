using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Lsa_SecuritySystemWideStatistics
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

        public static PerfFormattedData_Lsa_SecuritySystemWideStatistics[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_Lsa_SecuritySystemWideStatistics[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Lsa_SecuritySystemWideStatistics[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Lsa_SecuritySystemWideStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Lsa_SecuritySystemWideStatistics>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Lsa_SecuritySystemWideStatistics
                {
                    ActiveSchannelSessionCacheEntries =
                        (uint) managementObject.Properties["ActiveSchannelSessionCacheEntries"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DigestAuthentications = (uint) managementObject.Properties["DigestAuthentications"].Value,
                    ForwardedKerberosRequests = (uint) managementObject.Properties["ForwardedKerberosRequests"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    KDCarmoredASRequests = (uint) managementObject.Properties["KDCarmoredASRequests"].Value,
                    KDCarmoredTGSRequests = (uint) managementObject.Properties["KDCarmoredTGSRequests"].Value,
                    KDCASRequests = (uint) managementObject.Properties["KDCASRequests"].Value,
                    KDCclaimsawareASRequests = (uint) managementObject.Properties["KDCclaimsawareASRequests"].Value,
                    KDCclaimsawareserviceassertedidentityTGSrequests = (uint) managementObject
                        .Properties["KDCclaimsawareserviceassertedidentityTGSrequests"].Value,
                    KDCclaimsawareTGSRequests = (uint) managementObject.Properties["KDCclaimsawareTGSRequests"].Value,
                    KDCclassictypeconstraineddelegationTGSRequests = (uint) managementObject
                        .Properties["KDCclassictypeconstraineddelegationTGSRequests"].Value,
                    KDCkeytrustASRequests = (uint) managementObject.Properties["KDCkeytrustASRequests"].Value,
                    KDCresourcetypeconstraineddelegationTGSRequests = (uint) managementObject
                        .Properties["KDCresourcetypeconstraineddelegationTGSRequests"].Value,
                    KDCTGSRequests = (uint) managementObject.Properties["KDCTGSRequests"].Value,
                    KerberosAuthentications = (uint) managementObject.Properties["KerberosAuthentications"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NTLMAuthentications = (uint) managementObject.Properties["NTLMAuthentications"].Value,
                    SchannelSessionCacheEntries = (uint) managementObject.Properties["SchannelSessionCacheEntries"]
                        .Value,
                    SSLClientSideFullHandshakes = (uint) managementObject.Properties["SSLClientSideFullHandshakes"]
                        .Value,
                    SSLClientSideReconnectHandshakes =
                        (uint) managementObject.Properties["SSLClientSideReconnectHandshakes"].Value,
                    SSLServerSideFullHandshakes = (uint) managementObject.Properties["SSLServerSideFullHandshakes"]
                        .Value,
                    SSLServerSideReconnectHandshakes =
                        (uint) managementObject.Properties["SSLServerSideReconnectHandshakes"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}