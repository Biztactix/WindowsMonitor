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
	public sealed class TimeZone
	{
		public Int32 Bias { get; private set; }
public String Caption { get; private set; }
public Int32 DaylightBias { get; private set; }
public UInt32 DaylightDay { get; private set; }
public Byte DaylightDayOfWeek { get; private set; }
public UInt32 DaylightHour { get; private set; }
public UInt32 DaylightMillisecond { get; private set; }
public UInt32 DaylightMinute { get; private set; }
public UInt32 DaylightMonth { get; private set; }
public String DaylightName { get; private set; }
public UInt32 DaylightSecond { get; private set; }
public UInt32 DaylightYear { get; private set; }
public String Description { get; private set; }
public String SettingID { get; private set; }
public UInt32 StandardBias { get; private set; }
public UInt32 StandardDay { get; private set; }
public Byte StandardDayOfWeek { get; private set; }
public UInt32 StandardHour { get; private set; }
public UInt32 StandardMillisecond { get; private set; }
public UInt32 StandardMinute { get; private set; }
public UInt32 StandardMonth { get; private set; }
public String StandardName { get; private set; }
public UInt32 StandardSecond { get; private set; }
public UInt32 StandardYear { get; private set; }
		
		public static TimeZone[] Retrieve(string remote, string username, string password)
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

		public static TimeZone[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static TimeZone[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_TimeZone");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<TimeZone>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new TimeZone
				{
					Bias = (Int32) managementObject.Properties["Bias"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
DaylightBias = (Int32) managementObject.Properties["DaylightBias"].Value,
DaylightDay = (UInt32) managementObject.Properties["DaylightDay"].Value,
DaylightDayOfWeek = (Byte) managementObject.Properties["DaylightDayOfWeek"].Value,
DaylightHour = (UInt32) managementObject.Properties["DaylightHour"].Value,
DaylightMillisecond = (UInt32) managementObject.Properties["DaylightMillisecond"].Value,
DaylightMinute = (UInt32) managementObject.Properties["DaylightMinute"].Value,
DaylightMonth = (UInt32) managementObject.Properties["DaylightMonth"].Value,
DaylightName = (String) managementObject.Properties["DaylightName"].Value,
DaylightSecond = (UInt32) managementObject.Properties["DaylightSecond"].Value,
DaylightYear = (UInt32) managementObject.Properties["DaylightYear"].Value,
Description = (String) managementObject.Properties["Description"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
StandardBias = (UInt32) managementObject.Properties["StandardBias"].Value,
StandardDay = (UInt32) managementObject.Properties["StandardDay"].Value,
StandardDayOfWeek = (Byte) managementObject.Properties["StandardDayOfWeek"].Value,
StandardHour = (UInt32) managementObject.Properties["StandardHour"].Value,
StandardMillisecond = (UInt32) managementObject.Properties["StandardMillisecond"].Value,
StandardMinute = (UInt32) managementObject.Properties["StandardMinute"].Value,
StandardMonth = (UInt32) managementObject.Properties["StandardMonth"].Value,
StandardName = (String) managementObject.Properties["StandardName"].Value,
StandardSecond = (UInt32) managementObject.Properties["StandardSecond"].Value,
StandardYear = (UInt32) managementObject.Properties["StandardYear"].Value,
				});
            }

			return list.ToArray();
		}
	}
}