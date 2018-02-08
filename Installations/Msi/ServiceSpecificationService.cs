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
	public sealed class ServiceSpecificationService
	{
		public String Check { get; private set; }
public String Element { get; private set; }
		
		public static ServiceSpecificationService[] Retrieve(string remote, string username, string password)
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

		public static ServiceSpecificationService[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ServiceSpecificationService[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ServiceSpecificationService");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ServiceSpecificationService>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ServiceSpecificationService
				{
					Check = (String) managementObject.Properties["Check"].Value,
Element = (String) managementObject.Properties["Element"].Value,
				});
            }

			return list.ToArray();
		}
	}
}