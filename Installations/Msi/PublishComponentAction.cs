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
	public sealed class PublishComponentAction
	{
		public String ActionID { get; private set; }
public String AppData { get; private set; }
public String Caption { get; private set; }
public String ComponentID { get; private set; }
public String Description { get; private set; }
public UInt16 Direction { get; private set; }
public String Name { get; private set; }
public String Qual { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
		
		public static PublishComponentAction[] Retrieve(string remote, string username, string password)
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

		public static PublishComponentAction[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static PublishComponentAction[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_PublishComponentAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<PublishComponentAction>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new PublishComponentAction
				{
					ActionID = (String) managementObject.Properties["ActionID"].Value,
AppData = (String) managementObject.Properties["AppData"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
ComponentID = (String) managementObject.Properties["ComponentID"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Direction = (UInt16) managementObject.Properties["Direction"].Value,
Name = (String) managementObject.Properties["Name"].Value,
Qual = (String) managementObject.Properties["Qual"].Value,
SoftwareElementID = (String) managementObject.Properties["SoftwareElementID"].Value,
SoftwareElementState = (UInt16) managementObject.Properties["SoftwareElementState"].Value,
TargetOperatingSystem = (UInt16) managementObject.Properties["TargetOperatingSystem"].Value,
Version = (String) managementObject.Properties["Version"].Value,
				});
            }

			return list.ToArray();
		}
	}
}