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
	public sealed class ModuleLoadTrace
	{
		public UInt64 DefaultBase { get; private set; }
public String FileName { get; private set; }
public UInt64 ImageBase { get; private set; }
public UInt32 ImageChecksum { get; private set; }
public UInt64 ImageSize { get; private set; }
public UInt32 ProcessID { get; private set; }
public Byte[] SECURITY_DESCRIPTOR { get; private set; }
public UInt64 TIME_CREATED { get; private set; }
public UInt32 TimeDateStamp { get; private set; }
		
		public static ModuleLoadTrace[] Retrieve(string remote, string username, string password)
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

		public static ModuleLoadTrace[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ModuleLoadTrace[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ModuleLoadTrace");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ModuleLoadTrace>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ModuleLoadTrace
				{
					DefaultBase = (UInt64) managementObject.Properties["DefaultBase"].Value,
FileName = (String) managementObject.Properties["FileName"].Value,
ImageBase = (UInt64) managementObject.Properties["ImageBase"].Value,
ImageChecksum = (UInt32) managementObject.Properties["ImageChecksum"].Value,
ImageSize = (UInt64) managementObject.Properties["ImageSize"].Value,
ProcessID = (UInt32) managementObject.Properties["ProcessID"].Value,
SECURITY_DESCRIPTOR = (Byte[]) managementObject.Properties["SECURITY_DESCRIPTOR"].Value,
TIME_CREATED = (UInt64) managementObject.Properties["TIME_CREATED"].Value,
TimeDateStamp = (UInt32) managementObject.Properties["TimeDateStamp"].Value,
				});
            }

			return list.ToArray();
		}
	}
}