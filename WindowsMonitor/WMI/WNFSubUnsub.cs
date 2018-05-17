using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class WNFSubUnsub
    {
		public uint Callback { get; private set; }
		public uint DeliveryFlags { get; private set; }
		public uint NameSub { get; private set; }
		public uint RefCount { get; private set; }
		public ulong StateName { get; private set; }
		public uint Subscription { get; private set; }

        public static IEnumerable<WNFSubUnsub> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WNFSubUnsub> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WNFSubUnsub> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM WNFSubUnsub");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WNFSubUnsub
                {
                     Callback = (uint) (managementObject.Properties["Callback"]?.Value ?? default(uint)),
		 DeliveryFlags = (uint) (managementObject.Properties["DeliveryFlags"]?.Value ?? default(uint)),
		 NameSub = (uint) (managementObject.Properties["NameSub"]?.Value ?? default(uint)),
		 RefCount = (uint) (managementObject.Properties["RefCount"]?.Value ?? default(uint)),
		 StateName = (ulong) (managementObject.Properties["StateName"]?.Value ?? default(ulong)),
		 Subscription = (uint) (managementObject.Properties["Subscription"]?.Value ?? default(uint))
                };
        }
    }
}