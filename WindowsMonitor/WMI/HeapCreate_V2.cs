using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class HeapCreate_V2
    {
		public uint HeapFlags { get; private set; }
		public uint HeapHandle { get; private set; }

        public static IEnumerable<HeapCreate_V2> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HeapCreate_V2> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HeapCreate_V2> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM HeapCreate_V2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HeapCreate_V2
                {
                     HeapFlags = (uint) (managementObject.Properties["HeapFlags"]?.Value ?? default(uint)),
		 HeapHandle = (uint) (managementObject.Properties["HeapHandle"]?.Value ?? default(uint))
                };
        }
    }
}