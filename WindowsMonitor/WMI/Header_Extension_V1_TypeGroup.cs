using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Header_Extension_V1_TypeGroup
    {
		public uint Flags { get; private set; }
		public uint GroupMask1 { get; private set; }
		public uint GroupMask2 { get; private set; }
		public uint GroupMask3 { get; private set; }
		public uint GroupMask4 { get; private set; }
		public uint GroupMask5 { get; private set; }
		public uint GroupMask6 { get; private set; }
		public uint GroupMask7 { get; private set; }
		public uint GroupMask8 { get; private set; }

        public static IEnumerable<Header_Extension_V1_TypeGroup> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Header_Extension_V1_TypeGroup> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Header_Extension_V1_TypeGroup> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Header_Extension_V1_TypeGroup");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Header_Extension_V1_TypeGroup
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 GroupMask1 = (uint) (managementObject.Properties["GroupMask1"]?.Value ?? default(uint)),
		 GroupMask2 = (uint) (managementObject.Properties["GroupMask2"]?.Value ?? default(uint)),
		 GroupMask3 = (uint) (managementObject.Properties["GroupMask3"]?.Value ?? default(uint)),
		 GroupMask4 = (uint) (managementObject.Properties["GroupMask4"]?.Value ?? default(uint)),
		 GroupMask5 = (uint) (managementObject.Properties["GroupMask5"]?.Value ?? default(uint)),
		 GroupMask6 = (uint) (managementObject.Properties["GroupMask6"]?.Value ?? default(uint)),
		 GroupMask7 = (uint) (managementObject.Properties["GroupMask7"]?.Value ?? default(uint)),
		 GroupMask8 = (uint) (managementObject.Properties["GroupMask8"]?.Value ?? default(uint))
                };
        }
    }
}