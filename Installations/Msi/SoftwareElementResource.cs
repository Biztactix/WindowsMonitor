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
	public sealed class SoftwareElementResource
	{
		public String Element { get; private set; }
public String Setting { get; private set; }
		
		public static SoftwareElementResource[] Retrieve(string remote, string username, string password)
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

		public static SoftwareElementResource[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static SoftwareElementResource[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_SoftwareElementResource");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<SoftwareElementResource>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new SoftwareElementResource
				{
					Element = (String) managementObject.Properties["Element"].Value,
Setting = (String) managementObject.Properties["Setting"].Value,
				});
            }

			return list.ToArray();
		}
	}
}