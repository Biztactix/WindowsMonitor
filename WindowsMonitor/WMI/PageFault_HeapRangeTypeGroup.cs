using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class PageFault_HeapRangeTypeGroup
    {
		public uint Flags { get; private set; }
		public uint HeapHandle { get; private set; }
		public uint HRAddress { get; private set; }
		public dynamic HRSize { get; private set; }

        public static IEnumerable<PageFault_HeapRangeTypeGroup> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PageFault_HeapRangeTypeGroup> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PageFault_HeapRangeTypeGroup> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM PageFault_HeapRangeTypeGroup");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PageFault_HeapRangeTypeGroup
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 HeapHandle = (uint) (managementObject.Properties["HeapHandle"]?.Value ?? default(uint)),
		 HRAddress = (uint) (managementObject.Properties["HRAddress"]?.Value ?? default(uint)),
		 HRSize = (dynamic) (managementObject.Properties["HRSize"]?.Value ?? default(dynamic))
                };
        }
    }
}