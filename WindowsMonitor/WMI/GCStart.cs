using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class GCStart
    {
		public uint Count { get; private set; }
		public uint Depth { get; private set; }
		public uint Reason { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<GCStart> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<GCStart> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<GCStart> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM GCStart");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new GCStart
                {
                     Count = (uint) (managementObject.Properties["Count"]?.Value ?? default(uint)),
		 Depth = (uint) (managementObject.Properties["Depth"]?.Value ?? default(uint)),
		 Reason = (uint) (managementObject.Properties["Reason"]?.Value ?? default(uint)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}