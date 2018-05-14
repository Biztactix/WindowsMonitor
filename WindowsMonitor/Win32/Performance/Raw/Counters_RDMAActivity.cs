using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_RDMAActivity
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint RDMAAcceptedConnections { get; private set; }
		public uint RDMAActiveConnections { get; private set; }
		public uint RDMACompletionQueueErrors { get; private set; }
		public uint RDMAConnectionErrors { get; private set; }
		public uint RDMAFailedConnectionAttempts { get; private set; }
		public ulong RDMAInboundBytesPersec { get; private set; }
		public ulong RDMAInboundFramesPersec { get; private set; }
		public uint RDMAInitiatedConnections { get; private set; }
		public ulong RDMAOutboundBytesPersec { get; private set; }
		public ulong RDMAOutboundFramesPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_RDMAActivity> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_RDMAActivity> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_RDMAActivity> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_RDMAActivity");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_RDMAActivity
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 RDMAAcceptedConnections = (uint) (managementObject.Properties["RDMAAcceptedConnections"]?.Value ?? default(uint)),
		 RDMAActiveConnections = (uint) (managementObject.Properties["RDMAActiveConnections"]?.Value ?? default(uint)),
		 RDMACompletionQueueErrors = (uint) (managementObject.Properties["RDMACompletionQueueErrors"]?.Value ?? default(uint)),
		 RDMAConnectionErrors = (uint) (managementObject.Properties["RDMAConnectionErrors"]?.Value ?? default(uint)),
		 RDMAFailedConnectionAttempts = (uint) (managementObject.Properties["RDMAFailedConnectionAttempts"]?.Value ?? default(uint)),
		 RDMAInboundBytesPersec = (ulong) (managementObject.Properties["RDMAInboundBytesPersec"]?.Value ?? default(ulong)),
		 RDMAInboundFramesPersec = (ulong) (managementObject.Properties["RDMAInboundFramesPersec"]?.Value ?? default(ulong)),
		 RDMAInitiatedConnections = (uint) (managementObject.Properties["RDMAInitiatedConnections"]?.Value ?? default(uint)),
		 RDMAOutboundBytesPersec = (ulong) (managementObject.Properties["RDMAOutboundBytesPersec"]?.Value ?? default(ulong)),
		 RDMAOutboundFramesPersec = (ulong) (managementObject.Properties["RDMAOutboundFramesPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}