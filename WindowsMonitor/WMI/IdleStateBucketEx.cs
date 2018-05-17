using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class IdleStateBucketEx
    {
		public uint Count { get; private set; }
		public uint MaxTimeUs { get; private set; }
		public uint MinTimeUs { get; private set; }
		public ulong TotalTimeUs { get; private set; }

        public static IEnumerable<IdleStateBucketEx> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<IdleStateBucketEx> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<IdleStateBucketEx> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM IdleStateBucketEx");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new IdleStateBucketEx
                {
                     Count = (uint) (managementObject.Properties["Count"]?.Value ?? default(uint)),
		 MaxTimeUs = (uint) (managementObject.Properties["MaxTimeUs"]?.Value ?? default(uint)),
		 MinTimeUs = (uint) (managementObject.Properties["MinTimeUs"]?.Value ?? default(uint)),
		 TotalTimeUs = (ulong) (managementObject.Properties["TotalTimeUs"]?.Value ?? default(ulong))
                };
        }
    }
}