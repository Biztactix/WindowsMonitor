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
	public sealed class ClassInfoAction
	{
		public String ActionID { get; private set; }
public String AppID { get; private set; }
public String Argument { get; private set; }
public String Caption { get; private set; }
public String CLSID { get; private set; }
public String Context { get; private set; }
public String DefInprocHandler { get; private set; }
public String Description { get; private set; }
public UInt16 Direction { get; private set; }
public String FileTypeMask { get; private set; }
public UInt16 Insertable { get; private set; }
public String Name { get; private set; }
public String ProgID { get; private set; }
public String RemoteName { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
public String VIProgID { get; private set; }
		
		public static ClassInfoAction[] Retrieve(string remote, string username, string password)
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

		public static ClassInfoAction[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ClassInfoAction[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ClassInfoAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ClassInfoAction>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ClassInfoAction
				{
					ActionID = (String) managementObject.Properties["ActionID"].Value,
AppID = (String) managementObject.Properties["AppID"].Value,
Argument = (String) managementObject.Properties["Argument"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
CLSID = (String) managementObject.Properties["CLSID"].Value,
Context = (String) managementObject.Properties["Context"].Value,
DefInprocHandler = (String) managementObject.Properties["DefInprocHandler"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Direction = (UInt16) managementObject.Properties["Direction"].Value,
FileTypeMask = (String) managementObject.Properties["FileTypeMask"].Value,
Insertable = (UInt16) managementObject.Properties["Insertable"].Value,
Name = (String) managementObject.Properties["Name"].Value,
ProgID = (String) managementObject.Properties["ProgID"].Value,
RemoteName = (String) managementObject.Properties["RemoteName"].Value,
SoftwareElementID = (String) managementObject.Properties["SoftwareElementID"].Value,
SoftwareElementState = (UInt16) managementObject.Properties["SoftwareElementState"].Value,
TargetOperatingSystem = (UInt16) managementObject.Properties["TargetOperatingSystem"].Value,
Version = (String) managementObject.Properties["Version"].Value,
VIProgID = (String) managementObject.Properties["VIProgID"].Value,
				});
            }

			return list.ToArray();
		}
	}
}