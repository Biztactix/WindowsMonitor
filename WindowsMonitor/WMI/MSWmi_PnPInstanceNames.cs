using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSWmi_PnPInstanceNames
    {
		public bool Active { get; private set; }
		public uint Count { get; private set; }
		public string InstanceName { get; private set; }
		public string[] InstanceNameList { get; private set; }

        public static IEnumerable<MSWmi_PnPInstanceNames> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSWmi_PnPInstanceNames> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSWmi_PnPInstanceNames> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSWmi_PnPInstanceNames");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSWmi_PnPInstanceNames
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 Count = (uint) (managementObject.Properties["Count"]?.Value ?? default(uint)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 InstanceNameList = (string[]) (managementObject.Properties["InstanceNameList"]?.Value ?? new string[0])
                };
        }
    }
}