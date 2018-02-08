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
	public sealed class ExtensionInfoAction
	{
		public String ActionID { get; private set; }
public String Argument { get; private set; }
public String Caption { get; private set; }
public String Command { get; private set; }
public String Description { get; private set; }
public UInt16 Direction { get; private set; }
public String Extension { get; private set; }
public String MIME { get; private set; }
public String Name { get; private set; }
public String ProgID { get; private set; }
public String ShellNew { get; private set; }
public String ShellNewValue { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Verb { get; private set; }
public String Version { get; private set; }
		
		public static ExtensionInfoAction[] Retrieve(string remote, string username, string password)
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

		public static ExtensionInfoAction[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ExtensionInfoAction[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ExtensionInfoAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ExtensionInfoAction>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ExtensionInfoAction
				{
					ActionID = (String) managementObject.Properties["ActionID"].Value,
Argument = (String) managementObject.Properties["Argument"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Command = (String) managementObject.Properties["Command"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Direction = (UInt16) managementObject.Properties["Direction"].Value,
Extension = (String) managementObject.Properties["Extension"].Value,
MIME = (String) managementObject.Properties["MIME"].Value,
Name = (String) managementObject.Properties["Name"].Value,
ProgID = (String) managementObject.Properties["ProgID"].Value,
ShellNew = (String) managementObject.Properties["ShellNew"].Value,
ShellNewValue = (String) managementObject.Properties["ShellNewValue"].Value,
SoftwareElementID = (String) managementObject.Properties["SoftwareElementID"].Value,
SoftwareElementState = (UInt16) managementObject.Properties["SoftwareElementState"].Value,
TargetOperatingSystem = (UInt16) managementObject.Properties["TargetOperatingSystem"].Value,
Verb = (String) managementObject.Properties["Verb"].Value,
Version = (String) managementObject.Properties["Version"].Value,
				});
            }

			return list.ToArray();
		}
	}
}