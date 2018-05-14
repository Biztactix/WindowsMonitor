using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class CollectionOfMsEs
    {
		public string Caption { get; private set; }
		public string CollectionId { get; private set; }
		public string Description { get; private set; }

        public static IEnumerable<CollectionOfMsEs> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<CollectionOfMsEs> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<CollectionOfMsEs> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_CollectionOfMSEs");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new CollectionOfMsEs
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CollectionId = (string) (managementObject.Properties["CollectionID"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value)
                };
        }
    }
}