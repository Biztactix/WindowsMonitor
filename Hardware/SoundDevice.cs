using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SoundDevice
    {
        public ushort Availability { get; private set; }
        public string Caption { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public ushort DMABufferSize { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint LastErrorCode { get; private set; }
        public string Manufacturer { get; private set; }
        public uint MPU401Address { get; private set; }
        public string Name { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public string ProductName { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }

        public static SoundDevice[] Retrieve(string remote, string username, string password)
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

        public static SoundDevice[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SoundDevice[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SoundDevice");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SoundDevice>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SoundDevice
                {
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    DMABufferSize = (ushort) managementObject.Properties["DMABufferSize"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    MPU401Address = (uint) managementObject.Properties["MPU401Address"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    ProductName = (string) managementObject.Properties["ProductName"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value
                });

            return list.ToArray();
        }
    }
}