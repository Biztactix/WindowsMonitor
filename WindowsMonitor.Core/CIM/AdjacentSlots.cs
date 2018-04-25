using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class AdjacentSlots
    {
		public float DistanceBetweenSlots { get; private set; }
		public bool SharedSlots { get; private set; }
		public short SlotA { get; private set; }
		public short SlotB { get; private set; }

        public static IEnumerable<AdjacentSlots> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<AdjacentSlots> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<AdjacentSlots> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_AdjacentSlots");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new AdjacentSlots
                {
                     DistanceBetweenSlots = (float) (managementObject.Properties["DistanceBetweenSlots"]?.Value ?? default(float)),
		 SharedSlots = (bool) (managementObject.Properties["SharedSlots"]?.Value ?? default(bool)),
		 SlotA = (short) (managementObject.Properties["SlotA"]?.Value ?? default(short)),
		 SlotB = (short) (managementObject.Properties["SlotB"]?.Value ?? default(short))
                };
        }
    }
}