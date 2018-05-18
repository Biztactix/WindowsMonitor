using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SystemConfig_V2_DeviceFamily
    {
		public uint DeviceFamily { get; private set; }
		public uint DeviceForm { get; private set; }
		public uint Flags { get; private set; }
		public ulong UAPInfo { get; private set; }

        public static IEnumerable<SystemConfig_V2_DeviceFamily> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SystemConfig_V2_DeviceFamily> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SystemConfig_V2_DeviceFamily> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SystemConfig_V2_DeviceFamily");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SystemConfig_V2_DeviceFamily
                {
                     DeviceFamily = (uint) (managementObject.Properties["DeviceFamily"]?.Value ?? default(uint)),
		 DeviceForm = (uint) (managementObject.Properties["DeviceForm"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 UAPInfo = (ulong) (managementObject.Properties["UAPInfo"]?.Value ?? default(ulong))
                };
        }
    }
}