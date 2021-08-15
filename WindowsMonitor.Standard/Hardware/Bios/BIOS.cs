using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Hardware.Bios
{
    /// <summary>
    /// </summary>
    public sealed class Bios
    {
        public ushort[] BiosCharacteristics { get; private set; }
        public string[] BiosVersion { get; private set; }
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
        public string OtherTargetOs { get; private set; }
        public bool PrimaryBios { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string SerialNumber { get; private set; }
        public string SmbiosbiosVersion { get; private set; }
        public ushort SmbiosMajorVersion { get; private set; }
        public ushort SmbiosMinorVersion { get; private set; }
        public bool SmbiosPresent { get; private set; }
        public string SoftwareElementId { get; private set; }
        public ushort SoftwareElementState { get; private set; }
        public string Status { get; private set; }
        public byte SystemBiosMajorVersion { get; private set; }
        public byte SystemBiosMinorVersion { get; private set; }
        public ushort TargetOperatingSystem { get; private set; }
        public string Version { get; private set; }

        public static IEnumerable<Bios> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Bios> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static T ReturnDetail<T>(String Name, ManagementObject obj, T DefaultObj)
        {
            try
            {
                if (obj.Properties[Name] != null)
                {
                    if (obj.Properties[Name].Value != null)
                    {
                        return (T)(obj.Properties[Name].Value);
                    }
                    else
                    {
                        return DefaultObj;
                    }
                }
                else
                {
                    return DefaultObj;
                }
            }
            catch { return DefaultObj; }
        }

        public static IEnumerable<Bios> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_BIOS");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
            {
                ushort v = ReturnDetail<ushort>("SMBIOSMinorVersion", managementObject, default(ushort));
                yield return new Bios
                {
                    BiosCharacteristics = ReturnDetail("BiosCharacteristics", managementObject, new ushort[0]),
                    BiosVersion = ReturnDetail("BIOSVersion", managementObject, new string[0]),
                    BuildNumber = ReturnDetail("BuildNumber", managementObject, ""),
                    Caption = ReturnDetail("Caption", managementObject, ""),
                    CodeSet = ReturnDetail("CodeSet", managementObject, ""),
                    CurrentLanguage = ReturnDetail("CurrentLanguage", managementObject, ""),
                    Description = ReturnDetail("Description", managementObject, ""),
                    EmbeddedControllerMajorVersion = ReturnDetail<byte>("EmbeddedControllerMajorVersion", managementObject, default(byte)),
                    EmbeddedControllerMinorVersion = ReturnDetail<byte>("EmbeddedControllerMinorVersion", managementObject, default(byte)),
                    IdentificationCode = ReturnDetail("IdentificationCode", managementObject, ""),
                    InstallableLanguages = ReturnDetail<ushort>("InstallableLanguages", managementObject, default(ushort)),
                    InstallDate = ManagementDateTimeConverter.ToDateTime(ReturnDetail<string>("InstallDate", managementObject, "00010102000000.000000+060")),
                    LanguageEdition = ReturnDetail("LanguageEdition", managementObject, ""),
                    ListOfLanguages = ReturnDetail<string[]>("ListOfLanguages", managementObject, new string[0]),
                    Manufacturer = ReturnDetail("Manufacturer", managementObject, ""),
                    Name = ReturnDetail("Name", managementObject, ""),
                    OtherTargetOs = ReturnDetail("OtherTargetOS", managementObject, ""),
                    PrimaryBios = ReturnDetail<bool>("PrimaryBIOS", managementObject, default(bool)),
                    ReleaseDate = ManagementDateTimeConverter.ToDateTime( ReturnDetail<string>("ReleaseDate", managementObject, "00010102000000.000000+060")),
                    SerialNumber = ReturnDetail("SerialNumber", managementObject, ""),
                    SmbiosbiosVersion = ReturnDetail("SMBIOSBIOSVersion", managementObject, ""),
                    SmbiosMajorVersion = ReturnDetail("SMBIOSMajorVersion", managementObject, default(ushort)),
                    SmbiosMinorVersion = v,
                    SmbiosPresent = ReturnDetail<bool>("SMBIOSPresent", managementObject, default(bool)),
                    SoftwareElementId = ReturnDetail("SoftwareElementID", managementObject, ""),
                    SoftwareElementState = ReturnDetail<ushort>("SoftwareElementState", managementObject, default(ushort)),
                    Status = ReturnDetail("Status", managementObject, ""),
                    SystemBiosMajorVersion = ReturnDetail<byte>("SystemBiosMajorVersion", managementObject, default(byte)),
                    SystemBiosMinorVersion = ReturnDetail<byte>("SystemBiosMinorVersion", managementObject, default(byte)),
                    TargetOperatingSystem = ReturnDetail<ushort>("TargetOperatingSystem", managementObject, default(ushort)),
                    Version = ReturnDetail("Version", managementObject, "")
                };
            }
        }
    }
}