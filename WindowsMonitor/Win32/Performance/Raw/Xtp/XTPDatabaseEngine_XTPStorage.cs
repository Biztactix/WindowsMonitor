using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class XTPDatabaseEngine_XTPStorage
    {
		public string Caption { get; private set; }
		public ulong CheckpointsClosed { get; private set; }
		public ulong CheckpointsCompleted { get; private set; }
		public ulong CoreMergesCompleted { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong MergePolicyEvaluations { get; private set; }
		public ulong MergeRequestsOutstanding { get; private set; }
		public ulong MergesAbandoned { get; private set; }
		public ulong MergesInstalled { get; private set; }
		public string Name { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong TotalFilesMerged { get; private set; }

        public static IEnumerable<XTPDatabaseEngine_XTPStorage> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<XTPDatabaseEngine_XTPStorage> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<XTPDatabaseEngine_XTPStorage> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_XTPDatabaseEngine_XTPStorage");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new XTPDatabaseEngine_XTPStorage
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CheckpointsClosed = (ulong) (managementObject.Properties["CheckpointsClosed"]?.Value ?? default(ulong)),
		 CheckpointsCompleted = (ulong) (managementObject.Properties["CheckpointsCompleted"]?.Value ?? default(ulong)),
		 CoreMergesCompleted = (ulong) (managementObject.Properties["CoreMergesCompleted"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 MergePolicyEvaluations = (ulong) (managementObject.Properties["MergePolicyEvaluations"]?.Value ?? default(ulong)),
		 MergeRequestsOutstanding = (ulong) (managementObject.Properties["MergeRequestsOutstanding"]?.Value ?? default(ulong)),
		 MergesAbandoned = (ulong) (managementObject.Properties["MergesAbandoned"]?.Value ?? default(ulong)),
		 MergesInstalled = (ulong) (managementObject.Properties["MergesInstalled"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalFilesMerged = (ulong) (managementObject.Properties["TotalFilesMerged"]?.Value ?? default(ulong))
                };
        }
    }
}