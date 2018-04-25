using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class VideoBIOSFeature
    {
		public string Caption { get; private set; }
		public string[] CharacteristicDescriptions { get; private set; }
		public ushort[] Characteristics { get; private set; }
		public string Description { get; private set; }
		public string IdentifyingNumber { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string Name { get; private set; }
		public string ProductName { get; private set; }
		public string Status { get; private set; }
		public string Vendor { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<VideoBIOSFeature> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<VideoBIOSFeature> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<VideoBIOSFeature> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_VideoBIOSFeature");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new VideoBIOSFeature
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CharacteristicDescriptions = (string[]) (managementObject.Properties["CharacteristicDescriptions"]?.Value ?? new string[0]),
		 Characteristics = (ushort[]) (managementObject.Properties["Characteristics"]?.Value ?? new ushort[0]),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 IdentifyingNumber = (string) (managementObject.Properties["IdentifyingNumber"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ProductName = (string) (managementObject.Properties["ProductName"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 Vendor = (string) (managementObject.Properties["Vendor"]?.Value ?? default(string)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string))
                };
        }
    }
}