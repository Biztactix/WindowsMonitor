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
	public sealed class PnPSignedDriverCIMDataFile
	{
		public String Antecedent { get; private set; }
public String Dependent { get; private set; }
		
		public static PnPSignedDriverCIMDataFile[] Retrieve(string remote, string username, string password)
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

		public static PnPSignedDriverCIMDataFile[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static PnPSignedDriverCIMDataFile[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPSignedDriverCIMDataFile");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<PnPSignedDriverCIMDataFile>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new PnPSignedDriverCIMDataFile
				{
					Antecedent = (String) managementObject.Properties["Antecedent"].Value,
Dependent = (String) managementObject.Properties["Dependent"].Value,
				});
            }

			return list.ToArray();
		}
	}
}