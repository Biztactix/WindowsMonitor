using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class IoTimerEvent
    {
		public uint DeviceObject { get; private set; }
		public uint Flags { get; private set; }
		public uint TimerRoutine { get; private set; }

        public static IEnumerable<IoTimerEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<IoTimerEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<IoTimerEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM IoTimerEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new IoTimerEvent
                {
                     DeviceObject = (uint) (managementObject.Properties["DeviceObject"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 TimerRoutine = (uint) (managementObject.Properties["TimerRoutine"]?.Value ?? default(uint))
                };
        }
    }
}