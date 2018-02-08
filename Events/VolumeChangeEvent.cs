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
	public sealed class VolumeChangeEvent
	{
		public String DriveName { get; private set; }
public UInt16 EventType { get; private set; }
public Byte[] SECURITY_DESCRIPTOR { get; private set; }
public UInt64 TIME_CREATED { get; private set; }
		
		public static VolumeChangeEvent[] Retrieve(string remote, string username, string password)
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

		public static VolumeChangeEvent[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static VolumeChangeEvent[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_VolumeChangeEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<VolumeChangeEvent>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new VolumeChangeEvent
				{
					DriveName = (String) managementObject.Properties["DriveName"].Value,
EventType = (UInt16) managementObject.Properties["EventType"].Value,
SECURITY_DESCRIPTOR = (Byte[]) managementObject.Properties["SECURITY_DESCRIPTOR"].Value,
TIME_CREATED = (UInt64) managementObject.Properties["TIME_CREATED"].Value,
				});
            }

			return list.ToArray();
		}
	}
}