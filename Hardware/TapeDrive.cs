using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class TapeDrive
    {
        public ushort Availability { get; private set; }
        public ushort[] Capabilities { get; private set; }
        public string[] CapabilityDescriptions { get; private set; }
        public string Caption { get; private set; }
        public uint Compression { get; private set; }
        public string CompressionMethod { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public ulong DefaultBlockSize { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public uint ECC { get; private set; }
        public uint EOTWarningZoneSize { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public string ErrorMethodology { get; private set; }
        public uint FeaturesHigh { get; private set; }
        public uint FeaturesLow { get; private set; }
        public string Id { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint LastErrorCode { get; private set; }
        public string Manufacturer { get; private set; }
        public ulong MaxBlockSize { get; private set; }
        public ulong MaxMediaSize { get; private set; }
        public uint MaxPartitionCount { get; private set; }
        public string MediaType { get; private set; }
        public ulong MinBlockSize { get; private set; }
        public string Name { get; private set; }
        public bool NeedsCleaning { get; private set; }
        public uint NumberOfMediaSupported { get; private set; }
        public uint Padding { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public uint ReportSetMarks { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }

        public static TapeDrive[] Retrieve(string remote, string username, string password)
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

        public static TapeDrive[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static TapeDrive[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_TapeDrive");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<TapeDrive>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new TapeDrive
                {
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    Capabilities = (ushort[]) managementObject.Properties["Capabilities"].Value,
                    CapabilityDescriptions = (string[]) managementObject.Properties["CapabilityDescriptions"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Compression = (uint) managementObject.Properties["Compression"].Value,
                    CompressionMethod = (string) managementObject.Properties["CompressionMethod"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    DefaultBlockSize = (ulong) managementObject.Properties["DefaultBlockSize"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    ECC = (uint) managementObject.Properties["ECC"].Value,
                    EOTWarningZoneSize = (uint) managementObject.Properties["EOTWarningZoneSize"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    ErrorMethodology = (string) managementObject.Properties["ErrorMethodology"].Value,
                    FeaturesHigh = (uint) managementObject.Properties["FeaturesHigh"].Value,
                    FeaturesLow = (uint) managementObject.Properties["FeaturesLow"].Value,
                    Id = (string) managementObject.Properties["Id"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    MaxBlockSize = (ulong) managementObject.Properties["MaxBlockSize"].Value,
                    MaxMediaSize = (ulong) managementObject.Properties["MaxMediaSize"].Value,
                    MaxPartitionCount = (uint) managementObject.Properties["MaxPartitionCount"].Value,
                    MediaType = (string) managementObject.Properties["MediaType"].Value,
                    MinBlockSize = (ulong) managementObject.Properties["MinBlockSize"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NeedsCleaning = (bool) managementObject.Properties["NeedsCleaning"].Value,
                    NumberOfMediaSupported = (uint) managementObject.Properties["NumberOfMediaSupported"].Value,
                    Padding = (uint) managementObject.Properties["Padding"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    ReportSetMarks = (uint) managementObject.Properties["ReportSetMarks"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value
                });

            return list.ToArray();
        }
    }
}