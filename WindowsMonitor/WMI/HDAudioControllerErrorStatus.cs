using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class HDAudioControllerErrorStatus
    {
		public uint CorbMemoryError { get; private set; }
		public uint RirbFifoOverrun { get; private set; }

        public static IEnumerable<HDAudioControllerErrorStatus> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HDAudioControllerErrorStatus> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HDAudioControllerErrorStatus> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM HDAudioControllerErrorStatus");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HDAudioControllerErrorStatus
                {
                     CorbMemoryError = (uint) (managementObject.Properties["CorbMemoryError"]?.Value ?? default(uint)),
		 RirbFifoOverrun = (uint) (managementObject.Properties["RirbFifoOverrun"]?.Value ?? default(uint))
                };
        }
    }
}