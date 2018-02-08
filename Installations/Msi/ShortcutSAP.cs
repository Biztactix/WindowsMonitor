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
	public sealed class ShortcutSAP
	{
		public String Action { get; private set; }
public String Element { get; private set; }
		
		public static ShortcutSAP[] Retrieve(string remote, string username, string password)
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

		public static ShortcutSAP[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ShortcutSAP[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ShortcutSAP");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ShortcutSAP>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ShortcutSAP
				{
					Action = (String) managementObject.Properties["Action"].Value,
Element = (String) managementObject.Properties["Element"].Value,
				});
            }

			return list.ToArray();
		}
	}
}