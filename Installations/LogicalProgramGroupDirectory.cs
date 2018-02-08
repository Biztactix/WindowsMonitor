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
	public sealed class LogicalProgramGroupDirectory
	{
		public String Antecedent { get; private set; }
public String Dependent { get; private set; }
		
		public static LogicalProgramGroupDirectory[] Retrieve(string remote, string username, string password)
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

		public static LogicalProgramGroupDirectory[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static LogicalProgramGroupDirectory[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_LogicalProgramGroupDirectory");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<LogicalProgramGroupDirectory>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new LogicalProgramGroupDirectory
				{
					Antecedent = (String) managementObject.Properties["Antecedent"].Value,
Dependent = (String) managementObject.Properties["Dependent"].Value,
				});
            }

			return list.ToArray();
		}
	}
}