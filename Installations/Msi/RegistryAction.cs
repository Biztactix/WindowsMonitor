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
	public sealed class RegistryAction
	{
		public String ActionID { get; private set; }
public String Caption { get; private set; }
public String Description { get; private set; }
public UInt16 Direction { get; private set; }
public String EntryName { get; private set; }
public String EntryValue { get; private set; }
public String key { get; private set; }
public String Name { get; private set; }
public String Registry { get; private set; }
public Int16 Root { get; private set; }
public String SoftwareElementID { get; private set; }
public UInt16 SoftwareElementState { get; private set; }
public UInt16 TargetOperatingSystem { get; private set; }
public String Version { get; private set; }
		
		public static RegistryAction[] Retrieve(string remote, string username, string password)
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

		public static RegistryAction[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static RegistryAction[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_RegistryAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<RegistryAction>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new RegistryAction
				{
					ActionID = (String) managementObject.Properties["ActionID"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Direction = (UInt16) managementObject.Properties["Direction"].Value,
EntryName = (String) managementObject.Properties["EntryName"].Value,
EntryValue = (String) managementObject.Properties["EntryValue"].Value,
key = (String) managementObject.Properties["key"].Value,
Name = (String) managementObject.Properties["Name"].Value,
Registry = (String) managementObject.Properties["Registry"].Value,
Root = (Int16) managementObject.Properties["Root"].Value,
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