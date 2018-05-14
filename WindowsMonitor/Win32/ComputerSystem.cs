using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ComputerSystem
    {
		public ushort AdminPasswordStatus { get; private set; }
		public bool AutomaticManagedPagefile { get; private set; }
		public bool AutomaticResetBootOption { get; private set; }
		public bool AutomaticResetCapability { get; private set; }
		public ushort BootOptionOnLimit { get; private set; }
		public ushort BootOptionOnWatchDog { get; private set; }
		public bool BootROMSupported { get; private set; }
		public ushort[] BootStatus { get; private set; }
		public string BootupState { get; private set; }
		public string Caption { get; private set; }
		public ushort ChassisBootupState { get; private set; }
		public string ChassisSKUNumber { get; private set; }
		public string CreationClassName { get; private set; }
		public short CurrentTimeZone { get; private set; }
		public bool DaylightInEffect { get; private set; }
		public string Description { get; private set; }
		public string DNSHostName { get; private set; }
		public string Domain { get; private set; }
		public ushort DomainRole { get; private set; }
		public bool EnableDaylightSavingsTime { get; private set; }
		public ushort FrontPanelResetStatus { get; private set; }
		public bool HypervisorPresent { get; private set; }
		public bool InfraredSupported { get; private set; }
		public string[] InitialLoadInfo { get; private set; }
		public DateTime InstallDate { get; private set; }
		public ushort KeyboardPasswordStatus { get; private set; }
		public string LastLoadInfo { get; private set; }
		public string Manufacturer { get; private set; }
		public string Model { get; private set; }
		public string Name { get; private set; }
		public string NameFormat { get; private set; }
		public bool NetworkServerModeEnabled { get; private set; }
		public uint NumberOfLogicalProcessors { get; private set; }
		public uint NumberOfProcessors { get; private set; }
		public byte[] OEMLogoBitmap { get; private set; }
		public string[] OEMStringArray { get; private set; }
		public bool PartOfDomain { get; private set; }
		public long PauseAfterReset { get; private set; }
		public ushort PCSystemType { get; private set; }
		public ushort PCSystemTypeEx { get; private set; }
		public ushort[] PowerManagementCapabilities { get; private set; }
		public bool PowerManagementSupported { get; private set; }
		public ushort PowerOnPasswordStatus { get; private set; }
		public ushort PowerState { get; private set; }
		public ushort PowerSupplyState { get; private set; }
		public string PrimaryOwnerContact { get; private set; }
		public string PrimaryOwnerName { get; private set; }
		public ushort ResetCapability { get; private set; }
		public short ResetCount { get; private set; }
		public short ResetLimit { get; private set; }
		public string[] Roles { get; private set; }
		public string Status { get; private set; }
		public string[] SupportContactDescription { get; private set; }
		public string SystemFamily { get; private set; }
		public string SystemSKUNumber { get; private set; }
		public ushort SystemStartupDelay { get; private set; }
		public string[] SystemStartupOptions { get; private set; }
		public byte SystemStartupSetting { get; private set; }
		public string SystemType { get; private set; }
		public ushort ThermalState { get; private set; }
		public ulong TotalPhysicalMemory { get; private set; }
		public string UserName { get; private set; }
		public ushort WakeUpType { get; private set; }
		public string Workgroup { get; private set; }

        public static IEnumerable<ComputerSystem> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ComputerSystem> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ComputerSystem> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ComputerSystem
                {
                     AdminPasswordStatus = (ushort) (managementObject.Properties["AdminPasswordStatus"]?.Value ?? default(ushort)),
		 AutomaticManagedPagefile = (bool) (managementObject.Properties["AutomaticManagedPagefile"]?.Value ?? default(bool)),
		 AutomaticResetBootOption = (bool) (managementObject.Properties["AutomaticResetBootOption"]?.Value ?? default(bool)),
		 AutomaticResetCapability = (bool) (managementObject.Properties["AutomaticResetCapability"]?.Value ?? default(bool)),
		 BootOptionOnLimit = (ushort) (managementObject.Properties["BootOptionOnLimit"]?.Value ?? default(ushort)),
		 BootOptionOnWatchDog = (ushort) (managementObject.Properties["BootOptionOnWatchDog"]?.Value ?? default(ushort)),
		 BootROMSupported = (bool) (managementObject.Properties["BootROMSupported"]?.Value ?? default(bool)),
		 BootStatus = (ushort[]) (managementObject.Properties["BootStatus"]?.Value ?? new ushort[0]),
		 BootupState = (string) (managementObject.Properties["BootupState"]?.Value),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 ChassisBootupState = (ushort) (managementObject.Properties["ChassisBootupState"]?.Value ?? default(ushort)),
		 ChassisSKUNumber = (string) (managementObject.Properties["ChassisSKUNumber"]?.Value),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value),
		 CurrentTimeZone = (short) (managementObject.Properties["CurrentTimeZone"]?.Value ?? default(short)),
		 DaylightInEffect = (bool) (managementObject.Properties["DaylightInEffect"]?.Value ?? default(bool)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 DNSHostName = (string) (managementObject.Properties["DNSHostName"]?.Value),
		 Domain = (string) (managementObject.Properties["Domain"]?.Value),
		 DomainRole = (ushort) (managementObject.Properties["DomainRole"]?.Value ?? default(ushort)),
		 EnableDaylightSavingsTime = (bool) (managementObject.Properties["EnableDaylightSavingsTime"]?.Value ?? default(bool)),
		 FrontPanelResetStatus = (ushort) (managementObject.Properties["FrontPanelResetStatus"]?.Value ?? default(ushort)),
		 HypervisorPresent = (bool) (managementObject.Properties["HypervisorPresent"]?.Value ?? default(bool)),
		 InfraredSupported = (bool) (managementObject.Properties["InfraredSupported"]?.Value ?? default(bool)),
		 InitialLoadInfo = (string[]) (managementObject.Properties["InitialLoadInfo"]?.Value ?? new string[0]),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 KeyboardPasswordStatus = (ushort) (managementObject.Properties["KeyboardPasswordStatus"]?.Value ?? default(ushort)),
		 LastLoadInfo = (string) (managementObject.Properties["LastLoadInfo"]?.Value),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value),
		 Model = (string) (managementObject.Properties["Model"]?.Value),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 NameFormat = (string) (managementObject.Properties["NameFormat"]?.Value),
		 NetworkServerModeEnabled = (bool) (managementObject.Properties["NetworkServerModeEnabled"]?.Value ?? default(bool)),
		 NumberOfLogicalProcessors = (uint) (managementObject.Properties["NumberOfLogicalProcessors"]?.Value ?? default(uint)),
		 NumberOfProcessors = (uint) (managementObject.Properties["NumberOfProcessors"]?.Value ?? default(uint)),
		 OEMLogoBitmap = (byte[]) (managementObject.Properties["OEMLogoBitmap"]?.Value ?? new byte[0]),
		 OEMStringArray = (string[]) (managementObject.Properties["OEMStringArray"]?.Value ?? new string[0]),
		 PartOfDomain = (bool) (managementObject.Properties["PartOfDomain"]?.Value ?? default(bool)),
		 PauseAfterReset = (long) (managementObject.Properties["PauseAfterReset"]?.Value ?? default(long)),
		 PCSystemType = (ushort) (managementObject.Properties["PCSystemType"]?.Value ?? default(ushort)),
		 PCSystemTypeEx = (ushort) (managementObject.Properties["PCSystemTypeEx"]?.Value ?? default(ushort)),
		 PowerManagementCapabilities = (ushort[]) (managementObject.Properties["PowerManagementCapabilities"]?.Value ?? new ushort[0]),
		 PowerManagementSupported = (bool) (managementObject.Properties["PowerManagementSupported"]?.Value ?? default(bool)),
		 PowerOnPasswordStatus = (ushort) (managementObject.Properties["PowerOnPasswordStatus"]?.Value ?? default(ushort)),
		 PowerState = (ushort) (managementObject.Properties["PowerState"]?.Value ?? default(ushort)),
		 PowerSupplyState = (ushort) (managementObject.Properties["PowerSupplyState"]?.Value ?? default(ushort)),
		 PrimaryOwnerContact = (string) (managementObject.Properties["PrimaryOwnerContact"]?.Value),
		 PrimaryOwnerName = (string) (managementObject.Properties["PrimaryOwnerName"]?.Value),
		 ResetCapability = (ushort) (managementObject.Properties["ResetCapability"]?.Value ?? default(ushort)),
		 ResetCount = (short) (managementObject.Properties["ResetCount"]?.Value ?? default(short)),
		 ResetLimit = (short) (managementObject.Properties["ResetLimit"]?.Value ?? default(short)),
		 Roles = (string[]) (managementObject.Properties["Roles"]?.Value ?? new string[0]),
		 Status = (string) (managementObject.Properties["Status"]?.Value),
		 SupportContactDescription = (string[]) (managementObject.Properties["SupportContactDescription"]?.Value ?? new string[0]),
		 SystemFamily = (string) (managementObject.Properties["SystemFamily"]?.Value),
		 SystemSKUNumber = (string) (managementObject.Properties["SystemSKUNumber"]?.Value),
		 SystemStartupDelay = (ushort) (managementObject.Properties["SystemStartupDelay"]?.Value ?? default(ushort)),
		 SystemStartupOptions = (string[]) (managementObject.Properties["SystemStartupOptions"]?.Value ?? new string[0]),
		 SystemStartupSetting = (byte) (managementObject.Properties["SystemStartupSetting"]?.Value ?? default(byte)),
		 SystemType = (string) (managementObject.Properties["SystemType"]?.Value),
		 ThermalState = (ushort) (managementObject.Properties["ThermalState"]?.Value ?? default(ushort)),
		 TotalPhysicalMemory = (ulong) (managementObject.Properties["TotalPhysicalMemory"]?.Value ?? default(ulong)),
		 UserName = (string) (managementObject.Properties["UserName"]?.Value),
		 WakeUpType = (ushort) (managementObject.Properties["WakeUpType"]?.Value ?? default(ushort)),
		 Workgroup = (string) (managementObject.Properties["Workgroup"]?.Value)
                };
        }
    }
}