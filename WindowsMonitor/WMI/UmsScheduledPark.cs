using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class UmsScheduledPark
    {
		public uint Flags { get; private set; }
		public uint ParkFlags { get; private set; }
		public uint ProcessId { get; private set; }
		public uint ScheduledThreadId { get; private set; }

        public static IEnumerable<UmsScheduledPark> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<UmsScheduledPark> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<UmsScheduledPark> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM UmsScheduledPark");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new UmsScheduledPark
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 ParkFlags = (uint) (managementObject.Properties["ParkFlags"]?.Value ?? default(uint)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 ScheduledThreadId = (uint) (managementObject.Properties["ScheduledThreadId"]?.Value ?? default(uint))
                };
        }
    }
}