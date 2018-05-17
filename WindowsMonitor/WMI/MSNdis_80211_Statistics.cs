using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_80211_Statistics
    {
		public ulong ACKFailureCount { get; private set; }
		public bool Active { get; private set; }
		public ulong FailedCount { get; private set; }
		public ulong FCSErrorCount { get; private set; }
		public ulong FrameDuplicateCount { get; private set; }
		public string InstanceName { get; private set; }
		public ulong MulticastReceivedFrameCount { get; private set; }
		public ulong MulticastTransmittedFrameCount { get; private set; }
		public ulong MultipleRetryCount { get; private set; }
		public ulong ReceivedFragmentCount { get; private set; }
		public ulong RetryCount { get; private set; }
		public ulong RTSFailureCount { get; private set; }
		public ulong RTSSuccessCount { get; private set; }
		public uint StatisticsLength { get; private set; }
		public ulong TransmittedFragmentCount { get; private set; }

        public static IEnumerable<MSNdis_80211_Statistics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_80211_Statistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_80211_Statistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_80211_Statistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_80211_Statistics
                {
                     ACKFailureCount = (ulong) (managementObject.Properties["ACKFailureCount"]?.Value ?? default(ulong)),
		 Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 FailedCount = (ulong) (managementObject.Properties["FailedCount"]?.Value ?? default(ulong)),
		 FCSErrorCount = (ulong) (managementObject.Properties["FCSErrorCount"]?.Value ?? default(ulong)),
		 FrameDuplicateCount = (ulong) (managementObject.Properties["FrameDuplicateCount"]?.Value ?? default(ulong)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 MulticastReceivedFrameCount = (ulong) (managementObject.Properties["MulticastReceivedFrameCount"]?.Value ?? default(ulong)),
		 MulticastTransmittedFrameCount = (ulong) (managementObject.Properties["MulticastTransmittedFrameCount"]?.Value ?? default(ulong)),
		 MultipleRetryCount = (ulong) (managementObject.Properties["MultipleRetryCount"]?.Value ?? default(ulong)),
		 ReceivedFragmentCount = (ulong) (managementObject.Properties["ReceivedFragmentCount"]?.Value ?? default(ulong)),
		 RetryCount = (ulong) (managementObject.Properties["RetryCount"]?.Value ?? default(ulong)),
		 RTSFailureCount = (ulong) (managementObject.Properties["RTSFailureCount"]?.Value ?? default(ulong)),
		 RTSSuccessCount = (ulong) (managementObject.Properties["RTSSuccessCount"]?.Value ?? default(ulong)),
		 StatisticsLength = (uint) (managementObject.Properties["StatisticsLength"]?.Value ?? default(uint)),
		 TransmittedFragmentCount = (ulong) (managementObject.Properties["TransmittedFragmentCount"]?.Value ?? default(ulong))
                };
        }
    }
}