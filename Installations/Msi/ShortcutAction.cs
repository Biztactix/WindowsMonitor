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
	public sealed class ShortcutAction
	{
		public String ActionID { get; private set; }
public String Arguments { get; private set; }
public String Caption { get; private set; }
public String Description { get; private set; }
public UInt16 Direction { get; private set; }
public UInt16 HotKey { get; private set; }
public String IconIndex { get; private set; }
public String Name { get; private set; }
public String Shortcut { get; private set; }
public UInt16 ShowCmd { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public String Target { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
public String WkDir { get; private set; }
		
		public static ShortcutAction[] Retrieve(string remote, string username, string password)
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

		public static ShortcutAction[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ShortcutAction[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ShortcutAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ShortcutAction>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ShortcutAction
				{
					ActionID = (String) managementObject.Properties["ActionID"].Value,
Arguments = (String) managementObject.Properties["Arguments"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Direction = (UInt16) managementObject.Properties["Direction"].Value,
HotKey = (UInt16) managementObject.Properties["HotKey"].Value,
IconIndex = (String) managementObject.Properties["IconIndex"].Value,
Name = (String) managementObject.Properties["Name"].Value,
Shortcut = (String) managementObject.Properties["Shortcut"].Value,
ShowCmd = (UInt16) managementObject.Properties["ShowCmd"].Value,
SoftwareElementID = (String) managementObject.Properties["SoftwareElementID"].Value,
SoftwareElementState = (UInt16) managementObject.Properties["SoftwareElementState"].Value,
Target = (String) managementObject.Properties["Target"].Value,
TargetOperatingSystem = (UInt16) managementObject.Properties["TargetOperatingSystem"].Value,
Version = (String) managementObject.Properties["Version"].Value,
WkDir = (String) managementObject.Properties["WkDir"].Value,
				});
            }

			return list.ToArray();
		}
	}
}