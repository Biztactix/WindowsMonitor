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
	public sealed class PnPDevicePropertySint16Array
	{
		public Int16[] Data { get; private set; }
public String DeviceID { get; private set; }
public String key { get; private set; }
public String KeyName { get; private set; }
public UInt32 Type { get; private set; }
		
		public static PnPDevicePropertySint16Array[] Retrieve(string remote, string username, string password)
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

		public static PnPDevicePropertySint16Array[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static PnPDevicePropertySint16Array[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPDevicePropertySint16Array");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<PnPDevicePropertySint16Array>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new PnPDevicePropertySint16Array
				{
					Data = (Int16[]) managementObject.Properties["Data"].Value,
DeviceID = (String) managementObject.Properties["DeviceID"].Value,
key = (String) managementObject.Properties["key"].Value,
KeyName = (String) managementObject.Properties["KeyName"].Value,
Type = (UInt32) managementObject.Properties["Type"].Value,
				});
            }

			return list.ToArray();
		}
	}
}