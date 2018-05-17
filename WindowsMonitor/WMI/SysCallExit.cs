using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SysCallExit
    {
		public uint Flags { get; private set; }
		public uint SysCallNtStatus { get; private set; }

        public static IEnumerable<SysCallExit> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SysCallExit> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SysCallExit> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SysCallExit");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SysCallExit
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 SysCallNtStatus = (uint) (managementObject.Properties["SysCallNtStatus"]?.Value ?? default(uint))
                };
        }
    }
}