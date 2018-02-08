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
	public sealed class PageFileUsage
	{
		public UInt32 AllocatedBaseSize { get; private set; }
public String Caption { get; private set; }
public UInt32 CurrentUsage { get; private set; }
public String Description { get; private set; }
public DateTime InstallDate { get; private set; }
public String Name { get; private set; }
public UInt32 PeakUsage { get; private set; }
public String Status { get; private set; }
public Boolean TempPageFile { get; private set; }
		
		public static PageFileUsage[] Retrieve(string remote, string username, string password)
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

		public static PageFileUsage[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static PageFileUsage[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_PageFileUsage");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<PageFileUsage>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new PageFileUsage
				{
					AllocatedBaseSize = (UInt32) managementObject.Properties["AllocatedBaseSize"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
CurrentUsage = (UInt32) managementObject.Properties["CurrentUsage"].Value,
Description = (String) managementObject.Properties["Description"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
Name = (String) managementObject.Properties["Name"].Value,
PeakUsage = (UInt32) managementObject.Properties["PeakUsage"].Value,
Status = (String) managementObject.Properties["Status"].Value,
TempPageFile = (Boolean) managementObject.Properties["TempPageFile"].Value,
				});
            }

			return list.ToArray();
		}
	}
}