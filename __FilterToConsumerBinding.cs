using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __FilterToConsumerBinding
    {
		public short Consumer { get; private set; }
		public byte[] CreatorSID { get; private set; }
		public bool DeliverSynchronously { get; private set; }
		public uint DeliveryQoS { get; private set; }
		public short Filter { get; private set; }
		public bool MaintainSecurityContext { get; private set; }
		public bool SlowDownProviders { get; private set; }

        public static IEnumerable<__FilterToConsumerBinding> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__FilterToConsumerBinding> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__FilterToConsumerBinding> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __FilterToConsumerBinding");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __FilterToConsumerBinding
                {
                     Consumer = (short) (managementObject.Properties["Consumer"]?.Value ?? default(short)),
		 CreatorSID = (byte[]) (managementObject.Properties["CreatorSID"]?.Value ?? new byte[0]),
		 DeliverSynchronously = (bool) (managementObject.Properties["DeliverSynchronously"]?.Value ?? default(bool)),
		 DeliveryQoS = (uint) (managementObject.Properties["DeliveryQoS"]?.Value ?? default(uint)),
		 Filter = (short) (managementObject.Properties["Filter"]?.Value ?? default(short)),
		 MaintainSecurityContext = (bool) (managementObject.Properties["MaintainSecurityContext"]?.Value ?? default(bool)),
		 SlowDownProviders = (bool) (managementObject.Properties["SlowDownProviders"]?.Value ?? default(bool))
                };
        }
    }
}