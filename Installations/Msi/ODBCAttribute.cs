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
	public sealed class ODBCAttribute
	{
		public String Attribute { get; private set; }
public String Caption { get; private set; }
public String Description { get; private set; }
public String Driver { get; private set; }
public String SettingID { get; private set; }
public String Value { get; private set; }
		
		public static ODBCAttribute[] Retrieve(string remote, string username, string password)
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

		public static ODBCAttribute[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ODBCAttribute[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ODBCAttribute");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ODBCAttribute>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ODBCAttribute
				{
					Attribute = (String) managementObject.Properties["Attribute"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Driver = (String) managementObject.Properties["Driver"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
Value = (String) managementObject.Properties["Value"].Value,
				});
            }

			return list.ToArray();
		}
	}
}