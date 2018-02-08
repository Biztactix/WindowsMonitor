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
	public sealed class NTEventlogFile
	{
		public UInt32 AccessMask { get; private set; }
public Boolean Archive { get; private set; }
public String Caption { get; private set; }
public Boolean Compressed { get; private set; }
public String CompressionMethod { get; private set; }
public String CreationClassName { get; private set; }
public DateTime CreationDate { get; private set; }
public String CSCreationClassName { get; private set; }
public String CSName { get; private set; }
public String Description { get; private set; }
public String Drive { get; private set; }
public String EightDotThreeFileName { get; private set; }
public Boolean Encrypted { get; private set; }
public String EncryptionMethod { get; private set; }
public String Extension { get; private set; }
public String FileName { get; private set; }
public UInt64 FileSize { get; private set; }
public String FileType { get; private set; }
public String FSCreationClassName { get; private set; }
public String FSName { get; private set; }
public Boolean Hidden { get; private set; }
public DateTime InstallDate { get; private set; }
public UInt64 InUseCount { get; private set; }
public DateTime LastAccessed { get; private set; }
public DateTime LastModified { get; private set; }
public String LogfileName { get; private set; }
public String Manufacturer { get; private set; }
public UInt32 MaxFileSize { get; private set; }
public String Name { get; private set; }
public UInt32 NumberOfRecords { get; private set; }
public UInt32 OverwriteOutDated { get; private set; }
public String OverWritePolicy { get; private set; }
public String Path { get; private set; }
public Boolean Readable { get; private set; }
public String[] Sources { get; private set; }
public String Status { get; private set; }
public Boolean System { get; private set; }
public String Version { get; private set; }
public Boolean Writeable { get; private set; }
		
		public static NTEventlogFile[] Retrieve(string remote, string username, string password)
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

		public static NTEventlogFile[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static NTEventlogFile[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_NTEventlogFile");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<NTEventlogFile>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new NTEventlogFile
				{
					AccessMask = (UInt32) managementObject.Properties["AccessMask"].Value,
Archive = (Boolean) managementObject.Properties["Archive"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Compressed = (Boolean) managementObject.Properties["Compressed"].Value,
CompressionMethod = (String) managementObject.Properties["CompressionMethod"].Value,
CreationClassName = (String) managementObject.Properties["CreationClassName"].Value,
CreationDate = (DateTime) managementObject.Properties["CreationDate"].Value,
CSCreationClassName = (String) managementObject.Properties["CSCreationClassName"].Value,
CSName = (String) managementObject.Properties["CSName"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Drive = (String) managementObject.Properties["Drive"].Value,
EightDotThreeFileName = (String) managementObject.Properties["EightDotThreeFileName"].Value,
Encrypted = (Boolean) managementObject.Properties["Encrypted"].Value,
EncryptionMethod = (String) managementObject.Properties["EncryptionMethod"].Value,
Extension = (String) managementObject.Properties["Extension"].Value,
FileName = (String) managementObject.Properties["FileName"].Value,
FileSize = (UInt64) managementObject.Properties["FileSize"].Value,
FileType = (String) managementObject.Properties["FileType"].Value,
FSCreationClassName = (String) managementObject.Properties["FSCreationClassName"].Value,
FSName = (String) managementObject.Properties["FSName"].Value,
Hidden = (Boolean) managementObject.Properties["Hidden"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
InUseCount = (UInt64) managementObject.Properties["InUseCount"].Value,
LastAccessed = (DateTime) managementObject.Properties["LastAccessed"].Value,
LastModified = (DateTime) managementObject.Properties["LastModified"].Value,
LogfileName = (String) managementObject.Properties["LogfileName"].Value,
Manufacturer = (String) managementObject.Properties["Manufacturer"].Value,
MaxFileSize = (UInt32) managementObject.Properties["MaxFileSize"].Value,
Name = (String) managementObject.Properties["Name"].Value,
NumberOfRecords = (UInt32) managementObject.Properties["NumberOfRecords"].Value,
OverwriteOutDated = (UInt32) managementObject.Properties["OverwriteOutDated"].Value,
OverWritePolicy = (String) managementObject.Properties["OverWritePolicy"].Value,
Path = (String) managementObject.Properties["Path"].Value,
Readable = (Boolean) managementObject.Properties["Readable"].Value,
Sources = (String[]) managementObject.Properties["Sources"].Value,
Status = (String) managementObject.Properties["Status"].Value,
System = (Boolean) managementObject.Properties["System"].Value,
Version = (String) managementObject.Properties["Version"].Value,
Writeable = (Boolean) managementObject.Properties["Writeable"].Value,
				});
            }

			return list.ToArray();
		}
	}
}