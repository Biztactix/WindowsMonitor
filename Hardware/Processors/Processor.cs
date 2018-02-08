using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class Processor
    {
        public ushort AddressWidth { get; private set; }
        public ushort Architecture { get; private set; }
        public string AssetTag { get; private set; }
        public ushort Availability { get; private set; }
        public string Caption { get; private set; }
        public uint Characteristics { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public ushort CpuStatus { get; private set; }
        public string CreationClassName { get; private set; }
        public uint CurrentClockSpeed { get; private set; }
        public ushort CurrentVoltage { get; private set; }
        public ushort DataWidth { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public uint ExtClock { get; private set; }
        public ushort Family { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint L2CacheSize { get; private set; }
        public uint L2CacheSpeed { get; private set; }
        public uint L3CacheSize { get; private set; }
        public uint L3CacheSpeed { get; private set; }
        public uint LastErrorCode { get; private set; }
        public ushort Level { get; private set; }
        public ushort LoadPercentage { get; private set; }
        public string Manufacturer { get; private set; }
        public uint MaxClockSpeed { get; private set; }
        public string Name { get; private set; }
        public uint NumberOfCores { get; private set; }
        public uint NumberOfEnabledCore { get; private set; }
        public uint NumberOfLogicalProcessors { get; private set; }
        public string OtherFamilyDescription { get; private set; }
        public string PartNumber { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public string ProcessorId { get; private set; }
        public ushort ProcessorType { get; private set; }
        public ushort Revision { get; private set; }
        public string Role { get; private set; }
        public bool SecondLevelAddressTranslationExtensions { get; private set; }
        public string SerialNumber { get; private set; }
        public string SocketDesignation { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string Stepping { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public uint ThreadCount { get; private set; }
        public string UniqueId { get; private set; }
        public ushort UpgradeMethod { get; private set; }
        public string Version { get; private set; }
        public bool VirtualizationFirmwareEnabled { get; private set; }
        public bool VMMonitorModeExtensions { get; private set; }
        public uint VoltageCaps { get; private set; }

        public static Processor[] Retrieve(string remote, string username, string password)
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

        public static Processor[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static Processor[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Processor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<Processor>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new Processor
                {
                    AddressWidth = (ushort) managementObject.Properties["AddressWidth"].Value,
                    Architecture = (ushort) managementObject.Properties["Architecture"].Value,
                    AssetTag = (string) managementObject.Properties["AssetTag"].Value,
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Characteristics = (uint) managementObject.Properties["Characteristics"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CpuStatus = (ushort) managementObject.Properties["CpuStatus"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CurrentClockSpeed = (uint) managementObject.Properties["CurrentClockSpeed"].Value,
                    CurrentVoltage = (ushort) managementObject.Properties["CurrentVoltage"].Value,
                    DataWidth = (ushort) managementObject.Properties["DataWidth"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    ExtClock = (uint) managementObject.Properties["ExtClock"].Value,
                    Family = (ushort) managementObject.Properties["Family"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    L2CacheSize = (uint) managementObject.Properties["L2CacheSize"].Value,
                    L2CacheSpeed = (uint) managementObject.Properties["L2CacheSpeed"].Value,
                    L3CacheSize = (uint) managementObject.Properties["L3CacheSize"].Value,
                    L3CacheSpeed = (uint) managementObject.Properties["L3CacheSpeed"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    Level = (ushort) managementObject.Properties["Level"].Value,
                    LoadPercentage = (ushort) managementObject.Properties["LoadPercentage"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    MaxClockSpeed = (uint) managementObject.Properties["MaxClockSpeed"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberOfCores = (uint) managementObject.Properties["NumberOfCores"].Value,
                    NumberOfEnabledCore = (uint) managementObject.Properties["NumberOfEnabledCore"].Value,
                    NumberOfLogicalProcessors = (uint) managementObject.Properties["NumberOfLogicalProcessors"].Value,
                    OtherFamilyDescription = (string) managementObject.Properties["OtherFamilyDescription"].Value,
                    PartNumber = (string) managementObject.Properties["PartNumber"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    ProcessorId = (string) managementObject.Properties["ProcessorId"].Value,
                    ProcessorType = (ushort) managementObject.Properties["ProcessorType"].Value,
                    Revision = (ushort) managementObject.Properties["Revision"].Value,
                    Role = (string) managementObject.Properties["Role"].Value,
                    SecondLevelAddressTranslationExtensions = (bool) managementObject
                        .Properties["SecondLevelAddressTranslationExtensions"].Value,
                    SerialNumber = (string) managementObject.Properties["SerialNumber"].Value,
                    SocketDesignation = (string) managementObject.Properties["SocketDesignation"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    Stepping = (string) managementObject.Properties["Stepping"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    ThreadCount = (uint) managementObject.Properties["ThreadCount"].Value,
                    UniqueId = (string) managementObject.Properties["UniqueId"].Value,
                    UpgradeMethod = (ushort) managementObject.Properties["UpgradeMethod"].Value,
                    Version = (string) managementObject.Properties["Version"].Value,
                    VirtualizationFirmwareEnabled = (bool) managementObject.Properties["VirtualizationFirmwareEnabled"]
                        .Value,
                    VMMonitorModeExtensions = (bool) managementObject.Properties["VMMonitorModeExtensions"].Value,
                    VoltageCaps = (uint) managementObject.Properties["VoltageCaps"].Value
                });

            return list.ToArray();
        }
    }
}