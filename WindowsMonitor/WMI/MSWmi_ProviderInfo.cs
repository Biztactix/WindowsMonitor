using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSWmi_ProviderInfo
    {
		public bool Active { get; private set; }
		public string Description { get; private set; }
		public string FriendlyName { get; private set; }
		public string InstanceName { get; private set; }
		public string Location { get; private set; }
		public string Manufacturer { get; private set; }
		public string Service { get; private set; }

        public static IEnumerable<MSWmi_ProviderInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSWmi_ProviderInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSWmi_ProviderInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSWmi_ProviderInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSWmi_ProviderInfo
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FriendlyName = (string) (managementObject.Properties["FriendlyName"]?.Value ?? default(string)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 Location = (string) (managementObject.Properties["Location"]?.Value ?? default(string)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 Service = (string) (managementObject.Properties["Service"]?.Value ?? default(string))
                };
        }
    }
}