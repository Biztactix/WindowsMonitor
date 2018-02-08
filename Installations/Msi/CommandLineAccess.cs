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
	public sealed class CommandLineAccess
	{
		public String Caption { get; private set; }
public String CommandLine { get; private set; }
public String CreationClassName { get; private set; }
public String Description { get; private set; }
public DateTime InstallDate { get; private set; }
public String Name { get; private set; }
public String Status { get; private set; }
public String SystemCreationClassName { get; private set; }
public String SystemName { get; private set; }
public UInt32 Type { get; private set; }
		
		public static CommandLineAccess[] Retrieve(string remote, string username, string password)
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

		public static CommandLineAccess[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static CommandLineAccess[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_CommandLineAccess");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<CommandLineAccess>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new CommandLineAccess
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
CommandLine = (String) managementObject.Properties["CommandLine"].Value,
CreationClassName = (String) managementObject.Properties["CreationClassName"].Value,
Description = (String) managementObject.Properties["Description"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
Name = (String) managementObject.Properties["Name"].Value,
Status = (String) managementObject.Properties["Status"].Value,
SystemCreationClassName = (String) managementObject.Properties["SystemCreationClassName"].Value,
SystemName = (String) managementObject.Properties["SystemName"].Value,
Type = (UInt32) managementObject.Properties["Type"].Value,
				});
            }

			return list.ToArray();
		}
	}
}