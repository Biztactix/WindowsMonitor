using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class SQLSERVERAGENT_SQLAgentSystemJobs
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

        public static IEnumerable<SQLSERVERAGENT_SQLAgentSystemJobs> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SQLSERVERAGENT_SQLAgentSystemJobs> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SQLSERVERAGENT_SQLAgentSystemJobs> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_SQLSERVERAGENT_SQLAgentSystemJobs");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SQLSERVERAGENT_SQLAgentSystemJobs
                {
                     Activesystemjobs = (ulong) (managementObject.Properties["Activesystemjobs"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Failedsystemjobs = (ulong) (managementObject.Properties["Failedsystemjobs"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Queuedsystemjobs = (ulong) (managementObject.Properties["Queuedsystemjobs"]?.Value ?? default(ulong)),
		 Successfulsystemjobs = (ulong) (managementObject.Properties["Successfulsystemjobs"]?.Value ?? default(ulong)),
		 SystemJobsactivatedPerminute = (ulong) (managementObject.Properties["SystemJobsactivatedPerminute"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}