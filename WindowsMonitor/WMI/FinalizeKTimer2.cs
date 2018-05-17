using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class FinalizeKTimer2
    {
		public uint DisableCallback { get; private set; }
		public uint DisableContext { get; private set; }
		public uint Flags { get; private set; }
		public uint Timer { get; private set; }

        public static IEnumerable<FinalizeKTimer2> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FinalizeKTimer2> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FinalizeKTimer2> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM FinalizeKTimer2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FinalizeKTimer2
                {
                     DisableCallback = (uint) (managementObject.Properties["DisableCallback"]?.Value ?? default(uint)),
		 DisableContext = (uint) (managementObject.Properties["DisableContext"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Timer = (uint) (managementObject.Properties["Timer"]?.Value ?? default(uint))
                };
        }
    }
}