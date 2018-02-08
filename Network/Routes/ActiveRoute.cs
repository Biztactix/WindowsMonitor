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
	public sealed class ActiveRoute
	{
		public String SameElement { get; private set; }
public String SystemElement { get; private set; }
		
		public static ActiveRoute[] Retrieve(string remote, string username, string password)
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

		public static ActiveRoute[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ActiveRoute[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ActiveRoute");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ActiveRoute>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ActiveRoute
				{
					SameElement = (String) managementObject.Properties["SameElement"].Value,
SystemElement = (String) managementObject.Properties["SystemElement"].Value,
				});
            }

			return list.ToArray();
		}
	}
}