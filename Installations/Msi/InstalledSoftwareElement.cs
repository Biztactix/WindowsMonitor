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
	public sealed class InstalledSoftwareElement
	{
		public String Software { get; private set; }
public String System { get; private set; }
		
		public static InstalledSoftwareElement[] Retrieve(string remote, string username, string password)
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

		public static InstalledSoftwareElement[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static InstalledSoftwareElement[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_InstalledSoftwareElement");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<InstalledSoftwareElement>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new InstalledSoftwareElement
				{
					Software = (String) managementObject.Properties["Software"].Value,
System = (String) managementObject.Properties["System"].Value,
				});
            }

			return list.ToArray();
		}
	}
}