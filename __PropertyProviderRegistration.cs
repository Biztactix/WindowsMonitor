using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __PropertyProviderRegistration
    {
		public short provider { get; private set; }
		public bool SupportsGet { get; private set; }
		public bool SupportsPut { get; private set; }

        public static IEnumerable<__PropertyProviderRegistration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__PropertyProviderRegistration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__PropertyProviderRegistration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __PropertyProviderRegistration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __PropertyProviderRegistration
                {
                     provider = (short) (managementObject.Properties["provider"]?.Value ?? default(short)),
		 SupportsGet = (bool) (managementObject.Properties["SupportsGet"]?.Value ?? default(bool)),
		 SupportsPut = (bool) (managementObject.Properties["SupportsPut"]?.Value ?? default(bool))
                };
        }
    }
}