using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SystemConfig_V2_ProcNumber
    {
		public uint Flags { get; private set; }
		public uint ProcessorCount { get; private set; }
		public uint[] ProcessorNumber { get; private set; }

        public static IEnumerable<SystemConfig_V2_ProcNumber> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SystemConfig_V2_ProcNumber> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SystemConfig_V2_ProcNumber> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SystemConfig_V2_ProcNumber");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SystemConfig_V2_ProcNumber
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 ProcessorCount = (uint) (managementObject.Properties["ProcessorCount"]?.Value ?? default(uint)),
		 ProcessorNumber = (uint[]) (managementObject.Properties["ProcessorNumber"]?.Value ?? new uint[0])
                };
        }
    }
}