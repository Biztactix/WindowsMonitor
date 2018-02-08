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
	public sealed class InstalledProgramFramework
	{
		public String FrameworkName { get; private set; }
public String FrameworkPublisher { get; private set; }
public String FrameworkVersion { get; private set; }
public String FrameworkVersionActual { get; private set; }
public Boolean IsPrivate { get; private set; }
public String ProgramId { get; private set; }
		
		public static InstalledProgramFramework[] Retrieve(string remote, string username, string password)
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

		public static InstalledProgramFramework[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static InstalledProgramFramework[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_InstalledProgramFramework");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<InstalledProgramFramework>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new InstalledProgramFramework
				{
					FrameworkName = (String) managementObject.Properties["FrameworkName"].Value,
FrameworkPublisher = (String) managementObject.Properties["FrameworkPublisher"].Value,
FrameworkVersion = (String) managementObject.Properties["FrameworkVersion"].Value,
FrameworkVersionActual = (String) managementObject.Properties["FrameworkVersionActual"].Value,
IsPrivate = (Boolean) managementObject.Properties["IsPrivate"].Value,
ProgramId = (String) managementObject.Properties["ProgramId"].Value,
				});
            }

			return list.ToArray();
		}
	}
}