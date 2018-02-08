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
	public sealed class NTLogEventComputer
	{
		public String Computer { get; private set; }
public String Record { get; private set; }
		
		public static NTLogEventComputer[] Retrieve(string remote, string username, string password)
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

		public static NTLogEventComputer[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static NTLogEventComputer[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_NTLogEventComputer");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<NTLogEventComputer>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new NTLogEventComputer
				{
					Computer = (String) managementObject.Properties["Computer"].Value,
Record = (String) managementObject.Properties["Record"].Value,
				});
            }

			return list.ToArray();
		}
	}
}