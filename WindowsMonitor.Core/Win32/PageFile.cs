using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class PageFile
    {
		public uint AccessMask { get; private set; }
		public bool Archive { get; private set; }
		public string Caption { get; private set; }
		public bool Compressed { get; private set; }
		public string CompressionMethod { get; private set; }
		public string CreationClassName { get; private set; }
		public DateTime CreationDate { get; private set; }
		public string CSCreationClassName { get; private set; }
		public string CSName { get; private set; }
		public string Description { get; private set; }
		public string Drive { get; private set; }
		public string EightDotThreeFileName { get; private set; }
		public bool Encrypted { get; private set; }
		public string EncryptionMethod { get; private set; }
		public string Extension { get; private set; }
		public string FileName { get; private set; }
		public ulong FileSize { get; private set; }
		public string FileType { get; private set; }
		public uint FreeSpace { get; private set; }
		public string FSCreationClassName { get; private set; }
		public string FSName { get; private set; }
		public bool Hidden { get; private set; }
		public uint InitialSize { get; private set; }
		public DateTime InstallDate { get; private set; }
		public ulong InUseCount { get; private set; }
		public DateTime LastAccessed { get; private set; }
		public DateTime LastModified { get; private set; }
		public string Manufacturer { get; private set; }
		public uint MaximumSize { get; private set; }
		public string Name { get; private set; }
		public string Path { get; private set; }
		public bool Readable { get; private set; }
		public string Status { get; private set; }
		public bool System { get; private set; }
		public string Version { get; private set; }
		public bool Writeable { get; private set; }

        public static IEnumerable<PageFile> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PageFile> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PageFile> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PageFile");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PageFile
                {
                     AccessMask = (uint) (managementObject.Properties["AccessMask"]?.Value ?? default(uint)),
		 Archive = (bool) (managementObject.Properties["Archive"]?.Value ?? default(bool)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Compressed = (bool) (managementObject.Properties["Compressed"]?.Value ?? default(bool)),
		 CompressionMethod = (string) (managementObject.Properties["CompressionMethod"]?.Value ?? default(string)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 CreationDate = (DateTime) (managementObject.Properties["CreationDate"]?.Value ?? default(DateTime)),
		 CSCreationClassName = (string) (managementObject.Properties["CSCreationClassName"]?.Value ?? default(string)),
		 CSName = (string) (managementObject.Properties["CSName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Drive = (string) (managementObject.Properties["Drive"]?.Value ?? default(string)),
		 EightDotThreeFileName = (string) (managementObject.Properties["EightDotThreeFileName"]?.Value ?? default(string)),
		 Encrypted = (bool) (managementObject.Properties["Encrypted"]?.Value ?? default(bool)),
		 EncryptionMethod = (string) (managementObject.Properties["EncryptionMethod"]?.Value ?? default(string)),
		 Extension = (string) (managementObject.Properties["Extension"]?.Value ?? default(string)),
		 FileName = (string) (managementObject.Properties["FileName"]?.Value ?? default(string)),
		 FileSize = (ulong) (managementObject.Properties["FileSize"]?.Value ?? default(ulong)),
		 FileType = (string) (managementObject.Properties["FileType"]?.Value ?? default(string)),
		 FreeSpace = (uint) (managementObject.Properties["FreeSpace"]?.Value ?? default(uint)),
		 FSCreationClassName = (string) (managementObject.Properties["FSCreationClassName"]?.Value ?? default(string)),
		 FSName = (string) (managementObject.Properties["FSName"]?.Value ?? default(string)),
		 Hidden = (bool) (managementObject.Properties["Hidden"]?.Value ?? default(bool)),
		 InitialSize = (uint) (managementObject.Properties["InitialSize"]?.Value ?? default(uint)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 InUseCount = (ulong) (managementObject.Properties["InUseCount"]?.Value ?? default(ulong)),
		 LastAccessed = (DateTime) (managementObject.Properties["LastAccessed"]?.Value ?? default(DateTime)),
		 LastModified = (DateTime) (managementObject.Properties["LastModified"]?.Value ?? default(DateTime)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 MaximumSize = (uint) (managementObject.Properties["MaximumSize"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Path = (string) (managementObject.Properties["Path"]?.Value ?? default(string)),
		 Readable = (bool) (managementObject.Properties["Readable"]?.Value ?? default(bool)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 System = (bool) (managementObject.Properties["System"]?.Value ?? default(bool)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string)),
		 Writeable = (bool) (managementObject.Properties["Writeable"]?.Value ?? default(bool))
                };
        }
    }
}