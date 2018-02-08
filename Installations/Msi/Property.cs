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
	public sealed class Property
	{
		public String Caption { get; private set; }
public String Description { get; private set; }
public String ProductCode { get; private set; }
public String PropertyName { get; private set; }
public String SettingID { get; private set; }
public String Value { get; private set; }
		
		public static Property[] Retrieve(string remote, string username, string password)
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

		public static Property[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static Property[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_Property");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<Property>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new Property
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
ProductCode = (String) managementObject.Properties["ProductCode"].Value,
PropertyName = (String) managementObject.Properties["Property"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
Value = (String) managementObject.Properties["Value"].Value,
				});
            }

			return list.ToArray();
		}
	}
}