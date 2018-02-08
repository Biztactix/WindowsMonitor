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
	public sealed class ThreadStartTrace
	{
		public UInt32 ProcessID { get; private set; }
public Byte[] SECURITY_DESCRIPTOR { get; private set; }
public UInt64 StackBase { get; private set; }
public UInt64 StackLimit { get; private set; }
public UInt64 StartAddr { get; private set; }
public UInt32 ThreadID { get; private set; }
public UInt64 TIME_CREATED { get; private set; }
public UInt64 UserStackBase { get; private set; }
public UInt64 UserStackLimit { get; private set; }
public UInt32 WaitMode { get; private set; }
public UInt64 Win32StartAddr { get; private set; }
		
		public static ThreadStartTrace[] Retrieve(string remote, string username, string password)
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

		public static ThreadStartTrace[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ThreadStartTrace[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ThreadStartTrace");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ThreadStartTrace>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ThreadStartTrace
				{
					ProcessID = (UInt32) managementObject.Properties["ProcessID"].Value,
SECURITY_DESCRIPTOR = (Byte[]) managementObject.Properties["SECURITY_DESCRIPTOR"].Value,
StackBase = (UInt64) managementObject.Properties["StackBase"].Value,
StackLimit = (UInt64) managementObject.Properties["StackLimit"].Value,
StartAddr = (UInt64) managementObject.Properties["StartAddr"].Value,
ThreadID = (UInt32) managementObject.Properties["ThreadID"].Value,
TIME_CREATED = (UInt64) managementObject.Properties["TIME_CREATED"].Value,
UserStackBase = (UInt64) managementObject.Properties["UserStackBase"].Value,
UserStackLimit = (UInt64) managementObject.Properties["UserStackLimit"].Value,
WaitMode = (UInt32) managementObject.Properties["WaitMode"].Value,
Win32StartAddr = (UInt64) managementObject.Properties["Win32StartAddr"].Value,
				});
            }

			return list.ToArray();
		}
	}
}