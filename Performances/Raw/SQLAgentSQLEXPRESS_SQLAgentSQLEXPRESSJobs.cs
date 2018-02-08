using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_SQLAgentSQLEXPRESS_SQLAgentSQLEXPRESSJobs
    {
        public ulong Activejobs { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Failedjobs { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong JobsactivatedPerminute { get; private set; }
        public ulong Jobsuccessrate { get; private set; }
        public ulong Jobsuccessrate_Base { get; private set; }
        public string Name { get; private set; }
        public ulong Queuedjobs { get; private set; }
        public ulong Successfuljobs { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_SQLAgentSQLEXPRESS_SQLAgentSQLEXPRESSJobs[] Retrieve(string remote, string username,
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

        public static PerfRawData_SQLAgentSQLEXPRESS_SQLAgentSQLEXPRESSJobs[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_SQLAgentSQLEXPRESS_SQLAgentSQLEXPRESSJobs[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_SQLAgentSQLEXPRESS_SQLAgentSQLEXPRESSJobs");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_SQLAgentSQLEXPRESS_SQLAgentSQLEXPRESSJobs>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_SQLAgentSQLEXPRESS_SQLAgentSQLEXPRESSJobs
                {
                    Activejobs = (ulong) managementObject.Properties["Activejobs"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Failedjobs = (ulong) managementObject.Properties["Failedjobs"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    JobsactivatedPerminute = (ulong) managementObject.Properties["JobsactivatedPerminute"].Value,
                    Jobsuccessrate = (ulong) managementObject.Properties["Jobsuccessrate"].Value,
                    Jobsuccessrate_Base = (ulong) managementObject.Properties["Jobsuccessrate_Base"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Queuedjobs = (ulong) managementObject.Properties["Queuedjobs"].Value,
                    Successfuljobs = (ulong) managementObject.Properties["Successfuljobs"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}