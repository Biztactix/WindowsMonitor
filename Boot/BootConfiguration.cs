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
	public sealed class BootConfiguration
	{
		public String BootDirectory { get; private set; }
public String Caption { get; private set; }
public String ConfigurationPath { get; private set; }
public String Description { get; private set; }
public String LastDrive { get; private set; }
public String Name { get; private set; }
public String ScratchDirectory { get; private set; }
public String SettingID { get; private set; }
public String TempDirectory { get; private set; }
		
		public static BootConfiguration[] Retrieve(string remote, string username, string password)
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

		public static BootConfiguration[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static BootConfiguration[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_BootConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<BootConfiguration>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new BootConfiguration
				{
					BootDirectory = (String) managementObject.Properties["BootDirectory"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
ConfigurationPath = (String) managementObject.Properties["ConfigurationPath"].Value,
Description = (String) managementObject.Properties["Description"].Value,
LastDrive = (String) managementObject.Properties["LastDrive"].Value,
Name = (String) managementObject.Properties["Name"].Value,
ScratchDirectory = (String) managementObject.Properties["ScratchDirectory"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
TempDirectory = (String) managementObject.Properties["TempDirectory"].Value,
				});
            }

			return list.ToArray();
		}
	}
}