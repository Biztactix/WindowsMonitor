using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class PageFault_VirtualAlloc
    {
		public uint BaseAddress { get; private set; }
		public uint Flags { get; private set; }
		public uint ProcessId { get; private set; }
		public dynamic RegionSize { get; private set; }

        public static IEnumerable<PageFault_VirtualAlloc> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PageFault_VirtualAlloc> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PageFault_VirtualAlloc> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM PageFault_VirtualAlloc");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PageFault_VirtualAlloc
                {
                     BaseAddress = (uint) (managementObject.Properties["BaseAddress"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 RegionSize = (dynamic) (managementObject.Properties["RegionSize"]?.Value ?? default(dynamic))
                };
        }
    }
}