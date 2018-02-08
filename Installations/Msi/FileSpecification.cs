using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
        /// <summary>
        /// 
        /// </summary>
	public sealed class FileSpecification
	{
		public UInt16 Attributes { get; private set; }
public String Caption { get; private set; }
public String CheckID { get; private set; }
public Boolean CheckMode { get; private set; }
public UInt32 CheckSum { get; private set; }
public UInt32 CRC1 { get; private set; }
public UInt32 CRC2 { get; private set; }
public DateTime CreateTimeStamp { get; private set; }
public String Description { get; private set; }
public String FileID { get; private set; }
public UInt64 FileSize { get; private set; }
public String Language { get; private set; }
public String MD5Checksum { get; private set; }
public String Name { get; private set; }
public UInt16 Sequence { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
		
		public static FileSpecification[] Retrieve(string remote, string username, string password)
		{
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"),options);
            managementScope.Connect();

			return Retrieve(managementScope);
		}

		public static FileSpecification[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static FileSpecification[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_FileSpecification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<FileSpecification>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new FileSpecification
				{
					Attributes = (UInt16) managementObject.Properties["Attributes"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
CheckID = (String) managementObject.Properties["CheckID"].Value,
CheckMode = (Boolean) managementObject.Properties["CheckMode"].Value,
CheckSum = (UInt32) managementObject.Properties["CheckSum"].Value,
CRC1 = (UInt32) managementObject.Properties["CRC1"].Value,
CRC2 = (UInt32) managementObject.Properties["CRC2"].Value,
CreateTimeStamp = (DateTime) managementObject.Properties["CreateTimeStamp"].Value,
Description = (String) managementObject.Properties["Description"].Value,
FileID = (String) managementObject.Properties["FileID"].Value,
FileSize = (UInt64) managementObject.Properties["FileSize"].Value,
Language = (String) managementObject.Properties["Language"].Value,
MD5Checksum = (String) managementObject.Properties["MD5Checksum"].Value,
Name = (String) managementObject.Properties["Name"].Value,
Sequence = (UInt16) managementObject.Properties["Sequence"].Value,
SoftwareElementID = (String) managementObject.Properties["SoftwareElementID"].Value,
SoftwareElementState = (UInt16) managementObject.Properties["SoftwareElementState"].Value,
TargetOperatingSystem = (UInt16) managementObject.Properties["TargetOperatingSystem"].Value,
Version = (String) managementObject.Properties["Version"].Value,
				});
            }

			return list.ToArray();
		}
	}
}