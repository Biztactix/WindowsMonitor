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
	public sealed class ODBCSourceAttribute
	{
		public String Attribute { get; private set; }
public String Caption { get; private set; }
public String DataSource { get; private set; }
public String Description { get; private set; }
public String SettingID { get; private set; }
public String Value { get; private set; }
		
		public static ODBCSourceAttribute[] Retrieve(string remote, string username, string password)
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

		public static ODBCSourceAttribute[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ODBCSourceAttribute[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ODBCSourceAttribute");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ODBCSourceAttribute>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ODBCSourceAttribute
				{
					Attribute = (String) managementObject.Properties["Attribute"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
DataSource = (String) managementObject.Properties["DataSource"].Value,
Description = (String) managementObject.Properties["Description"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
Value = (String) managementObject.Properties["Value"].Value,
				});
            }

			return list.ToArray();
		}
	}
}