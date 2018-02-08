using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_SQLSERVERAGENT_SQLAgentSystemJobs
    {
        public ulong Activesystemjobs { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Failedsystemjobs { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Queuedsystemjobs { get; private set; }
        public ulong Successfulsystemjobs { get; private set; }
        public ulong SystemJobsactivatedPerminute { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_SQLSERVERAGENT_SQLAgentSystemJobs[] Retrieve(string remote, string username,
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

        public static PerfRawData_SQLSERVERAGENT_SQLAgentSystemJobs[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_SQLSERVERAGENT_SQLAgentSystemJobs[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_SQLSERVERAGENT_SQLAgentSystemJobs");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_SQLSERVERAGENT_SQLAgentSystemJobs>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_SQLSERVERAGENT_SQLAgentSystemJobs
                {
                    Activesystemjobs = (ulong) managementObject.Properties["Activesystemjobs"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Failedsystemjobs = (ulong) managementObject.Properties["Failedsystemjobs"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Queuedsystemjobs = (ulong) managementObject.Properties["Queuedsystemjobs"].Value,
                    Successfulsystemjobs = (ulong) managementObject.Properties["Successfulsystemjobs"].Value,
                    SystemJobsactivatedPerminute = (ulong) managementObject.Properties["SystemJobsactivatedPerminute"]
                        .Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}