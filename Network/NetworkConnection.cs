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
	public sealed class NetworkConnection
	{
		public UInt32 AccessMask { get; private set; }
public String Caption { get; private set; }
public String Comment { get; private set; }
public String ConnectionState { get; private set; }
public String ConnectionType { get; private set; }
public String Description { get; private set; }
public String DisplayType { get; private set; }
public DateTime InstallDate { get; private set; }
public String LocalName { get; private set; }
public String Name { get; private set; }
public Boolean Persistent { get; private set; }
public String ProviderName { get; private set; }
public String RemoteName { get; private set; }
public String RemotePath { get; private set; }
public String ResourceType { get; private set; }
public String Status { get; private set; }
public String UserName { get; private set; }
		
		public static NetworkConnection[] Retrieve(string remote, string username, string password)
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

		public static NetworkConnection[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static NetworkConnection[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_NetworkConnection");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<NetworkConnection>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new NetworkConnection
				{
					AccessMask = (UInt32) managementObject.Properties["AccessMask"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Comment = (String) managementObject.Properties["Comment"].Value,
ConnectionState = (String) managementObject.Properties["ConnectionState"].Value,
ConnectionType = (String) managementObject.Properties["ConnectionType"].Value,
Description = (String) managementObject.Properties["Description"].Value,
DisplayType = (String) managementObject.Properties["DisplayType"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
LocalName = (String) managementObject.Properties["LocalName"].Value,
Name = (String) managementObject.Properties["Name"].Value,
Persistent = (Boolean) managementObject.Properties["Persistent"].Value,
ProviderName = (String) managementObject.Properties["ProviderName"].Value,
RemoteName = (String) managementObject.Properties["RemoteName"].Value,
RemotePath = (String) managementObject.Properties["RemotePath"].Value,
ResourceType = (String) managementObject.Properties["ResourceType"].Value,
Status = (String) managementObject.Properties["Status"].Value,
UserName = (String) managementObject.Properties["UserName"].Value,
				});
            }

			return list.ToArray();
		}
	}
}