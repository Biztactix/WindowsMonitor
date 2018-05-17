using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class PoolAllocFree
    {
		public uint Entry { get; private set; }
		public uint Flags { get; private set; }
		public dynamic NumberOfBytes { get; private set; }
		public uint Tag { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<PoolAllocFree> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PoolAllocFree> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PoolAllocFree> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM PoolAllocFree");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PoolAllocFree
                {
                     Entry = (uint) (managementObject.Properties["Entry"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 NumberOfBytes = (dynamic) (managementObject.Properties["NumberOfBytes"]?.Value ?? default(dynamic)),
		 Tag = (uint) (managementObject.Properties["Tag"]?.Value ?? default(uint)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}