using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class Directory
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
		public string FSCreationClassName { get; private set; }
		public string FSName { get; private set; }
		public bool Hidden { get; private set; }
		public DateTime InstallDate { get; private set; }
		public ulong InUseCount { get; private set; }
		public DateTime LastAccessed { get; private set; }
		public DateTime LastModified { get; private set; }
		public string Name { get; private set; }
		public string Path { get; private set; }
		public bool Readable { get; private set; }
		public string Status { get; private set; }
		public bool System { get; private set; }
		public bool Writeable { get; private set; }

        public static IEnumerable<Directory> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Directory> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Directory> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_Directory");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Directory
                {
                     AccessMask = (uint) (managementObject.Properties["AccessMask"]?.Value ?? default(uint)),
		 Archive = (bool) (managementObject.Properties["Archive"]?.Value ?? default(bool)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Compressed = (bool) (managementObject.Properties["Compressed"]?.Value ?? default(bool)),
		 CompressionMethod = (string) (managementObject.Properties["CompressionMethod"]?.Value),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value),
		 CreationDate = (DateTime) (managementObject.Properties["CreationDate"]?.Value ?? default(DateTime)),
		 CSCreationClassName = (string) (managementObject.Properties["CSCreationClassName"]?.Value),
		 CSName = (string) (managementObject.Properties["CSName"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Drive = (string) (managementObject.Properties["Drive"]?.Value),
		 EightDotThreeFileName = (string) (managementObject.Properties["EightDotThreeFileName"]?.Value),
		 Encrypted = (bool) (managementObject.Properties["Encrypted"]?.Value ?? default(bool)),
		 EncryptionMethod = (string) (managementObject.Properties["EncryptionMethod"]?.Value),
		 Extension = (string) (managementObject.Properties["Extension"]?.Value),
		 FileName = (string) (managementObject.Properties["FileName"]?.Value),
		 FileSize = (ulong) (managementObject.Properties["FileSize"]?.Value ?? default(ulong)),
		 FileType = (string) (managementObject.Properties["FileType"]?.Value),
		 FSCreationClassName = (string) (managementObject.Properties["FSCreationClassName"]?.Value),
		 FSName = (string) (managementObject.Properties["FSName"]?.Value),
		 Hidden = (bool) (managementObject.Properties["Hidden"]?.Value ?? default(bool)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 InUseCount = (ulong) (managementObject.Properties["InUseCount"]?.Value ?? default(ulong)),
		 LastAccessed = (DateTime) (managementObject.Properties["LastAccessed"]?.Value ?? default(DateTime)),
		 LastModified = (DateTime) (managementObject.Properties["LastModified"]?.Value ?? default(DateTime)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Path = (string) (managementObject.Properties["Path"]?.Value),
		 Readable = (bool) (managementObject.Properties["Readable"]?.Value ?? default(bool)),
		 Status = (string) (managementObject.Properties["Status"]?.Value),
		 System = (bool) (managementObject.Properties["System"]?.Value ?? default(bool)),
		 Writeable = (bool) (managementObject.Properties["Writeable"]?.Value ?? default(bool))
                };
        }
    }
}