using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Process_V2_TypeGroup4
    {
		public uint Count { get; private set; }
		public uint Flags { get; private set; }
		public uint Object { get; private set; }
		public uint ProcessId { get; private set; }
		public uint Tag { get; private set; }

        public static IEnumerable<Process_V2_TypeGroup4> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Process_V2_TypeGroup4> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Process_V2_TypeGroup4> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Process_V2_TypeGroup4");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Process_V2_TypeGroup4
                {
                     Count = (uint) (managementObject.Properties["Count"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Object = (uint) (managementObject.Properties["Object"]?.Value ?? default(uint)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 Tag = (uint) (managementObject.Properties["Tag"]?.Value ?? default(uint))
                };
        }
    }
}