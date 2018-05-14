using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class Binary
    {
		public string Caption { get; private set; }
		public string Data { get; private set; }
		public string Description { get; private set; }
		public string Name { get; private set; }
		public string ProductCode { get; private set; }
		public string SettingID { get; private set; }

        public static IEnumerable<Binary> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Binary> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Binary> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Binary");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Binary
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Data = (string) (managementObject.Properties["Data"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 ProductCode = (string) (managementObject.Properties["ProductCode"]?.Value),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value)
                };
        }
    }
}