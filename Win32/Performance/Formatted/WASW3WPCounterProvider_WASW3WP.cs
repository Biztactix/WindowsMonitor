using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class WASW3WPCounterProvider_WASW3WP
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

        public static IEnumerable<WASW3WPCounterProvider_WASW3WP> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WASW3WPCounterProvider_WASW3WP> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WASW3WPCounterProvider_WASW3WP> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_WASW3WPCounterProvider_WASW3WP");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WASW3WPCounterProvider_WASW3WP
                {
                     ActiveListenerChannels = (uint) (managementObject.Properties["ActiveListenerChannels"]?.Value ?? default(uint)),
		 ActiveProtocolHandlers = (uint) (managementObject.Properties["ActiveProtocolHandlers"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 HealthPingReplyLatency = (ulong) (managementObject.Properties["HealthPingReplyLatency"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalHealthPings = (uint) (managementObject.Properties["TotalHealthPings"]?.Value ?? default(uint)),
		 TotalMessagesSenttoWAS = (uint) (managementObject.Properties["TotalMessagesSenttoWAS"]?.Value ?? default(uint)),
		 TotalRequestsServed = (uint) (managementObject.Properties["TotalRequestsServed"]?.Value ?? default(uint)),
		 TotalRuntimeStatusQueries = (uint) (managementObject.Properties["TotalRuntimeStatusQueries"]?.Value ?? default(uint)),
		 TotalWASMessagesReceived = (uint) (managementObject.Properties["TotalWASMessagesReceived"]?.Value ?? default(uint))
                };
        }
    }
}