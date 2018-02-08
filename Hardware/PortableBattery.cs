using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PortableBattery
    {
        public ushort Availability { get; private set; }
        public ushort BatteryStatus { get; private set; }
        public ushort CapacityMultiplier { get; private set; }
        public string Caption { get; private set; }
        public ushort Chemistry { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public string Description { get; private set; }
        public uint DesignCapacity { get; private set; }
        public ulong DesignVoltage { get; private set; }
        public string DeviceID { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public ushort EstimatedChargeRemaining { get; private set; }
        public uint EstimatedRunTime { get; private set; }
        public uint ExpectedLife { get; private set; }
        public uint FullChargeCapacity { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint LastErrorCode { get; private set; }
        public string Location { get; private set; }
        public string ManufactureDate { get; private set; }
        public string Manufacturer { get; private set; }
        public ushort MaxBatteryError { get; private set; }
        public uint MaxRechargeTime { get; private set; }
        public string Name { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public string SmartBatteryVersion { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public uint TimeOnBattery { get; private set; }
        public uint TimeToFullCharge { get; private set; }

        public static PortableBattery[] Retrieve(string remote, string username, string password)
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

        public static PortableBattery[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PortableBattery[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PortableBattery");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PortableBattery>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PortableBattery
                {
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    BatteryStatus = (ushort) managementObject.Properties["BatteryStatus"].Value,
                    CapacityMultiplier = (ushort) managementObject.Properties["CapacityMultiplier"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Chemistry = (ushort) managementObject.Properties["Chemistry"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DesignCapacity = (uint) managementObject.Properties["DesignCapacity"].Value,
                    DesignVoltage = (ulong) managementObject.Properties["DesignVoltage"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    EstimatedChargeRemaining = (ushort) managementObject.Properties["EstimatedChargeRemaining"].Value,
                    EstimatedRunTime = (uint) managementObject.Properties["EstimatedRunTime"].Value,
                    ExpectedLife = (uint) managementObject.Properties["ExpectedLife"].Value,
                    FullChargeCapacity = (uint) managementObject.Properties["FullChargeCapacity"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    Location = (string) managementObject.Properties["Location"].Value,
                    ManufactureDate = (string) managementObject.Properties["ManufactureDate"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    MaxBatteryError = (ushort) managementObject.Properties["MaxBatteryError"].Value,
                    MaxRechargeTime = (uint) managementObject.Properties["MaxRechargeTime"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    SmartBatteryVersion = (string) managementObject.Properties["SmartBatteryVersion"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    TimeOnBattery = (uint) managementObject.Properties["TimeOnBattery"].Value,
                    TimeToFullCharge = (uint) managementObject.Properties["TimeToFullCharge"].Value
                });

            return list.ToArray();
        }
    }
}