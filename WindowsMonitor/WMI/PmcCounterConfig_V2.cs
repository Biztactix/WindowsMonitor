using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class PmcCounterConfig_V2
    {
		public uint CounterCount { get; private set; }
		public string[] CounterName { get; private set; }
		public uint Flags { get; private set; }

        public static IEnumerable<PmcCounterConfig_V2> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PmcCounterConfig_V2> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PmcCounterConfig_V2> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM PmcCounterConfig_V2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PmcCounterConfig_V2
                {
                     CounterCount = (uint) (managementObject.Properties["CounterCount"]?.Value ?? default(uint)),
		 CounterName = (string[]) (managementObject.Properties["CounterName"]?.Value ?? new string[0]),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint))
                };
        }
    }
}