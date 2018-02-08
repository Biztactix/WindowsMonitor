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
	public sealed class PatchPackage
	{
		public String Caption { get; private set; }
public String Description { get; private set; }
public String PatchID { get; private set; }
public String ProductCode { get; private set; }
public String SettingID { get; private set; }
		
		public static PatchPackage[] Retrieve(string remote, string username, string password)
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

		public static PatchPackage[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static PatchPackage[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_PatchPackage");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<PatchPackage>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new PatchPackage
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
PatchID = (String) managementObject.Properties["PatchID"].Value,
ProductCode = (String) managementObject.Properties["ProductCode"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
				});
            }

			return list.ToArray();
		}
	}
}