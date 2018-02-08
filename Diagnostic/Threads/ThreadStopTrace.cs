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
	public sealed class ThreadStopTrace
	{
		public UInt32 ProcessID { get; private set; }
public Byte[] SECURITY_DESCRIPTOR { get; private set; }
public UInt32 ThreadID { get; private set; }
public UInt64 TIME_CREATED { get; private set; }
		
		public static ThreadStopTrace[] Retrieve(string remote, string username, string password)
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

		public static ThreadStopTrace[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ThreadStopTrace[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ThreadStopTrace");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ThreadStopTrace>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ThreadStopTrace
				{
					ProcessID = (UInt32) managementObject.Properties["ProcessID"].Value,
SECURITY_DESCRIPTOR = (Byte[]) managementObject.Properties["SECURITY_DESCRIPTOR"].Value,
ThreadID = (UInt32) managementObject.Properties["ThreadID"].Value,
TIME_CREATED = (UInt64) managementObject.Properties["TIME_CREATED"].Value,
				});
            }

			return list.ToArray();
		}
	}
}