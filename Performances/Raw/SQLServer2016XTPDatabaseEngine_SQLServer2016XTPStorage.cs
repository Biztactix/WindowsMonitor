using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPStorage
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

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPStorage[] Retrieve(string remote,
            string username, string password)
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

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPStorage[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPStorage[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPStorage");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPStorage>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPStorage
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CheckpointsClosed = (ulong) managementObject.Properties["CheckpointsClosed"].Value,
                    CheckpointsCompleted = (ulong) managementObject.Properties["CheckpointsCompleted"].Value,
                    CoreMergesCompleted = (ulong) managementObject.Properties["CoreMergesCompleted"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MergePolicyEvaluations = (ulong) managementObject.Properties["MergePolicyEvaluations"].Value,
                    MergeRequestsOutstanding = (ulong) managementObject.Properties["MergeRequestsOutstanding"].Value,
                    MergesAbandoned = (ulong) managementObject.Properties["MergesAbandoned"].Value,
                    MergesInstalled = (ulong) managementObject.Properties["MergesInstalled"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalFilesMerged = (ulong) managementObject.Properties["TotalFilesMerged"].Value
                });

            return list.ToArray();
        }
    }
}