using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Registry_HiveRundown
    {
		public string FileName { get; private set; }
		public uint Flags { get; private set; }
		public uint Hive { get; private set; }
		public string LinkPath { get; private set; }
		public uint LoadedKeyCount { get; private set; }
		public ulong Size { get; private set; }

        public static IEnumerable<Registry_HiveRundown> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Registry_HiveRundown> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Registry_HiveRundown> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Registry_HiveRundown");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Registry_HiveRundown
                {
                     FileName = (string) (managementObject.Properties["FileName"]?.Value ?? default(string)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Hive = (uint) (managementObject.Properties["Hive"]?.Value ?? default(uint)),
		 LinkPath = (string) (managementObject.Properties["LinkPath"]?.Value ?? default(string)),
		 LoadedKeyCount = (uint) (managementObject.Properties["LoadedKeyCount"]?.Value ?? default(uint)),
		 Size = (ulong) (managementObject.Properties["Size"]?.Value ?? default(ulong))
                };
        }
    }
}