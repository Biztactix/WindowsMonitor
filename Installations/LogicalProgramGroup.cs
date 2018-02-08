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
	public sealed class LogicalProgramGroup
	{
		public String Caption { get; private set; }
public String Description { get; private set; }
public String GroupName { get; private set; }
public DateTime InstallDate { get; private set; }
public String Name { get; private set; }
public String Status { get; private set; }
public String UserName { get; private set; }
		
		public static LogicalProgramGroup[] Retrieve(string remote, string username, string password)
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

		public static LogicalProgramGroup[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static LogicalProgramGroup[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_LogicalProgramGroup");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<LogicalProgramGroup>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new LogicalProgramGroup
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
GroupName = (String) managementObject.Properties["GroupName"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
Name = (String) managementObject.Properties["Name"].Value,
Status = (String) managementObject.Properties["Status"].Value,
UserName = (String) managementObject.Properties["UserName"].Value,
				});
            }

			return list.ToArray();
		}
	}
}