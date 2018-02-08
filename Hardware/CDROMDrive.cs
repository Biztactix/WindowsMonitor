using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class CDROMDrive
    {
        public ushort Availability { get; private set; }
        public ushort[] Capabilities { get; private set; }
        public string[] CapabilityDescriptions { get; private set; }
        public string Caption { get; private set; }
        public string CompressionMethod { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public ulong DefaultBlockSize { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public string Drive { get; private set; }
        public bool DriveIntegrity { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public string ErrorMethodology { get; private set; }
        public ushort FileSystemFlags { get; private set; }
        public uint FileSystemFlagsEx { get; private set; }
        public string Id { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint LastErrorCode { get; private set; }
        public string Manufacturer { get; private set; }
        public ulong MaxBlockSize { get; private set; }
        public uint MaximumComponentLength { get; private set; }
        public ulong MaxMediaSize { get; private set; }
        public bool MediaLoaded { get; private set; }
        public string MediaType { get; private set; }
        public string MfrAssignedRevisionLevel { get; private set; }
        public ulong MinBlockSize { get; private set; }
        public string Name { get; private set; }
        public bool NeedsCleaning { get; private set; }
        public uint NumberOfMediaSupported { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public string RevisionLevel { get; private set; }
        public uint SCSIBus { get; private set; }
        public ushort SCSILogicalUnit { get; private set; }
        public ushort SCSIPort { get; private set; }
        public ushort SCSITargetId { get; private set; }
        public string SerialNumber { get; private set; }
        public ulong Size { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public double TransferRate { get; private set; }
        public string VolumeName { get; private set; }
        public string VolumeSerialNumber { get; private set; }

        public static CDROMDrive[] Retrieve(string remote, string username, string password)
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

        public static CDROMDrive[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static CDROMDrive[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_CDROMDrive");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<CDROMDrive>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new CDROMDrive
                {
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    Capabilities = (ushort[]) managementObject.Properties["Capabilities"].Value,
                    CapabilityDescriptions = (string[]) managementObject.Properties["CapabilityDescriptions"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CompressionMethod = (string) managementObject.Properties["CompressionMethod"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    DefaultBlockSize = (ulong) managementObject.Properties["DefaultBlockSize"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    Drive = (string) managementObject.Properties["Drive"].Value,
                    DriveIntegrity = (bool) managementObject.Properties["DriveIntegrity"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    ErrorMethodology = (string) managementObject.Properties["ErrorMethodology"].Value,
                    FileSystemFlags = (ushort) managementObject.Properties["FileSystemFlags"].Value,
                    FileSystemFlagsEx = (uint) managementObject.Properties["FileSystemFlagsEx"].Value,
                    Id = (string) managementObject.Properties["Id"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    MaxBlockSize = (ulong) managementObject.Properties["MaxBlockSize"].Value,
                    MaximumComponentLength = (uint) managementObject.Properties["MaximumComponentLength"].Value,
                    MaxMediaSize = (ulong) managementObject.Properties["MaxMediaSize"].Value,
                    MediaLoaded = (bool) managementObject.Properties["MediaLoaded"].Value,
                    MediaType = (string) managementObject.Properties["MediaType"].Value,
                    MfrAssignedRevisionLevel = (string) managementObject.Properties["MfrAssignedRevisionLevel"].Value,
                    MinBlockSize = (ulong) managementObject.Properties["MinBlockSize"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NeedsCleaning = (bool) managementObject.Properties["NeedsCleaning"].Value,
                    NumberOfMediaSupported = (uint) managementObject.Properties["NumberOfMediaSupported"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    RevisionLevel = (string) managementObject.Properties["RevisionLevel"].Value,
                    SCSIBus = (uint) managementObject.Properties["SCSIBus"].Value,
                    SCSILogicalUnit = (ushort) managementObject.Properties["SCSILogicalUnit"].Value,
                    SCSIPort = (ushort) managementObject.Properties["SCSIPort"].Value,
                    SCSITargetId = (ushort) managementObject.Properties["SCSITargetId"].Value,
                    SerialNumber = (string) managementObject.Properties["SerialNumber"].Value,
                    Size = (ulong) managementObject.Properties["Size"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    TransferRate = (double) managementObject.Properties["TransferRate"].Value,
                    VolumeName = (string) managementObject.Properties["VolumeName"].Value,
                    VolumeSerialNumber = (string) managementObject.Properties["VolumeSerialNumber"].Value
                });

            return list.ToArray();
        }
    }
}