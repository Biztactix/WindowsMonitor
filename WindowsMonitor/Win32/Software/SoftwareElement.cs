using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class SoftwareElement
    {
		public ushort Attributes { get; private set; }
		public string BuildNumber { get; private set; }
		public string Caption { get; private set; }
		public string CodeSet { get; private set; }
		public string Description { get; private set; }
		public string IdentificationCode { get; private set; }
		public DateTime InstallDate { get; private set; }
		public short InstallState { get; private set; }
		public string LanguageEdition { get; private set; }
		public string Manufacturer { get; private set; }
		public string Name { get; private set; }
		public string OtherTargetOS { get; private set; }
		public string Path { get; private set; }
		public string SerialNumber { get; private set; }
		public string SoftwareElementID { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public string Status { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<SoftwareElement> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SoftwareElement> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SoftwareElement> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SoftwareElement");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SoftwareElement
                {
                     Attributes = (ushort) (managementObject.Properties["Attributes"]?.Value ?? default(ushort)),
		 BuildNumber = (string) (managementObject.Properties["BuildNumber"]?.Value),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CodeSet = (string) (managementObject.Properties["CodeSet"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 IdentificationCode = (string) (managementObject.Properties["IdentificationCode"]?.Value),
		 InstallDate = ManagementDateTimeConverter.ToDateTime (managementObject.Properties["InstallDate"]?.Value as string ?? "00010101000000.000000+060"),
		 InstallState = (short) (managementObject.Properties["InstallState"]?.Value ?? default(short)),
		 LanguageEdition = (string) (managementObject.Properties["LanguageEdition"]?.Value),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 OtherTargetOS = (string) (managementObject.Properties["OtherTargetOS"]?.Value),
		 Path = (string) (managementObject.Properties["Path"]?.Value),
		 SerialNumber = (string) (managementObject.Properties["SerialNumber"]?.Value),
		 SoftwareElementID = (string) (managementObject.Properties["SoftwareElementID"]?.Value),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 Status = (string) (managementObject.Properties["Status"]?.Value),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Version = (string) (managementObject.Properties["Version"]?.Value)
                };
        }
    }
}