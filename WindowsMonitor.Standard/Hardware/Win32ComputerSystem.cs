using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Hardware.Network
{
    /// <summary>
    /// </summary>
    public sealed class Win32ComputerSystem
    {
        public ushort AdminPasswordStatus { get; private set; }
        public bool AutomaticManagedPagefile { get; private set; }
        public bool AutomaticResetBootOption { get; private set; }
        public bool AutomaticResetCapability { get; private set; }
        public ushort BootOptionOnLimit { get; private set; }
        public ushort BootOptionOnWatchDog { get; private set; }
        public bool BootRomSupported { get; private set; }
        public ushort[] BootStatus { get; private set; }
        public string BootupState { get; private set; }
        public string Caption { get; private set; }
        public ushort ChassisBootupState { get; private set; }
        public string ChassisSkuNumber { get; private set; }
        public string CreationClassName { get; private set; }
        public string CurrentTimeZone { get; private set; }
        public bool DaylightInEffect { get; private set; }
        public string Description { get; private set; }
        public string DnsHostName { get; private set; }
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
        public byte[] OemLogoBitmap { get; private set; }
        public string[] OemStringArray { get; private set; }
        public bool PartOfDomain { get; private set; }
        public long PauseAfterReset { get; private set; }
        public ushort PcSystemType { get; private set; }
        public ushort PcSystemTypeEx { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public ushort PowerOnPasswordStatus { get; private set; }
        public ushort PowerState { get; private set; }
        public ushort PowerSupplyState { get; private set; }
        public string PrimaryOwnerContact { get; private set; }
        public string PrimaryOwnerName { get; private set; }
        public ushort ResetCapability { get; private set; }
        public string ResetCount { get; private set; }
        public string ResetLimit { get; private set; }
        public string[] Roles { get; private set; }
        public string Status { get; private set; }
        public string[] SupportContactDescription { get; private set; }
        public string SystemFamily { get; private set; }
        public string SystemSkuNumber { get; private set; }
        public ushort SystemStartupDelay { get; private set; }
        public string[] SystemStartupOptions { get; private set; }
        public byte SystemStartupSetting { get; private set; }
        public string SystemType { get; private set; }
        public ushort ThermalState { get; private set; }
        public ulong TotalPhysicalMemory { get; private set; }
        public string UserName { get; private set; }
        public ushort WakeUpType { get; private set; }
        public string Workgroup { get; private set; }

        public static IEnumerable<Win32ComputerSystem> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Win32ComputerSystem> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static T ReturnDetail<T>(String Name, ManagementObject obj, T DefaultObj)
        {
            try
            {
                if (obj.Properties[Name] != null)
                {
                    if (obj.Properties[Name].Value != null)
                    {
                        return (T)(obj.Properties[Name].Value);
                    }
                    else
                    {
                        return DefaultObj;
                    }
                }
                else
                {
                    return DefaultObj;
                }
            }
            catch { return DefaultObj; }
        }

        public static IEnumerable<Win32ComputerSystem> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Win32ComputerSystem
                {
                    AdminPasswordStatus = ReturnDetail<ushort>("AdminPasswordStatus", managementObject, default(ushort)),
                    AutomaticManagedPagefile = ReturnDetail<bool>("AutomaticManagedPagefile", managementObject, default(bool)),
                    AutomaticResetBootOption = ReturnDetail<bool>("AutomaticResetBootOption", managementObject, default(bool)),
                    AutomaticResetCapability = ReturnDetail<bool>("AutomaticResetCapability", managementObject, default(bool)),
                    BootOptionOnLimit = ReturnDetail<ushort>("BootOptionOnLimit", managementObject, default(ushort)),
                    BootOptionOnWatchDog = ReturnDetail<ushort>("BootOptionOnWatchDog", managementObject, default(ushort)),
                    BootRomSupported = ReturnDetail<bool>("BootROMSupported", managementObject, default(bool)),
                    BootStatus = ReturnDetail<ushort[]>("BootStatus", managementObject, new ushort[0]),
                    BootupState = ReturnDetail<string>("BootupState", managementObject, ""),
                    Caption = ReturnDetail<string>("Caption", managementObject, ""),
                    ChassisBootupState = ReturnDetail<ushort>("ChassisBootupState", managementObject, default(ushort)),
                    ChassisSkuNumber = ReturnDetail<string>("ChassisSKUNumber", managementObject, ""),
                    CreationClassName = ReturnDetail<string>("CreationClassName", managementObject, ""),
                    CurrentTimeZone = ReturnDetail<string>("CurrentTimeZone", managementObject, ""),
                    DaylightInEffect = ReturnDetail<bool>("DaylightInEffect", managementObject, default(bool)),
                    Description = ReturnDetail<string>("Description", managementObject, ""),
                    DnsHostName = ReturnDetail<string>("DNSHostName", managementObject, ""),
                    Domain = ReturnDetail<string>("Domain", managementObject, ""),
                    DomainRole = ReturnDetail<ushort>("DomainRole", managementObject, default(ushort)),
                    EnableDaylightSavingsTime = ReturnDetail<bool>("EnableDaylightSavingsTime", managementObject, default(bool)),
                    FrontPanelResetStatus = ReturnDetail<ushort>("FrontPanelResetStatus", managementObject, default(ushort)),
                    HypervisorPresent = ReturnDetail<bool>("HypervisorPresent", managementObject, default(bool)),
                    InfraredSupported = ReturnDetail<bool>("InfraredSupported", managementObject, default(bool)),
                    InitialLoadInfo = ReturnDetail<string[]>("InitialLoadInfo", managementObject, new string[0]),
                    InstallDate = ManagementDateTimeConverter.ToDateTime(ReturnDetail<string>("InstallDate", managementObject, "00010102000000.000000+060")),
                    KeyboardPasswordStatus = ReturnDetail<ushort>("KeyboardPasswordStatus", managementObject, default(ushort)),
                    LastLoadInfo = ReturnDetail<string>("LastLoadInfo", managementObject, ""),
                    Manufacturer = ReturnDetail<string>("Manufacturer", managementObject, ""),
                    Model = ReturnDetail<string>("Model", managementObject, ""),
                    Name = ReturnDetail<string>("Name", managementObject, ""),
                    NameFormat = ReturnDetail<string>("NameFormat", managementObject, ""),
                    NetworkServerModeEnabled = ReturnDetail<bool>("NetworkServerModeEnabled", managementObject, default(bool)),
                    NumberOfLogicalProcessors = ReturnDetail<uint>("NumberOfLogicalProcessors", managementObject, default(uint)),
                    NumberOfProcessors = ReturnDetail<uint>("NumberOfProcessors", managementObject, default(uint)),
                    OemLogoBitmap = ReturnDetail<byte[]>("OEMLogoBitmap", managementObject, new byte[0]),
                    OemStringArray = ReturnDetail<string[]>("OEMStringArray", managementObject, new string[0]),
                    PartOfDomain = ReturnDetail<bool>("PartOfDomain", managementObject, default(bool)),
                    PauseAfterReset = ReturnDetail<long>("PauseAfterReset", managementObject, default(long)),
                    PcSystemType = ReturnDetail<ushort>("PCSystemType", managementObject, default(ushort)),
                    PcSystemTypeEx = ReturnDetail<ushort>("PCSystemTypeEx", managementObject, default(ushort)),
                    PowerManagementCapabilities = (ushort[])(managementObject.Properties["PowerManagementCapabilities"]?.Value ?? new ushort[0]),
                    PowerManagementSupported = ReturnDetail<bool>("PowerManagementSupported", managementObject, default(bool)),
                    PowerOnPasswordStatus = ReturnDetail<ushort>("PowerOnPasswordStatus", managementObject, default(ushort)),
                    PowerState = ReturnDetail<ushort>("PowerState", managementObject, default(ushort)),
                    PowerSupplyState = ReturnDetail<ushort>("PowerSupplyState", managementObject, default(ushort)),
                    PrimaryOwnerContact = ReturnDetail<string>("PrimaryOwnerContact", managementObject, ""),
                    PrimaryOwnerName = ReturnDetail<string>("PrimaryOwnerName", managementObject, ""),
                    ResetCapability = ReturnDetail<ushort>("ResetCapability", managementObject, default(ushort)),
                    ResetCount = ReturnDetail<string>("ResetCount", managementObject, ""),
                    ResetLimit = ReturnDetail<string>("ResetLimit", managementObject, ""),
                    Roles = ReturnDetail<string[]>("Roles", managementObject, new string[0]),
                    Status = ReturnDetail<string>("Status", managementObject, ""),
                    SupportContactDescription = ReturnDetail<string[]>("SupportContactDescription", managementObject, new string[0]),
                    SystemFamily = ReturnDetail<string>("SystemFamily", managementObject, ""),
                    SystemSkuNumber = ReturnDetail<string>("SystemSKUNumber", managementObject, ""),
                    SystemStartupDelay = ReturnDetail<ushort>("SystemStartupDelay", managementObject, default(ushort)),
                    SystemStartupOptions = ReturnDetail<string[]>("SystemStartupOptions", managementObject, new string[0]),
                    SystemStartupSetting = ReturnDetail<byte>("SystemStartupSetting", managementObject, default(byte)),
                    SystemType = ReturnDetail<string>("SystemType", managementObject, ""),
                    ThermalState = ReturnDetail<ushort>("ThermalState", managementObject, default(ushort)),
                    TotalPhysicalMemory = ReturnDetail<ulong>("TotalPhysicalMemory", managementObject, default(ulong)),
                    UserName = ReturnDetail<string>("UserName", managementObject, ""),
                    WakeUpType = ReturnDetail<ushort>("WakeUpType", managementObject, default(ushort)),
                    Workgroup = ReturnDetail<string>("Workgroup", managementObject, "")
                };
        }
    }
}