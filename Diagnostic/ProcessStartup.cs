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
	public sealed class ProcessStartup
	{
		public UInt32 CreateFlags { get; private set; }
public String[] EnvironmentVariables { get; private set; }
public UInt16 ErrorMode { get; private set; }
public UInt32 FillAttribute { get; private set; }
public UInt32 PriorityClass { get; private set; }
public UInt16 ShowWindow { get; private set; }
public String Title { get; private set; }
public String WinstationDesktop { get; private set; }
public UInt32 X { get; private set; }
public UInt32 XCountChars { get; private set; }
public UInt32 XSize { get; private set; }
public UInt32 Y { get; private set; }
public UInt32 YCountChars { get; private set; }
public UInt32 YSize { get; private set; }
		
		public static ProcessStartup[] Retrieve(string remote, string username, string password)
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

		public static ProcessStartup[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ProcessStartup[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ProcessStartup");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ProcessStartup>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ProcessStartup
				{
					CreateFlags = (UInt32) managementObject.Properties["CreateFlags"].Value,
EnvironmentVariables = (String[]) managementObject.Properties["EnvironmentVariables"].Value,
ErrorMode = (UInt16) managementObject.Properties["ErrorMode"].Value,
FillAttribute = (UInt32) managementObject.Properties["FillAttribute"].Value,
PriorityClass = (UInt32) managementObject.Properties["PriorityClass"].Value,
ShowWindow = (UInt16) managementObject.Properties["ShowWindow"].Value,
Title = (String) managementObject.Properties["Title"].Value,
WinstationDesktop = (String) managementObject.Properties["WinstationDesktop"].Value,
X = (UInt32) managementObject.Properties["X"].Value,
XCountChars = (UInt32) managementObject.Properties["XCountChars"].Value,
XSize = (UInt32) managementObject.Properties["XSize"].Value,
Y = (UInt32) managementObject.Properties["Y"].Value,
YCountChars = (UInt32) managementObject.Properties["YCountChars"].Value,
YSize = (UInt32) managementObject.Properties["YSize"].Value,
				});
            }

			return list.ToArray();
		}
	}
}