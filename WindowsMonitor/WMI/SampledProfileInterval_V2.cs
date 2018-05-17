using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SampledProfileInterval_V2
    {
		public uint Flags { get; private set; }
		public uint NewInterval { get; private set; }
		public uint OldInterval { get; private set; }
		public uint Source { get; private set; }

        public static IEnumerable<SampledProfileInterval_V2> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SampledProfileInterval_V2> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SampledProfileInterval_V2> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SampledProfileInterval_V2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SampledProfileInterval_V2
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 NewInterval = (uint) (managementObject.Properties["NewInterval"]?.Value ?? default(uint)),
		 OldInterval = (uint) (managementObject.Properties["OldInterval"]?.Value ?? default(uint)),
		 Source = (uint) (managementObject.Properties["Source"]?.Value ?? default(uint))
                };
        }
    }
}