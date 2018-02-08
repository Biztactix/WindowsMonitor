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
	public sealed class ComClassAutoEmulator
	{
		public String NewVersion { get; private set; }
public String OldVersion { get; private set; }
		
		public static ComClassAutoEmulator[] Retrieve(string remote, string username, string password)
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

		public static ComClassAutoEmulator[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ComClassAutoEmulator[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ComClassAutoEmulator");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ComClassAutoEmulator>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ComClassAutoEmulator
				{
					NewVersion = (String) managementObject.Properties["NewVersion"].Value,
OldVersion = (String) managementObject.Properties["OldVersion"].Value,
				});
            }

			return list.ToArray();
		}
	}
}