using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class CacheMemory
    {
        public ushort Access { get; private set; }
        public byte[] AdditionalErrorData { get; private set; }
        public ushort Associativity { get; private set; }
        public ushort Availability { get; private set; }
        public ulong BlockSize { get; private set; }
        public uint CacheSpeed { get; private set; }
        public ushort CacheType { get; private set; }
        public string Caption { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public bool CorrectableError { get; private set; }
        public string CreationClassName { get; private set; }
        public ushort[] CurrentSRAM { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public ulong EndingAddress { get; private set; }
        public ushort ErrorAccess { get; private set; }
        public ulong ErrorAddress { get; private set; }
        public bool ErrorCleared { get; private set; }
        public ushort ErrorCorrectType { get; private set; }
        public byte[] ErrorData { get; private set; }
        public ushort ErrorDataOrder { get; private set; }
        public string ErrorDescription { get; private set; }
        public ushort ErrorInfo { get; private set; }
        public string ErrorMethodology { get; private set; }
        public ulong ErrorResolution { get; private set; }
        public DateTime ErrorTime { get; private set; }
        public uint ErrorTransferSize { get; private set; }
        public uint FlushTimer { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint InstalledSize { get; private set; }
        public uint LastErrorCode { get; private set; }
        public ushort Level { get; private set; }
        public uint LineSize { get; private set; }
        public ushort Location { get; private set; }
        public uint MaxCacheSize { get; private set; }
        public string Name { get; private set; }
        public ulong NumberOfBlocks { get; private set; }
        public string OtherErrorDescription { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public string Purpose { get; private set; }
        public ushort ReadPolicy { get; private set; }
        public ushort ReplacementPolicy { get; private set; }
        public ulong StartingAddress { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public ushort[] SupportedSRAM { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public bool SystemLevelAddress { get; private set; }
        public string SystemName { get; private set; }
        public ushort WritePolicy { get; private set; }

        public static CacheMemory[] Retrieve(string remote, string username, string password)
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

        public static CacheMemory[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static CacheMemory[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_CacheMemory");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<CacheMemory>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new CacheMemory
                {
                    Access = (ushort) managementObject.Properties["Access"].Value,
                    AdditionalErrorData = (byte[]) managementObject.Properties["AdditionalErrorData"].Value,
                    Associativity = (ushort) managementObject.Properties["Associativity"].Value,
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    BlockSize = (ulong) managementObject.Properties["BlockSize"].Value,
                    CacheSpeed = (uint) managementObject.Properties["CacheSpeed"].Value,
                    CacheType = (ushort) managementObject.Properties["CacheType"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CorrectableError = (bool) managementObject.Properties["CorrectableError"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CurrentSRAM = (ushort[]) managementObject.Properties["CurrentSRAM"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    EndingAddress = (ulong) managementObject.Properties["EndingAddress"].Value,
                    ErrorAccess = (ushort) managementObject.Properties["ErrorAccess"].Value,
                    ErrorAddress = (ulong) managementObject.Properties["ErrorAddress"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorCorrectType = (ushort) managementObject.Properties["ErrorCorrectType"].Value,
                    ErrorData = (byte[]) managementObject.Properties["ErrorData"].Value,
                    ErrorDataOrder = (ushort) managementObject.Properties["ErrorDataOrder"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    ErrorInfo = (ushort) managementObject.Properties["ErrorInfo"].Value,
                    ErrorMethodology = (string) managementObject.Properties["ErrorMethodology"].Value,
                    ErrorResolution = (ulong) managementObject.Properties["ErrorResolution"].Value,
                    ErrorTime = (DateTime) managementObject.Properties["ErrorTime"].Value,
                    ErrorTransferSize = (uint) managementObject.Properties["ErrorTransferSize"].Value,
                    FlushTimer = (uint) managementObject.Properties["FlushTimer"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    InstalledSize = (uint) managementObject.Properties["InstalledSize"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    Level = (ushort) managementObject.Properties["Level"].Value,
                    LineSize = (uint) managementObject.Properties["LineSize"].Value,
                    Location = (ushort) managementObject.Properties["Location"].Value,
                    MaxCacheSize = (uint) managementObject.Properties["MaxCacheSize"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberOfBlocks = (ulong) managementObject.Properties["NumberOfBlocks"].Value,
                    OtherErrorDescription = (string) managementObject.Properties["OtherErrorDescription"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    Purpose = (string) managementObject.Properties["Purpose"].Value,
                    ReadPolicy = (ushort) managementObject.Properties["ReadPolicy"].Value,
                    ReplacementPolicy = (ushort) managementObject.Properties["ReplacementPolicy"].Value,
                    StartingAddress = (ulong) managementObject.Properties["StartingAddress"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SupportedSRAM = (ushort[]) managementObject.Properties["SupportedSRAM"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemLevelAddress = (bool) managementObject.Properties["SystemLevelAddress"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    WritePolicy = (ushort) managementObject.Properties["WritePolicy"].Value
                });

            return list.ToArray();
        }
    }
}