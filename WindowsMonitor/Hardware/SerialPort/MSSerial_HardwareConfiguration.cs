using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSSerial_HardwareConfiguration
    {
		public bool Active { get; private set; }
		public ulong BaseIOAddress { get; private set; }
		public string InstanceName { get; private set; }
		public uint InterruptType { get; private set; }
		public ulong IrqAffinityMask { get; private set; }
		public uint IrqLevel { get; private set; }
		public uint IrqNumber { get; private set; }
		public uint IrqVector { get; private set; }

        public static IEnumerable<MSSerial_HardwareConfiguration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSerial_HardwareConfiguration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSerial_HardwareConfiguration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSSerial_HardwareConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSerial_HardwareConfiguration
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 BaseIOAddress = (ulong) (managementObject.Properties["BaseIOAddress"]?.Value ?? default(ulong)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 InterruptType = (uint) (managementObject.Properties["InterruptType"]?.Value ?? default(uint)),
		 IrqAffinityMask = (ulong) (managementObject.Properties["IrqAffinityMask"]?.Value ?? default(ulong)),
		 IrqLevel = (uint) (managementObject.Properties["IrqLevel"]?.Value ?? default(uint)),
		 IrqNumber = (uint) (managementObject.Properties["IrqNumber"]?.Value ?? default(uint)),
		 IrqVector = (uint) (managementObject.Properties["IrqVector"]?.Value ?? default(uint))
                };
        }
    }
}