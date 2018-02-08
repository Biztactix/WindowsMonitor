using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class VideoController
    {
        public ushort[] AcceleratorCapabilities { get; private set; }
        public string AdapterCompatibility { get; private set; }
        public string AdapterDACType { get; private set; }
        public uint AdapterRAM { get; private set; }
        public ushort Availability { get; private set; }
        public string[] CapabilityDescriptions { get; private set; }
        public string Caption { get; private set; }
        public uint ColorTableEntries { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public uint CurrentBitsPerPixel { get; private set; }
        public uint CurrentHorizontalResolution { get; private set; }
        public ulong CurrentNumberOfColors { get; private set; }
        public uint CurrentNumberOfColumns { get; private set; }
        public uint CurrentNumberOfRows { get; private set; }
        public uint CurrentRefreshRate { get; private set; }
        public ushort CurrentScanMode { get; private set; }
        public uint CurrentVerticalResolution { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public uint DeviceSpecificPens { get; private set; }
        public uint DitherType { get; private set; }
        public DateTime DriverDate { get; private set; }
        public string DriverVersion { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public uint ICMIntent { get; private set; }
        public uint ICMMethod { get; private set; }
        public string InfFilename { get; private set; }
        public string InfSection { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string InstalledDisplayDrivers { get; private set; }
        public uint LastErrorCode { get; private set; }
        public uint MaxMemorySupported { get; private set; }
        public uint MaxNumberControlled { get; private set; }
        public uint MaxRefreshRate { get; private set; }
        public uint MinRefreshRate { get; private set; }
        public bool Monochrome { get; private set; }
        public string Name { get; private set; }
        public ushort NumberOfColorPlanes { get; private set; }
        public uint NumberOfVideoPages { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public ushort ProtocolSupported { get; private set; }
        public uint ReservedSystemPaletteEntries { get; private set; }
        public uint SpecificationVersion { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public uint SystemPaletteEntries { get; private set; }
        public DateTime TimeOfLastReset { get; private set; }
        public ushort VideoArchitecture { get; private set; }
        public ushort VideoMemoryType { get; private set; }
        public ushort VideoMode { get; private set; }
        public string VideoModeDescription { get; private set; }
        public string VideoProcessor { get; private set; }

        public static VideoController[] Retrieve(string remote, string username, string password)
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

        public static VideoController[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static VideoController[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_VideoController");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<VideoController>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new VideoController
                {
                    AcceleratorCapabilities = (ushort[]) managementObject.Properties["AcceleratorCapabilities"].Value,
                    AdapterCompatibility = (string) managementObject.Properties["AdapterCompatibility"].Value,
                    AdapterDACType = (string) managementObject.Properties["AdapterDACType"].Value,
                    AdapterRAM = (uint) managementObject.Properties["AdapterRAM"].Value,
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    CapabilityDescriptions = (string[]) managementObject.Properties["CapabilityDescriptions"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ColorTableEntries = (uint) managementObject.Properties["ColorTableEntries"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CurrentBitsPerPixel = (uint) managementObject.Properties["CurrentBitsPerPixel"].Value,
                    CurrentHorizontalResolution = (uint) managementObject.Properties["CurrentHorizontalResolution"]
                        .Value,
                    CurrentNumberOfColors = (ulong) managementObject.Properties["CurrentNumberOfColors"].Value,
                    CurrentNumberOfColumns = (uint) managementObject.Properties["CurrentNumberOfColumns"].Value,
                    CurrentNumberOfRows = (uint) managementObject.Properties["CurrentNumberOfRows"].Value,
                    CurrentRefreshRate = (uint) managementObject.Properties["CurrentRefreshRate"].Value,
                    CurrentScanMode = (ushort) managementObject.Properties["CurrentScanMode"].Value,
                    CurrentVerticalResolution = (uint) managementObject.Properties["CurrentVerticalResolution"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    DeviceSpecificPens = (uint) managementObject.Properties["DeviceSpecificPens"].Value,
                    DitherType = (uint) managementObject.Properties["DitherType"].Value,
                    DriverDate = (DateTime) managementObject.Properties["DriverDate"].Value,
                    DriverVersion = (string) managementObject.Properties["DriverVersion"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    ICMIntent = (uint) managementObject.Properties["ICMIntent"].Value,
                    ICMMethod = (uint) managementObject.Properties["ICMMethod"].Value,
                    InfFilename = (string) managementObject.Properties["InfFilename"].Value,
                    InfSection = (string) managementObject.Properties["InfSection"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    InstalledDisplayDrivers = (string) managementObject.Properties["InstalledDisplayDrivers"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    MaxMemorySupported = (uint) managementObject.Properties["MaxMemorySupported"].Value,
                    MaxNumberControlled = (uint) managementObject.Properties["MaxNumberControlled"].Value,
                    MaxRefreshRate = (uint) managementObject.Properties["MaxRefreshRate"].Value,
                    MinRefreshRate = (uint) managementObject.Properties["MinRefreshRate"].Value,
                    Monochrome = (bool) managementObject.Properties["Monochrome"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberOfColorPlanes = (ushort) managementObject.Properties["NumberOfColorPlanes"].Value,
                    NumberOfVideoPages = (uint) managementObject.Properties["NumberOfVideoPages"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    ProtocolSupported = (ushort) managementObject.Properties["ProtocolSupported"].Value,
                    ReservedSystemPaletteEntries = (uint) managementObject.Properties["ReservedSystemPaletteEntries"]
                        .Value,
                    SpecificationVersion = (uint) managementObject.Properties["SpecificationVersion"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    SystemPaletteEntries = (uint) managementObject.Properties["SystemPaletteEntries"].Value,
                    TimeOfLastReset = (DateTime) managementObject.Properties["TimeOfLastReset"].Value,
                    VideoArchitecture = (ushort) managementObject.Properties["VideoArchitecture"].Value,
                    VideoMemoryType = (ushort) managementObject.Properties["VideoMemoryType"].Value,
                    VideoMode = (ushort) managementObject.Properties["VideoMode"].Value,
                    VideoModeDescription = (string) managementObject.Properties["VideoModeDescription"].Value,
                    VideoProcessor = (string) managementObject.Properties["VideoProcessor"].Value
                });

            return list.ToArray();
        }
    }
}