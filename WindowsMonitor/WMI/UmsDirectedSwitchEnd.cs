using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class UmsDirectedSwitchEnd
    {
		public uint Flags { get; private set; }
		public uint PrimaryThreadId { get; private set; }
		public uint ProcessId { get; private set; }
		public uint ScheduledThreadId { get; private set; }
		public uint SwitchFlags { get; private set; }

        public static IEnumerable<UmsDirectedSwitchEnd> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<UmsDirectedSwitchEnd> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<UmsDirectedSwitchEnd> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM UmsDirectedSwitchEnd");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new UmsDirectedSwitchEnd
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 PrimaryThreadId = (uint) (managementObject.Properties["PrimaryThreadId"]?.Value ?? default(uint)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 ScheduledThreadId = (uint) (managementObject.Properties["ScheduledThreadId"]?.Value ?? default(uint)),
		 SwitchFlags = (uint) (managementObject.Properties["SwitchFlags"]?.Value ?? default(uint))
                };
        }
    }
}