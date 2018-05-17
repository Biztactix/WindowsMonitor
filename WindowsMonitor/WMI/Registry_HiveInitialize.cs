using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Registry_HiveInitialize
    {
		public string FileName { get; private set; }
		public uint Flags { get; private set; }
		public uint Hive { get; private set; }
		public uint OperationType { get; private set; }
		public uint PoolTag { get; private set; }
		public uint Size { get; private set; }

        public static IEnumerable<Registry_HiveInitialize> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Registry_HiveInitialize> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Registry_HiveInitialize> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Registry_HiveInitialize");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Registry_HiveInitialize
                {
                     FileName = (string) (managementObject.Properties["FileName"]?.Value ?? default(string)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Hive = (uint) (managementObject.Properties["Hive"]?.Value ?? default(uint)),
		 OperationType = (uint) (managementObject.Properties["OperationType"]?.Value ?? default(uint)),
		 PoolTag = (uint) (managementObject.Properties["PoolTag"]?.Value ?? default(uint)),
		 Size = (uint) (managementObject.Properties["Size"]?.Value ?? default(uint))
                };
        }
    }
}