using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class OperatingSystem
    {
        public string BootDevice { get; private set; }
        public string BuildNumber { get; private set; }
        public string BuildType { get; private set; }
        public string Caption { get; private set; }
        public string CodeSet { get; private set; }
        public string CountryCode { get; private set; }
        public string CreationClassName { get; private set; }
        public string CSCreationClassName { get; private set; }
        public string CSDVersion { get; private set; }
        public string CSName { get; private set; }
        public short CurrentTimeZone { get; private set; }
        public bool DataExecutionPrevention_32BitApplications { get; private set; }
        public bool DataExecutionPrevention_Available { get; private set; }
        public bool DataExecutionPrevention_Drivers { get; private set; }
        public byte DataExecutionPrevention_SupportPolicy { get; private set; }
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
        public string[] MUILanguages { get; private set; }
        public string Name { get; private set; }
        public uint NumberOfLicensedUsers { get; private set; }
        public uint NumberOfProcesses { get; private set; }
        public uint NumberOfUsers { get; private set; }
        public uint OperatingSystemSKU { get; private set; }
        public string Organization { get; private set; }
        public string OSArchitecture { get; private set; }
        public uint OSLanguage { get; private set; }
        public uint OSProductSuite { get; private set; }
        public ushort OSType { get; private set; }
        public string OtherTypeDescription { get; private set; }
        public bool PAEEnabled { get; private set; }
        public string PlusProductID { get; private set; }
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

        public static OperatingSystem[] Retrieve(string remote, string username, string password)
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

        public static OperatingSystem[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static OperatingSystem[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<OperatingSystem>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new OperatingSystem
                {
                    BootDevice = (string) managementObject.Properties["BootDevice"].Value,
                    BuildNumber = (string) managementObject.Properties["BuildNumber"].Value,
                    BuildType = (string) managementObject.Properties["BuildType"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CodeSet = (string) managementObject.Properties["CodeSet"].Value,
                    CountryCode = (string) managementObject.Properties["CountryCode"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CSCreationClassName = (string) managementObject.Properties["CSCreationClassName"].Value,
                    CSDVersion = (string) managementObject.Properties["CSDVersion"].Value,
                    CSName = (string) managementObject.Properties["CSName"].Value,
                    CurrentTimeZone = (short) managementObject.Properties["CurrentTimeZone"].Value,
                    DataExecutionPrevention_32BitApplications = (bool) managementObject
                        .Properties["DataExecutionPrevention_32BitApplications"].Value,
                    DataExecutionPrevention_Available =
                        (bool) managementObject.Properties["DataExecutionPrevention_Available"].Value,
                    DataExecutionPrevention_Drivers =
                        (bool) managementObject.Properties["DataExecutionPrevention_Drivers"].Value,
                    DataExecutionPrevention_SupportPolicy = (byte) managementObject
                        .Properties["DataExecutionPrevention_SupportPolicy"].Value,
                    Debug = (bool) managementObject.Properties["Debug"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Distributed = (bool) managementObject.Properties["Distributed"].Value,
                    EncryptionLevel = (uint) managementObject.Properties["EncryptionLevel"].Value,
                    ForegroundApplicationBoost = (byte) managementObject.Properties["ForegroundApplicationBoost"].Value,
                    FreePhysicalMemory = (ulong) managementObject.Properties["FreePhysicalMemory"].Value,
                    FreeSpaceInPagingFiles = (ulong) managementObject.Properties["FreeSpaceInPagingFiles"].Value,
                    FreeVirtualMemory = (ulong) managementObject.Properties["FreeVirtualMemory"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LargeSystemCache = (uint) managementObject.Properties["LargeSystemCache"].Value,
                    LastBootUpTime = (DateTime) managementObject.Properties["LastBootUpTime"].Value,
                    LocalDateTime = (DateTime) managementObject.Properties["LocalDateTime"].Value,
                    Locale = (string) managementObject.Properties["Locale"].Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    MaxNumberOfProcesses = (uint) managementObject.Properties["MaxNumberOfProcesses"].Value,
                    MaxProcessMemorySize = (ulong) managementObject.Properties["MaxProcessMemorySize"].Value,
                    MUILanguages = (string[]) managementObject.Properties["MUILanguages"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberOfLicensedUsers = (uint) managementObject.Properties["NumberOfLicensedUsers"].Value,
                    NumberOfProcesses = (uint) managementObject.Properties["NumberOfProcesses"].Value,
                    NumberOfUsers = (uint) managementObject.Properties["NumberOfUsers"].Value,
                    OperatingSystemSKU = (uint) managementObject.Properties["OperatingSystemSKU"].Value,
                    Organization = (string) managementObject.Properties["Organization"].Value,
                    OSArchitecture = (string) managementObject.Properties["OSArchitecture"].Value,
                    OSLanguage = (uint) managementObject.Properties["OSLanguage"].Value,
                    OSProductSuite = (uint) managementObject.Properties["OSProductSuite"].Value,
                    OSType = (ushort) managementObject.Properties["OSType"].Value,
                    OtherTypeDescription = (string) managementObject.Properties["OtherTypeDescription"].Value,
                    PAEEnabled = (bool) managementObject.Properties["PAEEnabled"].Value,
                    PlusProductID = (string) managementObject.Properties["PlusProductID"].Value,
                    PlusVersionNumber = (string) managementObject.Properties["PlusVersionNumber"].Value,
                    PortableOperatingSystem = (bool) managementObject.Properties["PortableOperatingSystem"].Value,
                    Primary = (bool) managementObject.Properties["Primary"].Value,
                    ProductType = (uint) managementObject.Properties["ProductType"].Value,
                    RegisteredUser = (string) managementObject.Properties["RegisteredUser"].Value,
                    SerialNumber = (string) managementObject.Properties["SerialNumber"].Value,
                    ServicePackMajorVersion = (ushort) managementObject.Properties["ServicePackMajorVersion"].Value,
                    ServicePackMinorVersion = (ushort) managementObject.Properties["ServicePackMinorVersion"].Value,
                    SizeStoredInPagingFiles = (ulong) managementObject.Properties["SizeStoredInPagingFiles"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    SuiteMask = (uint) managementObject.Properties["SuiteMask"].Value,
                    SystemDevice = (string) managementObject.Properties["SystemDevice"].Value,
                    SystemDirectory = (string) managementObject.Properties["SystemDirectory"].Value,
                    SystemDrive = (string) managementObject.Properties["SystemDrive"].Value,
                    TotalSwapSpaceSize = (ulong) managementObject.Properties["TotalSwapSpaceSize"].Value,
                    TotalVirtualMemorySize = (ulong) managementObject.Properties["TotalVirtualMemorySize"].Value,
                    TotalVisibleMemorySize = (ulong) managementObject.Properties["TotalVisibleMemorySize"].Value,
                    Version = (string) managementObject.Properties["Version"].Value,
                    WindowsDirectory = (string) managementObject.Properties["WindowsDirectory"].Value
                });

            return list.ToArray();
        }
    }
}