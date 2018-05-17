using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ToasterBusInformation
    {
		public bool Active { get; private set; }
		public uint DebugPrintLevel { get; private set; }
		public uint ErrorCount { get; private set; }
		public string InstanceName { get; private set; }

        public static IEnumerable<ToasterBusInformation> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ToasterBusInformation> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ToasterBusInformation> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ToasterBusInformation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ToasterBusInformation
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 DebugPrintLevel = (uint) (managementObject.Properties["DebugPrintLevel"]?.Value ?? default(uint)),
		 ErrorCount = (uint) (managementObject.Properties["ErrorCount"]?.Value ?? default(uint)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string))
                };
        }
    }
}