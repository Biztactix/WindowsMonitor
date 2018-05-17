using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Registry_Counters
    {
		public ulong Counter1 { get; private set; }
		public ulong Counter10 { get; private set; }
		public ulong Counter11 { get; private set; }
		public ulong Counter2 { get; private set; }
		public ulong Counter3 { get; private set; }
		public ulong Counter4 { get; private set; }
		public ulong Counter5 { get; private set; }
		public ulong Counter6 { get; private set; }
		public ulong Counter7 { get; private set; }
		public ulong Counter8 { get; private set; }
		public ulong Counter9 { get; private set; }
		public uint Flags { get; private set; }

        public static IEnumerable<Registry_Counters> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Registry_Counters> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Registry_Counters> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Registry_Counters");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Registry_Counters
                {
                     Counter1 = (ulong) (managementObject.Properties["Counter1"]?.Value ?? default(ulong)),
		 Counter10 = (ulong) (managementObject.Properties["Counter10"]?.Value ?? default(ulong)),
		 Counter11 = (ulong) (managementObject.Properties["Counter11"]?.Value ?? default(ulong)),
		 Counter2 = (ulong) (managementObject.Properties["Counter2"]?.Value ?? default(ulong)),
		 Counter3 = (ulong) (managementObject.Properties["Counter3"]?.Value ?? default(ulong)),
		 Counter4 = (ulong) (managementObject.Properties["Counter4"]?.Value ?? default(ulong)),
		 Counter5 = (ulong) (managementObject.Properties["Counter5"]?.Value ?? default(ulong)),
		 Counter6 = (ulong) (managementObject.Properties["Counter6"]?.Value ?? default(ulong)),
		 Counter7 = (ulong) (managementObject.Properties["Counter7"]?.Value ?? default(ulong)),
		 Counter8 = (ulong) (managementObject.Properties["Counter8"]?.Value ?? default(ulong)),
		 Counter9 = (ulong) (managementObject.Properties["Counter9"]?.Value ?? default(ulong)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint))
                };
        }
    }
}