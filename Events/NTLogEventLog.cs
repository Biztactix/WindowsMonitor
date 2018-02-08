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
	public sealed class NTLogEventLog
	{
		public String Log { get; private set; }
public String Record { get; private set; }
		
		public static NTLogEventLog[] Retrieve(string remote, string username, string password)
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

		public static NTLogEventLog[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static NTLogEventLog[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_NTLogEventLog");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<NTLogEventLog>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new NTLogEventLog
				{
					Log = (String) managementObject.Properties["Log"].Value,
Record = (String) managementObject.Properties["Record"].Value,
				});
            }

			return list.ToArray();
		}
	}
}