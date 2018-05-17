using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Registry_HiveLink
    {
		public uint Flags { get; private set; }
		public uint Hive { get; private set; }
		public string Path { get; private set; }

        public static IEnumerable<Registry_HiveLink> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Registry_HiveLink> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Registry_HiveLink> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Registry_HiveLink");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Registry_HiveLink
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Hive = (uint) (managementObject.Properties["Hive"]?.Value ?? default(uint)),
		 Path = (string) (managementObject.Properties["Path"]?.Value ?? default(string))
                };
        }
    }
}