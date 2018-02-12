using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __IntervalTimerInstruction
    {
		public uint IntervalBetweenEvents { get; private set; }
		public bool SkipIfPassed { get; private set; }
		public string TimerId { get; private set; }

        public static IEnumerable<__IntervalTimerInstruction> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__IntervalTimerInstruction> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__IntervalTimerInstruction> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __IntervalTimerInstruction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __IntervalTimerInstruction
                {
                     IntervalBetweenEvents = (uint) (managementObject.Properties["IntervalBetweenEvents"]?.Value ?? default(uint)),
		 SkipIfPassed = (bool) (managementObject.Properties["SkipIfPassed"]?.Value ?? default(bool)),
		 TimerId = (string) (managementObject.Properties["TimerId"]?.Value ?? default(string))
                };
        }
    }
}