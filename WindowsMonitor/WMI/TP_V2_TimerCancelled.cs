using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class TP_V2_TimerCancelled
    {
		public uint SubQueue { get; private set; }
		public uint Timer { get; private set; }

        public static IEnumerable<TP_V2_TimerCancelled> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TP_V2_TimerCancelled> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TP_V2_TimerCancelled> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM TP_V2_TimerCancelled");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TP_V2_TimerCancelled
                {
                     SubQueue = (uint) (managementObject.Properties["SubQueue"]?.Value ?? default(uint)),
		 Timer = (uint) (managementObject.Properties["Timer"]?.Value ?? default(uint))
                };
        }
    }
}