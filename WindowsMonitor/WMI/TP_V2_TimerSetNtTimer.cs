using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class TP_V2_TimerSetNtTimer
    {
		public ulong DueTime { get; private set; }
		public uint SubQueue { get; private set; }
		public uint TolerableDelay { get; private set; }

        public static IEnumerable<TP_V2_TimerSetNtTimer> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TP_V2_TimerSetNtTimer> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TP_V2_TimerSetNtTimer> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM TP_V2_TimerSetNtTimer");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TP_V2_TimerSetNtTimer
                {
                     DueTime = (ulong) (managementObject.Properties["DueTime"]?.Value ?? default(ulong)),
		 SubQueue = (uint) (managementObject.Properties["SubQueue"]?.Value ?? default(uint)),
		 TolerableDelay = (uint) (managementObject.Properties["TolerableDelay"]?.Value ?? default(uint))
                };
        }
    }
}