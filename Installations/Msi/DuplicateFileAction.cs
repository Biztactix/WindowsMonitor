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
	public sealed class DuplicateFileAction
	{
		public String ActionID { get; private set; }
public String Caption { get; private set; }
public Boolean DeleteAfterCopy { get; private set; }
public String Description { get; private set; }
public String Destination { get; private set; }
public UInt16 Direction { get; private set; }
public String FileKey { get; private set; }
public String Name { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public String Source { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
		
		public static DuplicateFileAction[] Retrieve(string remote, string username, string password)
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

		public static DuplicateFileAction[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static DuplicateFileAction[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_DuplicateFileAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<DuplicateFileAction>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new DuplicateFileAction
				{
					ActionID = (String) managementObject.Properties["ActionID"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
DeleteAfterCopy = (Boolean) managementObject.Properties["DeleteAfterCopy"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Destination = (String) managementObject.Properties["Destination"].Value,
Direction = (UInt16) managementObject.Properties["Direction"].Value,
FileKey = (String) managementObject.Properties["FileKey"].Value,
Name = (String) managementObject.Properties["Name"].Value,
SoftwareElementID = (String) managementObject.Properties["SoftwareElementID"].Value,
SoftwareElementState = (UInt16) managementObject.Properties["SoftwareElementState"].Value,
Source = (String) managementObject.Properties["Source"].Value,
TargetOperatingSystem = (UInt16) managementObject.Properties["TargetOperatingSystem"].Value,
Version = (String) managementObject.Properties["Version"].Value,
				});
            }

			return list.ToArray();
		}
	}
}