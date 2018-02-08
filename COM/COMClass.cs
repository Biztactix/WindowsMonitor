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
	public sealed class COMClass
	{
		public String Caption { get; private set; }
public String Description { get; private set; }
public DateTime InstallDate { get; private set; }
public String Name { get; private set; }
public String Status { get; private set; }
		
		public static COMClass[] Retrieve(string remote, string username, string password)
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

		public static COMClass[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static COMClass[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_COMClass");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<COMClass>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new COMClass
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
Name = (String) managementObject.Properties["Name"].Value,
Status = (String) managementObject.Properties["Status"].Value,
				});
            }

			return list.ToArray();
		}
	}
}