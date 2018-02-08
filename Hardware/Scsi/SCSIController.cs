using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SCSIController
    {
        public ushort Availability { get; private set; }
        public string Caption { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public uint ControllerTimeouts { get; private set; }
        public string CreationClassName { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public string DeviceMap { get; private set; }
        public string DriverName { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public string HardwareVersion { get; private set; }
        public uint Index { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint LastErrorCode { get; private set; }
        public string Manufacturer { get; private set; }
        public uint MaxDataWidth { get; private set; }
        public uint MaxNumberControlled { get; private set; }
        public ulong MaxTransferRate { get; private set; }
        public string Name { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public ushort ProtectionManagement { get; private set; }
        public ushort ProtocolSupported { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public DateTime TimeOfLastReset { get; private set; }

        public static SCSIController[] Retrieve(string remote, string username, string password)
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

        public static SCSIController[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SCSIController[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SCSIController");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SCSIController>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SCSIController
                {
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    ControllerTimeouts = (uint) managementObject.Properties["ControllerTimeouts"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    DeviceMap = (string) managementObject.Properties["DeviceMap"].Value,
                    DriverName = (string) managementObject.Properties["DriverName"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    HardwareVersion = (string) managementObject.Properties["HardwareVersion"].Value,
                    Index = (uint) managementObject.Properties["Index"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    MaxDataWidth = (uint) managementObject.Properties["MaxDataWidth"].Value,
                    MaxNumberControlled = (uint) managementObject.Properties["MaxNumberControlled"].Value,
                    MaxTransferRate = (ulong) managementObject.Properties["MaxTransferRate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    ProtectionManagement = (ushort) managementObject.Properties["ProtectionManagement"].Value,
                    ProtocolSupported = (ushort) managementObject.Properties["ProtocolSupported"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    TimeOfLastReset = (DateTime) managementObject.Properties["TimeOfLastReset"].Value
                });

            return list.ToArray();
        }
    }
}