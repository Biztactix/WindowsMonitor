using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM.Bios
{
    /// <summary>
    /// </summary>
    public sealed class BiosElement
    {
		public string BuildNumber { get; private set; }
		public string Caption { get; private set; }
		public string CodeSet { get; private set; }
		public string Description { get; private set; }
		public string IdentificationCode { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string LanguageEdition { get; private set; }
		public string Manufacturer { get; private set; }
		public string Name { get; private set; }
		public string OtherTargetOs { get; private set; }
		public bool PrimaryBios { get; private set; }
		public string SerialNumber { get; private set; }
		public string SoftwareElementId { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public string Status { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<BiosElement> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<BiosElement> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<BiosElement> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_BIOSElement");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new BiosElement
                {
                     BuildNumber = (string) (managementObject.Properties["BuildNumber"]?.Value ?? default(string)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CodeSet = (string) (managementObject.Properties["CodeSet"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 IdentificationCode = (string) (managementObject.Properties["IdentificationCode"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 LanguageEdition = (string) (managementObject.Properties["LanguageEdition"]?.Value ?? default(string)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OtherTargetOs = (string) (managementObject.Properties["OtherTargetOS"]?.Value ?? default(string)),
		 PrimaryBios = (bool) (managementObject.Properties["PrimaryBIOS"]?.Value ?? default(bool)),
		 SerialNumber = (string) (managementObject.Properties["SerialNumber"]?.Value ?? default(string)),
		 SoftwareElementId = (string) (managementObject.Properties["SoftwareElementID"]?.Value ?? default(string)),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string))
                };
        }
    }
}