using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class HDAudBus_DMA
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public byte NewDeviceState { get; private set; }
		public byte OldDeviceState { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<HDAudBus_DMA> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HDAudBus_DMA> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HDAudBus_DMA> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM HDAudBus_DMA");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HDAudBus_DMA
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 NewDeviceState = (byte) (managementObject.Properties["NewDeviceState"]?.Value ?? default(byte)),
		 OldDeviceState = (byte) (managementObject.Properties["OldDeviceState"]?.Value ?? default(byte)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}