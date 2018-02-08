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
	public sealed class DCOMApplicationSetting
	{
		public String AppID { get; private set; }
public UInt32 AuthenticationLevel { get; private set; }
public String Caption { get; private set; }
public String CustomSurrogate { get; private set; }
public String Description { get; private set; }
public Boolean EnableAtStorageActivation { get; private set; }
public String LocalService { get; private set; }
public String RemoteServerName { get; private set; }
public String RunAsUser { get; private set; }
public String ServiceParameters { get; private set; }
public String SettingID { get; private set; }
public Boolean UseSurrogate { get; private set; }
		
		public static DCOMApplicationSetting[] Retrieve(string remote, string username, string password)
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

		public static DCOMApplicationSetting[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static DCOMApplicationSetting[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_DCOMApplicationSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<DCOMApplicationSetting>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new DCOMApplicationSetting
				{
					AppID = (String) managementObject.Properties["AppID"].Value,
AuthenticationLevel = (UInt32) managementObject.Properties["AuthenticationLevel"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
CustomSurrogate = (String) managementObject.Properties["CustomSurrogate"].Value,
Description = (String) managementObject.Properties["Description"].Value,
EnableAtStorageActivation = (Boolean) managementObject.Properties["EnableAtStorageActivation"].Value,
LocalService = (String) managementObject.Properties["LocalService"].Value,
RemoteServerName = (String) managementObject.Properties["RemoteServerName"].Value,
RunAsUser = (String) managementObject.Properties["RunAsUser"].Value,
ServiceParameters = (String) managementObject.Properties["ServiceParameters"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
UseSurrogate = (Boolean) managementObject.Properties["UseSurrogate"].Value,
				});
            }

			return list.ToArray();
		}
	}
}