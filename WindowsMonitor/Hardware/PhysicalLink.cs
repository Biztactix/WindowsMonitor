using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Hardware
{
    /// <summary>
    /// </summary>
    public sealed class PhysicalLink
    {
		public string Caption { get; private set; }
		public string CreationClassName { get; private set; }
		public string Description { get; private set; }
		public DateTime InstallDate { get; private set; }
		public double Length { get; private set; }
		public string Manufacturer { get; private set; }
		public double MaxLength { get; private set; }
		public ushort MediaType { get; private set; }
		public string Model { get; private set; }
		public string Name { get; private set; }
		public string OtherIdentifyingInfo { get; private set; }
		public string PartNumber { get; private set; }
		public bool PoweredOn { get; private set; }
		public string SerialNumber { get; private set; }
		public string Sku { get; private set; }
		public string Status { get; private set; }
		public string Tag { get; private set; }
		public string Version { get; private set; }
		public bool Wired { get; private set; }

        public static IEnumerable<PhysicalLink> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PhysicalLink> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PhysicalLink> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_PhysicalLink");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PhysicalLink
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 InstallDate = ManagementDateTimeConverter.ToDateTime (managementObject.Properties["InstallDate"]?.Value as string ?? "00010102000000.000000+060"),
		 Length = (double) (managementObject.Properties["Length"]?.Value ?? default(double)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value),
		 MaxLength = (double) (managementObject.Properties["MaxLength"]?.Value ?? default(double)),
		 MediaType = (ushort) (managementObject.Properties["MediaType"]?.Value ?? default(ushort)),
		 Model = (string) (managementObject.Properties["Model"]?.Value),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 OtherIdentifyingInfo = (string) (managementObject.Properties["OtherIdentifyingInfo"]?.Value),
		 PartNumber = (string) (managementObject.Properties["PartNumber"]?.Value),
		 PoweredOn = (bool) (managementObject.Properties["PoweredOn"]?.Value ?? default(bool)),
		 SerialNumber = (string) (managementObject.Properties["SerialNumber"]?.Value),
		 Sku = (string) (managementObject.Properties["SKU"]?.Value),
		 Status = (string) (managementObject.Properties["Status"]?.Value),
		 Tag = (string) (managementObject.Properties["Tag"]?.Value),
		 Version = (string) (managementObject.Properties["Version"]?.Value),
		 Wired = (bool) (managementObject.Properties["Wired"]?.Value ?? default(bool))
                };
        }
    }
}