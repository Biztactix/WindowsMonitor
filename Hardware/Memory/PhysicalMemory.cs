using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PhysicalMemory
    {
        public uint Attributes { get; private set; }
        public string BankLabel { get; private set; }
        public ulong Capacity { get; private set; }
        public string Caption { get; private set; }
        public uint ConfiguredClockSpeed { get; private set; }
        public uint ConfiguredVoltage { get; private set; }
        public string CreationClassName { get; private set; }
        public ushort DataWidth { get; private set; }
        public string Description { get; private set; }
        public string DeviceLocator { get; private set; }
        public ushort FormFactor { get; private set; }
        public bool HotSwappable { get; private set; }
        public DateTime InstallDate { get; private set; }
        public ushort InterleaveDataDepth { get; private set; }
        public uint InterleavePosition { get; private set; }
        public string Manufacturer { get; private set; }
        public uint MaxVoltage { get; private set; }
        public ushort MemoryType { get; private set; }
        public uint MinVoltage { get; private set; }
        public string Model { get; private set; }
        public string Name { get; private set; }
        public string OtherIdentifyingInfo { get; private set; }
        public string PartNumber { get; private set; }
        public uint PositionInRow { get; private set; }
        public bool PoweredOn { get; private set; }
        public bool Removable { get; private set; }
        public bool Replaceable { get; private set; }
        public string SerialNumber { get; private set; }
        public string SKU { get; private set; }
        public uint SMBIOSMemoryType { get; private set; }
        public uint Speed { get; private set; }
        public string Status { get; private set; }
        public string Tag { get; private set; }
        public ushort TotalWidth { get; private set; }
        public ushort TypeDetail { get; private set; }
        public string Version { get; private set; }

        public static PhysicalMemory[] Retrieve(string remote, string username, string password)
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

        public static PhysicalMemory[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PhysicalMemory[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PhysicalMemory>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PhysicalMemory
                {
                    Attributes = (uint) managementObject.Properties["Attributes"].Value,
                    BankLabel = (string) managementObject.Properties["BankLabel"].Value,
                    Capacity = (ulong) managementObject.Properties["Capacity"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConfiguredClockSpeed = (uint) managementObject.Properties["ConfiguredClockSpeed"].Value,
                    ConfiguredVoltage = (uint) managementObject.Properties["ConfiguredVoltage"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    DataWidth = (ushort) managementObject.Properties["DataWidth"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceLocator = (string) managementObject.Properties["DeviceLocator"].Value,
                    FormFactor = (ushort) managementObject.Properties["FormFactor"].Value,
                    HotSwappable = (bool) managementObject.Properties["HotSwappable"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    InterleaveDataDepth = (ushort) managementObject.Properties["InterleaveDataDepth"].Value,
                    InterleavePosition = (uint) managementObject.Properties["InterleavePosition"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    MaxVoltage = (uint) managementObject.Properties["MaxVoltage"].Value,
                    MemoryType = (ushort) managementObject.Properties["MemoryType"].Value,
                    MinVoltage = (uint) managementObject.Properties["MinVoltage"].Value,
                    Model = (string) managementObject.Properties["Model"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OtherIdentifyingInfo = (string) managementObject.Properties["OtherIdentifyingInfo"].Value,
                    PartNumber = (string) managementObject.Properties["PartNumber"].Value,
                    PositionInRow = (uint) managementObject.Properties["PositionInRow"].Value,
                    PoweredOn = (bool) managementObject.Properties["PoweredOn"].Value,
                    Removable = (bool) managementObject.Properties["Removable"].Value,
                    Replaceable = (bool) managementObject.Properties["Replaceable"].Value,
                    SerialNumber = (string) managementObject.Properties["SerialNumber"].Value,
                    SKU = (string) managementObject.Properties["SKU"].Value,
                    SMBIOSMemoryType = (uint) managementObject.Properties["SMBIOSMemoryType"].Value,
                    Speed = (uint) managementObject.Properties["Speed"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    Tag = (string) managementObject.Properties["Tag"].Value,
                    TotalWidth = (ushort) managementObject.Properties["TotalWidth"].Value,
                    TypeDetail = (ushort) managementObject.Properties["TypeDetail"].Value,
                    Version = (string) managementObject.Properties["Version"].Value
                });

            return list.ToArray();
        }
    }
}