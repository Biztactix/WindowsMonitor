using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SystemConfig_V0_IRQ
    {
		public string DeviceDescription { get; private set; }
		public uint DeviceDescriptionLen { get; private set; }
		public uint Flags { get; private set; }
		public ulong IRQAffinity { get; private set; }
		public uint IRQNum { get; private set; }

        public static IEnumerable<SystemConfig_V0_IRQ> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SystemConfig_V0_IRQ> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SystemConfig_V0_IRQ> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SystemConfig_V0_IRQ");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SystemConfig_V0_IRQ
                {
                     DeviceDescription = (string) (managementObject.Properties["DeviceDescription"]?.Value ?? default(string)),
		 DeviceDescriptionLen = (uint) (managementObject.Properties["DeviceDescriptionLen"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 IRQAffinity = (ulong) (managementObject.Properties["IRQAffinity"]?.Value ?? default(ulong)),
		 IRQNum = (uint) (managementObject.Properties["IRQNum"]?.Value ?? default(uint))
                };
        }
    }
}