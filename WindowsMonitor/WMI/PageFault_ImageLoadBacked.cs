using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class PageFault_ImageLoadBacked
    {
		public uint DeviceChar { get; private set; }
		public ushort FileChar { get; private set; }
		public uint FileObject { get; private set; }
		public uint Flags { get; private set; }
		public ushort LoadFlags { get; private set; }

        public static IEnumerable<PageFault_ImageLoadBacked> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PageFault_ImageLoadBacked> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PageFault_ImageLoadBacked> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM PageFault_ImageLoadBacked");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PageFault_ImageLoadBacked
                {
                     DeviceChar = (uint) (managementObject.Properties["DeviceChar"]?.Value ?? default(uint)),
		 FileChar = (ushort) (managementObject.Properties["FileChar"]?.Value ?? default(ushort)),
		 FileObject = (uint) (managementObject.Properties["FileObject"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 LoadFlags = (ushort) (managementObject.Properties["LoadFlags"]?.Value ?? default(ushort))
                };
        }
    }
}