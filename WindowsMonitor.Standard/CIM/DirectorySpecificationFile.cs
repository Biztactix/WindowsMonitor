using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class DirectorySpecificationFile
    {
		public short DirectorySpecification { get; private set; }
		public short FileSpecification { get; private set; }

        public static IEnumerable<DirectorySpecificationFile> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<DirectorySpecificationFile> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<DirectorySpecificationFile> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_DirectorySpecificationFile");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new DirectorySpecificationFile
                {
                     DirectorySpecification = (short) (managementObject.Properties["DirectorySpecification"]?.Value ?? default(short)),
		 FileSpecification = (short) (managementObject.Properties["FileSpecification"]?.Value ?? default(short))
                };
        }
    }
}