using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class WDMClassesOfDriver
    {
		public string ClassName { get; private set; }
		public string Driver { get; private set; }
		public uint HighDateTime { get; private set; }
		public uint LowDateTime { get; private set; }

        public static IEnumerable<WDMClassesOfDriver> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WDMClassesOfDriver> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WDMClassesOfDriver> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM WDMClassesOfDriver");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WDMClassesOfDriver
                {
                     ClassName = (string) (managementObject.Properties["ClassName"]?.Value ?? default(string)),
		 Driver = (string) (managementObject.Properties["Driver"]?.Value ?? default(string)),
		 HighDateTime = (uint) (managementObject.Properties["HighDateTime"]?.Value ?? default(uint)),
		 LowDateTime = (uint) (managementObject.Properties["LowDateTime"]?.Value ?? default(uint))
                };
        }
    }
}