using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class HBAFCPBindingEntry2
    {
		public dynamic FCPId { get; private set; }
		public byte[] Luid { get; private set; }
		public dynamic ScsiId { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<HBAFCPBindingEntry2> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HBAFCPBindingEntry2> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HBAFCPBindingEntry2> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM HBAFCPBindingEntry2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HBAFCPBindingEntry2
                {
                     FCPId = (dynamic) (managementObject.Properties["FCPId"]?.Value ?? default(dynamic)),
		 Luid = (byte[]) (managementObject.Properties["Luid"]?.Value ?? new byte[0]),
		 ScsiId = (dynamic) (managementObject.Properties["ScsiId"]?.Value ?? default(dynamic)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}