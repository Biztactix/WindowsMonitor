using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Header_DbgIdRSDS_TypeGroup
    {
		public uint Age { get; private set; }
		public uint Flags { get; private set; }
		public dynamic Guid { get; private set; }
		public string PdbName { get; private set; }

        public static IEnumerable<Header_DbgIdRSDS_TypeGroup> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Header_DbgIdRSDS_TypeGroup> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Header_DbgIdRSDS_TypeGroup> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Header_DbgIdRSDS_TypeGroup");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Header_DbgIdRSDS_TypeGroup
                {
                     Age = (uint) (managementObject.Properties["Age"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Guid = (dynamic) (managementObject.Properties["Guid"]?.Value ?? default(dynamic)),
		 PdbName = (string) (managementObject.Properties["PdbName"]?.Value ?? default(string))
                };
        }
    }
}