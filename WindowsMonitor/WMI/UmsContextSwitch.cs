using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class UmsContextSwitch
    {
		public uint Flags { get; private set; }
		public uint KernelYieldCount { get; private set; }
		public uint MixedYieldCount { get; private set; }
		public uint ScheduledThreadId { get; private set; }
		public uint SwitchCount { get; private set; }
		public uint YieldCount { get; private set; }

        public static IEnumerable<UmsContextSwitch> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<UmsContextSwitch> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<UmsContextSwitch> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM UmsContextSwitch");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new UmsContextSwitch
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 KernelYieldCount = (uint) (managementObject.Properties["KernelYieldCount"]?.Value ?? default(uint)),
		 MixedYieldCount = (uint) (managementObject.Properties["MixedYieldCount"]?.Value ?? default(uint)),
		 ScheduledThreadId = (uint) (managementObject.Properties["ScheduledThreadId"]?.Value ?? default(uint)),
		 SwitchCount = (uint) (managementObject.Properties["SwitchCount"]?.Value ?? default(uint)),
		 YieldCount = (uint) (managementObject.Properties["YieldCount"]?.Value ?? default(uint))
                };
        }
    }
}