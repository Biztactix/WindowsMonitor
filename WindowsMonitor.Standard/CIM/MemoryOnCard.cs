using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class MemoryOnCard
    {
		public short GroupComponent { get; private set; }
		public string LocationWithinContainer { get; private set; }
		public short PartComponent { get; private set; }

        public static IEnumerable<MemoryOnCard> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MemoryOnCard> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MemoryOnCard> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_MemoryOnCard");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MemoryOnCard
                {
                     GroupComponent = (short) (managementObject.Properties["GroupComponent"]?.Value ?? default(short)),
		 LocationWithinContainer = (string) (managementObject.Properties["LocationWithinContainer"]?.Value ?? default(string)),
		 PartComponent = (short) (managementObject.Properties["PartComponent"]?.Value ?? default(short))
                };
        }
    }
}