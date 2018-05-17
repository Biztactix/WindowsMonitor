using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Header_ProviderBinaryPath_TypeGroup
    {
		public string BinaryPath { get; private set; }
		public uint Flags { get; private set; }
		public dynamic[] Guid { get; private set; }
		public uint GuidCount { get; private set; }

        public static IEnumerable<Header_ProviderBinaryPath_TypeGroup> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Header_ProviderBinaryPath_TypeGroup> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Header_ProviderBinaryPath_TypeGroup> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Header_ProviderBinaryPath_TypeGroup");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Header_ProviderBinaryPath_TypeGroup
                {
                     BinaryPath = (string) (managementObject.Properties["BinaryPath"]?.Value ?? default(string)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Guid = (dynamic[]) (managementObject.Properties["Guid"]?.Value ?? new dynamic[0]),
		 GuidCount = (uint) (managementObject.Properties["GuidCount"]?.Value ?? default(uint))
                };
        }
    }
}