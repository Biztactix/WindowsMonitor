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
	public sealed class RemoveFileAction
	{
		public String ActionID { get; private set; }
public String Caption { get; private set; }
public String Description { get; private set; }
public UInt16 Direction { get; private set; }
public String DirProperty { get; private set; }
public String File { get; private set; }
public String FileKey { get; private set; }
public String FileName { get; private set; }
public UInt16 InstallMode { get; private set; }
public String Name { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
		
		public static RemoveFileAction[] Retrieve(string remote, string username, string password)
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

		public static RemoveFileAction[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static RemoveFileAction[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_RemoveFileAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<RemoveFileAction>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new RemoveFileAction
				{
					ActionID = (String) managementObject.Properties["ActionID"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Direction = (UInt16) managementObject.Properties["Direction"].Value,
DirProperty = (String) managementObject.Properties["DirProperty"].Value,
File = (String) managementObject.Properties["File"].Value,
FileKey = (String) managementObject.Properties["FileKey"].Value,
FileName = (String) managementObject.Properties["FileName"].Value,
InstallMode = (UInt16) managementObject.Properties["InstallMode"].Value,
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