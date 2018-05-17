using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class PerformanceStates
    {
		public uint Count { get; private set; }
		public uint Current { get; private set; }
		public dynamic[] State { get; private set; }
		public uint TransitionFunction { get; private set; }
		public uint TransitionLatency { get; private set; }

        public static IEnumerable<PerformanceStates> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PerformanceStates> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PerformanceStates> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM PerformanceStates");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PerformanceStates
                {
                     Count = (uint) (managementObject.Properties["Count"]?.Value ?? default(uint)),
		 Current = (uint) (managementObject.Properties["Current"]?.Value ?? default(uint)),
		 State = (dynamic[]) (managementObject.Properties["State"]?.Value ?? new dynamic[0]),
		 TransitionFunction = (uint) (managementObject.Properties["TransitionFunction"]?.Value ?? default(uint)),
		 TransitionLatency = (uint) (managementObject.Properties["TransitionLatency"]?.Value ?? default(uint))
                };
        }
    }
}