using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class OperatingSystem
    {
		public string Caption { get; private set; }
		public string CreationClassName { get; private set; }
		public string CSCreationClassName { get; private set; }
		public string CSName { get; private set; }
		public short CurrentTimeZone { get; private set; }
		public string Description { get; private set; }
		public bool Distributed { get; private set; }
		public ulong FreePhysicalMemory { get; private set; }
		public ulong FreeSpaceInPagingFiles { get; private set; }
		public ulong FreeVirtualMemory { get; private set; }
		public DateTime InstallDate { get; private set; }
		public DateTime LastBootUpTime { get; private set; }
		public DateTime LocalDateTime { get; private set; }
		public uint MaxNumberOfProcesses { get; private set; }
		public ulong MaxProcessMemorySize { get; private set; }
		public string Name { get; private set; }
		public uint NumberOfLicensedUsers { get; private set; }
		public uint NumberOfProcesses { get; private set; }
		public uint NumberOfUsers { get; private set; }
		public ushort OSType { get; private set; }
		public string OtherTypeDescription { get; private set; }
		public ulong SizeStoredInPagingFiles { get; private set; }
		public string Status { get; private set; }
		public ulong TotalSwapSpaceSize { get; private set; }
		public ulong TotalVirtualMemorySize { get; private set; }
		public ulong TotalVisibleMemorySize { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<OperatingSystem> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<OperatingSystem> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<OperatingSystem> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_OperatingSystem");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new OperatingSystem
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 CSCreationClassName = (string) (managementObject.Properties["CSCreationClassName"]?.Value ?? default(string)),
		 CSName = (string) (managementObject.Properties["CSName"]?.Value ?? default(string)),
		 CurrentTimeZone = (short) (managementObject.Properties["CurrentTimeZone"]?.Value ?? default(short)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Distributed = (bool) (managementObject.Properties["Distributed"]?.Value ?? default(bool)),
		 FreePhysicalMemory = (ulong) (managementObject.Properties["FreePhysicalMemory"]?.Value ?? default(ulong)),
		 FreeSpaceInPagingFiles = (ulong) (managementObject.Properties["FreeSpaceInPagingFiles"]?.Value ?? default(ulong)),
		 FreeVirtualMemory = (ulong) (managementObject.Properties["FreeVirtualMemory"]?.Value ?? default(ulong)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 LastBootUpTime = (DateTime) (managementObject.Properties["LastBootUpTime"]?.Value ?? default(DateTime)),
		 LocalDateTime = (DateTime) (managementObject.Properties["LocalDateTime"]?.Value ?? default(DateTime)),
		 MaxNumberOfProcesses = (uint) (managementObject.Properties["MaxNumberOfProcesses"]?.Value ?? default(uint)),
		 MaxProcessMemorySize = (ulong) (managementObject.Properties["MaxProcessMemorySize"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberOfLicensedUsers = (uint) (managementObject.Properties["NumberOfLicensedUsers"]?.Value ?? default(uint)),
		 NumberOfProcesses = (uint) (managementObject.Properties["NumberOfProcesses"]?.Value ?? default(uint)),
		 NumberOfUsers = (uint) (managementObject.Properties["NumberOfUsers"]?.Value ?? default(uint)),
		 OSType = (ushort) (managementObject.Properties["OSType"]?.Value ?? default(ushort)),
		 OtherTypeDescription = (string) (managementObject.Properties["OtherTypeDescription"]?.Value ?? default(string)),
		 SizeStoredInPagingFiles = (ulong) (managementObject.Properties["SizeStoredInPagingFiles"]?.Value ?? default(ulong)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 TotalSwapSpaceSize = (ulong) (managementObject.Properties["TotalSwapSpaceSize"]?.Value ?? default(ulong)),
		 TotalVirtualMemorySize = (ulong) (managementObject.Properties["TotalVirtualMemorySize"]?.Value ?? default(ulong)),
		 TotalVisibleMemorySize = (ulong) (managementObject.Properties["TotalVisibleMemorySize"]?.Value ?? default(ulong)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string))
                };
        }
    }
}