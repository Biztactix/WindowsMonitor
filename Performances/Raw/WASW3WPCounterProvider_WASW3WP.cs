using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_WASW3WPCounterProvider_WASW3WP
    {
        public uint ActiveListenerChannels { get; private set; }
        public uint ActiveProtocolHandlers { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong HealthPingReplyLatency { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalHealthPings { get; private set; }
        public uint TotalMessagesSenttoWAS { get; private set; }
        public uint TotalRequestsServed { get; private set; }
        public uint TotalRuntimeStatusQueries { get; private set; }
        public uint TotalWASMessagesReceived { get; private set; }

        public static PerfRawData_WASW3WPCounterProvider_WASW3WP[] Retrieve(string remote, string username,
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

        public static PerfRawData_WASW3WPCounterProvider_WASW3WP[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_WASW3WPCounterProvider_WASW3WP[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_WASW3WPCounterProvider_WASW3WP");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_WASW3WPCounterProvider_WASW3WP>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_WASW3WPCounterProvider_WASW3WP
                {
                    ActiveListenerChannels = (uint) managementObject.Properties["ActiveListenerChannels"].Value,
                    ActiveProtocolHandlers = (uint) managementObject.Properties["ActiveProtocolHandlers"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    HealthPingReplyLatency = (ulong) managementObject.Properties["HealthPingReplyLatency"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalHealthPings = (uint) managementObject.Properties["TotalHealthPings"].Value,
                    TotalMessagesSenttoWAS = (uint) managementObject.Properties["TotalMessagesSenttoWAS"].Value,
                    TotalRequestsServed = (uint) managementObject.Properties["TotalRequestsServed"].Value,
                    TotalRuntimeStatusQueries = (uint) managementObject.Properties["TotalRuntimeStatusQueries"].Value,
                    TotalWASMessagesReceived = (uint) managementObject.Properties["TotalWASMessagesReceived"].Value
                });

            return list.ToArray();
        }
    }
}