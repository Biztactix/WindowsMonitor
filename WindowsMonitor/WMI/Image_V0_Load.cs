using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Image_V0_Load
    {
		public uint BaseAddress { get; private set; }
		public uint Flags { get; private set; }
		public string ImageFileName { get; private set; }
		public uint ModuleSize { get; private set; }

        public static IEnumerable<Image_V0_Load> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Image_V0_Load> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Image_V0_Load> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Image_V0_Load");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Image_V0_Load
                {
                     BaseAddress = (uint) (managementObject.Properties["BaseAddress"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 ImageFileName = (string) (managementObject.Properties["ImageFileName"]?.Value ?? default(string)),
		 ModuleSize = (uint) (managementObject.Properties["ModuleSize"]?.Value ?? default(uint))
                };
        }
    }
}