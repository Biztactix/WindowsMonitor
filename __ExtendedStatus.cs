using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __ExtendedStatus
    {
		public string Description { get; private set; }
		public string Operation { get; private set; }
		public string ParameterInfo { get; private set; }
		public string ProviderName { get; private set; }
		public uint StatusCode { get; private set; }

        public static IEnumerable<__ExtendedStatus> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__ExtendedStatus> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__ExtendedStatus> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __ExtendedStatus");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __ExtendedStatus
                {
                     Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Operation = (string) (managementObject.Properties["Operation"]?.Value ?? default(string)),
		 ParameterInfo = (string) (managementObject.Properties["ParameterInfo"]?.Value ?? default(string)),
		 ProviderName = (string) (managementObject.Properties["ProviderName"]?.Value ?? default(string)),
		 StatusCode = (uint) (managementObject.Properties["StatusCode"]?.Value ?? default(uint))
                };
        }
    }
}