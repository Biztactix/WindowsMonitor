using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class FromDirectorySpecification
    {
		public string FileName { get; private set; }
		public string SourceDirectory { get; private set; }

        public static IEnumerable<FromDirectorySpecification> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FromDirectorySpecification> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FromDirectorySpecification> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_FromDirectorySpecification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FromDirectorySpecification
                {
                     FileName =  (managementObject.Properties["FileName"]?.Value?.ToString()),
		 SourceDirectory =  (managementObject.Properties["SourceDirectory"]?.Value?.ToString())
                };
        }
    }
}