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
	public sealed class IP4PersistedRouteTable
	{
		public String Caption { get; private set; }
public String Description { get; private set; }
public String Destination { get; private set; }
public DateTime InstallDate { get; private set; }
public String Mask { get; private set; }
public Int32 Metric1 { get; private set; }
public String Name { get; private set; }
public String NextHop { get; private set; }
public String Status { get; private set; }
		
		public static IP4PersistedRouteTable[] Retrieve(string remote, string username, string password)
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

		public static IP4PersistedRouteTable[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static IP4PersistedRouteTable[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_IP4PersistedRouteTable");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<IP4PersistedRouteTable>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new IP4PersistedRouteTable
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Destination = (String) managementObject.Properties["Destination"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
Mask = (String) managementObject.Properties["Mask"].Value,
Metric1 = (Int32) managementObject.Properties["Metric1"].Value,
Name = (String) managementObject.Properties["Name"].Value,
NextHop = (String) managementObject.Properties["NextHop"].Value,
Status = (String) managementObject.Properties["Status"].Value,
				});
            }

			return list.ToArray();
		}
	}
}