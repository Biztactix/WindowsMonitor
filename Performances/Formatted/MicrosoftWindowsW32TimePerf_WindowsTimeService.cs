using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MicrosoftWindowsW32TimePerf_WindowsTimeService
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

        public static PerfFormattedData_MicrosoftWindowsW32TimePerf_WindowsTimeService[] Retrieve(string remote,
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

        public static PerfFormattedData_MicrosoftWindowsW32TimePerf_WindowsTimeService[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MicrosoftWindowsW32TimePerf_WindowsTimeService[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MicrosoftWindowsW32TimePerf_WindowsTimeService");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MicrosoftWindowsW32TimePerf_WindowsTimeService>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MicrosoftWindowsW32TimePerf_WindowsTimeService
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ClockFrequencyAdjustment = (uint) managementObject.Properties["ClockFrequencyAdjustment"].Value,
                    ComputedTimeOffset = (ulong) managementObject.Properties["ComputedTimeOffset"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NTPClientTimeSourceCount = (uint) managementObject.Properties["NTPClientTimeSourceCount"].Value,
                    NTPRoundtripDelay = (uint) managementObject.Properties["NTPRoundtripDelay"].Value,
                    NTPServerIncomingRequests = (ulong) managementObject.Properties["NTPServerIncomingRequests"].Value,
                    NTPServerOutgoingResponses =
                        (ulong) managementObject.Properties["NTPServerOutgoingResponses"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}