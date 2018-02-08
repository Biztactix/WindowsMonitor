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
	public sealed class MoveFileAction
	{
		public String ActionID { get; private set; }
public String Caption { get; private set; }
public String Description { get; private set; }
public String DestFolder { get; private set; }
public String DestName { get; private set; }
public UInt16 Direction { get; private set; }
public String FileKey { get; private set; }
public String Name { get; private set; }
public UInt16 Options { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public String SourceFolder { get; private set; }
public String SourceName { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
		
		public static MoveFileAction[] Retrieve(string remote, string username, string password)
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

		public static MoveFileAction[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static MoveFileAction[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_MoveFileAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<MoveFileAction>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new MoveFileAction
				{
					ActionID = (String) managementObject.Properties["ActionID"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
DestFolder = (String) managementObject.Properties["DestFolder"].Value,
DestName = (String) managementObject.Properties["DestName"].Value,
Direction = (UInt16) managementObject.Properties["Direction"].Value,
FileKey = (String) managementObject.Properties["FileKey"].Value,
Name = (String) managementObject.Properties["Name"].Value,
Options = (UInt16) managementObject.Properties["Options"].Value,
SoftwareElementID = (String) managementObject.Properties["SoftwareElementID"].Value,
SoftwareElementState = (UInt16) managementObject.Properties["SoftwareElementState"].Value,
SourceFolder = (String) managementObject.Properties["SourceFolder"].Value,
SourceName = (String) managementObject.Properties["SourceName"].Value,
TargetOperatingSystem = (UInt16) managementObject.Properties["TargetOperatingSystem"].Value,
Version = (String) managementObject.Properties["Version"].Value,
				});
            }

			return list.ToArray();
		}
	}
}