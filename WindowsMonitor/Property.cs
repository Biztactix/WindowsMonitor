using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class Property
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public string ProductCode { get; private set; }
		public string Name { get; private set; }
		public string SettingID { get; private set; }
		public string Value { get; private set; }

        public static IEnumerable<Property> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Property> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Property> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Property");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Property
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 ProductCode = (string) (managementObject.Properties["ProductCode"]?.Value),
		 Name = (string) (managementObject.Properties["Property"]?.Value),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value),
		 Value = (string) (managementObject.Properties["Value"]?.Value)
                };
        }
    }
}