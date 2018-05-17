using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSLSA_LookupIsolatedNameInTrustedDomains_TypeGroup1
    {
		public string ClientNetworkAddress { get; private set; }
		public string IsolatedName { get; private set; }

        public static IEnumerable<MSLSA_LookupIsolatedNameInTrustedDomains_TypeGroup1> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<MSLSA_LookupIsolatedNameInTrustedDomains_TypeGroup1> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSLSA_LookupIsolatedNameInTrustedDomains_TypeGroup1> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSLSA_LookupIsolatedNameInTrustedDomains_TypeGroup1");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSLSA_LookupIsolatedNameInTrustedDomains_TypeGroup1
                {
                     ClientNetworkAddress = (string) (managementObject.Properties["ClientNetworkAddress"]?.Value ?? default(string)),
		 IsolatedName = (string) (managementObject.Properties["IsolatedName"]?.Value ?? default(string))
                };
        }
    }
}