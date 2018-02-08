using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class Volume
    {
        public ushort Access { get; private set; }
        public bool Automount { get; private set; }
        public ushort Availability { get; private set; }
        public ulong BlockSize { get; private set; }
        public bool BootVolume { get; private set; }
        public ulong Capacity { get; private set; }
        public string Caption { get; private set; }
        public bool Compressed { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public bool DirtyBitSet { get; private set; }
        public string DriveLetter { get; private set; }
        public uint DriveType { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public string ErrorMethodology { get; private set; }
        public string FileSystem { get; private set; }
        public ulong FreeSpace { get; private set; }
        public bool IndexingEnabled { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Label { get; private set; }
        public uint LastErrorCode { get; private set; }
        public uint MaximumFileNameLength { get; private set; }
        public string Name { get; private set; }
        public ulong NumberOfBlocks { get; private set; }
        public bool PageFilePresent { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public string Purpose { get; private set; }
        public bool QuotasEnabled { get; private set; }
        public bool QuotasIncomplete { get; private set; }
        public bool QuotasRebuilding { get; private set; }
        public uint SerialNumber { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public bool SupportsDiskQuotas { get; private set; }
        public bool SupportsFileBasedCompression { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public bool SystemVolume { get; private set; }

        public static Volume[] Retrieve(string remote, string username, string password)
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

        public static Volume[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static Volume[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Volume");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<Volume>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new Volume
                {
                    Access = (ushort) managementObject.Properties["Access"].Value,
                    Automount = (bool) managementObject.Properties["Automount"].Value,
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    BlockSize = (ulong) managementObject.Properties["BlockSize"].Value,
                    BootVolume = (bool) managementObject.Properties["BootVolume"].Value,
                    Capacity = (ulong) managementObject.Properties["Capacity"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Compressed = (bool) managementObject.Properties["Compressed"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    DirtyBitSet = (bool) managementObject.Properties["DirtyBitSet"].Value,
                    DriveLetter = (string) managementObject.Properties["DriveLetter"].Value,
                    DriveType = (uint) managementObject.Properties["DriveType"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    ErrorMethodology = (string) managementObject.Properties["ErrorMethodology"].Value,
                    FileSystem = (string) managementObject.Properties["FileSystem"].Value,
                    FreeSpace = (ulong) managementObject.Properties["FreeSpace"].Value,
                    IndexingEnabled = (bool) managementObject.Properties["IndexingEnabled"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    Label = (string) managementObject.Properties["Label"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    MaximumFileNameLength = (uint) managementObject.Properties["MaximumFileNameLength"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberOfBlocks = (ulong) managementObject.Properties["NumberOfBlocks"].Value,
                    PageFilePresent = (bool) managementObject.Properties["PageFilePresent"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    Purpose = (string) managementObject.Properties["Purpose"].Value,
                    QuotasEnabled = (bool) managementObject.Properties["QuotasEnabled"].Value,
                    QuotasIncomplete = (bool) managementObject.Properties["QuotasIncomplete"].Value,
                    QuotasRebuilding = (bool) managementObject.Properties["QuotasRebuilding"].Value,
                    SerialNumber = (uint) managementObject.Properties["SerialNumber"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SupportsDiskQuotas = (bool) managementObject.Properties["SupportsDiskQuotas"].Value,
                    SupportsFileBasedCompression = (bool) managementObject.Properties["SupportsFileBasedCompression"]
                        .Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    SystemVolume = (bool) managementObject.Properties["SystemVolume"].Value
                });

            return list.ToArray();
        }
    }
}