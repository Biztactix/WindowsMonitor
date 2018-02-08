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
	public sealed class DirectorySpecification
	{
		public String Caption { get; private set; }
public String CheckID { get; private set; }
public Boolean CheckMode { get; private set; }
public String DefaultDir { get; private set; }
public String Description { get; private set; }
public String Directory { get; private set; }
public String DirectoryPath { get; private set; }
public UInt16 DirectoryType { get; private set; }
public String Name { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
		
		public static DirectorySpecification[] Retrieve(string remote, string username, string password)
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

		public static DirectorySpecification[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static DirectorySpecification[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_DirectorySpecification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<DirectorySpecification>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new DirectorySpecification
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
CheckID = (String) managementObject.Properties["CheckID"].Value,
CheckMode = (Boolean) managementObject.Properties["CheckMode"].Value,
DefaultDir = (String) managementObject.Properties["DefaultDir"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Directory = (String) managementObject.Properties["Directory"].Value,
DirectoryPath = (String) managementObject.Properties["DirectoryPath"].Value,
DirectoryType = (UInt16) managementObject.Properties["DirectoryType"].Value,
Name = (String) managementObject.Properties["Name"].Value,
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