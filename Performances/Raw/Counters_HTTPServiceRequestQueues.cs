using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_HTTPServiceRequestQueues
    {
        public ulong ArrivalRate { get; private set; }
        public ulong CacheHitRate { get; private set; }
        public string Caption { get; private set; }
        public uint CurrentQueueSize { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong MaxQueueItemAge { get; private set; }
        public string Name { get; private set; }
        public ulong RejectedRequests { get; private set; }
        public ulong RejectionRate { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_HTTPServiceRequestQueues[] Retrieve(string remote, string username,
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

        public static PerfRawData_Counters_HTTPServiceRequestQueues[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_HTTPServiceRequestQueues[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_HTTPServiceRequestQueues");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_HTTPServiceRequestQueues>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_HTTPServiceRequestQueues
                {
                    ArrivalRate = (ulong) managementObject.Properties["ArrivalRate"].Value,
                    CacheHitRate = (ulong) managementObject.Properties["CacheHitRate"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentQueueSize = (uint) managementObject.Properties["CurrentQueueSize"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MaxQueueItemAge = (ulong) managementObject.Properties["MaxQueueItemAge"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    RejectedRequests = (ulong) managementObject.Properties["RejectedRequests"].Value,
                    RejectionRate = (ulong) managementObject.Properties["RejectionRate"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}