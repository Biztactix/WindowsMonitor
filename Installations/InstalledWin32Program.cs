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
	public sealed class InstalledWin32Program
	{
		public String Language { get; private set; }
public String MsiPackageCode { get; private set; }
public String MsiProductCode { get; private set; }
public String Name { get; private set; }
public String ProgramId { get; private set; }
public String Vendor { get; private set; }
public String Version { get; private set; }
		
		public static InstalledWin32Program[] Retrieve(string remote, string username, string password)
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

		public static InstalledWin32Program[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static InstalledWin32Program[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_InstalledWin32Program");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<InstalledWin32Program>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new InstalledWin32Program
				{
					Language = (String) managementObject.Properties["Language"].Value,
MsiPackageCode = (String) managementObject.Properties["MsiPackageCode"].Value,
MsiProductCode = (String) managementObject.Properties["MsiProductCode"].Value,
Name = (String) managementObject.Properties["Name"].Value,
ProgramId = (String) managementObject.Properties["ProgramId"].Value,
Vendor = (String) managementObject.Properties["Vendor"].Value,
Version = (String) managementObject.Properties["Version"].Value,
				});
            }

			return list.ToArray();
		}
	}
}