using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MicrosoftWindowsW32TimePerf_WindowsTimeService
    {
		public string Caption { get; private set; }
		public uint ClockFrequencyAdjustment { get; private set; }
		public ulong ComputedTimeOffset { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint NTPClientTimeSourceCount { get; private set; }
		public uint NTPRoundtripDelay { get; private set; }
		public ulong NTPServerIncomingRequests { get; private set; }
		public ulong NTPServerOutgoingResponses { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<MicrosoftWindowsW32TimePerf_WindowsTimeService> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MicrosoftWindowsW32TimePerf_WindowsTimeService> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MicrosoftWindowsW32TimePerf_WindowsTimeService> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MicrosoftWindowsW32TimePerf_WindowsTimeService");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MicrosoftWindowsW32TimePerf_WindowsTimeService
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 ClockFrequencyAdjustment = (uint) (managementObject.Properties["ClockFrequencyAdjustment"]?.Value ?? default(uint)),
		 ComputedTimeOffset = (ulong) (managementObject.Properties["ComputedTimeOffset"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 NTPClientTimeSourceCount = (uint) (managementObject.Properties["NTPClientTimeSourceCount"]?.Value ?? default(uint)),
		 NTPRoundtripDelay = (uint) (managementObject.Properties["NTPRoundtripDelay"]?.Value ?? default(uint)),
		 NTPServerIncomingRequests = (ulong) (managementObject.Properties["NTPServerIncomingRequests"]?.Value ?? default(ulong)),
		 NTPServerOutgoingResponses = (ulong) (managementObject.Properties["NTPServerOutgoingResponses"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}