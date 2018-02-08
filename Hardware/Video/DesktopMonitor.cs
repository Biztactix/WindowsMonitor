using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class DesktopMonitor
    {
        public ushort Availability { get; private set; }
        public uint Bandwidth { get; private set; }
        public string Caption { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public ushort DisplayType { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public DateTime InstallDate { get; private set; }
        public bool IsLocked { get; private set; }
        public uint LastErrorCode { get; private set; }
        public string MonitorManufacturer { get; private set; }
        public string MonitorType { get; private set; }
        public string Name { get; private set; }
        public uint PixelsPerXLogicalInch { get; private set; }
        public uint PixelsPerYLogicalInch { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public uint ScreenHeight { get; private set; }
        public uint ScreenWidth { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }

        public static DesktopMonitor[] Retrieve(string remote, string username, string password)
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

        public static DesktopMonitor[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static DesktopMonitor[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DesktopMonitor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<DesktopMonitor>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new DesktopMonitor
                {
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    Bandwidth = (uint) managementObject.Properties["Bandwidth"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    DisplayType = (ushort) managementObject.Properties["DisplayType"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    IsLocked = (bool) managementObject.Properties["IsLocked"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    MonitorManufacturer = (string) managementObject.Properties["MonitorManufacturer"].Value,
                    MonitorType = (string) managementObject.Properties["MonitorType"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PixelsPerXLogicalInch = (uint) managementObject.Properties["PixelsPerXLogicalInch"].Value,
                    PixelsPerYLogicalInch = (uint) managementObject.Properties["PixelsPerYLogicalInch"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    ScreenHeight = (uint) managementObject.Properties["ScreenHeight"].Value,
                    ScreenWidth = (uint) managementObject.Properties["ScreenWidth"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value
                });

            return list.ToArray();
        }
    }
}