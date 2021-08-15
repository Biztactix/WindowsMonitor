using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Windows
{
    /// <summary>
    /// </summary>
    public sealed class Win32OperatingSystem
    {
        public string BootDevice { get; private set; }
        public string BuildNumber { get; private set; }
        public string BuildType { get; private set; }
        public string Caption { get; private set; }
        public string CodeSet { get; private set; }
        public string CountryCode { get; private set; }
        public string CreationClassName { get; private set; }
        public string CsCreationClassName { get; private set; }
        public string CsdVersion { get; private set; }
        public string CsName { get; private set; }
        public string CurrentTimeZone { get; private set; }
        public bool DataExecutionPrevention32BitApplications { get; private set; }
        public bool DataExecutionPreventionAvailable { get; private set; }
        public bool DataExecutionPreventionDrivers { get; private set; }
        public byte DataExecutionPreventionSupportPolicy { get; private set; }
        public bool Debug { get; private set; }
        public string Description { get; private set; }
        public bool Distributed { get; private set; }
        public uint EncryptionLevel { get; private set; }
        public byte ForegroundApplicationBoost { get; private set; }
        public ulong FreePhysicalMemory { get; private set; }
        public ulong FreeSpaceInPagingFiles { get; private set; }
        public ulong FreeVirtualMemory { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint LargeSystemCache { get; private set; }
        public DateTime LastBootUpTime { get; private set; }
        public DateTime LocalDateTime { get; private set; }
        public string Locale { get; private set; }
        public string Manufacturer { get; private set; }
        public uint MaxNumberOfProcesses { get; private set; }
        public ulong MaxProcessMemorySize { get; private set; }
        public string[] MuiLanguages { get; private set; }
        public string Name { get; private set; }
        public uint NumberOfLicensedUsers { get; private set; }
        public uint NumberOfProcesses { get; private set; }
        public uint NumberOfUsers { get; private set; }
        public uint OperatingSystemSku { get; private set; }
        public string Organization { get; private set; }
        public string OsArchitecture { get; private set; }
        public uint OsLanguage { get; private set; }
        public uint OsProductSuite { get; private set; }
        public ushort OsType { get; private set; }
        public string OtherTypeDescription { get; private set; }
        public bool PaeEnabled { get; private set; }
        public string PlusProductId { get; private set; }
        public string PlusVersionNumber { get; private set; }
        public bool PortableOperatingSystem { get; private set; }
        public bool Primary { get; private set; }
        public uint ProductType { get; private set; }
        public string RegisteredUser { get; private set; }
        public string SerialNumber { get; private set; }
        public ushort ServicePackMajorVersion { get; private set; }
        public ushort ServicePackMinorVersion { get; private set; }
        public ulong SizeStoredInPagingFiles { get; private set; }
        public string Status { get; private set; }
        public uint SuiteMask { get; private set; }
        public string SystemDevice { get; private set; }
        public string SystemDirectory { get; private set; }
        public string SystemDrive { get; private set; }
        public ulong TotalSwapSpaceSize { get; private set; }
        public ulong TotalVirtualMemorySize { get; private set; }
        public ulong TotalVisibleMemorySize { get; private set; }
        public string Version { get; private set; }
        public string WindowsDirectory { get; private set; }

        public static IEnumerable<Win32OperatingSystem> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Win32OperatingSystem> Retrieve()
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

        public static IEnumerable<Win32OperatingSystem> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Win32OperatingSystem
                {
                    BootDevice = ReturnDetail<string>("BootDevice", managementObject, ""),
                    BuildNumber = ReturnDetail<string>("BuildNumber", managementObject, ""),
                    BuildType = ReturnDetail<string>("BuildType", managementObject, ""),
                    Caption = ReturnDetail<string>("Caption", managementObject, ""),
                    CodeSet = ReturnDetail<string>("CodeSet", managementObject, ""),
                    CountryCode = ReturnDetail<string>("CountryCode", managementObject, ""),
                    CreationClassName = ReturnDetail<string>("CreationClassName", managementObject, ""),
                    CsCreationClassName = ReturnDetail<string>("CSCreationClassName", managementObject, ""),
                    CsdVersion = ReturnDetail<string>("CSDVersion", managementObject, ""),
                    CsName = ReturnDetail<string>("CSName", managementObject, ""),
                    CurrentTimeZone = ReturnDetail<string>("CurrentTimeZone", managementObject, ""),
                    DataExecutionPrevention32BitApplications = ReturnDetail<bool>("DataExecutionPrevention_32BitApplications", managementObject, default(bool)),
                    DataExecutionPreventionAvailable = ReturnDetail<bool>("DataExecutionPrevention_Available", managementObject, default(bool)),
                    DataExecutionPreventionDrivers = ReturnDetail<bool>("DataExecutionPrevention_Drivers", managementObject, default(bool)),
                    DataExecutionPreventionSupportPolicy = ReturnDetail<byte>("DataExecutionPrevention_SupportPolicy", managementObject, default(byte)),
                    Debug = ReturnDetail<bool>("Debug", managementObject, default(bool)),
                    Description = ReturnDetail<string>("Description", managementObject, ""),
                    Distributed = ReturnDetail<bool>("Distributed", managementObject, default(bool)),
                    EncryptionLevel = ReturnDetail<uint>("EncryptionLevel", managementObject, default(uint)),
                    ForegroundApplicationBoost = ReturnDetail<byte>("ForegroundApplicationBoost", managementObject, default(byte)),
                    FreePhysicalMemory = ReturnDetail<ulong>("FreePhysicalMemory", managementObject, default(ulong)),
                    FreeSpaceInPagingFiles = ReturnDetail<ulong>("FreeSpaceInPagingFiles", managementObject, default(ulong)),
                    FreeVirtualMemory = ReturnDetail<ulong>("FreeVirtualMemory", managementObject, default(ulong)),
                    InstallDate = ManagementDateTimeConverter.ToDateTime(ReturnDetail<string>("InstallDate", managementObject, "00010102000000.000000+060")),
                    LargeSystemCache = ReturnDetail<uint>("LargeSystemCache", managementObject, default(uint)),
                    LastBootUpTime = ManagementDateTimeConverter.ToDateTime(ReturnDetail<string>("LastBootUpTime", managementObject, "00010102000000.000000+060")),
                    LocalDateTime = ManagementDateTimeConverter.ToDateTime(ReturnDetail<string>("LocalDateTime", managementObject, "00010102000000.000000+060")),
                    Locale = ReturnDetail<string>("Locale", managementObject, ""),
                    Manufacturer = ReturnDetail<string>("Manufacturer", managementObject, ""),
                    MaxNumberOfProcesses = ReturnDetail<uint>("MaxNumberOfProcesses", managementObject, default(uint)),
                    MaxProcessMemorySize = ReturnDetail<ulong>("MaxProcessMemorySize", managementObject, default(ulong)),
                    MuiLanguages = ReturnDetail<string[]>("MUILanguages", managementObject, new string[0]),
                    Name = ReturnDetail<string>("Name", managementObject, ""),
                    NumberOfLicensedUsers = ReturnDetail<uint>("NumberOfLicensedUsers", managementObject, default(uint)),
                    NumberOfProcesses = ReturnDetail<uint>("NumberOfProcesses", managementObject, default(uint)),
                    NumberOfUsers = ReturnDetail<uint>("NumberOfUsers", managementObject, default(uint)),
                    OperatingSystemSku = ReturnDetail<uint>("OperatingSystemSKU", managementObject, default(uint)),
                    Organization = ReturnDetail<string>("Organization", managementObject, ""),
                    OsArchitecture = ReturnDetail<string>("OSArchitecture", managementObject, ""),
                    OsLanguage = ReturnDetail<uint>("OSLanguage", managementObject, default(uint)),
                    OsProductSuite = ReturnDetail<uint>("OSProductSuite", managementObject, default(uint)),
                    OsType = ReturnDetail<ushort>("OSType", managementObject, default(ushort)),
                    OtherTypeDescription = ReturnDetail<string>("OtherTypeDescription", managementObject, ""),
                    PaeEnabled = ReturnDetail<bool>("PAEEnabled", managementObject, default(bool)),
                    PlusProductId = ReturnDetail<string>("PlusProductID", managementObject, ""),
                    PlusVersionNumber = ReturnDetail<string>("PlusVersionNumber", managementObject, ""),
                    PortableOperatingSystem = ReturnDetail<bool>("PortableOperatingSystem", managementObject, default(bool)),
                    Primary = ReturnDetail<bool>("Primary", managementObject, default(bool)),
                    ProductType = ReturnDetail<uint>("ProductType", managementObject, default(uint)),
                    RegisteredUser = ReturnDetail<string>("RegisteredUser", managementObject, ""),
                    SerialNumber = ReturnDetail<string>("SerialNumber", managementObject, ""),
                    ServicePackMajorVersion = ReturnDetail<ushort>("ServicePackMajorVersion", managementObject, default(ushort)),
                    ServicePackMinorVersion = ReturnDetail<ushort>("ServicePackMinorVersion", managementObject, default(ushort)),
                    SizeStoredInPagingFiles = ReturnDetail<ulong>("SizeStoredInPagingFiles", managementObject, default(ulong)),
                    Status = ReturnDetail<string>("Status", managementObject, ""),
                    SuiteMask = ReturnDetail<uint>("SuiteMask", managementObject, default(uint)),
                    SystemDevice = ReturnDetail<string>("SystemDevice", managementObject, ""),
                    SystemDirectory = ReturnDetail<string>("SystemDirectory", managementObject, ""),
                    SystemDrive = ReturnDetail<string>("SystemDrive", managementObject, ""),
                    TotalSwapSpaceSize = ReturnDetail<ulong>("TotalSwapSpaceSize", managementObject, default(ulong)),
                    TotalVirtualMemorySize = ReturnDetail<ulong>("TotalVirtualMemorySize", managementObject, default(ulong)),
                    TotalVisibleMemorySize = ReturnDetail<ulong>("TotalVisibleMemorySize", managementObject, default(ulong)),
                    Version = ReturnDetail<string>("Version", managementObject, ""),
                    WindowsDirectory = ReturnDetail<string>("WindowsDirectory", managementObject, "")
                };
        }
    }
}
