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
	public sealed class SoftwareElement
	{
		public UInt16 Attributes { get; private set; }
public String BuildNumber { get; private set; }
public String Caption { get; private set; }
public String CodeSet { get; private set; }
public String Description { get; private set; }
public String IdentificationCode { get; private set; }
public DateTime InstallDate { get; private set; }
public Int16 InstallState { get; private set; }
public String LanguageEdition { get; private set; }
public String Manufacturer { get; private set; }
public String Name { get; private set; }
public String OtherTargetOS { get; private set; }
public String Path { get; private set; }
public String SerialNumber { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public String Status { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
		
		public static SoftwareElement[] Retrieve(string remote, string username, string password)
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

		public static SoftwareElement[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static SoftwareElement[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_SoftwareElement");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<SoftwareElement>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new SoftwareElement
				{
					Attributes = (UInt16) managementObject.Properties["Attributes"].Value,
BuildNumber = (String) managementObject.Properties["BuildNumber"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
CodeSet = (String) managementObject.Properties["CodeSet"].Value,
Description = (String) managementObject.Properties["Description"].Value,
IdentificationCode = (String) managementObject.Properties["IdentificationCode"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
InstallState = (Int16) managementObject.Properties["InstallState"].Value,
LanguageEdition = (String) managementObject.Properties["LanguageEdition"].Value,
Manufacturer = (String) managementObject.Properties["Manufacturer"].Value,
Name = (String) managementObject.Properties["Name"].Value,
OtherTargetOS = (String) managementObject.Properties["OtherTargetOS"].Value,
Path = (String) managementObject.Properties["Path"].Value,
SerialNumber = (String) managementObject.Properties["SerialNumber"].Value,
SoftwareElementID = (String) managementObject.Properties["SoftwareElementID"].Value,
SoftwareElementState = (UInt16) managementObject.Properties["SoftwareElementState"].Value,
Status = (String) managementObject.Properties["Status"].Value,
TargetOperatingSystem = (UInt16) managementObject.Properties["TargetOperatingSystem"].Value,
Version = (String) managementObject.Properties["Version"].Value,
				});
            }

			return list.ToArray();
		}
	}
}