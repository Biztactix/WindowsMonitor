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
	public sealed class Binary
	{
		public String Caption { get; private set; }
public String Data { get; private set; }
public String Description { get; private set; }
public String Name { get; private set; }
public String ProductCode { get; private set; }
public String SettingID { get; private set; }
		
		public static Binary[] Retrieve(string remote, string username, string password)
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

		public static Binary[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static Binary[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_Binary");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<Binary>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new Binary
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
Data = (String) managementObject.Properties["Data"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Name = (String) managementObject.Properties["Name"].Value,
ProductCode = (String) managementObject.Properties["ProductCode"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
				});
            }

			return list.ToArray();
		}
	}
}