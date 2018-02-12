using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __InstanceProviderRegistration
    {
		public int InteractionType { get; private set; }
		public short provider { get; private set; }
		public string[] QuerySupportLevels { get; private set; }
		public bool SupportsBatching { get; private set; }
		public bool SupportsDelete { get; private set; }
		public bool SupportsEnumeration { get; private set; }
		public bool SupportsGet { get; private set; }
		public bool SupportsPut { get; private set; }
		public bool SupportsTransactions { get; private set; }

        public static IEnumerable<__InstanceProviderRegistration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__InstanceProviderRegistration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__InstanceProviderRegistration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __InstanceProviderRegistration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __InstanceProviderRegistration
                {
                     InteractionType = (int) (managementObject.Properties["InteractionType"]?.Value ?? default(int)),
		 provider = (short) (managementObject.Properties["provider"]?.Value ?? default(short)),
		 QuerySupportLevels = (string[]) (managementObject.Properties["QuerySupportLevels"]?.Value ?? new string[0]),
		 SupportsBatching = (bool) (managementObject.Properties["SupportsBatching"]?.Value ?? default(bool)),
		 SupportsDelete = (bool) (managementObject.Properties["SupportsDelete"]?.Value ?? default(bool)),
		 SupportsEnumeration = (bool) (managementObject.Properties["SupportsEnumeration"]?.Value ?? default(bool)),
		 SupportsGet = (bool) (managementObject.Properties["SupportsGet"]?.Value ?? default(bool)),
		 SupportsPut = (bool) (managementObject.Properties["SupportsPut"]?.Value ?? default(bool)),
		 SupportsTransactions = (bool) (managementObject.Properties["SupportsTransactions"]?.Value ?? default(bool))
                };
        }
    }
}