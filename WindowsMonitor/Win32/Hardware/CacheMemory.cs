using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
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

        public static IEnumerable<CacheMemory> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<CacheMemory> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<CacheMemory> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_CacheMemory");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new CacheMemory
                {
                     Access = (ushort) (managementObject.Properties["Access"]?.Value ?? default(ushort)),
		 AdditionalErrorData = (byte[]) (managementObject.Properties["AdditionalErrorData"]?.Value ?? new byte[0]),
		 Associativity = (ushort) (managementObject.Properties["Associativity"]?.Value ?? default(ushort)),
		 Availability = (ushort) (managementObject.Properties["Availability"]?.Value ?? default(ushort)),
		 BlockSize = (ulong) (managementObject.Properties["BlockSize"]?.Value ?? default(ulong)),
		 CacheSpeed = (uint) (managementObject.Properties["CacheSpeed"]?.Value ?? default(uint)),
		 CacheType = (ushort) (managementObject.Properties["CacheType"]?.Value ?? default(ushort)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ConfigManagerErrorCode = (uint) (managementObject.Properties["ConfigManagerErrorCode"]?.Value ?? default(uint)),
		 ConfigManagerUserConfig = (bool) (managementObject.Properties["ConfigManagerUserConfig"]?.Value ?? default(bool)),
		 CorrectableError = (bool) (managementObject.Properties["CorrectableError"]?.Value ?? default(bool)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 CurrentSRAM = (ushort[]) (managementObject.Properties["CurrentSRAM"]?.Value ?? new ushort[0]),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DeviceID = (string) (managementObject.Properties["DeviceID"]?.Value ?? default(string)),
		 EndingAddress = (ulong) (managementObject.Properties["EndingAddress"]?.Value ?? default(ulong)),
		 ErrorAccess = (ushort) (managementObject.Properties["ErrorAccess"]?.Value ?? default(ushort)),
		 ErrorAddress = (ulong) (managementObject.Properties["ErrorAddress"]?.Value ?? default(ulong)),
		 ErrorCleared = (bool) (managementObject.Properties["ErrorCleared"]?.Value ?? default(bool)),
		 ErrorCorrectType = (ushort) (managementObject.Properties["ErrorCorrectType"]?.Value ?? default(ushort)),
		 ErrorData = (byte[]) (managementObject.Properties["ErrorData"]?.Value ?? new byte[0]),
		 ErrorDataOrder = (ushort) (managementObject.Properties["ErrorDataOrder"]?.Value ?? default(ushort)),
		 ErrorDescription = (string) (managementObject.Properties["ErrorDescription"]?.Value ?? default(string)),
		 ErrorInfo = (ushort) (managementObject.Properties["ErrorInfo"]?.Value ?? default(ushort)),
		 ErrorMethodology = (string) (managementObject.Properties["ErrorMethodology"]?.Value ?? default(string)),
		 ErrorResolution = (ulong) (managementObject.Properties["ErrorResolution"]?.Value ?? default(ulong)),
		 ErrorTime = (DateTime) (managementObject.Properties["ErrorTime"]?.Value ?? default(DateTime)),
		 ErrorTransferSize = (uint) (managementObject.Properties["ErrorTransferSize"]?.Value ?? default(uint)),
		 FlushTimer = (uint) (managementObject.Properties["FlushTimer"]?.Value ?? default(uint)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 InstalledSize = (uint) (managementObject.Properties["InstalledSize"]?.Value ?? default(uint)),
		 LastErrorCode = (uint) (managementObject.Properties["LastErrorCode"]?.Value ?? default(uint)),
		 Level = (ushort) (managementObject.Properties["Level"]?.Value ?? default(ushort)),
		 LineSize = (uint) (managementObject.Properties["LineSize"]?.Value ?? default(uint)),
		 Location = (ushort) (managementObject.Properties["Location"]?.Value ?? default(ushort)),
		 MaxCacheSize = (uint) (managementObject.Properties["MaxCacheSize"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberOfBlocks = (ulong) (managementObject.Properties["NumberOfBlocks"]?.Value ?? default(ulong)),
		 OtherErrorDescription = (string) (managementObject.Properties["OtherErrorDescription"]?.Value ?? default(string)),
		 PNPDeviceID = (string) (managementObject.Properties["PNPDeviceID"]?.Value ?? default(string)),
		 PowerManagementCapabilities = (ushort[]) (managementObject.Properties["PowerManagementCapabilities"]?.Value ?? new ushort[0]),
		 PowerManagementSupported = (bool) (managementObject.Properties["PowerManagementSupported"]?.Value ?? default(bool)),
		 Purpose = (string) (managementObject.Properties["Purpose"]?.Value ?? default(string)),
		 ReadPolicy = (ushort) (managementObject.Properties["ReadPolicy"]?.Value ?? default(ushort)),
		 ReplacementPolicy = (ushort) (managementObject.Properties["ReplacementPolicy"]?.Value ?? default(ushort)),
		 StartingAddress = (ulong) (managementObject.Properties["StartingAddress"]?.Value ?? default(ulong)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 StatusInfo = (ushort) (managementObject.Properties["StatusInfo"]?.Value ?? default(ushort)),
		 SupportedSRAM = (ushort[]) (managementObject.Properties["SupportedSRAM"]?.Value ?? new ushort[0]),
		 SystemCreationClassName = (string) (managementObject.Properties["SystemCreationClassName"]?.Value ?? default(string)),
		 SystemLevelAddress = (bool) (managementObject.Properties["SystemLevelAddress"]?.Value ?? default(bool)),
		 SystemName = (string) (managementObject.Properties["SystemName"]?.Value ?? default(string)),
		 WritePolicy = (ushort) (managementObject.Properties["WritePolicy"]?.Value ?? default(ushort))
                };
        }
    }
}