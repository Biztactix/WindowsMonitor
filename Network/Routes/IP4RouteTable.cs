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
	public sealed class IP4RouteTable
	{
		public UInt32 Age { get; private set; }
public String Caption { get; private set; }
public String Description { get; private set; }
public String Destination { get; private set; }
public String Information { get; private set; }
public DateTime InstallDate { get; private set; }
public Int32 InterfaceIndex { get; private set; }
public String Mask { get; private set; }
public Int32 Metric1 { get; private set; }
public Int32 Metric2 { get; private set; }
public Int32 Metric3 { get; private set; }
public Int32 Metric4 { get; private set; }
public Int32 Metric5 { get; private set; }
public String Name { get; private set; }
public String NextHop { get; private set; }
public UInt32 Protocol { get; private set; }
public String Status { get; private set; }
public UInt32 Type { get; private set; }
		
		public static IP4RouteTable[] Retrieve(string remote, string username, string password)
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

		public static IP4RouteTable[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static IP4RouteTable[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_IP4RouteTable");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<IP4RouteTable>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new IP4RouteTable
				{
					Age = (UInt32) managementObject.Properties["Age"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Destination = (String) managementObject.Properties["Destination"].Value,
Information = (String) managementObject.Properties["Information"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
InterfaceIndex = (Int32) managementObject.Properties["InterfaceIndex"].Value,
Mask = (String) managementObject.Properties["Mask"].Value,
Metric1 = (Int32) managementObject.Properties["Metric1"].Value,
Metric2 = (Int32) managementObject.Properties["Metric2"].Value,
Metric3 = (Int32) managementObject.Properties["Metric3"].Value,
Metric4 = (Int32) managementObject.Properties["Metric4"].Value,
Metric5 = (Int32) managementObject.Properties["Metric5"].Value,
Name = (String) managementObject.Properties["Name"].Value,
NextHop = (String) managementObject.Properties["NextHop"].Value,
Protocol = (UInt32) managementObject.Properties["Protocol"].Value,
Status = (String) managementObject.Properties["Status"].Value,
Type = (UInt32) managementObject.Properties["Type"].Value,
				});
            }

			return list.ToArray();
		}
	}
}