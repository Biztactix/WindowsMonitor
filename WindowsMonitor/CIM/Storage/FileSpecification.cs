using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class FileSpecification
    {
		public string Caption { get; private set; }
		public string CheckId { get; private set; }
		public bool CheckMode { get; private set; }
		public uint CheckSum { get; private set; }
		public uint Crc1 { get; private set; }
		public uint Crc2 { get; private set; }
		public DateTime CreateTimeStamp { get; private set; }
		public string Description { get; private set; }
		public ulong FileSize { get; private set; }
		public string Md5Checksum { get; private set; }
		public string Name { get; private set; }
		public string SoftwareElementId { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<FileSpecification> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FileSpecification> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FileSpecification> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_FileSpecification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FileSpecification
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CheckId = (string) (managementObject.Properties["CheckID"]?.Value),
		 CheckMode = (bool) (managementObject.Properties["CheckMode"]?.Value ?? default(bool)),
		 CheckSum = (uint) (managementObject.Properties["CheckSum"]?.Value ?? default(uint)),
		 Crc1 = (uint) (managementObject.Properties["CRC1"]?.Value ?? default(uint)),
		 Crc2 = (uint) (managementObject.Properties["CRC2"]?.Value ?? default(uint)),
		 CreateTimeStamp = ManagementDateTimeConverter.ToDateTime (managementObject.Properties["CreateTimeStamp"]?.Value as string ?? "00010102000000.000000+060"),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 FileSize = (ulong) (managementObject.Properties["FileSize"]?.Value ?? default(ulong)),
		 Md5Checksum = (string) (managementObject.Properties["MD5Checksum"]?.Value),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 SoftwareElementId = (string) (managementObject.Properties["SoftwareElementID"]?.Value),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Version = (string) (managementObject.Properties["Version"]?.Value)
                };
        }
    }
}