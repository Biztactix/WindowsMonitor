using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class Win32Reg_SMSWindowsUpdate
    {
		public uint AUOptions { get; private set; }
		public string InstanceKey { get; private set; }
		public uint NoAutoUpdate { get; private set; }
		public uint UseWUServer { get; private set; }

        public static IEnumerable<Win32Reg_SMSWindowsUpdate> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<Win32Reg_SMSWindowsUpdate> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Win32Reg_SMSWindowsUpdate> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32Reg_SMSWindowsUpdate");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Win32Reg_SMSWindowsUpdate
                {
                     AUOptions = (uint) (managementObject.Properties["AUOptions"]?.Value ?? default(uint)),
		 InstanceKey = (string) (managementObject.Properties["InstanceKey"]?.Value ?? default(string)),
		 NoAutoUpdate = (uint) (managementObject.Properties["NoAutoUpdate"]?.Value ?? default(uint)),
		 UseWUServer = (uint) (managementObject.Properties["UseWUServer"]?.Value ?? default(uint))
                };
        }
    }
}