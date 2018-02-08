using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
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

        public static ComputerSystem[] Retrieve(string remote, string username, string password)
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

        public static ComputerSystem[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static ComputerSystem[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<ComputerSystem>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new ComputerSystem
                {
                    AdminPasswordStatus = (ushort) managementObject.Properties["AdminPasswordStatus"].Value,
                    AutomaticManagedPagefile = (bool) managementObject.Properties["AutomaticManagedPagefile"].Value,
                    AutomaticResetBootOption = (bool) managementObject.Properties["AutomaticResetBootOption"].Value,
                    AutomaticResetCapability = (bool) managementObject.Properties["AutomaticResetCapability"].Value,
                    BootOptionOnLimit = (ushort) managementObject.Properties["BootOptionOnLimit"].Value,
                    BootOptionOnWatchDog = (ushort) managementObject.Properties["BootOptionOnWatchDog"].Value,
                    BootROMSupported = (bool) managementObject.Properties["BootROMSupported"].Value,
                    BootStatus = (ushort[]) managementObject.Properties["BootStatus"].Value,
                    BootupState = (string) managementObject.Properties["BootupState"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ChassisBootupState = (ushort) managementObject.Properties["ChassisBootupState"].Value,
                    ChassisSKUNumber = (string) managementObject.Properties["ChassisSKUNumber"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CurrentTimeZone = (short) managementObject.Properties["CurrentTimeZone"].Value,
                    DaylightInEffect = (bool) managementObject.Properties["DaylightInEffect"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DNSHostName = (string) managementObject.Properties["DNSHostName"].Value,
                    Domain = (string) managementObject.Properties["Domain"].Value,
                    DomainRole = (ushort) managementObject.Properties["DomainRole"].Value,
                    EnableDaylightSavingsTime = (bool) managementObject.Properties["EnableDaylightSavingsTime"].Value,
                    FrontPanelResetStatus = (ushort) managementObject.Properties["FrontPanelResetStatus"].Value,
                    HypervisorPresent = (bool) managementObject.Properties["HypervisorPresent"].Value,
                    InfraredSupported = (bool) managementObject.Properties["InfraredSupported"].Value,
                    InitialLoadInfo = (string[]) managementObject.Properties["InitialLoadInfo"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    KeyboardPasswordStatus = (ushort) managementObject.Properties["KeyboardPasswordStatus"].Value,
                    LastLoadInfo = (string) managementObject.Properties["LastLoadInfo"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    Model = (string) managementObject.Properties["Model"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NameFormat = (string) managementObject.Properties["NameFormat"].Value,
                    NetworkServerModeEnabled = (bool) managementObject.Properties["NetworkServerModeEnabled"].Value,
                    NumberOfLogicalProcessors = (uint) managementObject.Properties["NumberOfLogicalProcessors"].Value,
                    NumberOfProcessors = (uint) managementObject.Properties["NumberOfProcessors"].Value,
                    OEMLogoBitmap = (byte[]) managementObject.Properties["OEMLogoBitmap"].Value,
                    OEMStringArray = (string[]) managementObject.Properties["OEMStringArray"].Value,
                    PartOfDomain = (bool) managementObject.Properties["PartOfDomain"].Value,
                    PauseAfterReset = (long) managementObject.Properties["PauseAfterReset"].Value,
                    PCSystemType = (ushort) managementObject.Properties["PCSystemType"].Value,
                    PCSystemTypeEx = (ushort) managementObject.Properties["PCSystemTypeEx"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    PowerOnPasswordStatus = (ushort) managementObject.Properties["PowerOnPasswordStatus"].Value,
                    PowerState = (ushort) managementObject.Properties["PowerState"].Value,
                    PowerSupplyState = (ushort) managementObject.Properties["PowerSupplyState"].Value,
                    PrimaryOwnerContact = (string) managementObject.Properties["PrimaryOwnerContact"].Value,
                    PrimaryOwnerName = (string) managementObject.Properties["PrimaryOwnerName"].Value,
                    ResetCapability = (ushort) managementObject.Properties["ResetCapability"].Value,
                    ResetCount = (short) managementObject.Properties["ResetCount"].Value,
                    ResetLimit = (short) managementObject.Properties["ResetLimit"].Value,
                    Roles = (string[]) managementObject.Properties["Roles"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    SupportContactDescription = (string[]) managementObject.Properties["SupportContactDescription"]
                        .Value,
                    SystemFamily = (string) managementObject.Properties["SystemFamily"].Value,
                    SystemSKUNumber = (string) managementObject.Properties["SystemSKUNumber"].Value,
                    SystemStartupDelay = (ushort) managementObject.Properties["SystemStartupDelay"].Value,
                    SystemStartupOptions = (string[]) managementObject.Properties["SystemStartupOptions"].Value,
                    SystemStartupSetting = (byte) managementObject.Properties["SystemStartupSetting"].Value,
                    SystemType = (string) managementObject.Properties["SystemType"].Value,
                    ThermalState = (ushort) managementObject.Properties["ThermalState"].Value,
                    TotalPhysicalMemory = (ulong) managementObject.Properties["TotalPhysicalMemory"].Value,
                    UserName = (string) managementObject.Properties["UserName"].Value,
                    WakeUpType = (ushort) managementObject.Properties["WakeUpType"].Value,
                    Workgroup = (string) managementObject.Properties["Workgroup"].Value
                });

            return list.ToArray();
        }
    }
}