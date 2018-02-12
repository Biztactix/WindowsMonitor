using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __TimerNextFiring
    {
		public long NextEvent64BitTime { get; private set; }
		public string TimerId { get; private set; }

        public static IEnumerable<__TimerNextFiring> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__TimerNextFiring> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__TimerNextFiring> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __TimerNextFiring");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __TimerNextFiring
                {
                     NextEvent64BitTime = (long) (managementObject.Properties["NextEvent64BitTime"]?.Value ?? default(long)),
		 TimerId = (string) (managementObject.Properties["TimerId"]?.Value ?? default(string))
                };
        }
    }
}