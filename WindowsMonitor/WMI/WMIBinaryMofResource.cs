using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class WMIBinaryMofResource
    {
		public uint HighDateTime { get; private set; }
		public uint LowDateTime { get; private set; }
		public bool MofProcessed { get; private set; }
		public string Name { get; private set; }

        public static IEnumerable<WMIBinaryMofResource> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WMIBinaryMofResource> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WMIBinaryMofResource> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM WMIBinaryMofResource");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WMIBinaryMofResource
                {
                     HighDateTime = (uint) (managementObject.Properties["HighDateTime"]?.Value ?? default(uint)),
		 LowDateTime = (uint) (managementObject.Properties["LowDateTime"]?.Value ?? default(uint)),
		 MofProcessed = (bool) (managementObject.Properties["MofProcessed"]?.Value ?? default(bool)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string))
                };
        }
    }
}