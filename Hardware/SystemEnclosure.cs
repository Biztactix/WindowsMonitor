using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SystemEnclosure
    {
        public bool AudibleAlarm { get; private set; }
        public string BreachDescription { get; private set; }
        public string CableManagementStrategy { get; private set; }
        public string Caption { get; private set; }
        public ushort[] ChassisTypes { get; private set; }
        public string CreationClassName { get; private set; }
        public short CurrentRequiredOrProduced { get; private set; }
        public float Depth { get; private set; }
        public string Description { get; private set; }
        public ushort HeatGeneration { get; private set; }
        public float Height { get; private set; }
        public bool HotSwappable { get; private set; }
        public DateTime InstallDate { get; private set; }
        public bool LockPresent { get; private set; }
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public string Name { get; private set; }
        public ushort NumberOfPowerCords { get; private set; }
        public string OtherIdentifyingInfo { get; private set; }
        public string PartNumber { get; private set; }
        public bool PoweredOn { get; private set; }
        public bool Removable { get; private set; }
        public bool Replaceable { get; private set; }
        public ushort SecurityBreach { get; private set; }
        public ushort SecurityStatus { get; private set; }
        public string SerialNumber { get; private set; }
        public string[] ServiceDescriptions { get; private set; }
        public ushort[] ServicePhilosophy { get; private set; }
        public string SKU { get; private set; }
        public string SMBIOSAssetTag { get; private set; }
        public string Status { get; private set; }
        public string Tag { get; private set; }
        public string[] TypeDescriptions { get; private set; }
        public string Version { get; private set; }
        public bool VisibleAlarm { get; private set; }
        public float Weight { get; private set; }
        public float Width { get; private set; }

        public static SystemEnclosure[] Retrieve(string remote, string username, string password)
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

        public static SystemEnclosure[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SystemEnclosure[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SystemEnclosure");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SystemEnclosure>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SystemEnclosure
                {
                    AudibleAlarm = (bool) managementObject.Properties["AudibleAlarm"].Value,
                    BreachDescription = (string) managementObject.Properties["BreachDescription"].Value,
                    CableManagementStrategy = (string) managementObject.Properties["CableManagementStrategy"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ChassisTypes = (ushort[]) managementObject.Properties["ChassisTypes"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CurrentRequiredOrProduced = (short) managementObject.Properties["CurrentRequiredOrProduced"].Value,
                    Depth = (float) managementObject.Properties["Depth"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    HeatGeneration = (ushort) managementObject.Properties["HeatGeneration"].Value,
                    Height = (float) managementObject.Properties["Height"].Value,
                    HotSwappable = (bool) managementObject.Properties["HotSwappable"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LockPresent = (bool) managementObject.Properties["LockPresent"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    Model = (string) managementObject.Properties["Model"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberOfPowerCords = (ushort) managementObject.Properties["NumberOfPowerCords"].Value,
                    OtherIdentifyingInfo = (string) managementObject.Properties["OtherIdentifyingInfo"].Value,
                    PartNumber = (string) managementObject.Properties["PartNumber"].Value,
                    PoweredOn = (bool) managementObject.Properties["PoweredOn"].Value,
                    Removable = (bool) managementObject.Properties["Removable"].Value,
                    Replaceable = (bool) managementObject.Properties["Replaceable"].Value,
                    SecurityBreach = (ushort) managementObject.Properties["SecurityBreach"].Value,
                    SecurityStatus = (ushort) managementObject.Properties["SecurityStatus"].Value,
                    SerialNumber = (string) managementObject.Properties["SerialNumber"].Value,
                    ServiceDescriptions = (string[]) managementObject.Properties["ServiceDescriptions"].Value,
                    ServicePhilosophy = (ushort[]) managementObject.Properties["ServicePhilosophy"].Value,
                    SKU = (string) managementObject.Properties["SKU"].Value,
                    SMBIOSAssetTag = (string) managementObject.Properties["SMBIOSAssetTag"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    Tag = (string) managementObject.Properties["Tag"].Value,
                    TypeDescriptions = (string[]) managementObject.Properties["TypeDescriptions"].Value,
                    Version = (string) managementObject.Properties["Version"].Value,
                    VisibleAlarm = (bool) managementObject.Properties["VisibleAlarm"].Value,
                    Weight = (float) managementObject.Properties["Weight"].Value,
                    Width = (float) managementObject.Properties["Width"].Value
                });

            return list.ToArray();
        }
    }
}