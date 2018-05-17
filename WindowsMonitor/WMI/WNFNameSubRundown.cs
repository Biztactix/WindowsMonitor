using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class WNFNameSubRundown
    {
		public uint NameSub { get; private set; }
		public ulong StateName { get; private set; }

        public static IEnumerable<WNFNameSubRundown> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WNFNameSubRundown> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WNFNameSubRundown> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM WNFNameSubRundown");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WNFNameSubRundown
                {
                     NameSub = (uint) (managementObject.Properties["NameSub"]?.Value ?? default(uint)),
		 StateName = (ulong) (managementObject.Properties["StateName"]?.Value ?? default(ulong))
                };
        }
    }
}