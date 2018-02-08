using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class BaseBoard
    {
        public string Caption { get; private set; }
        public string[] ConfigOptions { get; private set; }
        public string CreationClassName { get; private set; }
        public float Depth { get; private set; }
        public string Description { get; private set; }
        public float Height { get; private set; }
        public bool HostingBoard { get; private set; }
        public bool HotSwappable { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public string Name { get; private set; }
        public string OtherIdentifyingInfo { get; private set; }
        public string PartNumber { get; private set; }
        public bool PoweredOn { get; private set; }
        public string Product { get; private set; }
        public bool Removable { get; private set; }
        public bool Replaceable { get; private set; }
        public string RequirementsDescription { get; private set; }
        public bool RequiresDaughterBoard { get; private set; }
        public string SerialNumber { get; private set; }
        public string SKU { get; private set; }
        public string SlotLayout { get; private set; }
        public bool SpecialRequirements { get; private set; }
        public string Status { get; private set; }
        public string Tag { get; private set; }
        public string Version { get; private set; }
        public float Weight { get; private set; }
        public float Width { get; private set; }

        public static BaseBoard[] Retrieve(string remote, string username, string password)
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

        public static BaseBoard[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static BaseBoard[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_BaseBoard");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<BaseBoard>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new BaseBoard
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConfigOptions = (string[]) managementObject.Properties["ConfigOptions"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    Depth = (float) managementObject.Properties["Depth"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Height = (float) managementObject.Properties["Height"].Value,
                    HostingBoard = (bool) managementObject.Properties["HostingBoard"].Value,
                    HotSwappable = (bool) managementObject.Properties["HotSwappable"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    Model = (string) managementObject.Properties["Model"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OtherIdentifyingInfo = (string) managementObject.Properties["OtherIdentifyingInfo"].Value,
                    PartNumber = (string) managementObject.Properties["PartNumber"].Value,
                    PoweredOn = (bool) managementObject.Properties["PoweredOn"].Value,
                    Product = (string) managementObject.Properties["Product"].Value,
                    Removable = (bool) managementObject.Properties["Removable"].Value,
                    Replaceable = (bool) managementObject.Properties["Replaceable"].Value,
                    RequirementsDescription = (string) managementObject.Properties["RequirementsDescription"].Value,
                    RequiresDaughterBoard = (bool) managementObject.Properties["RequiresDaughterBoard"].Value,
                    SerialNumber = (string) managementObject.Properties["SerialNumber"].Value,
                    SKU = (string) managementObject.Properties["SKU"].Value,
                    SlotLayout = (string) managementObject.Properties["SlotLayout"].Value,
                    SpecialRequirements = (bool) managementObject.Properties["SpecialRequirements"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    Tag = (string) managementObject.Properties["Tag"].Value,
                    Version = (string) managementObject.Properties["Version"].Value,
                    Weight = (float) managementObject.Properties["Weight"].Value,
                    Width = (float) managementObject.Properties["Width"].Value
                });

            return list.ToArray();
        }
    }
}