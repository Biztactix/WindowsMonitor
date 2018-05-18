using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class HDAudioDmaEngineErrorStatus
    {
		public uint DescriptorError { get; private set; }
		public uint FifoError { get; private set; }

        public static IEnumerable<HDAudioDmaEngineErrorStatus> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HDAudioDmaEngineErrorStatus> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HDAudioDmaEngineErrorStatus> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM HDAudioDmaEngineErrorStatus");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HDAudioDmaEngineErrorStatus
                {
                     DescriptorError = (uint) (managementObject.Properties["DescriptorError"]?.Value ?? default(uint)),
		 FifoError = (uint) (managementObject.Properties["FifoError"]?.Value ?? default(uint))
                };
        }
    }
}