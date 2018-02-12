using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __EventConsumerProviderRegistration
    {
		public string[] ConsumerClassNames { get; private set; }
		public short provider { get; private set; }

        public static IEnumerable<__EventConsumerProviderRegistration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__EventConsumerProviderRegistration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__EventConsumerProviderRegistration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __EventConsumerProviderRegistration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __EventConsumerProviderRegistration
                {
                     ConsumerClassNames = (string[]) (managementObject.Properties["ConsumerClassNames"]?.Value ?? new string[0]),
		 provider = (short) (managementObject.Properties["provider"]?.Value ?? default(short))
                };
        }
    }
}