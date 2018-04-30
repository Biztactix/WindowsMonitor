using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Network
{
    /// <summary>
    /// </summary>
    public sealed class IP4PersistedRouteTable
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public string Destination { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string Mask { get; private set; }
		public int Metric1 { get; private set; }
		public string Name { get; private set; }
		public string NextHop { get; private set; }
		public string Status { get; private set; }

        public static IEnumerable<IP4PersistedRouteTable> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<IP4PersistedRouteTable> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<IP4PersistedRouteTable> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_IP4PersistedRouteTable");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new IP4PersistedRouteTable
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Destination = (string) (managementObject.Properties["Destination"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Mask = (string) (managementObject.Properties["Mask"]?.Value ?? default(string)),
		 Metric1 = (int) (managementObject.Properties["Metric1"]?.Value ?? default(int)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NextHop = (string) (managementObject.Properties["NextHop"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string))
                };
        }
    }
}