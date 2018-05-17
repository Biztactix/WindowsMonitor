using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class IdleExitLatency
    {
		public uint Flags { get; private set; }
		public uint PlatformState { get; private set; }
		public uint ProcessorState { get; private set; }
		public uint ReturnLatency { get; private set; }
		public uint TotalLatency { get; private set; }

        public static IEnumerable<IdleExitLatency> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<IdleExitLatency> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<IdleExitLatency> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM IdleExitLatency");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new IdleExitLatency
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 PlatformState = (uint) (managementObject.Properties["PlatformState"]?.Value ?? default(uint)),
		 ProcessorState = (uint) (managementObject.Properties["ProcessorState"]?.Value ?? default(uint)),
		 ReturnLatency = (uint) (managementObject.Properties["ReturnLatency"]?.Value ?? default(uint)),
		 TotalLatency = (uint) (managementObject.Properties["TotalLatency"]?.Value ?? default(uint))
                };
        }
    }
}