using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class IdleStateAccounting
    {
		public uint FailedTransitions { get; private set; }
		public uint[] IdleTimeBuckets { get; private set; }
		public uint IdleTransitions { get; private set; }
		public uint InvalidBucketIndex { get; private set; }
		public ulong TotalTime { get; private set; }

        public static IEnumerable<IdleStateAccounting> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<IdleStateAccounting> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<IdleStateAccounting> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM IdleStateAccounting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new IdleStateAccounting
                {
                     FailedTransitions = (uint) (managementObject.Properties["FailedTransitions"]?.Value ?? default(uint)),
		 IdleTimeBuckets = (uint[]) (managementObject.Properties["IdleTimeBuckets"]?.Value ?? new uint[0]),
		 IdleTransitions = (uint) (managementObject.Properties["IdleTransitions"]?.Value ?? default(uint)),
		 InvalidBucketIndex = (uint) (managementObject.Properties["InvalidBucketIndex"]?.Value ?? default(uint)),
		 TotalTime = (ulong) (managementObject.Properties["TotalTime"]?.Value ?? default(ulong))
                };
        }
    }
}