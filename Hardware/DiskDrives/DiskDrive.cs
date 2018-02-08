using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class DiskDrive
    {
        public ushort Availability { get; private set; }
        public uint BytesPerSector { get; private set; }
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
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public string ErrorMethodology { get; private set; }
        public string FirmwareRevision { get; private set; }
        public uint Index { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string InterfaceType { get; private set; }
        public uint LastErrorCode { get; private set; }
        public string Manufacturer { get; private set; }
        public ulong MaxBlockSize { get; private set; }
        public ulong MaxMediaSize { get; private set; }
        public bool MediaLoaded { get; private set; }
        public string MediaType { get; private set; }
        public ulong MinBlockSize { get; private set; }
        public string Model { get; private set; }
        public string Name { get; private set; }
        public bool NeedsCleaning { get; private set; }
        public uint NumberOfMediaSupported { get; private set; }
        public uint Partitions { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public uint SCSIBus { get; private set; }
        public ushort SCSILogicalUnit { get; private set; }
        public ushort SCSIPort { get; private set; }
        public ushort SCSITargetId { get; private set; }
        public uint SectorsPerTrack { get; private set; }
        public string SerialNumber { get; private set; }
        public uint Signature { get; private set; }
        public ulong Size { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public ulong TotalCylinders { get; private set; }
        public uint TotalHeads { get; private set; }
        public ulong TotalSectors { get; private set; }
        public ulong TotalTracks { get; private set; }
        public uint TracksPerCylinder { get; private set; }

        public static DiskDrive[] Retrieve(string remote, string username, string password)
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

        public static DiskDrive[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static DiskDrive[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DiskDrive");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<DiskDrive>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new DiskDrive
                {
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    BytesPerSector = (uint) managementObject.Properties["BytesPerSector"].Value,
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
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    ErrorMethodology = (string) managementObject.Properties["ErrorMethodology"].Value,
                    FirmwareRevision = (string) managementObject.Properties["FirmwareRevision"].Value,
                    Index = (uint) managementObject.Properties["Index"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    InterfaceType = (string) managementObject.Properties["InterfaceType"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    MaxBlockSize = (ulong) managementObject.Properties["MaxBlockSize"].Value,
                    MaxMediaSize = (ulong) managementObject.Properties["MaxMediaSize"].Value,
                    MediaLoaded = (bool) managementObject.Properties["MediaLoaded"].Value,
                    MediaType = (string) managementObject.Properties["MediaType"].Value,
                    MinBlockSize = (ulong) managementObject.Properties["MinBlockSize"].Value,
                    Model = (string) managementObject.Properties["Model"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NeedsCleaning = (bool) managementObject.Properties["NeedsCleaning"].Value,
                    NumberOfMediaSupported = (uint) managementObject.Properties["NumberOfMediaSupported"].Value,
                    Partitions = (uint) managementObject.Properties["Partitions"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    SCSIBus = (uint) managementObject.Properties["SCSIBus"].Value,
                    SCSILogicalUnit = (ushort) managementObject.Properties["SCSILogicalUnit"].Value,
                    SCSIPort = (ushort) managementObject.Properties["SCSIPort"].Value,
                    SCSITargetId = (ushort) managementObject.Properties["SCSITargetId"].Value,
                    SectorsPerTrack = (uint) managementObject.Properties["SectorsPerTrack"].Value,
                    SerialNumber = (string) managementObject.Properties["SerialNumber"].Value,
                    Signature = (uint) managementObject.Properties["Signature"].Value,
                    Size = (ulong) managementObject.Properties["Size"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    TotalCylinders = (ulong) managementObject.Properties["TotalCylinders"].Value,
                    TotalHeads = (uint) managementObject.Properties["TotalHeads"].Value,
                    TotalSectors = (ulong) managementObject.Properties["TotalSectors"].Value,
                    TotalTracks = (ulong) managementObject.Properties["TotalTracks"].Value,
                    TracksPerCylinder = (uint) managementObject.Properties["TracksPerCylinder"].Value
                });

            return list.ToArray();
        }
    }
}