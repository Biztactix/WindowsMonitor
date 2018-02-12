using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class SoftwareElementAction
    {
		public short Action { get; private set; }
		public short Element { get; private set; }

        public static IEnumerable<SoftwareElementAction> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SoftwareElementAction> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SoftwareElementAction> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SoftwareElementAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SoftwareElementAction
                {
                     Action = (short) (managementObject.Properties["Action"]?.Value ?? default(short)),
		 Element = (short) (managementObject.Properties["Element"]?.Value ?? default(short))
                };
        }
    }
}