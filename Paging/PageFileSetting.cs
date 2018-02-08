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
	public sealed class PageFileSetting
	{
		public String Caption { get; private set; }
public String Description { get; private set; }
public UInt32 InitialSize { get; private set; }
public UInt32 MaximumSize { get; private set; }
public String Name { get; private set; }
public String SettingID { get; private set; }
		
		public static PageFileSetting[] Retrieve(string remote, string username, string password)
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

		public static PageFileSetting[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static PageFileSetting[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_PageFileSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<PageFileSetting>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new PageFileSetting
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
InitialSize = (UInt32) managementObject.Properties["InitialSize"].Value,
MaximumSize = (UInt32) managementObject.Properties["MaximumSize"].Value,
Name = (String) managementObject.Properties["Name"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
				});
            }

			return list.ToArray();
		}
	}
}