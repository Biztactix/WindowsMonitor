using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.OnBoard
{
    /// <summary>
    /// </summary>
    public sealed class BIOS
    {
		public ushort[] BiosCharacteristics { get; private set; }
		public string[] BIOSVersion { get; private set; }
		public string BuildNumber { get; private set; }
		public string Caption { get; private set; }
		public string CodeSet { get; private set; }
		public string CurrentLanguage { get; private set; }
		public string Description { get; private set; }
		public byte EmbeddedControllerMajorVersion { get; private set; }
		public byte EmbeddedControllerMinorVersion { get; private set; }
		public string IdentificationCode { get; private set; }
		public ushort InstallableLanguages { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string LanguageEdition { get; private set; }
		public string[] ListOfLanguages { get; private set; }
		public string Manufacturer { get; private set; }
		public string Name { get; private set; }
		public string OtherTargetOS { get; private set; }
		public bool PrimaryBIOS { get; private set; }
		public DateTime ReleaseDate { get; private set; }
		public string SerialNumber { get; private set; }
		public string SMBIOSBIOSVersion { get; private set; }
		public ushort SMBIOSMajorVersion { get; private set; }
		public ushort SMBIOSMinorVersion { get; private set; }
		public bool SMBIOSPresent { get; private set; }
		public string SoftwareElementID { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public string Status { get; private set; }
		public byte SystemBiosMajorVersion { get; private set; }
		public byte SystemBiosMinorVersion { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<BIOS> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<BIOS> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<BIOS> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_BIOS");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new BIOS
                {
                     BiosCharacteristics = (ushort[]) (managementObject.Properties["BiosCharacteristics"]?.Value ?? new ushort[0]),
		 BIOSVersion = (string[]) (managementObject.Properties["BIOSVersion"]?.Value ?? new string[0]),
		 BuildNumber = (string) (managementObject.Properties["BuildNumber"]?.Value ?? default(string)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CodeSet = (string) (managementObject.Properties["CodeSet"]?.Value ?? default(string)),
		 CurrentLanguage = (string) (managementObject.Properties["CurrentLanguage"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 EmbeddedControllerMajorVersion = (byte) (managementObject.Properties["EmbeddedControllerMajorVersion"]?.Value ?? default(byte)),
		 EmbeddedControllerMinorVersion = (byte) (managementObject.Properties["EmbeddedControllerMinorVersion"]?.Value ?? default(byte)),
		 IdentificationCode = (string) (managementObject.Properties["IdentificationCode"]?.Value ?? default(string)),
		 InstallableLanguages = (ushort) (managementObject.Properties["InstallableLanguages"]?.Value ?? default(ushort)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 LanguageEdition = (string) (managementObject.Properties["LanguageEdition"]?.Value ?? default(string)),
		 ListOfLanguages = (string[]) (managementObject.Properties["ListOfLanguages"]?.Value ?? new string[0]),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OtherTargetOS = (string) (managementObject.Properties["OtherTargetOS"]?.Value ?? default(string)),
		 PrimaryBIOS = (bool) (managementObject.Properties["PrimaryBIOS"]?.Value ?? default(bool)),
		 ReleaseDate = (DateTime) (managementObject.Properties["ReleaseDate"]?.Value ?? default(DateTime)),
		 SerialNumber = (string) (managementObject.Properties["SerialNumber"]?.Value ?? default(string)),
		 SMBIOSBIOSVersion = (string) (managementObject.Properties["SMBIOSBIOSVersion"]?.Value ?? default(string)),
		 SMBIOSMajorVersion = (ushort) (managementObject.Properties["SMBIOSMajorVersion"]?.Value ?? default(ushort)),
		 SMBIOSMinorVersion = (ushort) (managementObject.Properties["SMBIOSMinorVersion"]?.Value ?? default(ushort)),
		 SMBIOSPresent = (bool) (managementObject.Properties["SMBIOSPresent"]?.Value ?? default(bool)),
		 SoftwareElementID = (string) (managementObject.Properties["SoftwareElementID"]?.Value ?? default(string)),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 SystemBiosMajorVersion = (byte) (managementObject.Properties["SystemBiosMajorVersion"]?.Value ?? default(byte)),
		 SystemBiosMinorVersion = (byte) (managementObject.Properties["SystemBiosMinorVersion"]?.Value ?? default(byte)),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string))
                };
        }
    }
}