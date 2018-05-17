using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MMCSSEvent
    {
		public uint Flags { get; private set; }
		public uint ScheduledPID { get; private set; }
		public uint ScheduledTID { get; private set; }
		public uint SchedulingPriority { get; private set; }
		public uint TaskIndex { get; private set; }

        public static IEnumerable<MMCSSEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MMCSSEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MMCSSEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MMCSSEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MMCSSEvent
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 ScheduledPID = (uint) (managementObject.Properties["ScheduledPID"]?.Value ?? default(uint)),
		 ScheduledTID = (uint) (managementObject.Properties["ScheduledTID"]?.Value ?? default(uint)),
		 SchedulingPriority = (uint) (managementObject.Properties["SchedulingPriority"]?.Value ?? default(uint)),
		 TaskIndex = (uint) (managementObject.Properties["TaskIndex"]?.Value ?? default(uint))
                };
        }
    }
}