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
	public sealed class CurrentTime
	{
		public UInt32 Day { get; private set; }
public UInt32 DayOfWeek { get; private set; }
public UInt32 Hour { get; private set; }
public UInt32 Milliseconds { get; private set; }
public UInt32 Minute { get; private set; }
public UInt32 Month { get; private set; }
public UInt32 Quarter { get; private set; }
public UInt32 Second { get; private set; }
public UInt32 WeekInMonth { get; private set; }
public UInt32 Year { get; private set; }
		
		public static CurrentTime[] Retrieve(string remote, string username, string password)
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

		public static CurrentTime[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static CurrentTime[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_CurrentTime");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<CurrentTime>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new CurrentTime
				{
					Day = (UInt32) managementObject.Properties["Day"].Value,
DayOfWeek = (UInt32) managementObject.Properties["DayOfWeek"].Value,
Hour = (UInt32) managementObject.Properties["Hour"].Value,
Milliseconds = (UInt32) managementObject.Properties["Milliseconds"].Value,
Minute = (UInt32) managementObject.Properties["Minute"].Value,
Month = (UInt32) managementObject.Properties["Month"].Value,
Quarter = (UInt32) managementObject.Properties["Quarter"].Value,
Second = (UInt32) managementObject.Properties["Second"].Value,
WeekInMonth = (UInt32) managementObject.Properties["WeekInMonth"].Value,
Year = (UInt32) managementObject.Properties["Year"].Value,
				});
            }

			return list.ToArray();
		}
	}
}