using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSFC_TM
    {
		public uint tm_hour { get; private set; }
		public uint tm_isdst { get; private set; }
		public uint tm_mday { get; private set; }
		public uint tm_min { get; private set; }
		public uint tm_mon { get; private set; }
		public uint tm_sec { get; private set; }
		public uint tm_wday { get; private set; }
		public uint tm_yday { get; private set; }
		public uint tm_year { get; private set; }

        public static IEnumerable<MSFC_TM> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<MSFC_TM> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSFC_TM> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFC_TM");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSFC_TM
                {
                     tm_hour = (uint) (managementObject.Properties["tm_hour"]?.Value ?? default(uint)),
		 tm_isdst = (uint) (managementObject.Properties["tm_isdst"]?.Value ?? default(uint)),
		 tm_mday = (uint) (managementObject.Properties["tm_mday"]?.Value ?? default(uint)),
		 tm_min = (uint) (managementObject.Properties["tm_min"]?.Value ?? default(uint)),
		 tm_mon = (uint) (managementObject.Properties["tm_mon"]?.Value ?? default(uint)),
		 tm_sec = (uint) (managementObject.Properties["tm_sec"]?.Value ?? default(uint)),
		 tm_wday = (uint) (managementObject.Properties["tm_wday"]?.Value ?? default(uint)),
		 tm_yday = (uint) (managementObject.Properties["tm_yday"]?.Value ?? default(uint)),
		 tm_year = (uint) (managementObject.Properties["tm_year"]?.Value ?? default(uint))
                };
        }
    }
}