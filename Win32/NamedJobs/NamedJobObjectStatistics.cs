using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class NamedJobObjectStatistics
    {
		public short Collection { get; private set; }
		public short Stats { get; private set; }

        public static IEnumerable<NamedJobObjectStatistics> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<NamedJobObjectStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NamedJobObjectStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_NamedJobObjectStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NamedJobObjectStatistics
                {
                     Collection = (short) (managementObject.Properties["Collection"]?.Value ?? default(short)),
		 Stats = (short) (managementObject.Properties["Stats"]?.Value ?? default(short))
                };
        }
    }
}