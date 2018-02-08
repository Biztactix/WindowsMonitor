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
	public sealed class SoftwareElementCheck
	{
		public String Check { get; private set; }
public String Element { get; private set; }
public UInt16 Phase { get; private set; }
		
		public static SoftwareElementCheck[] Retrieve(string remote, string username, string password)
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

		public static SoftwareElementCheck[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static SoftwareElementCheck[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_SoftwareElementCheck");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<SoftwareElementCheck>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new SoftwareElementCheck
				{
					Check = (String) managementObject.Properties["Check"].Value,
Element = (String) managementObject.Properties["Element"].Value,
Phase = (UInt16) managementObject.Properties["Phase"].Value,
				});
            }

			return list.ToArray();
		}
	}
}