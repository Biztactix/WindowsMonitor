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
	public sealed class COMApplicationClasses
	{
		public String GroupComponent { get; private set; }
public String PartComponent { get; private set; }
		
		public static COMApplicationClasses[] Retrieve(string remote, string username, string password)
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

		public static COMApplicationClasses[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static COMApplicationClasses[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_COMApplicationClasses");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<COMApplicationClasses>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new COMApplicationClasses
				{
					GroupComponent = (String) managementObject.Properties["GroupComponent"].Value,
PartComponent = (String) managementObject.Properties["PartComponent"].Value,
				});
            }

			return list.ToArray();
		}
	}
}