using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class AutoBoostEntryExhaustion
    {
		public uint Flags { get; private set; }
		public uint LockAddress { get; private set; }
		public uint ThreadId { get; private set; }

        public static IEnumerable<AutoBoostEntryExhaustion> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<AutoBoostEntryExhaustion> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<AutoBoostEntryExhaustion> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM AutoBoostEntryExhaustion");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new AutoBoostEntryExhaustion
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 LockAddress = (uint) (managementObject.Properties["LockAddress"]?.Value ?? default(uint)),
		 ThreadId = (uint) (managementObject.Properties["ThreadId"]?.Value ?? default(uint))
                };
        }
    }
}