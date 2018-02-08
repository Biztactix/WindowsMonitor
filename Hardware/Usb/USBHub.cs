using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class USBHub
    {
        public ushort Availability { get; private set; }
        public string Caption { get; private set; }
        public byte ClassCode { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public byte[] CurrentAlternateSettings { get; private set; }
        public byte CurrentConfigValue { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public bool GangSwitched { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint LastErrorCode { get; private set; }
        public string Name { get; private set; }
        public byte NumberOfConfigs { get; private set; }
        public byte NumberOfPorts { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public byte ProtocolCode { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public byte SubclassCode { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public ushort USBVersion { get; private set; }

        public static USBHub[] Retrieve(string remote, string username, string password)
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

        public static USBHub[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static USBHub[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_USBHub");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<USBHub>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new USBHub
                {
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ClassCode = (byte) managementObject.Properties["ClassCode"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CurrentAlternateSettings = (byte[]) managementObject.Properties["CurrentAlternateSettings"].Value,
                    CurrentConfigValue = (byte) managementObject.Properties["CurrentConfigValue"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    GangSwitched = (bool) managementObject.Properties["GangSwitched"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberOfConfigs = (byte) managementObject.Properties["NumberOfConfigs"].Value,
                    NumberOfPorts = (byte) managementObject.Properties["NumberOfPorts"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    ProtocolCode = (byte) managementObject.Properties["ProtocolCode"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SubclassCode = (byte) managementObject.Properties["SubclassCode"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    USBVersion = (ushort) managementObject.Properties["USBVersion"].Value
                });

            return list.ToArray();
        }
    }
}