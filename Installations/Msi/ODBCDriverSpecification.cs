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
	public sealed class ODBCDriverSpecification
	{
		public String Caption { get; private set; }
public String CheckID { get; private set; }
public Boolean CheckMode { get; private set; }
public String Description { get; private set; }
public String Driver { get; private set; }
public String File { get; private set; }
public String Name { get; private set; }
public String SetupFile { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
		
		public static ODBCDriverSpecification[] Retrieve(string remote, string username, string password)
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

		public static ODBCDriverSpecification[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ODBCDriverSpecification[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ODBCDriverSpecification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ODBCDriverSpecification>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ODBCDriverSpecification
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
CheckID = (String) managementObject.Properties["CheckID"].Value,
CheckMode = (Boolean) managementObject.Properties["CheckMode"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Driver = (String) managementObject.Properties["Driver"].Value,
File = (String) managementObject.Properties["File"].Value,
Name = (String) managementObject.Properties["Name"].Value,
SetupFile = (String) managementObject.Properties["SetupFile"].Value,
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