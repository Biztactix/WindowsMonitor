using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __EventFilter
    {
		public byte[] CreatorSID { get; private set; }
		public string EventAccess { get; private set; }
		public string EventNamespace { get; private set; }
		public string Name { get; private set; }
		public string Query { get; private set; }
		public string QueryLanguage { get; private set; }

        public static IEnumerable<__EventFilter> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__EventFilter> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__EventFilter> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __EventFilter");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __EventFilter
                {
                     CreatorSID = (byte[]) (managementObject.Properties["CreatorSID"]?.Value ?? new byte[0]),
		 EventAccess = (string) (managementObject.Properties["EventAccess"]?.Value ?? default(string)),
		 EventNamespace = (string) (managementObject.Properties["EventNamespace"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Query = (string) (managementObject.Properties["Query"]?.Value ?? default(string)),
		 QueryLanguage = (string) (managementObject.Properties["QueryLanguage"]?.Value ?? default(string))
                };
        }
    }
}