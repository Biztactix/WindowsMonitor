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
	public sealed class SelfRegModuleAction
	{
		public String ActionID { get; private set; }
public String Caption { get; private set; }
public UInt16 Cost { get; private set; }
public String Description { get; private set; }
public UInt16 Direction { get; private set; }
public String File { get; private set; }
public String Name { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
		
		public static SelfRegModuleAction[] Retrieve(string remote, string username, string password)
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

		public static SelfRegModuleAction[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static SelfRegModuleAction[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_SelfRegModuleAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<SelfRegModuleAction>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new SelfRegModuleAction
				{
					ActionID = (String) managementObject.Properties["ActionID"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Cost = (UInt16) managementObject.Properties["Cost"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Direction = (UInt16) managementObject.Properties["Direction"].Value,
File = (String) managementObject.Properties["File"].Value,
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