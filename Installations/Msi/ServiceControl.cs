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
	public sealed class ServiceControl
	{
		public String Arguments { get; private set; }
public String Caption { get; private set; }
public String Description { get; private set; }
public String Event { get; private set; }
public String ID { get; private set; }
public String Name { get; private set; }
public String ProductCode { get; private set; }
public String SettingID { get; private set; }
public UInt16 Wait { get; private set; }
		
		public static ServiceControl[] Retrieve(string remote, string username, string password)
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

		public static ServiceControl[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ServiceControl[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ServiceControl");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ServiceControl>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ServiceControl
				{
					Arguments = (String) managementObject.Properties["Arguments"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Event = (String) managementObject.Properties["Event"].Value,
ID = (String) managementObject.Properties["ID"].Value,
Name = (String) managementObject.Properties["Name"].Value,
ProductCode = (String) managementObject.Properties["ProductCode"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
Wait = (UInt16) managementObject.Properties["Wait"].Value,
				});
            }

			return list.ToArray();
		}
	}
}