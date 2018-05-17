using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class RefDefNgenBindRejectInfo
    {
		public string DefModuleName { get; private set; }
		public string RefModuleName { get; private set; }
		public uint RejectReason { get; private set; }

        public static IEnumerable<RefDefNgenBindRejectInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<RefDefNgenBindRejectInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<RefDefNgenBindRejectInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM RefDefNgenBindRejectInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new RefDefNgenBindRejectInfo
                {
                     DefModuleName = (string) (managementObject.Properties["DefModuleName"]?.Value ?? default(string)),
		 RefModuleName = (string) (managementObject.Properties["RefModuleName"]?.Value ?? default(string)),
		 RejectReason = (uint) (managementObject.Properties["RejectReason"]?.Value ?? default(uint))
                };
        }
    }
}