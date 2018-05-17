using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSFC_HBAPortStatistics
    {
		public long DumpedFrames { get; private set; }
		public long ErrorFrames { get; private set; }
		public long InvalidCRCCount { get; private set; }
		public long InvalidTxWordCount { get; private set; }
		public long LinkFailureCount { get; private set; }
		public long LIPCount { get; private set; }
		public long LossOfSignalCount { get; private set; }
		public long LossOfSyncCount { get; private set; }
		public long NOSCount { get; private set; }
		public long PrimitiveSeqProtocolErrCount { get; private set; }
		public long RxFrames { get; private set; }
		public long RxWords { get; private set; }
		public long SecondsSinceLastReset { get; private set; }
		public long TxFrames { get; private set; }
		public long TxWords { get; private set; }

        public static IEnumerable<MSFC_HBAPortStatistics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSFC_HBAPortStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSFC_HBAPortStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFC_HBAPortStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSFC_HBAPortStatistics
                {
                     DumpedFrames = (long) (managementObject.Properties["DumpedFrames"]?.Value ?? default(long)),
		 ErrorFrames = (long) (managementObject.Properties["ErrorFrames"]?.Value ?? default(long)),
		 InvalidCRCCount = (long) (managementObject.Properties["InvalidCRCCount"]?.Value ?? default(long)),
		 InvalidTxWordCount = (long) (managementObject.Properties["InvalidTxWordCount"]?.Value ?? default(long)),
		 LinkFailureCount = (long) (managementObject.Properties["LinkFailureCount"]?.Value ?? default(long)),
		 LIPCount = (long) (managementObject.Properties["LIPCount"]?.Value ?? default(long)),
		 LossOfSignalCount = (long) (managementObject.Properties["LossOfSignalCount"]?.Value ?? default(long)),
		 LossOfSyncCount = (long) (managementObject.Properties["LossOfSyncCount"]?.Value ?? default(long)),
		 NOSCount = (long) (managementObject.Properties["NOSCount"]?.Value ?? default(long)),
		 PrimitiveSeqProtocolErrCount = (long) (managementObject.Properties["PrimitiveSeqProtocolErrCount"]?.Value ?? default(long)),
		 RxFrames = (long) (managementObject.Properties["RxFrames"]?.Value ?? default(long)),
		 RxWords = (long) (managementObject.Properties["RxWords"]?.Value ?? default(long)),
		 SecondsSinceLastReset = (long) (managementObject.Properties["SecondsSinceLastReset"]?.Value ?? default(long)),
		 TxFrames = (long) (managementObject.Properties["TxFrames"]?.Value ?? default(long)),
		 TxWords = (long) (managementObject.Properties["TxWords"]?.Value ?? default(long))
                };
        }
    }
}