using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class PageFault_HeapRangeRundown_V2
    {
		public uint Flags { get; private set; }
		public uint HeapHandle { get; private set; }
		public uint HRFlags { get; private set; }
		public uint HRPid { get; private set; }
		public uint HRRangeCount { get; private set; }

        public static IEnumerable<PageFault_HeapRangeRundown_V2> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PageFault_HeapRangeRundown_V2> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PageFault_HeapRangeRundown_V2> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM PageFault_HeapRangeRundown_V2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PageFault_HeapRangeRundown_V2
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 HeapHandle = (uint) (managementObject.Properties["HeapHandle"]?.Value ?? default(uint)),
		 HRFlags = (uint) (managementObject.Properties["HRFlags"]?.Value ?? default(uint)),
		 HRPid = (uint) (managementObject.Properties["HRPid"]?.Value ?? default(uint)),
		 HRRangeCount = (uint) (managementObject.Properties["HRRangeCount"]?.Value ?? default(uint))
                };
        }
    }
}