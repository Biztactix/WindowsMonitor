using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SpinLockConfig_V3
    {
		public uint Flags { get; private set; }
		public uint SpinLockAcquireSampleRate { get; private set; }
		public uint SpinLockContentionSampleRate { get; private set; }
		public uint SpinLockHoldThreshold { get; private set; }
		public uint SpinLockSpinThreshold { get; private set; }

        public static IEnumerable<SpinLockConfig_V3> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SpinLockConfig_V3> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SpinLockConfig_V3> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SpinLockConfig_V3");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SpinLockConfig_V3
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 SpinLockAcquireSampleRate = (uint) (managementObject.Properties["SpinLockAcquireSampleRate"]?.Value ?? default(uint)),
		 SpinLockContentionSampleRate = (uint) (managementObject.Properties["SpinLockContentionSampleRate"]?.Value ?? default(uint)),
		 SpinLockHoldThreshold = (uint) (managementObject.Properties["SpinLockHoldThreshold"]?.Value ?? default(uint)),
		 SpinLockSpinThreshold = (uint) (managementObject.Properties["SpinLockSpinThreshold"]?.Value ?? default(uint))
                };
        }
    }
}