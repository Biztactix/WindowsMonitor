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
	public sealed class PNPAllocatedResource
	{
		public String Antecedent { get; private set; }
public String Dependent { get; private set; }
		
		public static PNPAllocatedResource[] Retrieve(string remote, string username, string password)
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

		public static PNPAllocatedResource[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static PNPAllocatedResource[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_PNPAllocatedResource");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<PNPAllocatedResource>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new PNPAllocatedResource
				{
					Antecedent = (String) managementObject.Properties["Antecedent"].Value,
Dependent = (String) managementObject.Properties["Dependent"].Value,
				});
            }

			return list.ToArray();
		}
	}
}