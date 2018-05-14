using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class SQLSERVERAGENT_SQLAgentJobs
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

        public static IEnumerable<SQLSERVERAGENT_SQLAgentJobs> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SQLSERVERAGENT_SQLAgentJobs> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SQLSERVERAGENT_SQLAgentJobs> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_SQLSERVERAGENT_SQLAgentJobs");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SQLSERVERAGENT_SQLAgentJobs
                {
                     Activejobs = (ulong) (managementObject.Properties["Activejobs"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Failedjobs = (ulong) (managementObject.Properties["Failedjobs"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 JobsactivatedPerminute = (ulong) (managementObject.Properties["JobsactivatedPerminute"]?.Value ?? default(ulong)),
		 Jobsuccessrate = (ulong) (managementObject.Properties["Jobsuccessrate"]?.Value ?? default(ulong)),
		 Jobsuccessrate_Base = (ulong) (managementObject.Properties["Jobsuccessrate_Base"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Queuedjobs = (ulong) (managementObject.Properties["Queuedjobs"]?.Value ?? default(ulong)),
		 Successfuljobs = (ulong) (managementObject.Properties["Successfuljobs"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}