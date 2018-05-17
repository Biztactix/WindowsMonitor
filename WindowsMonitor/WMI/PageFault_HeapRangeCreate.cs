using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class PageFault_HeapRangeCreate
    {
		public dynamic FirstRangeSize { get; private set; }
		public uint Flags { get; private set; }
		public uint HeapHandle { get; private set; }
		public uint HRCreateFlags { get; private set; }

        public static IEnumerable<PageFault_HeapRangeCreate> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PageFault_HeapRangeCreate> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PageFault_HeapRangeCreate> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM PageFault_HeapRangeCreate");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PageFault_HeapRangeCreate
                {
                     FirstRangeSize = (dynamic) (managementObject.Properties["FirstRangeSize"]?.Value ?? default(dynamic)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 HeapHandle = (uint) (managementObject.Properties["HeapHandle"]?.Value ?? default(uint)),
		 HRCreateFlags = (uint) (managementObject.Properties["HRCreateFlags"]?.Value ?? default(uint))
                };
        }
    }
}