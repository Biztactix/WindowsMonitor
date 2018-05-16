using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class ToDirectorySpecification
    {
		public string DestinationDirectory { get; private set; }
		public string FileName { get; private set; }

        public static IEnumerable<ToDirectorySpecification> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ToDirectorySpecification> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ToDirectorySpecification> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_ToDirectorySpecification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ToDirectorySpecification
                {
                     DestinationDirectory =  (managementObject.Properties["DestinationDirectory"]?.Value?.ToString()),
		 FileName =  (managementObject.Properties["FileName"]?.Value?.ToString())
                };
        }
    }
}