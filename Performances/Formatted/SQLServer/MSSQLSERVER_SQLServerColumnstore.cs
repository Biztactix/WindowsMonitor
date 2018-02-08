using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSERVER_SQLServerColumnstore
    {
        public string Caption { get; private set; }
        public ulong DeltaRowgroupsClosed { get; private set; }
        public ulong DeltaRowgroupsCompressed { get; private set; }
        public ulong DeltaRowgroupsCreated { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong SegmentCacheHitRatio { get; private set; }
        public ulong SegmentReadsPerSec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalDeleteBuffersMigrated { get; private set; }
        public ulong TotalMergePolicyEvaluations { get; private set; }
        public ulong TotalRowgroupsCompressed { get; private set; }
        public ulong TotalRowgroupsFitForMerge { get; private set; }
        public ulong TotalRowgroupsMergeCompressed { get; private set; }
        public ulong TotalSourceRowgroupsMerged { get; private set; }

        public static PerfFormattedData_MSSQLSERVER_SQLServerColumnstore[] Retrieve(string remote, string username,
            string password)
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

        public static PerfFormattedData_MSSQLSERVER_SQLServerColumnstore[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSERVER_SQLServerColumnstore[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerColumnstore");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSERVER_SQLServerColumnstore>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSERVER_SQLServerColumnstore
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    DeltaRowgroupsClosed = (ulong) managementObject.Properties["DeltaRowgroupsClosed"].Value,
                    DeltaRowgroupsCompressed = (ulong) managementObject.Properties["DeltaRowgroupsCompressed"].Value,
                    DeltaRowgroupsCreated = (ulong) managementObject.Properties["DeltaRowgroupsCreated"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SegmentCacheHitRatio = (ulong) managementObject.Properties["SegmentCacheHitRatio"].Value,
                    SegmentReadsPerSec = (ulong) managementObject.Properties["SegmentReadsPerSec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalDeleteBuffersMigrated =
                        (ulong) managementObject.Properties["TotalDeleteBuffersMigrated"].Value,
                    TotalMergePolicyEvaluations = (ulong) managementObject.Properties["TotalMergePolicyEvaluations"]
                        .Value,
                    TotalRowgroupsCompressed = (ulong) managementObject.Properties["TotalRowgroupsCompressed"].Value,
                    TotalRowgroupsFitForMerge = (ulong) managementObject.Properties["TotalRowgroupsFitForMerge"].Value,
                    TotalRowgroupsMergeCompressed =
                        (ulong) managementObject.Properties["TotalRowgroupsMergeCompressed"].Value,
                    TotalSourceRowgroupsMerged = (ulong) managementObject.Properties["TotalSourceRowgroupsMerged"].Value
                });

            return list.ToArray();
        }
    }
}