using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSFC_HbaApiVersion
    {
		public string Description { get; private set; }
		public uint HbaApiVersion { get; private set; }
		public uint WmiHbaApiVersion { get; private set; }

        public static IEnumerable<MSFC_HbaApiVersion> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSFC_HbaApiVersion> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSFC_HbaApiVersion> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFC_HbaApiVersion");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSFC_HbaApiVersion
                {
                     Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 HbaApiVersion = (uint) (managementObject.Properties["HbaApiVersion"]?.Value ?? default(uint)),
		 WmiHbaApiVersion = (uint) (managementObject.Properties["WmiHbaApiVersion"]?.Value ?? default(uint))
                };
        }
    }
}