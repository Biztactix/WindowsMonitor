using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class CritSecInit
    {
		public uint CritSecAddr { get; private set; }
		public uint SpinCount { get; private set; }

        public static IEnumerable<CritSecInit> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<CritSecInit> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<CritSecInit> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CritSecInit");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new CritSecInit
                {
                     CritSecAddr = (uint) (managementObject.Properties["CritSecAddr"]?.Value ?? default(uint)),
		 SpinCount = (uint) (managementObject.Properties["SpinCount"]?.Value ?? default(uint))
                };
        }
    }
}