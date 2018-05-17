using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SystemConfig_V2_FlightIds
    {
		public uint Flags { get; private set; }
		public string FlightIdList { get; private set; }
		public string UpdateId { get; private set; }

        public static IEnumerable<SystemConfig_V2_FlightIds> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SystemConfig_V2_FlightIds> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SystemConfig_V2_FlightIds> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SystemConfig_V2_FlightIds");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SystemConfig_V2_FlightIds
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 FlightIdList = (string) (managementObject.Properties["FlightIdList"]?.Value ?? default(string)),
		 UpdateId = (string) (managementObject.Properties["UpdateId"]?.Value ?? default(string))
                };
        }
    }
}