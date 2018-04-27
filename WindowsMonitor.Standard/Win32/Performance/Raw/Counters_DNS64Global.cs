using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_DNS64Global
    {
		public ulong AAAAqueriesFailed { get; private set; }
		public ulong AAAAqueriesSuccessful { get; private set; }
		public ulong AAAASynthesizedrecords { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong IP6ARPAqueriesMatched { get; private set; }
		public string Name { get; private set; }
		public ulong OtherqueriesFailed { get; private set; }
		public ulong OtherqueriesSuccessful { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_DNS64Global> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_DNS64Global> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_DNS64Global> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_DNS64Global");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_DNS64Global
                {
                     AAAAqueriesFailed = (ulong) (managementObject.Properties["AAAAqueriesFailed"]?.Value ?? default(ulong)),
		 AAAAqueriesSuccessful = (ulong) (managementObject.Properties["AAAAqueriesSuccessful"]?.Value ?? default(ulong)),
		 AAAASynthesizedrecords = (ulong) (managementObject.Properties["AAAASynthesizedrecords"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IP6ARPAqueriesMatched = (ulong) (managementObject.Properties["IP6ARPAqueriesMatched"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OtherqueriesFailed = (ulong) (managementObject.Properties["OtherqueriesFailed"]?.Value ?? default(ulong)),
		 OtherqueriesSuccessful = (ulong) (managementObject.Properties["OtherqueriesSuccessful"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}