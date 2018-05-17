using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Image_V1_Load
    {
		public string FileName { get; private set; }
		public uint Flags { get; private set; }
		public uint ImageBase { get; private set; }
		public uint ImageSize { get; private set; }
		public uint ProcessId { get; private set; }

        public static IEnumerable<Image_V1_Load> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Image_V1_Load> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Image_V1_Load> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Image_V1_Load");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Image_V1_Load
                {
                     FileName = (string) (managementObject.Properties["FileName"]?.Value ?? default(string)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 ImageBase = (uint) (managementObject.Properties["ImageBase"]?.Value ?? default(uint)),
		 ImageSize = (uint) (managementObject.Properties["ImageSize"]?.Value ?? default(uint)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint))
                };
        }
    }
}