using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Network
{
    /// <summary>
    /// </summary>
    public sealed class NetworkClient
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string Manufacturer { get; private set; }
		public string Name { get; private set; }
		public string Status { get; private set; }

        public static IEnumerable<NetworkClient> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NetworkClient> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NetworkClient> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_NetworkClient");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NetworkClient
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string))
                };
        }
    }
}