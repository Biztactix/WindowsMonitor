using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSRedbook_Performance
    {
		public bool Active { get; private set; }
		public long DataProcessed { get; private set; }
		public string InstanceName { get; private set; }
		public uint StreamPausedCount { get; private set; }
		public long TimeReadDelay { get; private set; }
		public long TimeReading { get; private set; }
		public long TimeStreamDelay { get; private set; }
		public long TimeStreaming { get; private set; }

        public static IEnumerable<MSRedbook_Performance> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSRedbook_Performance> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSRedbook_Performance> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSRedbook_Performance");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSRedbook_Performance
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 DataProcessed = (long) (managementObject.Properties["DataProcessed"]?.Value ?? default(long)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 StreamPausedCount = (uint) (managementObject.Properties["StreamPausedCount"]?.Value ?? default(uint)),
		 TimeReadDelay = (long) (managementObject.Properties["TimeReadDelay"]?.Value ?? default(long)),
		 TimeReading = (long) (managementObject.Properties["TimeReading"]?.Value ?? default(long)),
		 TimeStreamDelay = (long) (managementObject.Properties["TimeStreamDelay"]?.Value ?? default(long)),
		 TimeStreaming = (long) (managementObject.Properties["TimeStreaming"]?.Value ?? default(long))
                };
        }
    }
}