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
	public sealed class Patch
	{
		public UInt16 Attributes { get; private set; }
public String Caption { get; private set; }
public String Description { get; private set; }
public String File { get; private set; }
public UInt32 PatchSize { get; private set; }
public String ProductCode { get; private set; }
public Int16 Sequence { get; private set; }
public String SettingID { get; private set; }
		
		public static Patch[] Retrieve(string remote, string username, string password)
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

		public static Patch[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static Patch[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_Patch");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<Patch>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new Patch
				{
					Attributes = (UInt16) managementObject.Properties["Attributes"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
File = (String) managementObject.Properties["File"].Value,
PatchSize = (UInt32) managementObject.Properties["PatchSize"].Value,
ProductCode = (String) managementObject.Properties["ProductCode"].Value,
Sequence = (Int16) managementObject.Properties["Sequence"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
				});
            }

			return list.ToArray();
		}
	}
}