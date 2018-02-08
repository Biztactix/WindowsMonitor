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
	public sealed class ProcessStartTrace
	{
		public UInt32 ParentProcessID { get; private set; }
public UInt32 ProcessID { get; private set; }
public String ProcessName { get; private set; }
public Byte[] SECURITY_DESCRIPTOR { get; private set; }
public UInt32 SessionID { get; private set; }
public Byte[] Sid { get; private set; }
public UInt64 TIME_CREATED { get; private set; }
		
		public static ProcessStartTrace[] Retrieve(string remote, string username, string password)
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

		public static ProcessStartTrace[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ProcessStartTrace[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ProcessStartTrace");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ProcessStartTrace>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ProcessStartTrace
				{
					ParentProcessID = (UInt32) managementObject.Properties["ParentProcessID"].Value,
ProcessID = (UInt32) managementObject.Properties["ProcessID"].Value,
ProcessName = (String) managementObject.Properties["ProcessName"].Value,
SECURITY_DESCRIPTOR = (Byte[]) managementObject.Properties["SECURITY_DESCRIPTOR"].Value,
SessionID = (UInt32) managementObject.Properties["SessionID"].Value,
Sid = (Byte[]) managementObject.Properties["Sid"].Value,
TIME_CREATED = (UInt64) managementObject.Properties["TIME_CREATED"].Value,
				});
            }

			return list.ToArray();
		}
	}
}