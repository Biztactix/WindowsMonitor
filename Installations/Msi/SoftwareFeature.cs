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
	public sealed class SoftwareFeature
	{
		public UInt16 Accesses { get; private set; }
public UInt16 Attributes { get; private set; }
public String Caption { get; private set; }
public String Description { get; private set; }
public String IdentifyingNumber { get; private set; }
public DateTime InstallDate { get; private set; }
public Int16 InstallState { get; private set; }
public DateTime LastUse { get; private set; }
public String Name { get; private set; }
public String ProductName { get; private set; }
public String Status { get; private set; }
public String Vendor { get; private set; }
public String Version { get; private set; }
		
		public static SoftwareFeature[] Retrieve(string remote, string username, string password)
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

		public static SoftwareFeature[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static SoftwareFeature[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_SoftwareFeature");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<SoftwareFeature>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new SoftwareFeature
				{
					Accesses = (UInt16) managementObject.Properties["Accesses"].Value,
Attributes = (UInt16) managementObject.Properties["Attributes"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
IdentifyingNumber = (String) managementObject.Properties["IdentifyingNumber"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
InstallState = (Int16) managementObject.Properties["InstallState"].Value,
LastUse = (DateTime) managementObject.Properties["LastUse"].Value,
Name = (String) managementObject.Properties["Name"].Value,
ProductName = (String) managementObject.Properties["ProductName"].Value,
Status = (String) managementObject.Properties["Status"].Value,
Vendor = (String) managementObject.Properties["Vendor"].Value,
Version = (String) managementObject.Properties["Version"].Value,
				});
            }

			return list.ToArray();
		}
	}
}