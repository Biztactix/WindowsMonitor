using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class IP4RouteTable
    {
		public uint Age { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public string Destination { get; private set; }
		public string Information { get; private set; }
		public DateTime InstallDate { get; private set; }
		public int InterfaceIndex { get; private set; }
		public string Mask { get; private set; }
		public int Metric1 { get; private set; }
		public int Metric2 { get; private set; }
		public int Metric3 { get; private set; }
		public int Metric4 { get; private set; }
		public int Metric5 { get; private set; }
		public string Name { get; private set; }
		public string NextHop { get; private set; }
		public uint Protocol { get; private set; }
		public string Status { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<IP4RouteTable> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<IP4RouteTable> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<IP4RouteTable> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_IP4RouteTable");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new IP4RouteTable
                {
                     Age = (uint) (managementObject.Properties["Age"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Destination = (string) (managementObject.Properties["Destination"]?.Value ?? default(string)),
		 Information = (string) (managementObject.Properties["Information"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 InterfaceIndex = (int) (managementObject.Properties["InterfaceIndex"]?.Value ?? default(int)),
		 Mask = (string) (managementObject.Properties["Mask"]?.Value ?? default(string)),
		 Metric1 = (int) (managementObject.Properties["Metric1"]?.Value ?? default(int)),
		 Metric2 = (int) (managementObject.Properties["Metric2"]?.Value ?? default(int)),
		 Metric3 = (int) (managementObject.Properties["Metric3"]?.Value ?? default(int)),
		 Metric4 = (int) (managementObject.Properties["Metric4"]?.Value ?? default(int)),
		 Metric5 = (int) (managementObject.Properties["Metric5"]?.Value ?? default(int)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NextHop = (string) (managementObject.Properties["NextHop"]?.Value ?? default(string)),
		 Protocol = (uint) (managementObject.Properties["Protocol"]?.Value ?? default(uint)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}