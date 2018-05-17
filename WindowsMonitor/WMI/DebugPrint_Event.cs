using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class DebugPrint_Event
    {
		public uint Component { get; private set; }
		public uint Flags { get; private set; }
		public uint Level { get; private set; }
		public string Message { get; private set; }

        public static IEnumerable<DebugPrint_Event> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<DebugPrint_Event> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<DebugPrint_Event> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM DebugPrint_Event");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new DebugPrint_Event
                {
                     Component = (uint) (managementObject.Properties["Component"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Level = (uint) (managementObject.Properties["Level"]?.Value ?? default(uint)),
		 Message = (string) (managementObject.Properties["Message"]?.Value ?? default(string))
                };
        }
    }
}