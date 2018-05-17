using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class WNFCallback
    {
		public uint Callback { get; private set; }
		public uint ChangeStamp { get; private set; }
		public uint DeliveryFlags { get; private set; }
		public uint NameSub { get; private set; }
		public uint Return { get; private set; }
		public ulong StateName { get; private set; }
		public uint Subscription { get; private set; }

        public static IEnumerable<WNFCallback> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WNFCallback> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WNFCallback> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM WNFCallback");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WNFCallback
                {
                     Callback = (uint) (managementObject.Properties["Callback"]?.Value ?? default(uint)),
		 ChangeStamp = (uint) (managementObject.Properties["ChangeStamp"]?.Value ?? default(uint)),
		 DeliveryFlags = (uint) (managementObject.Properties["DeliveryFlags"]?.Value ?? default(uint)),
		 NameSub = (uint) (managementObject.Properties["NameSub"]?.Value ?? default(uint)),
		 Return = (uint) (managementObject.Properties["Return"]?.Value ?? default(uint)),
		 StateName = (ulong) (managementObject.Properties["StateName"]?.Value ?? default(ulong)),
		 Subscription = (uint) (managementObject.Properties["Subscription"]?.Value ?? default(uint))
                };
        }
    }
}