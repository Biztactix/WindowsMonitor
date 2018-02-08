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
	public sealed class ServiceSpecification
	{
		public String Caption { get; private set; }
public String CheckID { get; private set; }
public Boolean CheckMode { get; private set; }
public String Dependencies { get; private set; }
public String Description { get; private set; }
public String DisplayName { get; private set; }
public Int32 ErrorControl { get; private set; }
public String ID { get; private set; }
public String LoadOrderGroup { get; private set; }
public String Name { get; private set; }
public String Password { get; private set; }
public Int32 ServiceType { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public String StartName { get; private set; }
public Int32 StartType { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
		
		public static ServiceSpecification[] Retrieve(string remote, string username, string password)
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

		public static ServiceSpecification[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ServiceSpecification[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ServiceSpecification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ServiceSpecification>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ServiceSpecification
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
CheckID = (String) managementObject.Properties["CheckID"].Value,
CheckMode = (Boolean) managementObject.Properties["CheckMode"].Value,
Dependencies = (String) managementObject.Properties["Dependencies"].Value,
Description = (String) managementObject.Properties["Description"].Value,
DisplayName = (String) managementObject.Properties["DisplayName"].Value,
ErrorControl = (Int32) managementObject.Properties["ErrorControl"].Value,
ID = (String) managementObject.Properties["ID"].Value,
LoadOrderGroup = (String) managementObject.Properties["LoadOrderGroup"].Value,
Name = (String) managementObject.Properties["Name"].Value,
Password = (String) managementObject.Properties["Password"].Value,
ServiceType = (Int32) managementObject.Properties["ServiceType"].Value,
SoftwareElementID = (String) managementObject.Properties["SoftwareElementID"].Value,
SoftwareElementState = (UInt16) managementObject.Properties["SoftwareElementState"].Value,
StartName = (String) managementObject.Properties["StartName"].Value,
StartType = (Int32) managementObject.Properties["StartType"].Value,
TargetOperatingSystem = (UInt16) managementObject.Properties["TargetOperatingSystem"].Value,
Version = (String) managementObject.Properties["Version"].Value,
				});
            }

			return list.ToArray();
		}
	}
}